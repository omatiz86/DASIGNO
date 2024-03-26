using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PruebaDemokrata.Core.Entites;
using PruebaDemokrata.Core.Entites.DTO;
using PruebaDemokrata.Core.Interface;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace PruebaDemokrata.Api.Controllers
{
    public class DasignoCRUDController : Controller
    {

        #region Atributos y Propiedades
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        #endregion

        #region Construccion
        public DasignoCRUDController(IUsuarioService service, IMapper mapper)
        {
            _usuarioService = service;
            _mapper = mapper;
        }

        #endregion

        #region Metodos y Funciones

        [HttpPost]
        [Route("CrearUsuario")]
        [SwaggerOperation(Summary = "Insertar Usuario")]
        public ResponseDto CrearUsuario([FromBody] UsuarioInDto usuariosDTO)
        {
            ResponseDto response = new ResponseDto
            {
                Estado = true,
                Codigo = HttpStatusCode.OK.GetHashCode(),
                mensaje = "Creación de Usuario generada correctamente."
            };
            try
            {
                var result = _usuarioService.CrearUsuario(_mapper.Map<Usuario>(usuariosDTO));
                response.data = result;
            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Codigo = HttpStatusCode.InternalServerError.GetHashCode();
                response.mensaje = ex.Message + " ** ERROR  ** " + ex.InnerException;
            }

            return response;
        }

        [HttpPut]
        [Route("EditarUsuario")]
        [SwaggerOperation(Summary = "Editar un Usuario")]
        public ResponseDto EditarUsuario([FromBody] UsuarioInDto usuariosDTO)
        {
            ResponseDto response = new ResponseDto
            {
                Estado = true,
                Codigo = HttpStatusCode.OK.GetHashCode(),
                mensaje = "Editar un Usuario se genero correctamente."
            };
            try
            {
                var result = _usuarioService.EditarUsuario(_mapper.Map<Usuario>(usuariosDTO));
                response.data = result;
            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Codigo = HttpStatusCode.InternalServerError.GetHashCode();
                response.mensaje = ex.Message + " -- ERROR  -- " + ex.InnerException;
            }

            return response;
        }


        [HttpDelete]
        [Route("BorrarRegistroUsuario")]
        [SwaggerOperation(Summary = "Eliminar registro de Usuario")]
        public ResponseDto CancelarRegistroUsuario([FromQuery] int id)
        {
            ResponseDto response = new ResponseDto
            {
                Estado = true,
                Codigo = HttpStatusCode.OK.GetHashCode(),
                mensaje = "Se elimino el registro correctamente."
            };
            try
            {
                var result = _usuarioService.EliminarUsuario(id);
                response.data = result;
            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Codigo = HttpStatusCode.InternalServerError.GetHashCode();
                response.mensaje = ex.Message + " -- ERROR  -- " + ex.InnerException;
            }

            return response;
        }


        [HttpPost]
        [Route("ObtenerUsuariosFiltros")]
        [SwaggerOperation(Summary = "Consultar Usuarios con filtros")]
        public async Task<ResponseDto> ObtenerUsuariosFiltros([FromBody] RequestPaginacionDto entrada)
        {
            ResponseDto response = new ResponseDto
            {
                Estado = true,
                Codigo = HttpStatusCode.OK.GetHashCode(),
                mensaje = "Consulta de Usuario generada correctamente."
            };
            try
            {
                FiltrosUsuariosDto filtro = JsonConvert.DeserializeObject<FiltrosUsuariosDto>(entrada.Filtro.ToString());

                var usuarios = await _usuarioService.FiltroUsuarios(filtro);

                List<UsuarioFiltroDto> filter = usuarios.Select(s => new UsuarioFiltroDto
                {                    
                    PrimerNombre = s.PrimerNombre,
                    SegundoNombre = s.SegundoNombre,
                    PrimerApellido = s.PrimerApellido,
                    SegundoApellido = s.SegundoApellido,
                    FechaCreacion = s.FechaCreacion,
                    Sueldo = s.Sueldo,
                    FechaModificacion = s.FechaModificacion,
                    FechaNacimiento = s.FechaNacimiento,
                    Id = s.Id
                }).ToList();

                var list = _usuarioService.ObtenerUsuariosModificarPaginadoFiltro(filter, entrada.Paginacion);


                response.data = list;

            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Codigo = HttpStatusCode.InternalServerError.GetHashCode();
                response.mensaje = ex.Message + " -- ERROR  -- " + ex.InnerException;
            }

            return response;
        }



        #endregion




    }
}
