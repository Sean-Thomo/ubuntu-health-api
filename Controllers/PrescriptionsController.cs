using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prescription>>> GetAllPrescriptions()
        {
            var prescription = await _prescriptionService.GetAllPrescriptionsAsync();
            return Ok(prescriptions)
        }
    }
}