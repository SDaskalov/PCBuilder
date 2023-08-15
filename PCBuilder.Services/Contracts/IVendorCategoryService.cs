using PCBuilder.Web.ViewModels.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Services.Contracts
{
    public interface IVendorCategoryService
    {
        Task<IEnumerable<CPUVendorCategoryFormModel>> GetAllVendorCategoriesAsync();


    }
}
