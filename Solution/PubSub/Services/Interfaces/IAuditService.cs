using Entities;

namespace Services.Interfaces
{
    public interface IAuditService
    {
        public Task<bool> InsertMediaAudit(MediaSongDTO mediaSongDTO, string auditType);
        public Task<bool> InsertExceptionAudit(string stackTrace, string TransactionId, string auditType);
        public Task<bool> InsertMediaAudit(RecieveMediaDTO mediaSongDTO, string auditType);
        public Task<bool> InsertSubscriberMediaAudit(SubscriberDTO<ArtistDTO> artistDTO, string auditType);
    }
}