using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using System;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignupController : ControllerBase
    {
        [HttpPost("submit-form")]
        public IActionResult SubmitForm([FromForm] UserFormData user)
        {
            Console.WriteLine($"Received user: {user.Name}, {user.Email}, {user.Password}");
            return Ok();
        }
    }
}