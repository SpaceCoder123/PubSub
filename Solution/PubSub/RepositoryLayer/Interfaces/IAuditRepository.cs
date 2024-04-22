using Entities;

namespace RepositoryLayer.Interfaces
{
    public interface IAuditRepository
    {
        public Task<bool> AddAudit(Audit audit);
    }
}