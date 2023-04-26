using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RemediosIO.Models;
using RemediosIO.Models.InputModels;
using RemediosIO.Repositories.Interfaces;

namespace RemediosIO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicineController(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var medicines = await _medicineRepository.GetAllAsync();
            return Ok(medicines);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var medicines = await _medicineRepository.GetByIdAsync(id);

            if (medicines == null)
            {
                return NotFound();
            }

            return Ok(medicines);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MedicineInputModel model)
        {
            var medicine = new Medicine(model.Name, model.Manufacturer, model.DosageInstructions, model.Warnings, model.Postedat, model.IdSupplier, model.IdStrip, model.IdCategory);

            await _medicineRepository.CreateAsync(medicine);

            return CreatedAtAction(nameof(GetById), new { id = medicine.Id }, model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var medicine = await _medicineRepository.GetByIdAsync(id);

            if (medicine == null)
            {
                return NotFound();
            }

            await _medicineRepository.DeleteAsync(medicine);
            return NoContent();
        }
    }
}
