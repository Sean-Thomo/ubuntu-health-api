using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using System;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignupController : ControllerBase
    {
        [HttpPost("practitioner-signup")]
        public IActionResult SubmitForm([FromForm] Practitioner practitioner)
        {
            Console.WriteLine($"Received user: {practitioner.FirstName}, {practitioner.LastName}, {practitioner.Email}");
            return Ok();
        }
    }
}