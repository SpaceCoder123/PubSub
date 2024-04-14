using Entities;

namespace Services.Interfaces
{
    public interface IAuditService
    {
        public Task<bool> InsertMediaAudit(MediaSongDTO mediaSongDTO, string auditType);
    }
}
