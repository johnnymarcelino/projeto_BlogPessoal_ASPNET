using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.Src.Contextos;
using BlogApi.Src.Modelos;
//using BlogPessoal.src.contextos;
//using BlogPessoal.src.modelos;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// <para>Resumo: Classe responsavel por implementar ITema</para>
/// <para>Criado por: Johnny Marcelino</para>
/// <para>Versão: 1.0</para>
/// <para>Data: 11/08/2022</para>
/// </summary>

namespace BlogApi.Src.Repositorios.Implement {
    //public class TemaRepositorio : ICrud {
    //    public Task Create(object obj) {
    //        return Task.CompletedTask;
    //        Console.WriteLine("Postagens");
    //    }

    //    public Task Delete(object obj) {
    //        Console.WriteLine("Delete");
    //    }

    //    public Task<object> Read() {
    //        throw new NotImplementedException();
    //    }
    //    public Task<IEnumerable<object>> GetAll() {
    //    }
    //}

    public class TemaRepositorio : ITema {

        #region Atributos

        private readonly BlogPessoalContexto _contexto;

        #endregion

        #region Construtor

        public TemaRepositorio(BlogPessoalContexto contexto) {
            _contexto = contexto;
        }

        #endregion

        #region Metodos


        public async Task<List<Tema>> PegarTodosOsTemasAsync() {
            return await _contexto.Temas.ToListAsync();
        }
        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar um tema pelo Id</para>
        /// </summary>
        /// <param name="id">Id do tema</param>
        /// <return>TemaModelo</return>
        /// <exception cref="Exception">Id não pode ser nulo</exception>

        public async Task<Tema> PegarTemaPeloIdAsync(int id) {

            if (!ExisteId(id)) throw new Exception("id do tema não encontrado");

            return await _contexto.Temas.FirstOrDefaultAsync(t => t.Id == id);

            // função auxiliar
            bool ExisteId(int id) {

                var auxiliar = _contexto.Temas.FirstOrDefault(t => t.Id == id);

                return auxiliar != null;
            }
        }

        //private bool Existe(int id) {
        //    throw new NotImplementedException();

        public async Task NovoTemaAsync(Tema tema) {
            await _contexto.Temas.AddAsync(
                new Tema {
                    Descricao = tema.Descricao
                });
            await _contexto.SaveChangesAsync();
        }

        //if (!ExisteDescricao(tema.Descricao)) throw new Exception("Descrição já existe no sistema");

        //await _contexto.Temas.AddAsync(new Tema {
        //    Descricao = tema.Descricao
        //});
        //await _contexto.SavaChangesAsync();

        //// função auxiliar
        //bool ExisteId(int id) {

        //    var auxiliar = _contexto.Temas.FirstOrDefault(t => t.Descricao == descricao);

        //    return auxiliar != null;


        public async Task AtualizarTemaAsync(Tema tema) {

            // if (!ExisteDescricao(tema.Descricao)) throw new Exception("Descrição já existe no sistema");

            var auxiliar = await PegarTemaPeloIdAsync(tema.Id);
            auxiliar.Descricao = tema.Descricao;
            _contexto.Temas.Update(auxiliar);
            await _contexto.SaveChangesAsync();
        }
        public async Task DeletarTemaAsync(int id) {

            // var auxiliar = await PegarTemaPeloId(id);
            _contexto.Temas.Remove(await PegarTemaPeloIdAsync (id));
            await _contexto.SaveChangesAsync();
        }

        private bool ExisteDescricao(string descricao) {

            var auxiliar = _contexto.Temas.FirstOrDefault(t => t.Descricao == descricao);

            return auxiliar != null;
        }
        #endregion
        //public Task<Tema> PegarTemaPeloId(int id) {
        //    var auxiliar = await PegarTemaPeloIdAsync(id);
        //    _contexto.Tema.Remove(auxiliar);
        //    await _contexto.SaveChangesAsync();
        //}
    }
}

//public Task<Tema> PegarTemaPeloId(int id);
//Task NovoTemaAsync(Tema tema);
//Task AtualizarTemaAsync(Tema tema);
//Task DeletarTemaAsync(int id);

//    Task<List<Tema>> ITema.PegarTodosOsTemasAsync() {
//        throw new NotImplementedException();
//    }
//    Task<Tema> ITema.PegarTemaPeloId(int id) {
//        throw new NotImplementedException();
//    }

//    public Task NovoTemaAsync(Tema tema) {
//        throw new NotImplementedException();
//    }

//    public Task AtualizarTemaAsync(Tema tema) {
//        throw new NotImplementedException();
//    }

//    Task ITema.DeletarTemaAsync(int id) {
//        throw new NotImplementedException();
//    }
//}