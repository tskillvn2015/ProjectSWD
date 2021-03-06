﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoes_Store.Data.Entities;
using Shoes_Store.Data.Interfaces;
using Shoes_Store.Data.ViewModels;

namespace Shoes_Store.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        [Route("api/register")]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
        {
            var rs = await _accountService.Register(model);
            return Ok(rs);
        }
        [HttpPost]
        [Route("api/login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            var rs = await _accountService.Login(model);
            if (rs != null)
                return Ok(rs);
            else
                return BadRequest();
        }


        [HttpGet]
        [Route("api/Accounts")]
        public async Task<IActionResult> GetUserPagging([FromQuery]SearchAccountViewModel model)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity.IsAuthenticated)
            {
                Guid id = Guid.Parse(identity.FindFirst("Id").Value);

                var rs = await _accountService.GetUserPagging(model,id);
                return Ok(rs);
            }
            else
            {
                return BadRequest("token valid");
            }
            
        }

        [HttpGet]
        [Route("api/Account/detail")]
        public async Task<IActionResult> GetUser([FromQuery]Guid id)
        {
            var rs = await _accountService.GetUser(id);
            return Ok(rs);
        }

        [HttpDelete]
        [Route("api/Account")]
        public async Task<IActionResult> DeleteAccount([FromQuery]Guid id)
        {
            var rs = await _accountService.DeleteAccount(id);
            return Ok(rs);
        }

        [HttpPut]
        [Route("api/Account")]
        public async Task<IActionResult> UpdateAccount([FromBody]UpdateAccountViewModel model)
        {
            var rs = await _accountService.UpdateAccount(model);
            return Ok(rs);
        }

        [HttpPost]
        [Route("api/Account")]
        public async Task<IActionResult> CreateAccount([FromBody]CreateAccountViewModel model)
        {
            var rs = await _accountService.CreateAccount(model);
            return Ok(rs);
        }
    }
}