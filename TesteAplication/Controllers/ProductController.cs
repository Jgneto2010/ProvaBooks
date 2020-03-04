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
            return Created($"api/aplicacao/{prod.Name}", new {prod.Price });
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
            var productCommand = new Product(upDateProductModels.Name, upDateProductModels.Price);

            productCommand.Id = result.Id;

            await productRepository.Add(productCommand);
            await productRepository.SaveChanges();
            return Created($"api/aplicacao/{productCommand.Name}", new { productCommand.Price, productCommand.Id, productCommand.Category });

        }
    }
}