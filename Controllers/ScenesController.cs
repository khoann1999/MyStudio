using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStudioApp.Models;

namespace MyStudioApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScenesController : ControllerBase
    {
        private readonly MyStudioContext _context;

        public ScenesController(MyStudioContext context)
        {
            _context = context;
        }

        // GET: api/Scenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scene>>> GetScenes()
        {
            return await _context.Scenes.ToListAsync();
        }

        // GET: api/Scenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scene>> GetScene(int id)
        {
            var scene = await _context.Scenes.FindAsync(id);

            if (scene == null)
            {
                return NotFound();
            }

            return scene;
        }

        // PUT: api/Scenes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScene(int id, Scene scene)
        {
            if (id != scene.Id)
            {
                return BadRequest();
            }

            _context.Entry(scene).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SceneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Scenes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Scene>> PostScene(Scene scene)
        {
            _context.Scenes.Add(scene);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SceneExists(scene.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetScene", new { id = scene.Id }, scene);
        }

        // DELETE: api/Scenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScene(int id)
        {
            var scene = await _context.Scenes.FindAsync(id);
            if (scene == null)
            {
                return NotFound();
            }

            _context.Scenes.Remove(scene);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SceneExists(int id)
        {
            return _context.Scenes.Any(e => e.Id == id);
        }
    }
}
