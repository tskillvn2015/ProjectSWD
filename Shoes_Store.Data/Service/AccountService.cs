using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shoes_Store.Data.EF;
using Shoes_Store.Data.Entities;
using Shoes_Store.Data.Interfaces;
using Shoes_Store.Data.ViewModels;
using Shoes_Store.Interfaces;
using Shoes_Store.Ultility.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shoes_Store.Data.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly IApiResponse _apiResponse;
        public AccountService(IUnitOfWork unitOfWork, IConfiguration configuration,IApiResponse apiResponse)
        {
            _apiResponse = apiResponse;
            _configuration =configuration;
            _unitOfWork = unitOfWork;
            _connectionString = configuration.GetConnectionString("ShoeserSolutionDb");
        }
        public async Task<int> Register(RegisterViewModel model)
        {
            var result = _unitOfWork.AccountRepository.Get(c => c.Username.Equals(model.Username));
            if(result.FirstOrDefault() != null)
            {
                throw new Exception("This username already exist!");
            }
            var account = new Account
            {
                Username = model.Username,
                Password =model.Password,
                Role=model.Role,
                FullName=model.FullName,
                Address=model.Address,
            };
            _unitOfWork.AccountRepository.Add(account);
            return  _unitOfWork.Save();
        }
        public async Task<Object> Login(LoginViewModel model)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                var parameters = new DynamicParameters();
                parameters.Add("@username", model.Username);
                parameters.Add("@password", model.Password);
                var sql = "Select Id,Username,Role from Account where Username=@username and Password=@password";
                var rs = await conn.QueryAsync<Account>(sql, parameters, null, null, CommandType.Text);
                var user = rs.FirstOrDefault();
                if (user == null)
                {
                    return _apiResponse.Error(ShoerserException.AccountException.A01, nameof(ShoerserException.AccountException.A01));
                }

                var token = GenerateJwtToken(user);
                var tokenString = (new { token = new JwtSecurityTokenHandler().WriteToken(token) });

                var result = _apiResponse.Ok(tokenString);

                return result;

            }
        }

        //Generate Jwt Token
        private JwtSecurityToken GenerateJwtToken(Account user)
        {
            var claims = new Claim[]
                {
                    new Claim("Id",user.Id.ToString()),
                    new Claim("Username",user.Username),
                    new Claim(ClaimTypes.Role,user.Role.ToString()),
                };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Tokens:Issuer"],
                _configuration["Tokens:Issuer"],
                // claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds,
                claims: claims);

                return token;

            }
        }

        
    
}
