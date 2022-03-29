using MentorMate.Restaurant.Business.Services.Interfaces;
using MentorMate.Restaurant.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MentorMate.Restaurant.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TablesController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TablesController(ITableService tableService)
        {
            _tableService = tableService ?? throw new ArgumentNullException(nameof(tableService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tables = await _tableService.GetAllAsync();

            if (!tables.Any())
            {
                return NotFound(tables);
            }

            var response = MapExtension.MapTableCollection(tables);

            return Ok(response);
        }

        [HttpGet("{tableId}")]
        public async Task<IActionResult> Get(int tableId)
        {
            var table = await _tableService.GetByIdAsync(tableId);

            if(table == null)
            {
                return NotFound(table);
            }

            var response = MapExtension.MapTable(table);

            return Ok(response);
        }

        [HttpPatch("{tableId}")]
        public async Task<IActionResult> Clear(int tableId)
        {
            var response = await _tableService.ClearAsync(tableId);

            if(!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
