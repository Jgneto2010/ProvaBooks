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
    {
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
            return Created($"api/aplicacao/{prod.Id}", new {prod.Price, prod.Name, prod.Id });
        }

        [HttpGet]
        [Route("buscarListaProdutos")]
        public async Task<IEnumerable<ListProductModel>> Get([FromServices] IProductRepository repositorio)
        {
            return await repositorio.ListAll(x => new ListProductModel { Id = x.Id, Name = x.Name });
        }

        [HttpPut]
        [Route("Alterar/Product")]
        public async Task<IActionResult> Put([FromServices]IProductRepository productRepository, [FromBody]UpDateProductModels upDateProductModels)
        {
            var result = await productRepository.GetById(upDateProductModels.Id);

            result.EditProduct(
            upDateProductModels.Name,
            upDateProductModels.Price,
            upDateProductModels.CategoryId,
            upDateProductModels.Id);

            result.Id = new Guid();
            result.IdCategory = new Guid();
           
            productRepository.UpDate(result);
            await productRepository.SaveChanges();
            return Created($"api/product/{result.Name}", new { result.Id, result.IdCategory, result.Price, result.Name });

        }
    }
}