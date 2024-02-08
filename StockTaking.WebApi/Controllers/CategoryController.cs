using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockTaking.Entities;
using StockTaking.Persistence.Interfaces;
using Dtos = StockTaking.DTOs.Category;

namespace StockTaking.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();

            var categoriesDto = _mapper.Map<List<Dtos.CategoryToListDto>>(categories);

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categories = await _categoryRepository.GetByIdAsync(id);

            var categoryDto = _mapper.Map<Dtos.CategoryToListDto>(categories);

            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Dtos.CategoryToCreateDto categoryToCreateDto)
        {
            /*Version 1*
            Category categoryToCreate = new Category {
                Name = categoryToCreateDto.Name,
                Description = categoryToCreateDto.Description,
                CreateAt = DateTime.Now,
            };

           

            var categoryCreatedDto = new Dtos.CategoryToListDto{
                Id = categoryCreated.Id,
                Name = categoryCreated.Name,
                Description = categoryCreated.Description,
                CreateAt = categoryCreated.CreateAt,
                UpdateAt = categoryCreated.UpdateAt
            };

            return Ok(categoryCreatedDto);
            */

            /*Version with Mapper*/

            var categoryToCreate = _mapper.Map<Category>(categoryToCreateDto);
            categoryToCreate.CreateAt = DateTime.Now;

            var categoryCreated = await _categoryRepository.AddAsync(categoryToCreate);

            var categoryCreatedDto = _mapper.Map<Dtos.CategoryToListDto>(categoryToCreateDto);

            return Ok(categoryToCreateDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Dtos.CategoryToEditDto categoryToEditDto)
        {
            if (id != categoryToEditDto.Id)
            {
                return BadRequest("Error en los datos de entrada");
            }

            var categoryToUpdate = await _categoryRepository.GetByIdAsync(id);

            if (categoryToUpdate is null)
            {
                return BadRequest("Id no encontrado");
            }

            _mapper.Map(categoryToEditDto, categoryToUpdate);

            categoryToUpdate.UpdateAt = DateTime.Now;

            var updated = await _categoryRepository.UpdateAsync(id, categoryToUpdate);

            if (!updated)
            {
                return BadRequest("Erroneo");
            }

            var category = await _categoryRepository.GetByIdAsync(id);

            var categoryDto = _mapper.Map<Dtos.CategoryToListDto>(categoryToUpdate);

            return Ok(categoryDto);

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {

            var categoryToDelete = await _categoryRepository.GetByIdAsync(id);

            if (categoryToDelete is null)
            {
                return BadRequest("Id no encontrado");
            }

            var deleted = await _categoryRepository.DeleteAsync(categoryToDelete);

             if (!deleted)
            {
                return BadRequest("Erroneo");
            }

            return Ok("Registro borrado");
        }

    }
}