using AutoMapper;
using Entities;

namespace Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<MediaSongDTO, MediaSongEntity>();
        }
    }
}
