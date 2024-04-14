using Dapper;
using Entities;
using RepositoryLayer.Interfaces;
using System.Data;

namespace RepositoryLayer
{
    public class PublisherRepository : IPublisherRepository
    {
        private DbConnectionLayer _connectionLayer;

        public PublisherRepository(DbConnectionLayer connectionLayer)
        {
            _connectionLayer = connectionLayer;
        }

        public async Task<bool> InsertSong(MediaSongEntity mediaSongEntity)
        {
            using (IDbConnection connection = _connectionLayer.CreateConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("Title", mediaSongEntity.Title);
                parameters.Add("Artist", mediaSongEntity.Artist);
                parameters.Add("Album", mediaSongEntity.Album);
                parameters.Add("GenreType", mediaSongEntity.GenreType);
                parameters.Add("ReleaseDate", mediaSongEntity.ReleaseDate);
                parameters.Add("CreatedOn", mediaSongEntity.CreatedOn);
                parameters.Add("CreatedBy", mediaSongEntity.CreatedBy);

                connection.Open();
                var rowCountChange = await connection.ExecuteAsync("[dbo].[pubsub_addData]", parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return rowCountChange > 0;
            }
        }
    }
}
