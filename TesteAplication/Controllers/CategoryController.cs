using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteAplication.ViewerModel;

namespace TesteAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class CategoryController : ControllerBase
    {
        //Esse metodo Adiciona Uma categoria
        [HttpPost]
        [Route("addCategory")]
        public async Task<IActionResult> Post([FromServices]ICategoryRepository repositorio, [FromBody]AddCategorysModels categoryModel)
        {
            var prod = new Category(categoryModel.Name);
            await repositorio.Add(prod);
            await repositorio.SaveChanges();
            return Created($"api/category/{prod.Name}", new { prod.Id });
        }
        //Esse metodo traz a Lista de categorias
        [HttpGet]
        [Route("searchListCategorys")]
        public async Task<IEnumerable<listCategoryModels>> Get([FromServices] ICategoryRepository repositorio)
        {
            return await repositorio.ListAll(x => new listCategoryModels { Id = x.Id, Name = x.Name });
        }

        //Esse metodo Remove Um Objeto dado seu Id
        [HttpDelete]
        [Route("removeCategorys")]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> RemoveDados([FromServices]ICategoryRepository categoryRepository, Guid id)
        {
            await categoryRepository.GetById(id);
            await categoryRepository.Remove(id);
            await categoryRepository.SaveChanges();
            return Ok();
        }
        // Esse metodo altera um objeto e Salva No Banco
        [HttpPut]
        [Route("changeCategory")]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> Put([FromServices]ICategoryRepository categoryRepository, [FromBody]UpdateCategoryModels upDateCategoryModels)
        {
            var result = await categoryRepository.GetById(upDateCategoryModels.Id);
            result.EditCategory(
            upDateCategoryModels.Name);
            categoryRepository.UpDate(result);
            await categoryRepository.SaveChanges();
            return Created($"api/category/{result.Id}", new { result.Id, result.Name });
        }
    }
}