using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shoes_Store.Data.Interfaces;
using Shoes_Store.Data.ViewModels;

namespace Shoes_Store.Controllers
{
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;
        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpPost]
        [Route("api/searchproductbyids")]
        public async Task<IActionResult> SearchHistoryByID([FromBody]SearchHistoryVMs model)
        {
            var result = await _historyService.SearchHistoryByID(model);
            return Ok(result);
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllHistory(HistoryViewModel model)
        {
            var result = await _historyService.GetAllHistory(model);
            return Ok(result);
        }

    }
}