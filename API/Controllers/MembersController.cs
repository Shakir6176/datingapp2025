using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var members =await context.Users.ToListAsync();

            return members;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetMember(string id)
        {
            var member =await context.Users.FindAsync(id);
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
