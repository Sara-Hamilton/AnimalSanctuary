using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalSanctuary.Models;

namespace AnimalSanctuary.Tests
{
    [TestClass]
    public class AnimalTests
    {

        [TestMethod]
        public void GetName_ReturnsAnimalName_String()
        {
            //Arrange
            var testAnimal = new Animal();
            testAnimal.Name = "Leo";

            //Act
            var result = testAnimal.Name;

            //Assert
            Assert.AreEqual("Leo", result);

        }

        [TestMethod]
        public void GetSpecies_ReturnsAnimalSpecies_String()
        {
            //Arrange
            var testAnimal = new Animal();
            testAnimal.Species = "Lion";

            //Act
            var result = testAnimal.Species;

            //Assert
            Assert.AreEqual("Lion", result);
        }

    }
}
