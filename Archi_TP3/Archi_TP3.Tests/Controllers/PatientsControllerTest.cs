using Archi_TP3.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;

namespace Archi_TP3.Tests.Controllers
{
    [TestClass]
    public class PatientsControllerTest
    {
        [TestMethod]
        [DataRow("Albert", "Léna", "s@aze.com", "sk,k, azer, azer, azer", 102030405)]
        public void Index(String LastName, String FirstName, String Email, String Address, int Telephone = 0)
        {
            // Arrange
            PatientsController controller = new PatientsController();

            // Act
            ViewResult result = controller.Index(LastName, FirstName, Email, Address, Telephone) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            PatientsController controller = new PatientsController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [DataRow(1)]
        public void Edit(int? id)
        {
            // Arrange
            PatientsController controller = new PatientsController();

            // Act
            ViewResult result = controller.Edit(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [DataRow(1)]
        public void Delete(int? id)
        {
            // Arrange
            PatientsController controller = new PatientsController();

            // Act
            ViewResult result = controller.Delete(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
