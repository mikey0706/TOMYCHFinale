using AutoMapper;
using Common.Enums;
using Common.Exceptions;
using Entities.Interfaces;
using Entities.Models;
using Microsoft.Extensions.Caching.Memory;
using Services.BusinessObjects;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ReportCreateService : IReportCreateService
    {
        private IUnitOfWork _unit;
        private IMapper _mapper;
        private IMemoryCache _cache;
        private string _key = "report";

        public ReportCreateService(IUnitOfWork unit, IMapper mapper, IMemoryCache cache) 
        {
            _unit = unit;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<long> CreateReport(ReportTypes type) 
        {
            var requests = _mapper.Map<IEnumerable<SupportRequestBO>>(
                await _unit.GetSupportRequest.GetResolvedRequests(type));

            if (requests is null)
            {
                throw new SupportRequestNotFoundException($"There are no requests of type {type}.");
            }

            byte[] content = null;
            using (var ms = new MemoryStream())
                {
                    content = JsonSerializer.SerializeToUtf8Bytes(requests);
                }

            var report = new Report
                {
                    Content = content,
                    CreatedAt = DateTime.Now,
                    ReportType = type,
                    FileSize = content.LongLength
                };

            await _unit.GetReport.CreateReport(report);
            await _unit.SaveDataAsync();
            _cache.Remove(_key);

            return report.Id;
        } 
    }
}
