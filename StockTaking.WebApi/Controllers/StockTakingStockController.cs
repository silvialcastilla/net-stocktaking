
using AutoMapper;
using StockTaking.Entities;
using StockTaking.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Dtos = StockTaking.DTOs.StockTakingStock;

namespace StockTaking.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockTakingStockController : ControllerBase
    {
        private readonly IStockTakingStockRepository _StockTakingStockRepository;
        private readonly IMapper _mapper;

        public StockTakingStockController(IStockTakingStockRepository StockTakingStockRepository, IMapper mapper)
        {
            _StockTakingStockRepository=StockTakingStockRepository;
            _mapper=mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var StockTakingStocks = await _StockTakingStockRepository.GetAllAsync();
            return Ok(_mapper.Map<List<Dtos.StockTakingStockToListDto>>( StockTakingStocks));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var StockTakingStock = await _StockTakingStockRepository.GetByIdAsync(id);
            return Ok(_mapper.Map<Dtos.StockTakingStockToListDto>( StockTakingStock));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Dtos.StockTakingStockToCreateDto StockTakingStockToCreateDto)
        {
            var StockTakingStockToCreate = _mapper.Map<StockTakingStock>(StockTakingStockToCreateDto);
            StockTakingStockToCreate.CreateAt = DateTime.Now;
            var StockTakingCreated = await _StockTakingStockRepository.AddAsync(StockTakingStockToCreate);

            return Ok(_mapper.Map<Dtos.StockTakingStockToListDto>(StockTakingCreated));

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Dtos.StockTakingStockToEditDto StockTakingStockToEditDto)
        {
            if(id != StockTakingStockToEditDto.Id)
                return BadRequest("Error en los datos de entrada");

            var StockTakingStockToUpdate = await _StockTakingStockRepository.GetByIdAsync(id);
            if(StockTakingStockToUpdate is null)
                return BadRequest("Id no encontrado");
            
            _mapper.Map(StockTakingStockToEditDto,StockTakingStockToUpdate);
            var updated = await _StockTakingStockRepository.UpdateAsync(id,StockTakingStockToUpdate);

            if(!updated)
                return NoContent();

            var StockTakingStock = await _StockTakingStockRepository.GetByIdAsync(id);
            return Ok(_mapper.Map<Dtos.StockTakingStockToListDto>(StockTakingStock));            

        }



    }
}