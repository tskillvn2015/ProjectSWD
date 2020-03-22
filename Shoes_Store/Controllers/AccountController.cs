﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            var rs = await _accountService.GetUserPagging(model);
            return Ok(rs);
        }

        [HttpPut]
        [Route("api/deleteAccount")]
        public async Task<IActionResult> DeleteAccount([FromBody]DeleteAccountViewModel model)
        {
            var rs = await _accountService.DeleteAccount(model);
            return Ok(rs);
        }

        [HttpPut]
        [Route("api/updateAccount")]
        public async Task<IActionResult> UpdateAccount([FromBody]UpdateAccountViewModel model)
        {
            var rs = await _accountService.UpdateAccount(model);
            return Ok(rs);
        }
    }
}