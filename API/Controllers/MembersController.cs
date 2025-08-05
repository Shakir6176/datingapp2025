using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  
    public class MembersController(AppDbContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var members = await context.Users.ToListAsync();

            return members;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetMember(string id)
        {
            var member = await context.Users.FindAsync(id);
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



    }
}
