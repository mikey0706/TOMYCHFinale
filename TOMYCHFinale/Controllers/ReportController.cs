using AutoMapper;
using Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;
using TOMYCHFinale.Contracts.Response;

namespace TOMYCHFinale.Controllers
{
    
    [Route("Report")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ReportController : ControllerBase
    {
        private IReportCreateService _reportCreator;
        private IReportReadService _reportReader;
       

        public ReportController(IReportCreateService reportCreator,
            IReportReadService reportReader) 
        {
            _reportCreator = reportCreator;
            _reportReader = reportReader;
        }
        
        

        [AllowAnonymous]
        [HttpGet("/create-report")]
        public async Task<IActionResult> CreateReport([FromQuery] ReportTypes type) 
        {
            var key = await _reportCreator.CreateReport(type);
            return Ok(key);
        }

        [AllowAnonymous]
        [HttpGet("{id:long}")]
        public async Task<IActionResult> DownloadReport([FromRoute] long id)
        {
            var mime = await _reportReader.GenerateReport(id);
            return File(mime.Payload, mime.MimeType, mime.FileName);
        }

    }
}
