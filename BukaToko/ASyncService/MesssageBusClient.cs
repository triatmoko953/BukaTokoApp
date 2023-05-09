namespace BukaToko.AsyncService
{
    public class MesssageBusClient : BackgroundService
    {
        private readonly IConfiguration _configuration;

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
