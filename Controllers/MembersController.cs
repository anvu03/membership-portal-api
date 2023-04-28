using Microsoft.AspNetCore.Mvc;

namespace MembershipPortalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MembersController : ControllerBase
{
    private readonly ILogger<MembersController> _logger;
    private readonly IMemberCollection memberCollection;

    public MembersController(ILogger<MembersController> logger, IMemberCollection memberCollection)
    {
        _logger = logger;
        this.memberCollection = memberCollection;
    }

    [HttpGet(Name = "search")]
    [Route("search")]
    public async Task<IActionResult> Search()
    {
        var members = await this.memberCollection.Find();

        return Ok(members);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewMember([FromBody] NewMemberInputModel model)
    {
        var member = new Member
        {
            LastName = model.LastName,
            FirstName = model.FirstName
        };
        var newMember = await this.memberCollection.Create(member);
        return Created("", member);
    }
}
