using Shoes_Store.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shoes_Store.Data.Interfaces
{
    public interface IHistoryService
    {
        object GetHistoryById(HistoryViewModel model);
        Task<object> GetAllHistory(HistoryViewModel model);
    }
}
