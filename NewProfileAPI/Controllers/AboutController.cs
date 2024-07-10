using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ProfileAPI.Data;
using ProfileAPI.Models;

namespace ProfileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly ProfileContext _context;

        public AboutController(ProfileContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<About>> GetAbout()
        {
            try
            {
                Console.WriteLine("GET request received for About");
                var about = await _context.Abouts.FirstOrDefaultAsync();
                if (about == null)
                {
                    Console.WriteLine("No About found");
                    return NotFound("No About information found.");
                }
                Console.WriteLine($"Returning About: {System.Text.Json.JsonSerializer.Serialize(about)}");
                return Ok(about);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAbout: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<About>> UpdateAbout(About about)
        {
            try
            {
                Console.WriteLine($"Received update request: {System.Text.Json.JsonSerializer.Serialize(about)}");

                var existingAbout = await _context.Abouts.FindAsync(about.Id);
                if (existingAbout == null)
                {
                    return NotFound($"About with ID {about.Id} not found.");
                }

                _context.Entry(existingAbout).CurrentValues.SetValues(about);
                await _context.SaveChangesAsync();

                Console.WriteLine("Update successful");
                return Ok(existingAbout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating About: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                return StatusCode(500, $"An error occurred while updating the About information: {ex.Message}");
            }
        }
    }
}
