using Xunit;
using Moq;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Application.MediatR.Bookings.CreateBooking;
using Application.MediatR.Clients;
using System;

public class CreateBookingHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IRepository<Client>> _clientRepoMock;
    private readonly Mock<IRepository<Booking>> _bookingRepoMock;
    private readonly IMapper _mapper;
    private readonly CreateBookingHandler _handler;

    public CreateBookingHandlerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _clientRepoMock = new Mock<IRepository<Client>>();
        _bookingRepoMock = new Mock<IRepository<Booking>>();

        // Setup repos in unit of work mock
        _unitOfWorkMock.Setup(u => u.Repository<Client>()).Returns(_clientRepoMock.Object);
        _unitOfWorkMock.Setup(u => u.Repository<Booking>()).Returns(_bookingRepoMock.Object);

        // Setup automapper config
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CreateBookingCommand, Booking>()
                // Necesitas convertir StartDate y EndDate de string a DateTime en el mapa
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateTime.Parse(src.StartDate)))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => DateTime.Parse(src.EndDate)));
            cfg.CreateMap<ClientDto, Client>();
        });
        _mapper = config.CreateMapper();

        _handler = new CreateBookingHandler(_unitOfWorkMock.Object, _mapper);
    }

    [Fact]
    public async Task Handle_WhenClientExists_UpdatesClientAndAddsBooking()
    {
        // Arrange
        var existingClient = new Client
        {
            Id = 1,
            Document = "123",
            Phone = "555-1111",
            FullName = "John Doe",
            Email = "john@example.com"
        };

        var command = new CreateBookingCommand(
            StartDate: "2025-06-01",
            EndDate: "2025-06-05",
            VehicleId: 10,
            EmployeeId: 5,
            Client: new ClientDto
            {
                Id = 1,
                Document = "999",
                Phone = "555-2222",
                FullName = "John Updated",
                Email = "john_updated@example.com"
            }
        );

        _unitOfWorkMock.Setup(u => u.BeginAsync<Booking>()).Returns(Task.CompletedTask);
        _clientRepoMock.Setup(r => r.GetByIdAsync(existingClient.Id)).ReturnsAsync(existingClient);
        _clientRepoMock.Setup(r => r.UpdateAsync(It.IsAny<Client>())).ReturnsAsync(existingClient);
        _bookingRepoMock.Setup(r => r.AddAsync(It.IsAny<Booking>())).ReturnsAsync(new Booking());
        _unitOfWorkMock.Setup(u => u.CommitAsync()).Returns(Task.CompletedTask);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _unitOfWorkMock.Verify(u => u.BeginAsync<Booking>(), Times.Once);
        _clientRepoMock.Verify(r => r.GetByIdAsync(existingClient.Id), Times.Once);
        _clientRepoMock.Verify(r => r.UpdateAsync(It.Is<Client>(c =>
            c.Document == command.Client.Document &&
            c.Phone == command.Client.Phone &&
            c.FullName == command.Client.FullName &&
            c.Email == command.Client.Email
        )), Times.Once);
        _bookingRepoMock.Verify(r => r.AddAsync(It.Is<Booking>(b =>
            b.ClientId == existingClient.Id &&
            b.VehicleId == command.VehicleId &&
            b.EmployeeId == command.EmployeeId
        )), Times.Once);
        _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
    }

    [Fact]
    public async Task Handle_WhenClientIsNew_AddsClientAndBooking()
    {
        // Arrange
        var newClient = new Client
        {
            Id = 99,
            Document = "888",
            Phone = "555-3333",
            FullName = "New Client",
            Email = "newclient@example.com"
        };

        var command = new CreateBookingCommand(
            StartDate: "2025-06-10",
            EndDate: "2025-06-15",
            VehicleId: 11,
            EmployeeId: 6,
            Client: new ClientDto
            {
                Id = 0,
                Document = newClient.Document,
                Phone = newClient.Phone,
                FullName = newClient.FullName,
                Email = newClient.Email
            }
        );

        _unitOfWorkMock.Setup(u => u.BeginAsync<Booking>()).Returns(Task.CompletedTask);
        _clientRepoMock.Setup(r => r.AddAsync(It.IsAny<Client>())).ReturnsAsync(newClient);
        _bookingRepoMock.Setup(r => r.AddAsync(It.IsAny<Booking>())).ReturnsAsync(new Booking());
        _unitOfWorkMock.Setup(u => u.CommitAsync()).Returns(Task.CompletedTask);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _unitOfWorkMock.Verify(u => u.BeginAsync<Booking>(), Times.Once);
        _clientRepoMock.Verify(r => r.AddAsync(It.Is<Client>(c =>
            c.Document == newClient.Document &&
            c.Phone == newClient.Phone &&
            c.FullName == newClient.FullName &&
            c.Email == newClient.Email
        )), Times.Once);
        _bookingRepoMock.Verify(r => r.AddAsync(It.Is<Booking>(b =>
            b.ClientId == newClient.Id &&
            b.VehicleId == command.VehicleId &&
            b.EmployeeId == command.EmployeeId
        )), Times.Once);
        _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
    }

    [Fact]
    public async Task Handle_WhenExceptionThrown_ThrowsException()
    {
        // Arrange
        var command = new CreateBookingCommand(
            StartDate: "2025-06-01",
            EndDate: "2025-06-05",
            VehicleId: 10,
            EmployeeId: 5,
            Client: new ClientDto { Id = 0, Document = "X", Phone = "Y", FullName = "Z", Email = "z@example.com" }
        );

        _unitOfWorkMock.Setup(u => u.BeginAsync<Booking>()).ThrowsAsync(new Exception("fail"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _handler.Handle(command, CancellationToken.None));
    }
}
