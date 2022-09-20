using BlogApi.Src.Modelos;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlogApi.Src.Contextos {

    /// <summary>
    /// <para>Resumo: Responsavel por representar criar contextos para métodos</para>
    /// <para>Criado por: Johnny Marcelino</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 22/08/2022</para>
    /// </summary>

    public class BlogPessoalContexto : DbContext {
        #region Atributos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tema> Temas { get; set; }
        public DbSet<Postagem> Postagens { get; set; }
        #endregion

        #region Construtores
        public BlogPessoalContexto(DbContextOptions<BlogPessoalContexto> opt) : base(opt) {
        }
        #endregion
    }
}