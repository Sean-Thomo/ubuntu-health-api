using AutoMapper;
using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Helpers
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<Patient, PatientDto>();
      CreateMap<Invoice, InvoiceDto>();
      CreateMap<Appointment, AppointmentDto>();
      CreateMap<ClinicalNote, ClinicalNoteDto>();
      CreateMap<Prescription, PrescriptionDto>();
    }
  }
}