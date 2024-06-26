﻿using RepositoryLayer.Interfaces;

namespace RepositoryLayer
{
    public class PublisherRepository : IPublisherRepository
    {
        private DbConnectionLayer _connectionLayer;

        public PublisherRepository(DbConnectionLayer connectionLayer)
        {
            _connectionLayer = connectionLayer;
        }

        //public async Task<bool> InsertSong(MediaSongDTO mediaSongDTO)
        //{
        //    using (IDbConnection connection = _connectionLayer.CreateConnection())
        //    {
        //        var parameters = new DynamicParameters();

        //        parameters.Add("Title", mediaSongDTO.Title);
        //        parameters.Add("Artist", mediaSongDTO.Artist);
        //        parameters.Add("Album", mediaSongDTO.Album);
        //        parameters.Add("Duration", mediaSongDTO.Duration);
        //        parameters.Add("GenreType", mediaSongDTO.GenreType);
        //        parameters.Add("ReleaseDate", mediaSongDTO.ReleaseDate);
        //        parameters.Add("CreatedOn", mediaSongDTO.CreatedOn);
        //        parameters.Add("CreatedBy", mediaSongDTO.CreatedBy);
        //        parameters.Add("RowCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

        //        connection.Open();
        //        await connection.ExecuteAsync("[dbo].[pubsub_addData]", parameters, commandType: CommandType.StoredProcedure);
        //        int rowCountChange = parameters.Get<int>("RowCount");
        //        connection.Close();
        //        return rowCountChange > 0;
        //    }
        //}
    }
}