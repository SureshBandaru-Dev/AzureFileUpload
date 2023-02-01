using AutoMapper;
using API.DTOs;

public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<EmployeeDto, Employee>();               
            CreateMap<Employee, EmployeeDto>();                
        }
    }