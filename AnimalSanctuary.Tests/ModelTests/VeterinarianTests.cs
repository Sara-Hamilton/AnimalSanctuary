using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalSanctuary.Models;

namespace AnimalSanctuary.Tests.ModelTests
{
    [TestClass]
    public class VeterinarianTests
    {
        [TestMethod]
        public void GetName_ReturnsVetName_String()
        {
            //Arrange
            var testVeterinarian = new Veterinarian();
            testVeterinarian.Name = "Dr. Doolittle";

            //Act
            var result = testVeterinarian.Name;

            //Assert
            Assert.AreEqual("Dr. Doolittle", result);
        }
    }
}
