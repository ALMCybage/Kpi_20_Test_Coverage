using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Models;
 
namespace WebApplication1.Tests.Models
{
    [TestClass]
    public class Converter2Test
    {
        // Test 1 of 3 methods -> ~33% new-code coverage.
        // Test all 3 -> 100%. Test none (delete this) -> 0%.
        [TestMethod]
        public void CelsiusToFahrenheit_Works()
        {
            var converter = new Converter2();
            Assert.AreEqual(32, converter.CelsiusToFahrenheit(0));
        }
    }
}
