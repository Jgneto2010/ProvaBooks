using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteAplication.ViewerModel;

namespace TesteAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {   //esse metodo adiciona Um produto ao estoque
        [HttpPost]
        [Route("addProduct")]
        public async Task<IActionResult> Post([FromServices]IProductRepository productRepository, [FromServices] ICategoryRepository categoryRepository, [FromBody]AddProductsModels productModel)
        {
            var result = await categoryRepository.GetById(productModel.IdCategory);
            var prod = new Product(productModel.Name, productModel.Price);

            if (result == default)
                return NotFound();
            prod.IdCategory = result.Id;

            await productRepository.Add(prod);
            await productRepository.SaveChanges();
            return Created($"api/product/{prod.Id}", new { prod.Price, prod.Name, prod.Id });
        }
        //Esse metodo Traz A Lista com todos os produtos
        [HttpGet]
        [Route("searchListProducts")]
        public async Task<IEnumerable<ListProductModel>> Get([FromServices] IProductRepository repositorio)
        {
            return await repositorio.ListAll(x => new ListProductModel { Id = x.Id, Name = x.Name });
        }
        // Esse metodo altera um objeto e Salva No Banco
        [HttpPut]
        [Route("change/Product")]
        public async Task<IActionResult> Put([FromServices]IProductRepository productRepository, [FromBody]UpDateProductModels upDateProductModels)
        {
            var result = await productRepository.GetById(upDateProductModels.Id);

            result.EditProduct(
            upDateProductModels.Name,
            upDateProductModels.Price,
            upDateProductModels.CategoryId);

            productRepository.UpDate(result);
            await productRepository.SaveChanges();
            return Created($"api/product/{result.Id}", new { result.Id, result.IdCategory, result.Price, result.Name });

        }
        //Esse metodo Remove Um Objeto dado seu Id
        [HttpDelete]
        [Route("removeProduct")]
        public async Task<IActionResult> RemoveDados([FromServices]IProductRepository productRepository, Guid id)
        {
            await productRepository.GetById(id);
            await productRepository.Remove(id);
            await productRepository.SaveChanges();

            return Ok();

        }
        //Esse Metodo traz Um produto com sua categoria
        [HttpGet]
        [Route("productCategory")]
        public async Task<IActionResult> Get([FromServices] IProductRepository repositorio, Guid id)
        {
            var rca = await repositorio.Buscar(id);

            return Ok(new GetProductCategory 
            { 
             IdCategory = rca.IdCategory,
             NameCategory = rca.Category.Name
            });

        }
    }
}