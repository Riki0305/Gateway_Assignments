using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Product_Management.Controllers;
using Product_Management.Models;
using Product_Management.Mvc;
using Product_Management.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace Product_Management.UnitTestingWebApi.Controllers
{
    
    [TestClass]
    public class ProductControllerWebApiTest
    {
        

       
        [TestMethod]
        public void GetProducts()
        {
            //Arrange

            ProductsController controller = new ProductsController();

            //Act
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products").Result;
            //var response = controller.GetProduct();
            //var contentResult = response as OkNegotiatedContentResult<Product>;
            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            Assert.AreEqual("application/json", response.Content.Headers.ContentType.MediaType);

        }

        [TestMethod]
        public void GetProductById()
        {
            //Arrange

            ProductsController controller = new ProductsController();

            //Act
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products/"+"30").Result;
            //var response = controller.GetProduct();
            //var contentResult = response as OkNegotiatedContentResult<Product>;
            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            Assert.AreEqual("application/json", response.Content.Headers.ContentType.MediaType);

        }
        [TestMethod]
        public void PostProduct()
        {
            //Arrange
            Product product = new Product
            {
               Id=0,
                Name = "Redmi note 5",
                CategoryId = 2,
                Price = 12000,
                ShortDesc = "hehehehdsn",
                LongDesc = "hohohohohoho",
                SmallImagePath = "jsjak",
                LongImagePath = "hajsj"
            };
            var json = JsonConvert.SerializeObject(product);
            //Act
            
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Products",product).Result;
           
            //Assert
            Assert.IsNotNull(response);
            //Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);

            
        }

        [TestMethod]
        public void PutProduct()
        {
            //Arrange
            Product product = new Product
            {
                Id = 29,
                Name = "Redmi note 5",
                CategoryId = 2,
                Price = 12000,
                ShortDesc = "hehehehdsn",
                LongDesc = "hohohohohoho",
                SmallImagePath = "jsjak",
                LongImagePath = "hajsj"
            };
            //Act
            HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Products/29", product).Result;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void DeleteProduct()
        {
            //Arrange
           
            //Act
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Products/29").Result;
            //Assert
            Assert.IsNotNull(response);
        }
     

    }
}
