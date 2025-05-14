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
      CreateMap<Appointment, AppointmentResponseDto>();
      CreateMap<AppointmentCreateDto, AppointmentResponseDto>();

      CreateMap<ClinicalNoteCreateDto, ClinicalNote>();
      CreateMap<ClinicalNoteUpdateDto, ClinicalNote>();
      CreateMap<ClinicalNote, ClinicalNoteResponseDto>();
      CreateMap<ClinicalNoteCreateDto, ClinicalNoteResponseDto>();

      CreateMap<PrescriptionCreateDto, Prescription>();
      CreateMap<PrescriptionUpdateDto, Prescription>();
      CreateMap<Prescription, PrescriptionResponseDto>();
      CreateMap<PrescriptionCreateDto, PrescriptionResponseDto>();

      CreateMap<InvoiceCreateDto, Invoice>();
      CreateMap<InvoiceUpdateDto, Invoice>();
      CreateMap<Invoice, InvoiceResponseDto>();
      CreateMap<InvoiceCreateDto, InvoiceResponseDto>();

      // Model -> Response DTO
      CreateMap<Patient, PatientDto>();
    }
  }
}