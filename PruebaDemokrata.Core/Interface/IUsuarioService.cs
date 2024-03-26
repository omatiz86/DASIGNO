using PruebaDemokrata.Core.Entites.DTO;
using PruebaDemokrata.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDemokrata.Core.Interface
{
    public interface IUsuarioService
    {

        object CrearUsuario(Usuario usuario);

        object EditarUsuario(Usuario usuario);

        bool EliminarUsuario(int Id);

        public Task<List<Usuario>> FiltroUsuarios(FiltrosUsuariosDto filtro);

        public ResponseDto ObtenerUsuariosModificarPaginadoFiltro(List<UsuarioFiltroDto> usuarios, PaginacionDto paginacion);

    }
}
