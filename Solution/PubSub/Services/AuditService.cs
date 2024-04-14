using AutoMapper;
using Entities;
using Newtonsoft.Json;
using RepositoryLayer.Interfaces;
using Services.Interfaces;
using System.Text.Json.Serialization;

namespace Services
{
    public class AuditService : IAuditService
    {
        private IAuditRepository _auditRepository;
        private IMapper _mapper;
        public AuditService(IAuditRepository auditRepository, IMapper mapper)
        {
            _auditRepository = auditRepository;
            _mapper = mapper;
        }
        public async Task<bool> InsertMediaAudit(MediaSongDTO mediaSongDTO, string auditType)
        {
            var audit = new Audit
            {
                TransactionId = mediaSongDTO.TransactionId,
                AuditType = auditType,
                Code = 200,
                Payload = JsonConvert.SerializeObject(mediaSongDTO)
            };
            return await _auditRepository.AddAudit(audit); ;
        }
    }
}
