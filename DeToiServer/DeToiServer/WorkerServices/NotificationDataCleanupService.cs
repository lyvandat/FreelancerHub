using AutoMapper;
using System.Threading;

namespace DeToiServer.WorkerServices
{
    public class NotificationDataCleanupService(IServiceProvider serviceProvider) : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromDays(1), cancellationToken); // Run daily, adjust as needed

                using var scope = _serviceProvider.CreateScope();
                UnitOfWork _unitOfWork = scope.ServiceProvider.GetRequiredService<UnitOfWork>();
                await _unitOfWork.NotificationRepo.RemoveOldNotificationsAsync();
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
