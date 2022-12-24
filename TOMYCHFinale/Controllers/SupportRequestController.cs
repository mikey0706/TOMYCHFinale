using AutoMapper;
using Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.BusinessObjects;
using Services.Services.Interfaces;
using TOMYCHFinale.Contracts.Request;
using TOMYCHFinale.Contracts.Response;

namespace TOMYCHFinale.Controllers
{
    [Route("SupportRequest")]
    [Authorize(Roles = "User, Admin")]
    [ApiController]
    public class SupportRequestController : ControllerBase
    {
        private IRequestCreateService _requestCreateService;
        private IRequestReadService _requestReadService;
        private IMapper _mapper;

        public SupportRequestController(IRequestCreateService requestCreateService, 
            IRequestReadService requestReadService, 
            IMapper mapper) 
        {
            _requestCreateService = requestCreateService;
            _requestReadService = requestReadService;
            _mapper = mapper;
        }

        [HttpPost("/create-request")]
        public async Task<IActionResult> CreateRequest([FromQuery] UrgencyTypes type, [FromQuery] IssueTypes issue, [FromBody] SupportRequestCreateModel data)
        {
            var request = _mapper.Map<SupportRequestBO>(data);
            var mail = HttpContext.User.Identity.Name;
            request.UrgencyLevel = type;
            request.IssueType = issue;

            var output = await _requestCreateService.CreateRequest(request, mail);
            return Ok(output);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> SupportRequestDetails([FromRoute] long id)
        {
            return Ok(_mapper.Map<SupportRequestResponse>(
                await _requestReadService.GetSupportRequest(id)));
        }

        [HttpPost("{requestId:long}/create-support-message")]
        public async Task<IActionResult> CreateSupportMessage([FromRoute] long requestId, [FromBody] string content)
        {
            await _requestCreateService.SendMessageAsync(requestId, content);
            return Ok();
        }

        [Authorize(Roles ="Admin")]
        [HttpPost("{requestId:long}")]

        public async Task<IActionResult> UpdateStatus([FromRoute] long requestId, [FromQuery] RequestStatusTypes type)
        {
            await _requestCreateService.UpdateStatus(requestId, type);
            return Ok();
        }
    }
}
