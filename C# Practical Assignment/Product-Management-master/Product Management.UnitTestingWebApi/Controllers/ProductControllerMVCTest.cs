using Microsoft.VisualStudio.TestTools.UnitTesting;
using Product_Management.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Product_Management.UnitTestingWebApi.Controllers
{
    [TestClass]
    public class ProductControllerMVCTest
    {
        [TestMethod]
        public void ProductIndexPageTesting()
        {
            //Arrange
            ProductController controller = new ProductController();
            FormCollection form = new FormCollection();
            form["searchBy"] = "Name";
            form["search"] = "O";

            //Act
            var result = controller.Index(1,"Name",form,"Name","O") as ActionResult;


            //Assert

            Assert.IsNotNull(result);
            
        }

        [TestMethod]
        public void ProductAddorEditPage()
        {
            //Arrange
            ProductController controller = new ProductController();
            

            //Act
            var result = controller.AddorEdit() as ActionResult;


            //Assert

            Assert.IsNotNull(result);

        }


    }
}
