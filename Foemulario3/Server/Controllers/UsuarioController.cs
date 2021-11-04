using Foemulario3.Server.Data;
using Foemulario3.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foemulario3.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    
    [AllowAnonymous]
    public class UsuarioController : ControllerBase
    {

        private ApplicationDbContext _controlaBanco;

        public UsuarioController(ApplicationDbContext controlaBanco)
        {
            _controlaBanco = controlaBanco;
        }



        [HttpGet("{id}")]
        public IActionResult BuscaUsuario(int Id)
        {
            Usuario usuario = _controlaBanco.Usuarios.FirstOrDefault(p => p.Id == Id);

            return Ok(usuario);

        }



        [HttpPost]
        public IActionResult AdicionaUsuario(Usuario usuario)
        {
            
                _controlaBanco.Usuarios.Add(usuario);
                _controlaBanco.SaveChanges();

                return Ok();            
            
        }

    }
}
