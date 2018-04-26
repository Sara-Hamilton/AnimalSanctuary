using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AnimalSanctuary.Models;
using AnimalSanctuary.Controllers;
using Moq;
using System.Linq;
using AnimalSanctuary.Models.Repositories;
using System;

namespace AnimalSanctuary.Tests.ControllerTests
{
    [TestClass]
    public class AnimalsControllerTest : IDisposable
    {
        Mock<IVeterinarianRepository> vetMock = new Mock<IVeterinarianRepository>();
        Mock<IAnimalRepository> mock = new Mock<IAnimalRepository>();
        EFAnimalRepository dbAnimal = new EFAnimalRepository(new TestDbContext());
        EFVeterinarianRepository dbVet = new EFVeterinarianRepository(new TestDbContext());

        public void Dispose()
        {
            dbAnimal.DeleteAll();
            dbVet.DeleteAll();
        }

        private void DbSetup()
        {
            vetMock.Setup(v => v.Veterinarians).Returns(new Veterinarian[]
            {
                new Veterinarian {VeterinarianId = 1, Name = "Dr. Doolittle"}
            }.AsQueryable());

            mock.Setup(m => m.Animals).Returns(new Animal[]
            {
                new Animal{AnimalId = 1, Name = "Leo", Species = "lion", Sex = "M", HabitatType = "cave", MedicalEmergency = false, VeterinarianId = 1},
                new Animal{AnimalId = 1, Name = "Percy", Species = "penguin", Sex = "M", HabitatType = "Arctic", MedicalEmergency = false, VeterinarianId = 1},
                new Animal{AnimalId = 1, Name = "Ginny", Species = "giraffe", Sex = "F", HabitatType = "plains", MedicalEmergency = false, VeterinarianId = 1},
            }.AsQueryable());

            
        }

            

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult() // Confirms route returns view
        {
            //Arrange
            DbSetup();
            AnimalsController controller = new AnimalsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexContainsModelData_List()
        {
            //Arrange
            DbSetup();
            ViewResult indexView = new AnimalsController(mock.Object).Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<Animal>));
        }

        [TestMethod]
        public void Mock_IndexModelContainsAnimals_Collection()
        {
            //Arrange
            DbSetup();
            AnimalsController controller = new AnimalsController(mock.Object);
            Animal testAnimal = new Animal();
            testAnimal.Name = "Leo";
            testAnimal.AnimalId = 1;

            //Act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Animal> collection = indexView.ViewData.Model as List<Animal>;

            //Assert
            CollectionAssert.Contains(collection, testAnimal);
        }

        [TestMethod]
        public void Mock_PostViewResultCreate_ViewResult()
        {
            //Arrange
            Animal testAnimal = new Animal
            {
                AnimalId = 1,
                Name = "Leo"
            };

            DbSetup();
            AnimalsController controller = new AnimalsController(mock.Object);

            //Act
            var resultView = controller.Create(testAnimal) as RedirectToActionResult;

            //Assert
            Assert.IsInstanceOfType(resultView, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {
            //Arrange
            Animal testAnimal = new Animal
            {
                AnimalId = 1,
                Name = "Leo"
            };

            DbSetup();
            AnimalsController controller = new AnimalsController(mock.Object);

            //Act
            var resultView = controller.Details(testAnimal.AnimalId) as ViewResult;
            var model = resultView.ViewData.Model as Animal;

            //Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Animal));
        }

        [TestMethod]
        public void DB_CreatesNewEntries_Collection()
        {
            //Arrange
            AnimalsController controller = new AnimalsController(dbAnimal);
            Animal testAnimal = new Animal();
            testAnimal.Name = "testAnimal";

            //Act
            controller.Create(testAnimal);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Animal>;

            //Assert
            CollectionAssert.Contains(collection, testAnimal);
        }

    }
}
