using BlogApi.Src.Modelos;
using BlogApi.Src.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace BlogApi.Src.Controladores {
    [ApiController]
    [Route("api/Temas")]
    [Produces("application/json")]
    public class TemaControlador : ControllerBase {

        #region Atributos

        private readonly ITema _repositorio;
        //private readonly IPostagem _repositorio;

        #endregion

        #region Construtores
        //public PostagemControlador(IPostagem repositorio) {
        //    _repositorio = repositorio;
        //}
        public TemaControlador(ITema repositorio) {
            _repositorio = repositorio;
        }

        #endregion

        #region Métodos

        //[HttpGet]
        //public string HelloWorld() {
        //    return "Hello World Dotnet Turma 2";
        //}

        //[HttpGet("ROTA2")]
        //public string HelloWorld() {
        //    return "Hello World Dotnet Turma 2 rota 2";
        //}

        [HttpGet]
        public async Task<ActionResult> PegarTodosOsTemasAsync() {
            var lista = await _repositorio.PegarTodosOsTemasAsync();

            if (lista.Count < 1) return NoContent();

            return Ok(lista);
        }

        [HttpGet("id/{idTema}")]
        public async Task<ActionResult> PegarTemaPeloIdAsync([FromRoute] int idTema) {

            try {
                return Ok(await _repositorio.PegarTemaPeloIdAsync(idTema));
            }

            catch (Exception ex) {
                return NotFound(new { Mensagem = ex.Message });
            }

        }

        [HttpPost]
        public async Task<ActionResult> NovoTemaAsync([FromBody] Tema tema) {

            //try {
            await _repositorio.NovoTemaAsync(tema);
            return Created($"api/Temas", tema);
            //}

            //catch (Exception ex) {
            //    return BadRequest(new { Mensagem = ex.Message });
            //}
        }
        //return Created($"api/Usuarios/{usuario.Email}", usuario);

        //[HttpPost]
        //public async Task<ActionResult> NovoUsuarioAsync([FromBody] Usuario usuario) {
        //    await _repositorio.UsuarioAsync(usuario);

        //    return Created($"api/Usuarios/{usuario.Email}", usuario);
        //}

        //[HttpGet("email/{emailUsuario}")]
        //public async Task<ActionResult> PegarUsuarioPeloEmailAsync([FromRoute] string emailUsuario) {
        //    var usuario = await _repositorio.UsuarioPeloEmailAsync(emailUsuario);

        //    if (usuario == null) return NotFound(new { Mesagem = "Usuario não encontrado" });

        //    return Ok(usuario);
        //}

        [HttpPut]
        public async Task<ActionResult> AtualizarTemaAsync([FromBody] Tema tema) {
            try {
                await _repositorio.AtualizarTemaAsync(tema);
                return Ok(tema);
            }

            catch (Exception ex) {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpDelete("id/{idTema}")]
        public async Task<ActionResult> DeletarTemaAsync([FromRoute] int idTema) {

            try {
                await _repositorio.DeletarTemaAsync(idTema);
                return NoContent();
            }

            catch (Exception ex) {
                return NotFound(new { Mensagem = ex.Message });
            }

        }

        [HttpDelete("all")]
        public async Task<ActionResult> DeletarTodosTemaAsync() {

            try {
                var lista = await _repositorio.PegarTodosOsTemasAsync();

                foreach (var tema in lista) {
                    await _repositorio.DeletarTemaAsync(tema.Id);
                }
                return NoContent();
            }
            catch (Exception ex) {
                return NotFound(new { Mensagem = ex.Message });
            }

        }
        #endregion
    }
}
