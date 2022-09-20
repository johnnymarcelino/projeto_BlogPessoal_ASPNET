using BlogApi.Src.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace BlogApi.Src.Repositorios {
    public interface IPostagem {
        Task<List<Postagem>> PegarTodasAsPostagensAsync();
        Task<Postagem> PegarPostagemPeloIdAsync(int id);
        Task NovaPostagemAsync(Postagem postagem);
        Task AtualizarPostagemAsync(Postagem postagem);
        Task DeletarPostagemAsync(int id);
    }
}
