using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Contracts;
using ProductsApi.Models;
using ProductsApi.Repositories;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController: ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public ProductsController(IProductRepository productRepo){
            _productRepo = productRepo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){
            try{
                var product = await _productRepo.GetProduct(id);
                return Ok(product);
            }
            catch(NullReferenceException e){
                return NotFound("Product not found");
            }            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts(){
            return Ok(await _productRepo.GetAllProducts());
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] PostCreateProductRequest request){
            Product toAdd = new(){
                Name = request.Name,
                Price = request.Price,
                DateCreated = DateTime.Now
            };            
            await _productRepo.Add(toAdd);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct([FromBody] PutUpdateProductRequest request){
            try{
                await _productRepo.Update(request.Product);
                return Ok();
            }
            catch(NullReferenceException e){
                return NotFound("Product to update Not Found");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id){
            try{
                await _productRepo.Delete(id);
                return Ok();
            }
            catch(NullReferenceException e){
                return BadRequest("Product could not be deleted as it does not exist.");
            }
        }
    }
}