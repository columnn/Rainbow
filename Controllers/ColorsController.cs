using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Rainbow.Data;
using Microsoft.AspNetCore.Identity;

namespace Rainbow;

[Route("api/[controller]")]
[ApiController]
public class ColorsController : Controller
{
    private readonly ApplicationDbContext _db;

    public ColorsController(ApplicationDbContext db) { _db = db; }

    [HttpGet]
    public async Task<ActionResult<List<Color>>> GetColors()
    {
        return await _db.Colors
            .AsNoTracking()
            .ToListAsync();
    }

    [HttpGet("mycolors")]
    public async Task<ActionResult<List<Color>>> GetColorsByUsername(string username)
    {
        var colors = await _db.Colors
            .Where(c => c.Username == username)
            .AsNoTracking()
            .ToListAsync();

        if(colors is null)
            return NotFound();

        return colors;
    }

    [HttpGet("{colorId}")]
    public async Task<ActionResult<Color>> GetColorById(int colorId)
    {
        var color = await _db.Colors
            .Where(c => c.ColorId == colorId)
            .AsNoTracking()
            .SingleOrDefaultAsync();
        
        if(color is null)
            return NotFound();

        return color;
    }

    [HttpPost]
    public async Task<ActionResult> AddColor(Color color)
    {
        _db.Colors.Add(color);
        await _db.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateColor(int id, Color newColor)
    {
        var colorToUpdate = await _db.Colors
            .Where(c => c.ColorId == id)
            .AsNoTracking()
            .SingleOrDefaultAsync();

        if(colorToUpdate is null)
            return NotFound();

        colorToUpdate.Name = newColor.Name;
        colorToUpdate.Hex = newColor.Hex;

        _db.Colors.Update(colorToUpdate);
        await _db.SaveChangesAsync();
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteColor(int id)
    {
        var colorToDelete = await _db.Colors
            .Where(c => c.ColorId == id)
            .AsNoTracking()
            .SingleOrDefaultAsync();

        if(colorToDelete is null)
            return NotFound();

        _db.Colors.Remove(colorToDelete);
        await _db.SaveChangesAsync();

        return Ok();
    }
}