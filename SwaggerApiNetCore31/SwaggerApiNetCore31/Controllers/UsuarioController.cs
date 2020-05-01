using Microsoft.AspNetCore.Mvc;
using SwaggerApiNetCore31.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SwaggerApiNetCore31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var usuarios = ObterUsuarios();
                return Ok(usuarios);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var usuarios = ObterUsuarios();
                var usuario = usuarios.FirstOrDefault(x => x.Id.Equals(id));

                if (usuario == null)
                    return NotFound(new { message = "Usuário não encontrado." });

                return Ok(usuario);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post(UsuarioPostVm usuario)
        {
            try
            {
                //Salva o usuário na base de dados.
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]Guid id, [FromBody] UsuarioPutVm usuario)
        {
            try
            {
                var usuarios = ObterUsuarios();
                var usuarioFakeDb = usuarios.FirstOrDefault(x => x.Id.Equals(id));

                if (usuarioFakeDb == null)
                    return NotFound(new { message = "Usuário não encontrado." });

                //Atualiza o usuário na base de dados.

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var usuarios = ObterUsuarios();
                var ususario = usuarios.FirstOrDefault(x => x.Id.Equals(id));

                if (ususario == null)
                    return NotFound(new { message = "Usuário não encontrado." });

                //Exclui o usuário na base de dados.

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        private IEnumerable<UsuarioGetVm> ObterUsuarios()
        {
            return new List<UsuarioGetVm>
            {
                new UsuarioGetVm { Id = Guid.Parse("CAEF4812-598E-4473-8EFC-B338AF69A18F"), Name = "João", Email = "joao@outlook.com" },
                new UsuarioGetVm { Id = Guid.Parse("B88DCCAF-A3A2-436F-8B09-27F0E1F73321"), Name = "José", Email = "jose@outlook.com" },
                new UsuarioGetVm { Id = Guid.Parse("1E018A4E-FC1B-4E2D-91CA-8076D60CF63F"), Name = "Maria", Email = "maria@outlook.com" }
            };
        }
    }
}