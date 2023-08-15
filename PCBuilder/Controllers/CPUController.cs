using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Services.Contracts;
using PCBuilder.Web.Infrastructure.Extensions;
using PCBuilder.Web.ViewModels.CPU;

namespace PCBuilder.Controllers
{
    [Authorize]
    public class CPUController : Controller
    {
        private readonly ISocketCategoryService _socketCategoryService;
        private readonly IVendorCategoryService _vendorCategoryService;
        private readonly IBuilderService _builderService;

        public CPUController(ISocketCategoryService socketCategoryService, IVendorCategoryService vendorCategoryService, IBuilderService builderService)
        {
            _socketCategoryService = socketCategoryService;
            _vendorCategoryService = vendorCategoryService;
            _builderService = builderService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Add()
        {

            bool isBuilder = await this._builderService.BuilderAlreadyExcistsByUserId(this.User.GetId()!);

            CPUFormViewModel model = new CPUFormViewModel()
            {

                SocketCategories = await this._socketCategoryService.GetAllSocketCategoriesAsync(),
                VendorCategories = await this._vendorCategoryService.GetAllVendorCategoriesAsync()
            };

            return View(model);


        }




    }
}
