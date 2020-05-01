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
        /// <summary>
        /// Obter todos os usuários.
        /// </summary>
        /// <response code="200">A lista de usuários foi obtida com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao obter a lista de usuários.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<UsuarioGetVm>), 200)]
        [ProducesResponseType(500)]
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

        /// <summary>
        /// Obter um usuário específico por ID.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        /// <response code="200">O usuário foi obtido com sucesso.</response>
        /// <response code="404">Não foi encontrado usuário com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao obter o usuário.</response>
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

        /// <summary>
        /// Cadastrar usuário.
        /// </summary>
        /// <param name="usuario">Modelo do usuário.</param>
        /// <response code="200">O usuário foi cadastrado com sucesso.</response>
        /// <response code="400">O modelo do usuário enviado é inválido.</response>
        /// <response code="500">Ocorreu um erro ao cadastrar o usuário.</response>
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

        /// <summary>
        /// Alterar usuário.
        /// </summary> 
        /// <param name="id">ID do usuário.</param>
        /// <param name="usuario">Modelo do usuário.</param>
        /// <response code="200">O usuário foi alterado com sucesso.</response>
        /// <response code="400">O modelo do usuário enviado é inválido.</response>
        /// <response code="404">Não foi encontrado usuário com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao alterar o usuário.</response>
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

        /// <summary>
        /// Deletar usuário.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        /// <response code="200">O usuário foi deletado com sucesso.</response>
        /// <response code="404">Não foi encontrado usuário com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao deletar o usuário.</response>
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