using AutoMapper;
using Common.Exceptions;
using CsvHelper;
using CsvHelper.Configuration;
using Entities.Interfaces;
using Services.BusinessObjects;
using Services.Services.Interfaces;
using System.Globalization;
using System.Text.Json;

namespace Services.Services
{
    public class ReportReaderService : IReportReadService
    {
        private IUnitOfWork _unit;
        private IMapper _mapper;

        public ReportReaderService(IUnitOfWork unit, IMapper mapper) 
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<CsvMimeData> GenerateReport(long id) 
        {
            var data = await _unit.GetReport.FindById(id);
            if (data is null) 
            {
                throw new ReportNotFoundException("Report not found.");
            }

            var report = _mapper.Map<ReportBO>(data);
            var reportName = $"report_from_{DateTime.Now}.csv";
            byte[] content = null;

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ";"
            };

            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(ms))
                using (var csv = new CsvWriter(sw, config))
                {
                    csv.WriteHeader<ReportBO>();
                    await csv.NextRecordAsync();
                    csv.WriteRecord(report);
                    await csv.NextRecordAsync();
                    csv.WriteHeader<ReportRequests>();
                    await csv.NextRecordAsync();
                    csv.WriteRecords(DeserializeRequests(data.Content));
                    
                    await sw.FlushAsync();
                    await csv.FlushAsync(); 
                }
                content = ms.ToArray();
            }

            return new CsvMimeData()
            {
                FileName = reportName,
                Payload = content
            };
        }

        private IEnumerable<ReportRequests> DeserializeRequests(byte[] requests) 
        {
            var jsonUtfReader = new Utf8JsonReader(requests);
            return JsonSerializer.Deserialize<IEnumerable<ReportRequests>>(ref jsonUtfReader);
        }

    }
}
