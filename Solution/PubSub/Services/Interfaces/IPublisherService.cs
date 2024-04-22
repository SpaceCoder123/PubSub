using Entities;

namespace Services.Interfaces
{
    public interface IPublisherService
    {
        public Task<bool> SendPlayableMedia(MediaSongDTO mediaSongDTO);
    }
}