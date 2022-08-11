using System;
using BlogApi.Src.Modelos;
using BlogApi.Src.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogApi.Src.Controladores {
    public class PostagemControlador {

        #region Atributos

        private readonly IPostagem _repositorio;

        //private readonly IPostagem _repositorio;

        #endregion

        #region Construtores
        //public PostagemControlador(IPostagem repositorio) {
        //    _repositorio = repositorio;
        //}
        public PostagemControlador(IPostagem repositorio) {
            _repositorio = repositorio;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<ActionResult> PegarTodasAsPostagensAsync() {

            var lista = await _repositorio.PegarTodasAsPostagensAsync();

            if (lista.Count < 1) return NoContent();

            return Ok(lista);
        }

        [HttpGet("id/{idPostagem}")]
        public async Task<ActionResult> PegarPostagemPeloIdAsync([FromRoute] int idPostagem) {

            try {
                return Ok(await _repositorio.PegarPostagemPeloIdAsync(idPostagem));
            }

            catch (Exception ex) {
                return NotFound(new { Mensagem = ex.Message });
            }

        }

        [HttpPost]
        public async Task<ActionResult> NovaPostagemAsync([FromBody] Postagem postagem) {

            //try {
            await _repositorio.NovaPostagemAsync(postagem);
            return Create($"api/Postagens", postagem);
        }
        [HttpPut]
        public async Task<ActionResult> AtualizarPostagemAsync([FromBody] Postagem postagem) {
            try {
                await _repositorio.AtualizarPostagemAsync(postagem);
                return Ok(postagem);
            }

            catch (Exception ex) {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        [HttpDelete("id/{idPostagem}")]
        public async Task<ActionResult> DeletarPostagemAsync([FromRoute] int idPostagem) {

            try {
                await _repositorio.DeletarPostagemAsync(idPostagem);
                return NoContent();
            }

            catch (Exception ex) {
                return NotFound(new { Mensagem = ex.Message });
            }

        }

        [HttpDelete("all")]
        public async Task<ActionResult> DeletarPostagemAsync() {

            try {
                var lista = await _repositorio.PegarTodasAsPostagensAsync();

                foreach (var postagem in lista) {
                    await _repositorio.DeletarPostagemAsync(postagem.Id);
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
