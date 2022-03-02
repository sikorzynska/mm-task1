using MentorMate.Restaurant.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MentorMate.Restaurant.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class TablesController : Controller
    {
        private readonly ITableService _tableService;

        public TablesController(ITableService tableService)
        {
            _tableService = tableService ?? throw new ArgumentNullException(nameof(tableService));
        }

        [HttpGet]
        public async Task<IActionResult> GetTables()
        {
            var tables = await _tableService.GetAllAsync();

            if (!tables.Any())
            {
                return NotFound();
            }

            return Ok(tables);
        }
    }
}
