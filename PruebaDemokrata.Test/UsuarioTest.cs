using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using PruebaDemokrata.Core.Interface;
using PruebaDemokrata.Core.Service;
using PruebaDemokrata.Infrastructure.Context;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDemokrata.Test
{
    [TestClass]
    public class UsuarioTest
    {

        IUsuarioService service;
        IMapper _mapper;
        private IConfiguration existingConfiguration;

        public UsuarioTest()
        {

            var config = new ConfigurationBuilder().AddConfiguration(existingConfiguration).Build(); //AddJsonFile("appsettings.json").Build();    
            var connectionString = config.GetConnectionString("DefaultConnection");
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });
            _mapper = mockMapper.CreateMapper();
            EFContext context = new EFContext(options);
            UnitOfWork unitOfWork = new UnitOfWork(context);            
            service = new UsuarioService(unitOfWork);

        }

        [TestMethod]
        public void AdicionarUsuario()
        {
            //Preparacion
            string mensaje;
            var Usuario = new Core.Entites.Usuario();            

            Usuario.PrimerNombre = "OMAR";
            Usuario.SegundoNombre = "JAVIER";
            Usuario.PrimerApellido = "CHACON";
            Usuario.SegundoApellido = "MATIZ";            
            
            //Ejecucion
            try
            {
                var result = service.CrearUsuario(Usuario );
                //Validacion
                //Assert.IsTrue(result. != 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la creacion de usuario");
            }
        }

        [TestMethod]
        public void EditarUsuario()
        {
            //Preparacion
            string mensaje;
            var Usuario = new Core.Entites.Usuario();

            //Preparacion          
            Usuario.Id = 1;
            Usuario.PrimerNombre = "AGUSTIN";
            Usuario.SegundoNombre = "XAVIER";
            Usuario.PrimerApellido = "CHACON";
            Usuario.SegundoApellido = "SANCHEZ";            

            //Ejecucion
            try
            {
                var result = service.EditarUsuario(Usuario);
                //Validacion
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la creacion de usuario");
            }
        }

    }
}
