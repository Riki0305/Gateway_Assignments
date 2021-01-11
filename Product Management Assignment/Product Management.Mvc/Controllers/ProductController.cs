using Product_Management.Models;
using Product_Management.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Product_Management.Mvc.Utility;

namespace Product_Management.Mvc.Controllers
{
    public class ProductController : Controller
    {
        //private ProductContext db = new ProductContext();
        // GET: Product
        public ActionResult Index(int? page,string sortBy,FormCollection formCollection,string SearchBy, string Search)
        {
            ViewBag.SortNameParameter = string.IsNullOrEmpty(sortBy) ? "Name Desc" : "";
            ViewBag.SortCategoryParameter = sortBy == "Category" ? "Category Desc" : "Category";
            ViewBag.SearchBy = SearchBy;
            ViewBag.Search = Search;
            IEnumerable<Product> productList;
            if(ViewBag.SearchBy != null && ViewBag.Search != null)
            {
                MyLogger.GetInstance().Info("SearchBy - " + SearchBy + " Search - " + Search);
                formCollection["SearchBy"] = ViewBag.SearchBy;
                formCollection["Search"] = ViewBag.Search;
            }
            if (formCollection.Count != 0)
            {
                
                if (formCollection["submitButton1"] != "Delete Multiple" && formCollection["Search"] != "" && ViewBag.Search != "")
                {
                    try
                    {
                        //Code for Search Operation
                        MyLogger.GetInstance().Info("Searching for : " + formCollection["Search"]);
                        TempData["SuccessMessage"] = "Search Results for : "  + formCollection["Search"];

                        HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products/ProductSearch/" + formCollection["SearchBy"] + "/" + formCollection["Search"]).Result;
                        productList = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                        
                        TempData["SearchProducts"] = productList;
                      
                    }
                    catch(Exception ex)
                    {
                        MyLogger.GetInstance().Error("Exception at Search operation : "+ex.Message);
                       
                    }



                }
                if(formCollection["submitButton1"] == "Delete Multiple")
                {
                    try
                    {
                        //Code for Delete multiple Operation
                        //TempData["SuccessMessage"] = "Submit for Delete";
                        
                        if (formCollection.Count != 3)
                        {
                            MyLogger.GetInstance().Info("Deleting products with Ids : " + formCollection["productId"]);
                            string[] Ids = formCollection["productId"].Split(new char[] { ',' });
                            foreach (string id in Ids)
                            {
                                HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Products/" + id.ToString()).Result;
                            }
                           
                            TempData["SuccessMessage"] = "Deleted Products successfully";
                        }
                        else
                        {
                            MyLogger.GetInstance().Warn("Deleting empty : " + formCollection["productId"]);
                            TempData["ErrorMessage"] = "Nothing is Selected ";

                        }
                    }
                    catch(Exception ex)
                    {
                        MyLogger.GetInstance().Error("Exception at Multiple deletion operation : " + ex.Message);
                    }
                    
                }
            }



            if (TempData["SearchProducts"] == null)
            {
                MyLogger.GetInstance().Info("Default Index operation.");
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products").Result;
                productList = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                
            }
            else
            {
                MyLogger.GetInstance().Info("Search results sent.");
                productList = (IEnumerable<Product>)TempData["SearchProducts"];
                
            }

            IEnumerable<Product> sortedProducts;

            switch (sortBy)
            {
                case "Name Desc":
                    sortedProducts = productList.OrderByDescending(x => x.Name);
                    break;
                case "Category Desc":
                    sortedProducts = productList.OrderByDescending(x => x.Category.Name);
                    break;
                case "Category":
                    sortedProducts = productList.OrderBy(x => x.Category.Name);
                    break;
                default:
                    sortedProducts = productList.OrderBy(x => x.Name);
                    break;
            }
            if(sortBy==null)
            {
                MyLogger.GetInstance().Info("Products sorted by : Name");
            }
            else
            {
                MyLogger.GetInstance().Info("Products sorted by : "+sortBy);
            }
            


            return View(sortedProducts.ToPagedList(page ?? 1, 4));
        }

       
        
