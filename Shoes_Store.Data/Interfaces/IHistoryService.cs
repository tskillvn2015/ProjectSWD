using Shoes_Store.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shoes_Store.Data.Interfaces
{
    public interface IHistoryService
    {
        Task<Object> SearchHistoryByID(SearchHistoryVMs model);
        Task<Object> GetAllHistory(HistoryViewModel model);
    }
}
