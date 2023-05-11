using BukaToko.DTOS;

namespace BukaToko.ASyncService
{
    public interface IMessageBusClient
    {
        void PublishNewWallet(TopUpPublishedDto topUpPublishedDto);
    }
}
