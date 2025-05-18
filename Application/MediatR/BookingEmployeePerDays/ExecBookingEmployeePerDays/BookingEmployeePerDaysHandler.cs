using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.MediatR.BookingEmployeePerDays.ExecBookingEmployeePerDays
{
    class BookingEmployeePerDaysHandler : IRequestHandler<BookingEmployeePerDaysCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingEmployeePerDaysHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(BookingEmployeePerDaysCommand request, CancellationToken cancellationToken)
        {
            // Llamar a BeginAsync sin asignarlo a una variable
            await _unitOfWork.BeginAsync<BookingEmployeePerDay>();

            try
            {
                // Lógica del resto del código
                var activities = await _unitOfWork.Repository<Activity>().GetAsync(x => x.Id == 1);
                var activityOne = activities.FirstOrDefault();

                if (activityOne == null)
                {
                    throw new InvalidOperationException("Activity not found.");
                }

                DateTime now = DateTime.Now;
                TimeSpan timeNow = now.TimeOfDay;
                TimeSpan scheduled = activityOne.ScheduledTime;
                DateTime? lastRun = activityOne.LastExecuted;

                bool alreadyRanToday = lastRun?.Date == now.Date;
                bool shouldRun = activityOne.RunNow || timeNow >= scheduled;

                if (shouldRun)
                {
                    var pendingBookings = await _unitOfWork.Repository<Booking>().GetMulipleAsync(x => x.IsProcessed == false);

                    var pendingBookingsGroup = pendingBookings
                        .Where(r => r.CreatedAt.HasValue)
                        .GroupBy(r => new { r.CreatedAt.Value.Date, r.EmployeeId })
                        .Select(g => new
                        {
                            g.Key.Date,
                            g.Key.EmployeeId,
                            BookingsNumber = g.Count()
                        })
                        .ToList();

                    foreach (var group in pendingBookingsGroup)
                    {
                        var bookingEmployeeExists = await _unitOfWork.Repository<BookingEmployeePerDay>()
                            .GetAsync(x => x.day == group.Date && x.EmployeeId == group.EmployeeId);

                        var bookingEmployee = bookingEmployeeExists.FirstOrDefault();
                        if (bookingEmployee != null)
                        {
                            bookingEmployee.BookingsNumber += group.BookingsNumber;
                            await _unitOfWork.Repository<BookingEmployeePerDay>().UpdateAsync(bookingEmployee);
                        }
                        else
                        {
                            var newBookingEmployeePerDay = new BookingEmployeePerDay
                            {
                                day = group.Date,
                                EmployeeId = group.EmployeeId,
                                BookingsNumber = group.BookingsNumber
                            };

                            await _unitOfWork.Repository<BookingEmployeePerDay>().AddAsync(newBookingEmployeePerDay);
                        }
                    }

                    foreach (var booking in pendingBookings)
                    {
                        booking.IsProcessed = true;
                        await _unitOfWork.Repository<Booking>().UpdateAsync(booking);
                    }
                    activityOne.LastExecuted = DateTime.Now;
                    activityOne.RunNow = false;
                    await _unitOfWork.Repository<Activity>().UpdateAsync(activityOne);
                }
                

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {

                await _unitOfWork.RollbackAsync();

                throw new InvalidOperationException("Error during transaction", ex);
            }
        }

    }
}
