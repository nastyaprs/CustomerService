using CustomerService.Application.Services.SupportRequestMessages.CreateSupportRequestMessage;
using CustomerService.Contracts.SupportRequestMessages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.API.Controllers
{
    [Route("user/{userId}/supportRequest/{supportRequestId}/message")]
    [ApiController]
    public class SupportRequestMessagesController : ControllerBase
    {
        private readonly ICreateSupportRequestMessageService _createSupportRequestMessageService;

        public SupportRequestMessagesController(ICreateSupportRequestMessageService createSupportRequestMessageService)
        {
            _createSupportRequestMessageService = createSupportRequestMessageService;
        }

        [HttpPost("create")]
        [Authorize(Roles = "Customer, Admin")]
        public async Task<IActionResult> Create(
            CreateSupportRequestMessageRequest request,
            [FromRoute]string supportRequestId,
            [FromRoute]string userId)
        {
            var message = await _createSupportRequestMessageService.CreateMessage(
                request.Content,
                Convert.ToInt64(supportRequestId),
                Convert.ToInt64(userId));

            var response = new CreateSupportRequestMessageResponse(
                message.Content,
                message.CreatedAt,
                message.CreatedBy);

            return Ok(response);
        }
    }
}
