using BlogApi.Src.Contextos;
using BlogApi.Src.Modelos; // modelos
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq; // pesquisas -> dbset
namespace BlogTeste.Contextos {
    /// <summary>
    /// <para>Resumo: Classe para texte unitario de contexto de usuario</para>
    /// <para>Criado por: Generation</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 03/08/2022</para>
    /// </summary>
    [TestClass]
    public class UsuarioContextoTeste {

        #region Atributos

        private BlogPessoalContexto _contexto;
        private object _contextos;

        #endregion

        #region Métodos

        [TestMethod]
        public void InserirNovoUsuarioRetornaUsuarioInserido() {
            // Ambiente 
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT2")
            .Options;

            // DADO - Dado que adiciono 3 usuarios novos no sistema
            _contexto = new BlogPessoalContexto(opt);
            _contexto.Usuarios.Add(new Usuario {
                Nome = "Johnny Boaz",
                Email = "johnny@email.com",
                Foto = "URLDAFOTO",
                Senha = "123456"
            });
            _contexto.SaveChanges();

            // QUANDO - Quando eu pesquisar por todos os usuarios
            var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Email == "johnny@email.com");
            //var resultado1 = _contexto.Usuarios.Where(u => u.Nome.Contains("hgskjdk") == "johnny@email.com");
            //var resultado2 = _contexto.Usuarios.Where(u => u.Nome.Contains("hgskjdk")).ToList();
            //var auxiliar = from user in resultado2 where user.Nome == ""

            // ENTÃO - Então deve retornar uma lista com 3 usuarios
            Assert.IsNotNull(resultado);
            Assert.AreEqual("Johnny Boaz", resultado.Nome);

        }
        [TestMethod]
        public void InserirNovoUsuarioRetornaUsuarioInserido() {
            // Ambiente 
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT2")
            .Options;

            // DADO - Dado que adiciono 3 usuarios novos no sistema
            _contexto = new BlogPessoalContexto(opt);
            _contexto.Usuarios.Add(new Usuario {
                Nome = "Johnny Boaz",
                Email = "johnny@email.com",
                Foto = "URLDAFOTO",
                Senha = "123456"
            });
            _contexto.SaveChanges();

            // QUANDO - Quando eu pesquisar por todos os usuarios
            var resultado = _contexto.Usuarios.FirstOrDefault(u => u.Email == "johnny@email.com");
            //var resultado1 = _contexto.Usuarios.Where(u => u.Nome.Contains("hgskjdk") == "johnny@email.com");
            //var resultado2 = _contexto.Usuarios.Where(u => u.Nome.Contains("hgskjdk")).ToList();
            //var auxiliar = from user in resultado2 where user.Nome == ""

            // ENTÃO - Então deve retornar uma lista com 3 usuarios
            Assert.IsNotNull(resultado);
            Assert.AreEqual(3, resultado.Cont);
        }

            [TestMethod]
        public void InserirNovoUsuarioRetornaUsuarioInserido() {
            // Ambiente 
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "IMD_blog_gen_UCT1")
            .Options;

            // DADO - Dado que adiciono 3 usuarios novos no sistema
            _contexto = new BlogPessoalContexto(opt);
            _contexto.Usuarios.Add(new Usuario {
                Nome = "Zenildo Boaz",
                Email = "zenildo@email.com",
                Foto = "URLDAFOTOZENILDOBOAZ",
                Senha = "123456"
            });
            _contexto.SaveChanges();

            // QUANDO - Quando eu pesquisar por todos os usuarios
            var resultado1 = _contexto.Usuarios.FirstOrDefault(u => u.Email == "zenildo@email.com");
            auxiliar.Nome = "Zenildo Rosa";
            _contexto.Usuarios.Update(auxiliar);
            _contexto.SaveChanges();

            //var resultado1 = _contexto.Usuarios.Where(u => u.Nome.Contains("hgskjdk") == "johnny@email.com");
            //var resultado2 = _contexto.Usuarios.Where(u => u.Nome.Contains("hgskjdk")).ToList();
            //var auxiliar = from user in resultado2 where user.Nome == ""

            // ENTÃO - Então deve retornar uma lista com 3 usuarios
            //Assert.IsNotNull(resultado);
            Assert.IsNotNull(resultado1);
        }
    }
}