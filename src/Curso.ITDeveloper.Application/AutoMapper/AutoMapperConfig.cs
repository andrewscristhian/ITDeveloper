using AutoMapper;
using Curso.ITDeveloper.Application.ViewModels;
using Curso.ITDeveloper.Domain.Entities;

namespace Curso.ITDeveloper.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Paciente, PacienteViewModel>().ReverseMap();
        }
    }
}