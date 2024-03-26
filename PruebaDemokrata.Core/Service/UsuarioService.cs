using PruebaDemokrata.Core.Entites.DTO;
using PruebaDemokrata.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaDemokrata.Core.Interface;
using PruebaDemokrata.Core.Interface.Repository;

namespace PruebaDemokrata.Core.Service
{
    public class UsuarioService : BaseService, IUsuarioService
    {

        public UsuarioService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { 
        
        }

        public object CrearUsuario(Usuario usuario)
        {

            var repository = UnitOfWork.UsuarioRepository();

            var respuestaUsuario = repository.AddUsuario(usuario);
            UnitOfWork.SaveChanges();

            return respuestaUsuario;

        }

        public object EditarUsuario(Usuario usuario)
        {
            var repository = UnitOfWork.UsuarioRepository();

            var result = repository.UpdateUsuario(usuario);


            return result;

        }

        public bool EliminarUsuario(int Id)
        {

            var repository = UnitOfWork.UsuarioRepository();
            var respuesta = repository
                                .EliminarRegistroUsuario(Id);
            UnitOfWork.SaveChanges();

            return respuesta;
        }

        public async Task<List<Usuario>> FiltroUsuarios(FiltrosUsuariosDto filtro)
        {
            return await UnitOfWork.UsuarioRepository().FiltroUsuarios(filtro);
        }



        public ResponseDto ObtenerUsuariosModificarPaginadoFiltro(List<UsuarioFiltroDto> usuarios, PaginacionDto paginacion)
        {
            paginacion.TotalRegistros = usuarios.Count;

            int pagina = paginacion.Pagina;
            int registrosPagina = paginacion.RegistrosPagina;

            int indiceInicio = (pagina - 1) * registrosPagina;
            int elementosRestantes = usuarios.Count - indiceInicio;

            var listaPaginada = elementosRestantes > 0
                ? usuarios.GetRange(indiceInicio, Math.Min(elementosRestantes, registrosPagina))
                : new List<UsuarioFiltroDto>();

            return new ResponseDto
            {
                data = listaPaginada,
            };
        }


    }
}
