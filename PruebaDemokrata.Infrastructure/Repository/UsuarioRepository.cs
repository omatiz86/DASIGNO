using PruebaDemokrata.Core.Entites.DTO;
using PruebaDemokrata.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaDemokrata.Core.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using PruebaDemokrata.Infrastructure.Context;
using Microsoft.VisualBasic;

namespace PruebaDemokrata.Infrastructure.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        #region Atributos y Propiedades
        private readonly EFContext context;        
        #endregion Atributos y Propiedades

        #region Constructor
        public UsuarioRepository(EFContext dbContext) : base(dbContext)
        {
            this.context = dbContext;
        }
        #endregion



        #region Métodos y Funciones
        public object AddUsuario(Usuario usuario)
        {
            this.context.Usuarios.Add(usuario);
            context.SaveChanges();

            var result = context.Usuarios.Where(e => e.Id == usuario.Id);
             return result;
        }

        public bool EliminarRegistroUsuario(int Id)
        {
            var objUsuario = this.context.Usuarios.Where(u => u.Id == Id )                              
                               .FirstOrDefault();
            this.context.Usuarios.Remove(objUsuario);

            return true;
        }
       

        public object UpdateUsuario(Usuario usuario)
        {
            this.context.Usuarios.Update(usuario);
            context.SaveChanges();

            var result = context.Usuarios.Where(e => e.Id == usuario.Id);
            return result;

        }

        
        public async Task<List<Usuario>> FiltroUsuarios(FiltrosUsuariosDto filtro)
        {
            var query = context.Usuarios.AsQueryable();

            if (filtro != null)
            {
                query = query.Where(usuario =>
                    (filtro.Id == null || usuario.Id == filtro.Id) &&
                    (string.IsNullOrEmpty(filtro.PrimerNombre) || usuario.PrimerNombre == filtro.PrimerNombre) &&
                    (string.IsNullOrEmpty(filtro.SegundoNombre) || usuario.SegundoNombre == filtro.SegundoNombre) &&
                    (string.IsNullOrEmpty(filtro.PrimerApellido) || usuario.PrimerApellido == filtro.PrimerApellido) &&
                    (string.IsNullOrEmpty(filtro.SegundoApellido) || usuario.SegundoApellido == filtro.SegundoApellido) &&
                    (!filtro.FechaNacimiento.HasValue || usuario.FechaNacimiento == filtro.FechaNacimiento) &&
                    (!filtro.Sueldo.HasValue || usuario.Sueldo == filtro.Sueldo) &&
                    (!filtro.FechaCreacion.HasValue || usuario.FechaCreacion == filtro.FechaCreacion) &&
                    (!filtro.FechaModificacion.HasValue || usuario.FechaModificacion == filtro.FechaModificacion)
                );
            }

            return await query.ToListAsync();
        }

       

        #endregion
    }
}
