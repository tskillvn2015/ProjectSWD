using Shoes_Store.Data.Interfaces;
using Shoes_Store.Data.ViewModels;
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
        public HistoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }




        //public Task<object> GetHistory()
        //{
        //    var result = getAllHistory.Histories;
        //    return _unitOfWork.Save();
        //}

        public object GetHistoryById(HistoryViewModel model)
        {
            var result = _unitOfWork.HistoryRepository.Get(c => c.Id == model.Id).FirstOrDefault();
            return result;
        }
        public Task<object> GetAllHistory(HistoryViewModel model)
        {
            //    var result = _unitOfWork.HistoryRepository.GetByID();
            //    return ;
            throw new NotImplementedException();
        }

    }
}
