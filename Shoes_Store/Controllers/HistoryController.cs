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

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetHistoryById([FromBody]HistoryViewModel model)
        {
            var result = _historyService.GetHistoryById(model);
            return Ok(result);
        }

        //[HttpGet]
        //[Route("{id}")]
        //public IActionResult GetByIdAccount(Guid id)
        //{
        //    var result = getAllHistory.Histories.Where(c => c.IdAccount = id).FirstOrDefault();
        //    if (result == null)
        //        return NotFound();
        //    return Ok(result);
        //}
    }
}