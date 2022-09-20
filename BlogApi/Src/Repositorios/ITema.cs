using BlogApi.Src.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

    /// <summary>
    /// <para>Resumo: Responsável por representar ações de CRUD de Tema</para>
    /// </summary>
    /// <param name="usuario">Construtor para cadastrar postagem</param>

namespace BlogApi.Src.Repositorios {
    public interface ITema {
        Task<List<Tema>> PegarTodosOsTemasAsync();
        Task<Tema> PegarTemaPeloIdAsync(int id);
        Task NovoTemaAsync(Tema tema);
        Task AtualizarTemaAsync(Tema tema);
        Task DeletarTemaAsync(int id);
    }
}
