using BlogApi.Src.Modelos;
using BlogApi.Src.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Src.Controladores {

    [ApiController]
    [Route("api/Postagens")]
    [Produces("application/json")]
    public class UsuarioControlador : ControllerBase {

        #region Atributos

        //private readonly IPostagem _repositorio;
        private readonly IUsuario _repositorio;

        #endregion

        #region Construtores
        public UsuarioControlador(IUsuario repositorio) {
            _repositorio = repositorio;
        }

        #endregion

        #region Métodos

        [HttpGet]
        public string HelloWorld() {
            return "Hello World Dotnet Turma 2";
        }

        [HttpGet ("ROTA2")]
        public string HelloWorld() {
            return "Hello World Dotnet Turma 2 rota 2";
        }

        [HttpPost]
        public async Task<ActionResult> NovoUsuarioAsync([FromBody] Usuario usuario) {
            await _repositorio.UsuarioAsync(usuario);

            return Created($"api/Usuarios/{usuario.Email}", usuario);
        }

        [HttpGet("email/{emailUsuario}")]
        public async Task<ActionResult> PegarUsuarioPeloEmailAsync([FromRoute] string emailUsuario) {
            var usuario = await _repositorio.UsuarioPeloEmailAsync(emailUsuario);

            if (usuario == null) return NotFound(new { Mesagem = "Usuario não encontrado" });

            return Ok(usuario);
        }
        #endregion
    }
}