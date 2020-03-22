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

        public async Task<Object> GetAllHistory(SearchHistoryViewModel model)
        {
            var data = _unitOfWork.HistoryRepository.Get(c => (model.Id == null) || c.Id.ToString().Contains(model.Id));

            int totalRow = data.Count();

            var dataWithPage = data.Skip((model.PageIndex - 1) * model.PageSize).Take(model.PageSize).Select(c => new HistoryViewModel()
            {
                Id = c.Id,
                NameOrder = c.NameOrder,
                CreatedDate = c.CreatedDate,
                TotalPrice = c.TotalPrice,
                IdAccount = c.IdAccount
            }).ToList();

            var result = new PagedResult<HistoryViewModel>
            {
                TotalRecord = totalRow,
                Items = dataWithPage
            };

            return _apiResponse.Ok(result);
        }

        //public async Task<Object> SearchHistoryByID(SearchHistoryViewModel model)
        //{
        //    History history = _unitOfWork.HistoryRepository.GetByID(model.Id);
        //    if (history == null)
        //    {
        //        return _apiResponse.Error(ShoerserException.HistpryException.H01, nameof(ShoerserException.HistpryException.H01));
        //    }
        //    var result = _apiResponse.Ok(history);
        //    return result;
        //}
    }
}
