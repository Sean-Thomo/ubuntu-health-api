using AutoMapper;
using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Helpers
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      // Request DTO -> Model
      CreateMap<AppointmentCreateDto, Appointment>();
      CreateMap<AppointmentUpdateDto, Appointment>();
      // Model -> Response DTO
      CreateMap<Patient, PatientDto>();
      CreateMap<Invoice, InvoiceDto>();
      CreateMap<Appointment, AppointmentResponseDto>();
      CreateMap<ClinicalNote, ClinicalNoteDto>();
      CreateMap<Prescription, PrescriptionDto>();
    }
  }
}