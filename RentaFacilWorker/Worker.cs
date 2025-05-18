using Application.MediatR.BookingEmployeePerDays.ExecBookingEmployeePerDays;
using MediatR;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IMediator _mediator;
    private readonly IServiceScopeFactory _scopeFactory;

    public Worker(ILogger<Worker> logger, IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            await mediator.Send(new BookingEmployeePerDaysCommand(), stoppingToken);

            _logger.LogInformation("Worker executed command at: {time}", DateTimeOffset.Now);

            await Task.Delay(60_000, stoppingToken); // Espera 1 minuto
        }
    }
}
