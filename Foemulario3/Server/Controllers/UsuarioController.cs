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
        private object listaUsuarios;

        public UsuarioController(ApplicationDbContext controlaBanco)
        {
            _controlaBanco = controlaBanco;
        }

        
        [HttpGet]
        public IActionResult BuscaListaUsuarios()
        {
            List<Usuario> lista = _controlaBanco.Usuarios.ToList();

            return Ok(lista);
        }


        [HttpGet("{id}")]
        public IActionResult BuscaUsuario(int Id)
        {
            Usuario usuario = _controlaBanco.Usuarios.FirstOrDefault(p => p.Id == Id);

            if(usuario == null)
            {
                return NotFound("Usuario não encontrado.");
            }

            return Ok(usuario);

        }        

        [HttpPost]
        public IActionResult AdicionaUsuario(Usuario usuario)
        {
            
                _controlaBanco.Usuarios.Add(usuario);
                _controlaBanco.SaveChanges();
            

                return Ok(usuario);                    
        }


        [HttpPut]
        public IActionResult AlteraUsuario(Usuario usuario)
        {
            Usuario alterado = _controlaBanco.Usuarios.FirstOrDefault(p => p.Id == usuario.Id);

            if(alterado == null)
            {
                return NotFound("Pessoa não encontrada.");
            }
            alterado.Nome = usuario.Nome;
            alterado.Idade = usuario.Idade;

            _controlaBanco.SaveChanges();

            return Ok();
        }

        [HttpDelete("{nome}")]
        public IActionResult DeletaUsuario(string nome)
        {
            Usuario usuario = _controlaBanco.Usuarios.FirstOrDefault(p => p.Nome == nome);

            _controlaBanco.Usuarios.Remove(usuario);
            _controlaBanco.SaveChanges();

            return Ok($"O usuario {usuario.Nome} foi apagado do banco de dados!");



        }

    }
}
