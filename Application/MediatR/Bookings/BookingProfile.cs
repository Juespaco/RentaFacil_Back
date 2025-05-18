using Application.MediatR.Bookings.CreateBooking;
using AutoMapper;
using Domain.Entities;

namespace Application.MediatR.Bookings
{
    class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingDto>();
            CreateMap<CreateBookingCommand, Booking>().ForMember(dest => dest.Client, opt => opt.Ignore()); ;
        }
    }
}
