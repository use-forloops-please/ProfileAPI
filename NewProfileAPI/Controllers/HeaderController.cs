using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ProfileAPI.Data;
using ProfileAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class HeaderController : ControllerBase
{
    private readonly ProfileContext _context;

    public HeaderController(ProfileContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<Header>> GetHeader()
    {
        return await _context.Headers.FirstOrDefaultAsync();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateHeader(Header header)
    {
        _context.Entry(header).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
