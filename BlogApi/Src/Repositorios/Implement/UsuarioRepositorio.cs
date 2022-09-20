using System.Threading.Tasks;
using BlogApi.Src.Contextos;
using BlogApi.Src.Modelos;
using BlogApi.Src.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Src.Repositorios.Implement {

    /// <summary>
    /// <para>Resumo: Classe responsavel por implementar IPostagem</para>
    /// <para>Criado por: Johnny Marcelino</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 22/08/2022</para>
    /// </summary>
    
    public class UsuarioRepositorio : IUsuario {
        #region Atributos

        private readonly BlogPessoalContexto _contexto;

        #endregion Atributos

        #region Construtores
        public UsuarioRepositorio(BlogPessoalContexto contexto) {
            _contexto = contexto;
        }
        #endregion Construtores


        #region Métodos

        /// <summary>
        /// <para>Resumo: Método assíncrono para salvar um novo usuario</para>
        /// </summary>
        /// <param name="usuario">Construtor para cadastrar usuario</param>
        
        public async Task NovoUsuarioAsync(Usuario usuario) {
            await _contexto.Usuarios.AddAsync(new Usuario {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Foto = usuario.Foto,
                Tipo = usuario.Tipo
            });
            await _contexto.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para salvar uma nova postagem</para>
        /// </summary>
        /// <param name="usuario">Construtor para cadastrar postagem</param>
        /// <return>UsuarioModelo</return>

        public async Task<Usuario> PegarUsuarioPeloEmailAsync(string email) {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }
        #endregion Métodos
    }
}