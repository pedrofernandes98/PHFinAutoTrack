using AutoMapper;
using PHFinAutoTrack.Application.DTOs;
using PHFinAutoTrack.Domain.Entities;

namespace PHFinAutoTrack.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Lancamento, LancamentoDTO>().ReverseMap();
        }
    }
}
