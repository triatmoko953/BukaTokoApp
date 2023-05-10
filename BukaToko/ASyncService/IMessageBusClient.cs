using BukaToko.DTOS;

namespace BukaToko.ASyncService
{
    public interface IMessageBusClient
    {
        void PublishNewProduct(ProductPublishDto productPublishDto);
    }
}
