using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RemediosIO.Models;
using RemediosIO.Models.InputModels;
using RemediosIO.Repositories.Interfaces;

namespace RemediosIO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyRepository _pharmacyRepository;

        public PharmacyController(IPharmacyRepository pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pharmacies = await _pharmacyRepository.GetAllAsync();

            if (pharmacies == null)
            {
                return NotFound();
            }

            return Ok(pharmacies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pharmacy = await _pharmacyRepository.GetByIdAsync(id);

            if (pharmacy == null)
            {
                return NotFound();
            }

            return Ok(pharmacy);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PharmacyInputModel model)
        {
            var pharmacy = new Pharmacy(model.Name, model.Address, model.PhoneNumber, model.Email);

            await _pharmacyRepository.CreateAsync(pharmacy);

            return CreatedAtAction(nameof(GetById), new { id = pharmacy.Id }, model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pharmacy = await _pharmacyRepository.GetByIdAsync(id);

            if (pharmacy == null)
            {
                return NotFound();
            }

            await _pharmacyRepository.DeleteAsync(pharmacy);

            return NoContent();
        }
    }
}
