using StockTaking.Entities;
using StockTaking.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Dtos = StockTaking.DTOs.StockTakingMovement;
using StockTaking.Persistence.Repositories;

namespace StockTaking.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockTakingMovementController : ControllerBase
    {
        private readonly IStockTakingMovementRepository _StockTakingMovementRepository;
        private readonly IMapper _mapper;

        public StockTakingMovementController(IStockTakingMovementRepository StockTakingMovementRepository, IMapper mapper)
        {
            _StockTakingMovementRepository=StockTakingMovementRepository;
            _mapper=mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var StockTakingMovement = await _StockTakingMovementRepository.GetAllAsync();
            return Ok(_mapper.Map<List<Dtos.StockTakingMovementToListDto>>(StockTakingMovement));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var StockTakingMovement = await _StockTakingMovementRepository.GetByIdAsync(id);
            return Ok(_mapper.Map<Dtos.StockTakingMovementToListDto>(StockTakingMovement));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Dtos.StockTakingMovementToCreateDto StockTakingMovementToCreateDto)
        {
            var StockTakingMovementToCreate = _mapper.Map<StockTakingMovement>(StockTakingMovementToCreateDto);
            var StockTakingMovementCreated = await _StockTakingMovementRepository.AddAsync(StockTakingMovementToCreate);

            return Ok(_mapper.Map<Dtos.StockTakingMovementToListDto>(StockTakingMovementCreated));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Dtos.StockTakingMovementToEditDto StockTakingMovementToEditDto)
        {
            if(id != StockTakingMovementToEditDto.Id)
                return BadRequest("Error en los datos de entrada")  ;

                var StockTakingMovementToUpdate = await _StockTakingMovementRepository.GetByIdAsync(id);
                if(StockTakingMovementToUpdate != null)
                    return BadRequest("Error en los datos de entrada");

                _mapper.Map(StockTakingMovementToEditDto,StockTakingMovementToUpdate);

                var updated = await _StockTakingMovementRepository.UpdateAsync(id,StockTakingMovementToUpdate);

                if(!updated)
                    return NoContent();
                
                var StockTakingMovement = await _StockTakingMovementRepository.GetByIdAsync(id);

                return Ok(_mapper.Map<Dtos.StockTakingMovementToListDto>(StockTakingMovement));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var StockTakingMovementToDelete = await _StockTakingMovementRepository.GetByIdAsync(id);
            if(StockTakingMovementToDelete is null)
                return NotFound("Id no encontrado");
            
            var deleted = await _StockTakingMovementRepository.DeleteAsync(id);
            if(!deleted)
                return Ok("Registro no borrado consulte al administrados");
            
            return Ok("Registro borrado");
        }

    }
}