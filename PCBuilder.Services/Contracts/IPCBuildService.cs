using PCBuilder.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Services.Contracts
{
    public interface IPCBuildService
    {
        Task<IEnumerable<PCBuildViewModel>> LastThreeBuildsAsync();

    }
}
