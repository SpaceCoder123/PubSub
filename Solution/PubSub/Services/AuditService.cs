﻿using Entities;
using Newtonsoft.Json;
using RepositoryLayer.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class AuditService : IAuditService
    {
        private IAuditRepository _auditRepository;
        public AuditService(IAuditRepository auditRepository)
        {
            _auditRepository = auditRepository;
        }
        public async Task<bool> InsertMediaAudit(MediaSongDTO mediaSongDTO, string auditType)
        {
            var audit = new Audit
            {
                TransactionId = mediaSongDTO.TransactionId.ToString(),
                AuditType = auditType,
                Code = 200,
                Payload = JsonConvert.SerializeObject(mediaSongDTO)
            };
            return await _auditRepository.AddAudit(audit); ;
        }

        public async Task<bool> InsertExceptionAudit(string stackTrace, string TransactionId, string auditType)
        {
            var audit = new Audit
            {
                TransactionId = TransactionId,
                AuditType = auditType,
                Code = 400,
                Payload = stackTrace
            };
            return await _auditRepository.AddAudit(audit); ;
        }

        public async Task<bool> InsertMediaAudit(RecieveMediaDTO mediaSongDTO, string auditType)
        {
            var audit = new Audit
            {
                TransactionId = mediaSongDTO.TransactionId.ToString(),
                AuditType = auditType,
                Code = 200,
                Payload = JsonConvert.SerializeObject(mediaSongDTO)
            };
            return await _auditRepository.AddAudit(audit); ;
        }
    }
}