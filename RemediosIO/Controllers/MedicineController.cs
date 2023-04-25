using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
