using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CategoryController : ControllerBase
    {
        [HttpPost]
        [Route("addCategory")]
        public async Task<IActionResult> Post([FromServices]ICategoryRepository repositorio, [FromBody]AddCategorysModels categoryModel)
        {

            var prod = new Category(categoryModel.Name);
            
            await repositorio.Add(prod);
            await repositorio.SaveChanges();
            return Created($"api/aplicacao/{prod.Name}", new { prod.Id });
        }
    }
}