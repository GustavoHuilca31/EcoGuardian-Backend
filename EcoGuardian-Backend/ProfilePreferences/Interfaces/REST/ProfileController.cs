using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Queries;
using EcoGuardian_Backend.ProfilePreferences.Domain.Services;
using EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.Resources;
using EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.Trasform;
using EcoGuardian_Backend.Shared.Interfaces.Filters;

namespace EcoGuardian_Backend.ProfilePreferences.Interfaces.REST;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[ProducesResponseType(500)]
[Route("api/v1/profiles")]
public class ProfileController(IProfileCommandService profileCommandService, IProfileQueryService profileQueryService) : ControllerBase
{
    [HttpPost]
    [AuthorizeFilter("Admin", "Domestic", "Business")]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreateProfile([FromBody] CreateProfileResource resource)
    {
        var command = CreateProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
        await profileCommandService.Handle(command);
        return StatusCode(201, true);
    }
    
    [HttpPut("{id:int}")]
    [AuthorizeFilter("Admin", "Domestic", "Business")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> UpdateProfile([FromForm] UpdateProfileResource resource, [FromRoute] int id)
    {
        var command = UpdateProfileCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        await profileCommandService.Handle(command);
        return Ok(true);
    }
    [HttpGet]
    [AuthorizeFilter("Admin", "Domestic", "Business")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetProfileById([FromQuery] string email)
    {
        var query = new GetProfileByEmailQuery(email);
        var profile = await profileQueryService.Handle(query);
        if (profile == null)
        {
            return NotFound();
        }
        var resource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return Ok(resource);
    }
}