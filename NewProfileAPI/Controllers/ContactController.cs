using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ProfileAPI.Data;
using ProfileAPI.Models;

namespace ProfileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ProfileContext _context;

        public ContactController(ProfileContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Contact>> GetContact()
        {
            return await _context.Contacts.FirstOrDefaultAsync();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
