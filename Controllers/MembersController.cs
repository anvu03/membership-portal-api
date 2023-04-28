using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

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
            FirstName = model.FirstName,
            MemberType = model.MemberType,
            Address = model.Address,
            City = model.City,
            State = model.State,
            ZIP = model.ZIP,
            BirthDate = model.BirthDate,
            ExpirationDate = model.Expiration, 
            HomePhoneNumber = model.HomePhoneNumber,
            BusinessPhoneNumber = model.BusinessPhoneNumber,
            CellPhoneNumber  = model.CellPhoneNumber,
            Gender = model.Gender, 
            IsActive = model.IsActive, 
            IsHeadHousehold = model.IsHeadHousehold,
            Volunteer = model.Volunteer, 
            Occupation = model.Occupation,
            Email = model.Email
        };
        var newMember = await this.memberCollection.Create(member);
        return Created("", member);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById([FromQuery] string id)
    {
      var member = await this.memberCollection.GetById(ObjectId.Parse(id));
      return Ok(member);
    }
}
