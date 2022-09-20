using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogTeste.Contextos {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TesteDeSomaDeDoisValores() {
            var result = 2 + 5;
            Assert.AreEqual(7, result);
        }
    }
}
