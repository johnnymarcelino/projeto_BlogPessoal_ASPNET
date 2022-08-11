using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.Src.Modelos;

/// <summary>
/// <para>Resumo: Responsável por representar ações de CRUD de Tema</para>
/// </summary>
/// <param name="usuario">Construtor para cadastrar postagem</param>

namespace BlogApi.Src.Repositorios {
    public interface IUsuario {
        Task<Usuario> PegarUsuarioPeloEmailAsync(string email);
        void NovoUsuarioAsync(Usuario usuario);
    }
}