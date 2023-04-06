﻿using CustomerService.Application.Services.SupportRequests.CreateSupportRequest;
using CustomerService.Application.Services.SupportRequests.GetSupportRequest;
using CustomerService.Application.Services.SupportRequests.UpdateStatus;
using CustomerService.Contracts.SupportRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.API.Controllers
{
    [Route("user/{userId}/support_requests")]
    [ApiController]
    [Authorize]
    public class SupportRequestsController : ControllerBase
    {
        private readonly ICreateSupportRequestService _createSupportRequestService;
        private readonly IGetSupportRequestService _getSupportRequestService;
        private readonly IUpdateSupportRequestStatusService _updateSupportRequestStatusService;

        public SupportRequestsController(ICreateSupportRequestService createSupportRequestService,
            IGetSupportRequestService getSupportRequestService,
            IUpdateSupportRequestStatusService updateSupportRequestStatusService)
        {
            _createSupportRequestService = createSupportRequestService;
            _getSupportRequestService = getSupportRequestService;
            _updateSupportRequestStatusService = updateSupportRequestStatusService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSupportRequest(
            CreateSupportRequestRequest request, 
            UrgencyLevel urgencyLevel,
            [FromRoute]string userId)
        {
            var supportRequest = await _createSupportRequestService.CreateSupportRequest(
                request.IssueSubject,
                request.IssueType,
                request.IssueDescription,
                urgencyLevel.ToString(),
                userId);

            var response = new CreateSupportRequestResponse(supportRequest.Id,
                supportRequest.IssueSubject,
                supportRequest.IssueType,
                supportRequest.IssueDescription,
                supportRequest.UrgencyLevel,
                supportRequest.DueDate,
                supportRequest.CreatedAt,
                supportRequest.Status);

            return Ok(response);
        }

        [HttpGet("get_support_request/{requestId}")]
        public async Task<IActionResult> GetSupportRequest([FromRoute]string requestId)
        {
            var supportRequest = await _getSupportRequestService.Get(requestId);

            var response = new GetSupportRequestResponse(
                supportRequest.IssueSubject,
                supportRequest.IssueType,
                supportRequest.IssueDescription,
                supportRequest.UrgencyLevel,
                supportRequest.DueDate,
                supportRequest.CreatedAt,
                supportRequest.UpdatedAt,
                supportRequest.Status,
                supportRequest.StatusDetails,
                supportRequest.GetSupportRequestMessages
                .Select(message => new Contracts.SupportRequests.GetSupportRequestMessages(
                    message.Content,
                    message.CreatedAt,
                    message.CreatedBy))
                .ToList());

            return Ok(response);
        }

        [HttpPost("update_status/{requestId}")]
        public async Task<IActionResult> UpdateStatus([FromRoute]string requestId,
            UpdateSupportRequestStatusRequest request,
            Status status)
        {
            await _updateSupportRequestStatusService.UpdateStatus(requestId, status.ToString(), request.StatusDetails);

            return Ok("Status was successfully updated.");
        }
    }
}