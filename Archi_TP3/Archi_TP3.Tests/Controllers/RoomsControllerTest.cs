﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archi_TP3;
using Archi_TP3.Controllers;

namespace Archi_TP3.Tests.Controllers
{
    [TestClass]
    public class RoomsControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            RoomsController controller = new RoomsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            RoomsController controller = new RoomsController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [DataRow(2)]
        public void Edit(int? id)
        {
            // Arrange
            RoomsController controller = new RoomsController();

            // Act
            ViewResult result = controller.Edit(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [DataRow(2)]
        public void Delete(int? id)
        {
            // Arrange
            RoomsController controller = new RoomsController();

            // Act
            ViewResult result = controller.Delete(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
