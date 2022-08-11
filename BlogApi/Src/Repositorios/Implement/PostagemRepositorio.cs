using BlogApi.Src.Contextos;
using BlogApi.Src.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Src.Repositorios.Implement {
    public class PostagemRepositorio : IPostagem {

        #region Atributos

        private readonly BlogPessoalContexto _contexto;

        #endregion

        #region Construtor
        public PostagemRepositorio(BlogPessoalContexto contexto) {
            _contexto = contexto;
        }

        #endregion

        #region Metodos
        public async Task<List<Postagem>> PegarTodasAsPostagensAsync() {
            return await _contexto.Postagens.ToListAsync();
        }

        public async Task<Postagem> PegarPostagemPeloIdAsync(int id) {

            if (!ExisteId(id)) throw new Exception("Id postagem não encontrado");

            return await _contexto.Postagens.FirstOrDefaultAsync(p => p.Id == id);

            // função auxiliar
            bool ExisteId(int id) {

                var auxiliar = _contexto.Postagens.FirstOrDefault(p => p.Id == id);

                return auxiliar != null;
            }
        }

        public async Task NovaPostagemAsync(Postagem postagem) {
            await _contexto.Postagens.AddAsync(
                new Postagem {
                    Descricao = postagem.Descricao
                });
            await _contexto.SaveChangesAsync();
        }
        public async Task AtualizarPostagemAsync(Postagem postagem) {

            // if (!ExisteDescricao(postagem.Descricao)) throw new Exception("Descrição já existe no sistema");

            var auxiliar = await PegarPostagemPeloIdAsync(postagem.Id);
            auxiliar.Descricao = postagem.Descricao;
            _contexto.Postagens.Update(auxiliar);
            await _contexto.SaveChangesAsync();
        }

        public async Task DeletarPostagemAsync(int id) {

            // var auxiliar = await PegarPostagemPeloId(id);
            _contexto.Postagens.Remove(await PegarPostagemPeloIdAsync(id));
            await _contexto.SaveChangesAsync();
        }
        private bool ExisteDescricao(string descricao) {

            var auxiliar = _contexto.Postagens.FirstOrDefault(p => p.Descricao == descricao);

            return auxiliar != null;
        }
        #endregion

        //public Task Deleted() {
        //    throw new NotImplementedException();
        //}
        //public Task Read() {
        //    throw new NotImplementedException();
        //}
        //public Task Updated() {
        //    throw new NotImplementedException();
        //}
    }
}