using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RemediosIO.Models;
using RemediosIO.Models.InputModels;
using RemediosIO.Repositories.Interfaces;

namespace RemediosIO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripController : ControllerBase
    {
        private readonly IStripRepository _stripRepository;

        public StripController(IStripRepository stripRepository)
        {
            _stripRepository = stripRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var strips = await _stripRepository.GetAllAsync();

            if (strips == null)
            {
                return NotFound();
            }

            return Ok(strips);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var strip = await _stripRepository.GetByIdAsync(id);

            if (strip == null)
            {
                return NotFound();
            }

            return Ok(strip);
        }

        [HttpPost]
        public async Task<IActionResult> Post(StripInputModel model)
        {
            var strip = new Strip(model.StripName, model.Description);

            await _stripRepository.CreateAsync(strip);

            return CreatedAtAction(nameof(GetById), new { id = strip.Id }, model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var strip = await _stripRepository.GetByIdAsync(id);

            if (strip == null)
            {
                return NotFound();
            }

            await _stripRepository.DeleteAsync(strip);
            return NoContent();
        }
    }
}