        public ActionResult AddorEdit(int id = 0)
        {
            try
            {
                if (id == 0)
                {
                    //var _categories = db.Category.ToList();
                    IEnumerable<Category> _categories;
                    HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Categories").Result;
                    _categories = response.Content.ReadAsAsync<IEnumerable<Category>>().Result;

                    var viewModel = new ProductFormViewModel
                    {
                        product = new Product(),
                        category = _categories
                    };

                    return View(viewModel);
                }
                else
                {
                    IEnumerable<Category> _categories;
                    HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Categories").Result;
                    _categories = response.Content.ReadAsAsync<IEnumerable<Category>>().Result;

                    HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("Products/" + id.ToString()).Result;

                    Product _product = response1.Content.ReadAsAsync<Product>().Result;
                    var viewModel = new ProductFormViewModel
                    {
                        product = _product,
                        category = _categories
                    };

                    ViewBag.SmallImagePath = _product.SmallImagePath;
                    return View(viewModel);
                }
            }
            catch(Exception ex)
            {
                MyLogger.GetInstance().Error("Exception at AddorEdit : " + ex.Message);
                return RedirectToAction("Index");
            }
            
        }

        //mvc adding or editing single product
        [HttpPost]
        public ActionResult AddorEdit(Product product,HttpPostedFileBase smallImage, HttpPostedFileBase largeImage, HttpPostedFileBase smallImageEdit, HttpPostedFileBase largeImageEdit)
        {
            try
            {
                IEnumerable<Category> _categories;
                HttpResponseMessage responseCategory = GlobalVariables.WebApiClient.GetAsync("Categories").Result;
                _categories = responseCategory.Content.ReadAsAsync<IEnumerable<Category>>().Result;

                
                   
                    if (product.Id == 0)
                    {
                    if(smallImage==null )
                    {
                        ModelState.AddModelError("smallImage", "Small image is required");
                        var newProduct = new ProductFormViewModel { product = product, category = _categories };
                        return View("AddorEdit", newProduct);
                    }
                    if (largeImage == null)
                    {
                        ModelState.AddModelError("largeImage", "Large image is required");
                        var newProduct = new ProductFormViewModel { product = product, category = _categories };
                        return View("AddorEdit", newProduct);
                    }
                    //new product entry
                    var imageName = Path.GetFileName(smallImage.FileName);
                        var imageExtension = Path.GetExtension(smallImage.FileName).ToLower();

                    if (smallImage.ContentLength >= 2097152)
                    {
                        ModelState.AddModelError("sizemsgsmall", "Image should be less then 2 MB");
                        var newProduct = new ProductFormViewModel { product = product, category = _categories };
                        return View("AddorEdit", newProduct);
                    }
                    if (imageExtension != ".jpg" && imageExtension != ".gif" && imageExtension != ".jpeg" && imageExtension != ".png")
                    {
                        ModelState.AddModelError("smallImage", "Only image files are allowed");
                        var newProduct = new ProductFormViewModel { product = product, category = _categories };
                        return View("AddorEdit", newProduct);
                    }
                    var limageName = Path.GetFileName(largeImage.FileName);
                    var limageExtension = Path.GetExtension(largeImage.FileName).ToLower();

                    if (limageExtension != ".jpg" && limageExtension != ".gif" && limageExtension != ".jpeg" && limageExtension != ".png")
                    {
                        ModelState.AddModelError("largeImage", "Only image files are allowed");
                        var newProduct = new ProductFormViewModel { product = product, category = _categories };
                        return View("AddorEdit", newProduct);
                    }

                    var fullName = DateTime.Now.ToString("yymmssfff") + imageName;
                    product.SmallImagePath = "~/Uploads/" + fullName;
                    var fullPath = Path.Combine(Server.MapPath("~/Uploads/"), fullName);
                    smallImage.SaveAs(fullPath);



                   

                    var lfullName = DateTime.Now.ToString("yymmssfff") + limageName;
                    product.LongImagePath = "~/Uploads/" + lfullName;
                    var lfullPath = Path.Combine(Server.MapPath("~/Uploads/"), lfullName);
                    largeImage.SaveAs(lfullPath);
                        

                    HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Products", product).Result;
                    MyLogger.GetInstance().Info("New product added by name : " + product.Name);
                    TempData["SuccessMessage"] = "Saved " + product.Name + " Successfully";
                }
                else
                {
                    //updating product
                    HttpResponseMessage responseGetProduct = GlobalVariables.WebApiClient.GetAsync("Products/"+ product.Id.ToString()).Result;
                    var editingProduct = responseGetProduct.Content.ReadAsAsync<Product>().Result;
                    product.SmallImagePath = editingProduct.SmallImagePath;
                    product.LongImagePath = editingProduct.LongImagePath;
                    if (smallImageEdit!=null)
                        {
                            var imageName = Path.GetFileName(smallImageEdit.FileName);
                            var imageExtension = Path.GetExtension(smallImageEdit.FileName).ToLower();

                            if (smallImageEdit.ContentLength >= 2097152)
                            {
                                ModelState.AddModelError("smallImageEdit", "Image should be less then 2 MB ");
                                var newProduct = new ProductFormViewModel { product = product, category = _categories };
                                return View("AddorEdit", newProduct);
                            }
                            if (imageExtension != ".jpg" && imageExtension != ".gif" && imageExtension != ".jpeg" && imageExtension != ".png")
                            {
                                ModelState.AddModelError("smallImageEdit", "Only image files are allowed ");
                                var newProduct = new ProductFormViewModel { product = product, category = _categories };
                                return View("AddorEdit", newProduct);
                            }
                            var fullName = DateTime.Now.ToString("yymmssfff") + imageName;
                            var oldPath = Server.MapPath(product.SmallImagePath);
                            product.SmallImagePath = "~/Uploads/" + fullName;
                            var fullPath = Path.Combine(Server.MapPath("~/Uploads/"), fullName);
                            smallImageEdit.SaveAs(fullPath);
                            System.IO.File.Delete(oldPath);
                    }
                    if(largeImageEdit!=null)
                    {
                        var limageName = Path.GetFileName(largeImageEdit.FileName);
                        var limageExtension = Path.GetExtension(largeImageEdit.FileName).ToLower();

                           
                        if (limageExtension != ".jpg" && limageExtension != ".gif" && limageExtension != ".jpeg" && limageExtension != ".png")
                        {
                            ModelState.AddModelError("largeImageEdit", "Only image files are allowed ");
                            var newProduct = new ProductFormViewModel { product = product, category = _categories };
                            return View("AddorEdit", newProduct);
                        }
                        var lfullName = DateTime.Now.ToString("yymmssfff") + limageName;
                        var oldpath = Server.MapPath(product.LongImagePath);
                        product.LongImagePath = "~/Uploads/" + lfullName;
                        var lfullPath = Path.Combine(Server.MapPath("~/Uploads/"), lfullName);
                        largeImageEdit.SaveAs(lfullPath);
                        System.IO.File.Delete(oldpath);
                    }
                    if(smallImageEdit==null)
                    {
                        product.SmallImagePath = editingProduct.SmallImagePath;
                    }
                    if (largeImageEdit == null)
                    {
                        product.LongImagePath = editingProduct.LongImagePath;
                    }
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Products/" + product.Id, product).Result;
                        MyLogger.GetInstance().Info("Updated product by Id : " + product.Id);
                        TempData["SuccessMessage"] = "Updated " + product.Name + " Successfully";
                }
               
                
            }
            catch(Exception ex)
            {
                MyLogger.GetInstance().Error("Exception at AddorEdit : " + ex.Message);
            }
            return RedirectToAction("Index");
        }

        //mvc single delete product
        public ActionResult Delete(int id)
        {
            try
            {
                HttpResponseMessage responseGet = GlobalVariables.WebApiClient.GetAsync("Products/" + id.ToString()).Result;
                var userDelete = responseGet.Content.ReadAsAsync<Product>().Result;
                string deleteSmallImagePath = Server.MapPath(userDelete.SmallImagePath);
                string deleteLargeImagePath = Server.MapPath(userDelete.LongImagePath);
                System.IO.File.Delete(deleteSmallImagePath);
                System.IO.File.Delete(deleteLargeImagePath);
                HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Products/" + id.ToString()).Result;
               
                TempData["SuccessMessage"] = "Product deleted successfully";
                MyLogger.GetInstance().Info("Deleted product with ID : " + id);
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = "Can not delete Product";
                MyLogger.GetInstance().Error("Exception at Product Deletion : " + ex.Message);
                
            }
            return RedirectToAction("Index");
        }

       
        
    }
}