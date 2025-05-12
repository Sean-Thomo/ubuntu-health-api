using Microsoft.AspNetCore.Mvc;
using ubuntu_health_api.Models;
using ubuntu_health_api.Services;
using Microsoft.AspNetCore.Authorization;
using ubuntu_health_api.Helpers;

namespace ubuntu_health_api.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class ClinicalNotesController(IHttpContextAccessor httpContextAccessor) : ControllerBase
  {
    private readonly IClinicalNoteService _clinicalNoteService;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

  }
}