using Dapper;
using Entities;
using RepositoryLayer.Interfaces;
using System.Data;

namespace RepositoryLayer
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private DbConnectionLayer _connectionLayer;

        public SubscriberRepository(DbConnectionLayer connectionLayer)
        {
            _connectionLayer = connectionLayer;
        }

        public async Task<bool> InsertBasicDetailsToDb(RecieveMediaDTO mediaSongDTO)
        {
            using (IDbConnection connection = _connectionLayer.CreateConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("Title", mediaSongDTO.Title);
                parameters.Add("Artist", mediaSongDTO.Artist);
                parameters.Add("Album", mediaSongDTO.Album);
                parameters.Add("Duration", mediaSongDTO.Duration);
                parameters.Add("GenreType", mediaSongDTO.GenreType);
                parameters.Add("ReleaseDate", mediaSongDTO.ReleaseDate);
                parameters.Add("CreatedOn", mediaSongDTO.CreatedOn);
                parameters.Add("CreatedBy", mediaSongDTO.CreatedBy);
                parameters.Add("RowCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Open();
                await connection.ExecuteAsync("[dbo].[pubsub_addData]", parameters, commandType: CommandType.StoredProcedure);
                int rowCountChange = parameters.Get<int>("RowCount");
                connection.Close();
                return rowCountChange > 0;
            }
        }

        public async Task<bool> InsertArtistDetails(ArtistDTO artistDTO)
        {
            using (IDbConnection connection = _connectionLayer.CreateConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("ArtistName", artistDTO.Name);
                parameters.Add("Website", artistDTO.Website);
                parameters.Add("CreatedOn", artistDTO.CreatedOn);
                parameters.Add("CreatedBy", artistDTO.CreatedBy);
                parameters.Add("RowCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Open();
                await connection.ExecuteAsync("[dbo].[pubsub_InsertArtist]", parameters, commandType: CommandType.StoredProcedure);
                int rowCountChange = parameters.Get<int>("RowCount");
                connection.Close();
                return rowCountChange > 0;
            }
        }
    }
}
