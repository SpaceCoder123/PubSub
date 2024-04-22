using Entities;

namespace Services.Interfaces
{
    public interface IArtistService
    {
        public Task<bool> AddArtist(ArtistDTO artistDTO);
        //public Task<bool> UpdateArtist(ArtistDTO artistDTO);
        //public Task<bool> GetAll();
    }
}
