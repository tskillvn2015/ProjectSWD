using Shoes_Store.Data.Entities;
using Shoes_Store.Data.Interfaces;
using Shoes_Store.Data.ViewModels;
using Shoes_Store.Interfaces;
using Shoes_Store.Ultility.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoes_Store.Data.Service
{
    public class HistoryService : IHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApiResponse _apiResponse;
        public HistoryService(IUnitOfWork unitOfWork, IApiResponse apiResponse)
        {
            _unitOfWork = unitOfWork;
            _apiResponse = apiResponse;
        }

        public async Task<Object> GetAllHistory(HistoryViewModel model)
        {
            var listHistory = HistoryViewModel.Histories;
            return listHistory;
        }

        public async Task<Object> SearchHistoryByID(SearchHistoryVMs model)
        {
            History history = _unitOfWork.HistoryRepository.GetByID(model.Id);
            if(history == null)
            {
                return _apiResponse.Error(ShoerserException.HistpryException.H01,nameof(ShoerserException.HistpryException.H01));
            }
            var result = _apiResponse.Ok(history);
            return result;
        }
    }
}
