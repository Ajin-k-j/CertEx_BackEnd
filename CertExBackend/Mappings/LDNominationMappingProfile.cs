// LDNominationMappingProfile.cs
using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;

namespace CertExBackend
{
    public class LDNominationMappingProfile : Profile
    {
        public LDNominationMappingProfile()
        {
            // Map from Nomination entity to LDNominationDto
            CreateMap<Nomination, LDNominationDto>()
                .ForMember(dest => dest.NominationId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Employee.Id))
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => $"{src.Employee.FirstName} {src.Employee.LastName}"))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Employee.Email))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Employee.Department.DepartmentName))
                .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src.CertificationExam.CertificationProvider.ProviderName))
                .ForMember(dest => dest.CertificationName, opt => opt.MapFrom(src => src.CertificationExam.CertificationName))
                .ForMember(dest => dest.Criticality, opt => opt.MapFrom(src => src.CertificationExam.Level))
                .ForMember(dest => dest.NominationDate, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.PlannedExamMonth, opt => opt.MapFrom(src => src.PlannedExamMonth))
                .ForMember(dest => dest.MotivationDescription, opt => opt.MapFrom(src => src.MotivationDescription))
                .ForMember(dest => dest.ManagerRecommendation, opt => opt.MapFrom(src => src.ManagerRecommendation))
                .ForMember(dest => dest.ManagerRemarks, opt => opt.MapFrom(src => src.ManagerRemarks))
                .ForMember(dest => dest.IsDepartmentApproved, opt => opt.MapFrom(src => src.IsDepartmentApproved))
/*                .ForMember(dest => dest.DepartmentHeadRemarks, opt => opt.MapFrom(src => src.DepartmentHeadRemarks))*/
                .ForMember(dest => dest.IsLndApproved, opt => opt.MapFrom(src => src.IsLndApproved))
/*                .ForMember(dest => dest.LndRemarks, opt => opt.MapFrom(src => src.LndRemarks))*/
                .ForMember(dest => dest.ExamDate, opt => opt.MapFrom(src => src.ExamDate))
                .ForMember(dest => dest.ExamStatus, opt => opt.MapFrom(src => src.ExamStatus))
                .ForMember(dest => dest.UploadCertificateStatus, opt => opt.MapFrom(src => src.ExamDetails.UploadCertificateStatus))
                .ForMember(dest => dest.SkillMatrixStatus, opt => opt.MapFrom(src => src.ExamDetails.SkillMatrixStatus))
                .ForMember(dest => dest.ReimbursementStatus, opt => opt.MapFrom(src => src.ExamDetails.ReimbursementStatus))
                .ForMember(dest => dest.NominationStatus, opt => opt.MapFrom(src => src.NominationStatus))
                .ForMember(dest => dest.FinancialYear, opt => opt.Ignore()) // Adjust as needed
                .ForMember(dest => dest.CostOfCertification, opt => opt.MapFrom(src => src.CertificationExam.CostInr)); // Adjust as needed
        }
    }
}
