using PruebaDemokrata.Core.Entites.DTO;
using PruebaDemokrata.Core.Entites;
using AutoMapper;

namespace PruebaDemokrata.Api.Extensions
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioInDto, Usuario>();
            CreateMap<Usuario, UsuarioDto>();
        }


    }
}
