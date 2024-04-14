using Entities;
namespace RepositoryLayer.Interfaces
{
    public interface IPublisherRepository
    {
        public Task<bool> InsertSong(MediaSongDTO mediaSong);
    }
}
