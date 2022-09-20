using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.Src.Modelos;

    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de usuario </ para >
    /// <para>Criado por: Johnny Marcelino</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 22/08/2022</para>
    /// </summary>

namespace BlogApi.Src.Repositorios {
    public interface IUsuario {
        Task<Usuario> PegarUsuarioPeloEmailAsync(string email);
        Task NovoUsuarioAsync(Usuario usuario);
    }
}