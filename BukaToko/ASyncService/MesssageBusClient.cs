namespace BukaToko.AsyncService
{
    public class MesssageBusPublish : BackgroundService
    {
        private readonly IConfiguration _configuration;

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
