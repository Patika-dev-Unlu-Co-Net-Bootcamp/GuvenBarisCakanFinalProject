using System;
using Microsoft.AspNetCore.Mvc;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;

namespace WebAPI.Controllers
{
    [Route("api/Categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
    
        public CategoryController( ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_categoryService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetProductByCategory(int id)
        {
            // Kategori Id ye göre ürünleri dön id == 0 ise bütün ürünler dönülecek

            return Ok();
        }

        [HttpPost]
        public IActionResult Create()
        {
            //[FromBody]CategoryModel model
            //Category oluştur.
            return Ok();
        }

        [HttpPut]
        public IActionResult Update()
        {
            //[FromBody]CategoryModel model
            //Category güncelle.
            return Ok();
        }

        [HttpPatch]
        public IActionResult UpdateIsDeleted()
        {
            //[FromBody] bool 
            //Category isDeleted güncelle.
            return Ok();
        }
    }

}
