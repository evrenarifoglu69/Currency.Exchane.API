using Currency.Exchange.Core.DbEntities;
using Currency.Exchange.EntityFramework.UnitOfWork;
using Currency.Exchange.Public.BaseResultModels;
using Currency.Exchange.Shared.ServiceDependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Exchange.Services.Validation
{
    public class ValidationService : IValidationService, IScopedService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ValidationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<BaseResponse<bool>> IsValidTransaction(string userId)
        {
           var transactionCountInHour = _unitOfWork.GetRepository<ExchangeRateEntity>().GetAll(x=> x.CreatedBy == userId && x.CreatedOn > DateTime.Now.AddHours(-1)).Count();
            return Task.FromResult(new BaseResponse<bool>()
            {
                Data = transactionCountInHour < 10
            });
        }
    }
}
