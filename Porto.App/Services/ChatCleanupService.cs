using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Porto;
using Porto.Data.Models;

namespace Porto.App.Services
{
    public class ChatCleanupService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public ChatCleanupService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var now = DateTime.Now;
                var midnight = DateTime.Today.AddDays(1);
                var delay = midnight - now;

                await Task.Delay(delay, stoppingToken);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

                    context.ChatMessages.RemoveRange(context.ChatMessages);
                    await context.SaveChangesAsync();
                }

            }
        }
    }
}
