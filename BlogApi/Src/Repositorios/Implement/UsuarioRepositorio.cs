using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.Src.Contextos;
using BlogApi.Src.Modelos;
using BlogApi.Src.Repositorios;
using BlogPessoal.src.contextos;
using BlogPessoal.src.modelos;
using Microsoft.EntityFrameworkCore;
namespace BlogAPI.Src.Repositorios.Implementacoes {
    /// <summary>
    /// <para>Resumo: Classe responsavel por implementar IPostagem</para>
    /// <para>Criado por: Generation</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 12/05/2022</para>
    /// </summary>
    public class PostagemRepositorio : IUsuario {
        #region Atributos

        private readonly BlogPessoalContexto _contexto;

        #endregion Atributos

        #region Construtores
        public PostagemRepositorio(BlogPessoalContexto contexto) {
            _contexto = contexto;
        }
        #endregion Construtores


        #region Métodos
        /// <summary>
        /// <para>Resumo: Método assíncrono para salvar uma nova postagem</para>
        /// </summary>
        /// <param name="usuario">Construtor para cadastrar postagem</param>
        public async Task NovoUsuarioAsync(Usuario usuario) {
            await _contexto.Usuarios.AddAsync(new Usuario {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Foto = usuario.Foto,
            });
            await _contexto.SaveChangesAsync();
        }

        public async Task<Usuario> PegarUsuarioPeloEmailAsync(string email) {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }


        #endregion Métodos

    }
}