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
    public class VeterinariansControllerTest : IDisposable
    {
        Mock<IVeterinarianRepository> vetMock = new Mock<IVeterinarianRepository>();
        EFVeterinarianRepository dbVet = new EFVeterinarianRepository(new TestDbContext());

        public void Dispose()
        {
            dbVet.DeleteAll();
        }

        private void DbSetup()
        {
            vetMock.Setup(v => v.Veterinarians).Returns(new Veterinarian[]
            {
                new Veterinarian {VeterinarianId = 1, Name = "Dr. Doolittle"}
            }.AsQueryable());
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult()
        {
            //Arrange
            DbSetup();
            VeterinariansController controller = new VeterinariansController(vetMock.Object);

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
            ViewResult indexView = new VeterinariansController(vetMock.Object).Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<Veterinarian>));
        }

        [TestMethod]
        public void Mock_IndexModelContainsVeterinarians_Collection()
        {
            //Arrange
            DbSetup();
            VeterinariansController controller = new VeterinariansController(vetMock.Object);
            Veterinarian testVeterinarian = new Veterinarian();
            testVeterinarian.Name = "Dr. Doolittle";
            testVeterinarian.VeterinarianId = 1;

            //Act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Veterinarian> collection = indexView.ViewData.Model as List<Veterinarian>;

            //Assert
            CollectionAssert.Contains(collection, testVeterinarian);
        }

        [TestMethod]
        public void Mock_PostViewResultCreate_ViewResult()
        {
            //Arrange
            Veterinarian testVeterinarian = new Veterinarian
            {
                VeterinarianId = 1,
                Name = "Dr. Doolittle"
            };

            DbSetup();
            VeterinariansController controller = new VeterinariansController(vetMock.Object);

            //Act
            var resultView = controller.Create(testVeterinarian) as RedirectToActionResult;

            //Assert
            Assert.IsInstanceOfType(resultView, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {
            //Arrange
            Veterinarian testVeterinarian = new Veterinarian
            {
                VeterinarianId = 1,
                Name = "Dr. Doolittle"
            };

            DbSetup();
            VeterinariansController controller = new VeterinariansController(vetMock.Object);

            //Act
            var resultView = controller.Details(testVeterinarian.VeterinarianId) as ViewResult;
            var model = resultView.ViewData.Model as Veterinarian;

            //Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Veterinarian));
        }

        [TestMethod]
        public void DB_CreatesNewEntries_Collection()
        {
            //Arrange
            VeterinariansController controller = new VeterinariansController(dbVet);
            Veterinarian testVeterinarian = new Veterinarian();
            testVeterinarian.Name = "testVeterinarian";

            //Act
            controller.Create(testVeterinarian);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Veterinarian>;

            //Assert
            CollectionAssert.Contains(collection, testVeterinarian);
        }

    }
}
