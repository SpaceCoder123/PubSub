using Entities;

namespace RepositoryLayer.Interfaces
{
    public interface ISubscriberRepository
    {
        public Task<bool> InsertBasicDetailsToDb(RecieveMediaDTO mediaSong);
        public Task<bool> InsertArtistDetails(ArtistDTO artistDTO);
    }
}
