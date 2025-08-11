using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]

    public class MembersController(IMemberRepository memberRepository) : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Member>>> GetMembers()
        {
            return Ok(await memberRepository.GetMembersAsync());


        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(string id)
        {
            var member = await memberRepository.GetMemberByIdAsync(id);
            if (member == null) return NotFound();
            return member;
            // return Ok(new { msg = "retun from new" });

        }


        // [HttpGet]
        //  public ActionResult<AppUser> GetMem(string id)
        // {
        //     var member = context.Users.Find(id);
        //     if (member == null) return NotFound();

        //     return Ok(new { msg = "retun from new" , member = member });

        // }

        [HttpGet("{id}/photos")]

        public async Task<ActionResult<IReadOnlyList<Photo>>> GetMemberPhotos(string id)
        {
            return Ok(await memberRepository.GetPhotosForMemberAsync(id));
        }

    }
}
