using PruebaDemokrata.Core.Entites;
using PruebaDemokrata.Core.Entites.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDemokrata.Core.Interface.Repository
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        object AddUsuario(Usuario usuario);

        object UpdateUsuario(Usuario usuario);

        public bool EliminarRegistroUsuario(int Id);

        public Task<List<Usuario>> FiltroUsuarios(FiltrosUsuariosDto filtro);

    }
}
