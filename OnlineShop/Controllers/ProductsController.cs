using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Facade.Models;
using OnlineShop.Facade.Interfaces;
using OlineShop.Logger.Interfaces;
using OlineShop.Logger.Enums;

namespace OnlineShop.Controllers
{
    [Produces("application/json")]
    public class ProductsController : Controller
    {
        private readonly IProductFacade _productFacade;
        private readonly ILogger _logger;
        private readonly IHostingEnvironment _environment;
        private readonly string imageTempFolder;
        private readonly string imageFolder;

        public ProductsController(IProductFacade productFacade, IHostingEnvironment environment, ILogger logger)
        {
            _productFacade = productFacade;
            _environment = environment;
            _logger = logger;
            imageTempFolder = "app\\images\\temp";
            imageFolder = "app\\images";
        }
        #region privates
        private string moveImage(string sourcePath, int groupId, int productId)
        {
            var fileExctention = sourcePath.Substring(sourcePath.LastIndexOf('.') + 1);
            var filePath = Path.Combine(imageFolder, $"{groupId}", $"{productId}.{fileExctention}");
            var fileFullPath = Path.Combine(_environment.WebRootPath, filePath);
            var sourceFullPath = Path.Combine(_environment.WebRootPath, sourcePath.Replace(@"/", @"\"));
            if (System.IO.File.Exists(sourceFullPath))
            {
                if (System.IO.File.Exists(fileFullPath))
                {
                    System.IO.File.Delete(fileFullPath);
                }
                System.IO.File.Move(sourceFullPath, fileFullPath);
            }
            return filePath.Replace(@"\", @"/");
        }
        private string saveImage(IFormFile uploadedFile)
        {
            var fileExctention = uploadedFile.ContentType.Substring(uploadedFile.ContentType.IndexOf('/') + 1);
            var filePath = Path.Combine(imageTempFolder, $"{DateTime.Now.Ticks.ToString()}.{fileExctention}");
            var fileFullPath = Path.Combine(_environment.WebRootPath, filePath);

            using (var stream = new FileStream(fileFullPath, FileMode.Create))
            {
                uploadedFile.CopyTo(stream);
            }
            return filePath.Replace(@"\", @"/");
        }
        #endregion

        //override onException
        [HttpPost]
        [Route("api/products/getAllProducts")]
        public IActionResult GetAllProducts(int? groupId, string key)
        {
            _logger.LogInfo(key, LogEvents.ListItems, $"Attempt to get products list.");
            ProductListResponse productResponse = _productFacade.GetAllProduct(key, groupId);
            //throw new ApplicationException("Error");
            _logger.LogInfo(key, LogEvents.ListItems, $"{ productResponse.Products.Count} products was/were fetched successfully.");
            return Ok(productResponse);
        }
        [HttpPost]
        [Route("api/products/getProductGroups")]
        public IActionResult GetProductGroups(string key)
        {
            _logger.LogInfo(key, LogEvents.ListItems, $"Attempt to get product groups list.");
            ProductGroupListResponse productGroupsResponse = _productFacade.GetProductGroups();
            _logger.LogInfo(key, LogEvents.ListItems, $"{ productGroupsResponse.ProductGroups.Count} product groups was/were fetched successfully.");
            return Ok(productGroupsResponse);
        }
        [HttpPost]
        [Route("api/products/addProduct")]
        public IActionResult AddProduct(AddProductParams product, string key)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentNullException("product");
            }
            else
            {
                _logger.LogInfo(key, LogEvents.AddItem, $"Attempt to add product.");

                int productId = _productFacade.AddProduct(key, product);

                if (!string.IsNullOrWhiteSpace(product.ImagePath))
                {
                    _logger.LogInfo(key, LogEvents.AddItem, $"Attempt to update product's new image path.");

                    product.ImagePath = moveImage(product.ImagePath, product.GroupId, productId);
                    UpdateProductParams productParams = new UpdateProductParams()
                    {
                        Id = productId,
                        GroupId = product.GroupId,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        QuantityOnHand = product.QuantityOnHand,
                        ImagePath = product.ImagePath
                    };
                    _productFacade.UpdateProduct(key, productParams);
                    _logger.LogInfo(key, LogEvents.AddItem, $"Product's new image path was updated successfully.");
                }
                _logger.LogInfo(key, LogEvents.AddItem, $"Product with Id: {productId} was added successfully.");
                return Ok(productId);
            }
        }
        [HttpPost]
        [Route("api/products/updateProduct")]
        public IActionResult UpdateProduct(string key, UpdateProductParams product)
        {
            _logger.LogInfo(key, LogEvents.UpdateItem, $"Attempt to update product with Id: {product.Id}.");

            if (product.ImagePath.Contains("temp"))
                product.ImagePath = moveImage(product.ImagePath, product.GroupId, product.Id);

            Product newProduct = _productFacade.UpdateProduct(key, product);
            _logger.LogInfo(key, LogEvents.UpdateItem, $"Product with Id: {product.Id} was updated successfully.");

            return Ok(newProduct);
        }

        [HttpPost]
        [Route("api/products/deleteProduct")]
        public IActionResult DeleteProduct(string key, int Id)
        {
            _logger.LogInfo(key, LogEvents.DeleteItem, $"Attemp to delete product with Id: {Id}");

            _productFacade.DeleteProduct(key, Id);
            _logger.LogInfo(key, LogEvents.DeleteItem, $"Product with Id: {Id} deleted successfully");
            return Ok();
        }
        [HttpPost]
        [Route("api/products/getProductInfo")]
        public IActionResult GetProductInfo(string key, int id)
        {
            _logger.LogInfo(key, LogEvents.GetItem, $"Attemp to get product with Id: {id} info");
            Product Product = _productFacade.GetProductInfo(id);
            if (Product == null)
            {
                _logger.LogError(key, LogEvents.GetItemNotFound, "Attemp to get product info, however product was not found.");
                return NotFound();
            }
            else
            {
                _logger.LogInfo(key, LogEvents.GetItem, "Product info was fetched successfully");
                return Ok(Product);
            }
        }
        [HttpPost]
        [Route("api/products/uploadImage")]
        public IActionResult UploadImage(string key)
        {
            _logger.LogInfo(key, LogEvents.UploadFile, "Attemp to upload Image.");
            if (HttpContext.Request.Form.Files.Any())
            {
                var uploadedFile = HttpContext.Request.Form.Files["file"];
                if (uploadedFile.Length > 0)
                {
                    var filePath = saveImage(uploadedFile);
                    _logger.LogInfo(key, LogEvents.UploadFile, "Image uploaded to the temp folder successfully.");
                    return Ok(filePath);
                }
                else
                {
                    _logger.LogError(key, LogEvents.UploadFile, "Attemp to upload Image however image was not found.");
                    return NotFound();
                }
            }
            else
            {
                _logger.LogError(key, LogEvents.UploadFile, "Attemp to upload Image however image was not found.");
                return NotFound();
            }
        }
    }
}