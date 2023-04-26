using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RemediosIO.Models;
using RemediosIO.Models.InputModels;
using RemediosIO.Repositories.Interfaces;

namespace RemediosIO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var suppliers = await _supplierRepository.GetAllAsync();

            if (suppliers == null)
            {
                return NotFound();
            }

            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SupplierInputModel model)
        {
            var supplier = new Supplier(model.SupplierName, model.Cnpj, model.Email, model.Address, model.State);

            await _supplierRepository.CreateAsync(supplier);

            return CreatedAtAction(nameof(GetById), new { id = supplier.Id }, model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            await _supplierRepository.DeleteAsync(supplier);

            return NoContent();
        }
    }
}
