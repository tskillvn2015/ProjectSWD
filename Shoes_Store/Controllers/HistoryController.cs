using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shoes_Store.Data.Interfaces;
using Shoes_Store.Data.ViewModels;

namespace Shoes_Store.Controllers
{
    [Route("api/historys")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;
        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        //[HttpPost]
        //[Route("api/searchproductbyids")]
        //public async Task<IActionResult> SearchHistoryByID([FromBody]SearchHistoryViewModel model)
        //{
        //    var result = await _historyService.SearchHistoryByID(model);
        //    return Ok(result);
        //}
        [HttpGet]
        [Route("api/historys")]
        public async Task<IActionResult> GetAllHistory([FromQuery]SearchHistoryViewModel model)
        {
            var result = await _historyService.GetAllHistory(model);
            return Ok(result);
        }
    }
}