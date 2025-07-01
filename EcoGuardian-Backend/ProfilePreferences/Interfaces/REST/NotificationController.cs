using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Queries;
using EcoGuardian_Backend.ProfilePreferences.Domain.Services;
using EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.Trasform;
using EcoGuardian_Backend.Shared.Interfaces.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EcoGuardian_Backend.ProfilePreferences.Interfaces.REST;

[ApiController]
[ProducesResponseType(500)]
[Route("api/v1/notifications")]
public class NotificationController(INotificationQueryService notificationQueryService) : ControllerBase
{
    [HttpGet]
    [AuthorizeFilter("Admin", "Domestic", "Business")]
    public async Task<IActionResult> GetNotificationsByProfileId([FromQuery] int profileId)
    {
        var query = new GetNotificationsByProfileIdQuery(profileId);
        var notifications = await notificationQueryService.Handle(query);
        var notificationResource =
            notifications.Select(NotificationResourceFromEntityAssember.ToResourceFromEntityAssembler);
        return Ok(notificationResource);
    }
}