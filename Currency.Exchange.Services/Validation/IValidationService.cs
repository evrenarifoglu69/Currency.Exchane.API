using Currency.Exchange.Public.BaseResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Exchange.Services.Validation
{
    public interface IValidationService
    {
        public Task<BaseResponse<bool>> IsValidTransaction(string userId);
    }
}
