using System;
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
        public async Task<IActionResult> Post([FromServices]IProductRepository repositorio, [FromBody]AddProductsModels productModel, [FromRoute] Guid idCategory)
        {
            var result = await repositorio.GetById(idCategory);
            
            if (result == default)
                return NotFound();

            
            var prod = new Product(productModel.Name, productModel.Price);
            await repositorio.AddProd(idCategory, prod);
            await repositorio.SaveChanges();
            return Created($"api/aplicacao/{prod.Name}", new {prod.Price });
        }
    }
}