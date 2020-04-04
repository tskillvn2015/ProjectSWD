using Shoes_Store.Data.Entities;
using Shoes_Store.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shoes_Store.Data.Interfaces
{
    public interface IAccountService
    {
        Task<Object> Register(RegisterViewModel model);
        Task<Object> Login(LoginViewModel model);
        Task<Object> GetUserPagging(SearchAccountViewModel model,Guid currentUser);
        Task<Object> DeleteAccount(Guid id);
        Task<Object> UpdateAccount(UpdateAccountViewModel model);
        Task<Object> CreateAccount(CreateAccountViewModel model);
        Task<Object> GetUser(Guid id);
    }
}
