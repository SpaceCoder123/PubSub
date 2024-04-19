using Entities;

namespace Services.Interfaces
{
    public interface ISubscriberService
    {
        public Task<bool> InsertSongDetails(RecieveMediaDTO mediaSong);
    }
}
