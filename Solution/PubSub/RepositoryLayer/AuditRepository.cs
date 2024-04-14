using Dapper;
using Entities;
using RepositoryLayer.Interfaces;
using System.Data;

namespace RepositoryLayer
{
    public class AuditRepository : IAuditRepository
    {
        private DbConnectionLayer _connectionLayer;

        public AuditRepository(DbConnectionLayer connectionLayer)
        {
            _connectionLayer = connectionLayer;
        }

        public async Task<bool> AddAudit(Audit audit)
        {
            using (IDbConnection connection = _connectionLayer.CreateConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("TransactionId", audit.TransactionId.ToString());
                parameters.Add("Message", audit.Message);
                parameters.Add("Code", audit.Code);
                parameters.Add("AuditType", audit.AuditType);
                parameters.Add("Payload", audit.Payload);

                connection.Open();
                var rowCountChange = await connection.ExecuteAsync("[dbo].[pubSub_InsertAuditRecord]", parameters, commandType: CommandType.StoredProcedure);
                connection.Close();
                return rowCountChange > 0;
            }
        }
    }
}
