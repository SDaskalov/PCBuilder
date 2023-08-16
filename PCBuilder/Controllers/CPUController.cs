
namespace PCBuilder.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.Infrastructure.Extensions;
    using PCBuilder.Web.ViewModels.CPU;
    using static PCBuilder.Common.NotificationMessagesConstants;

    [Authorize]
    public class CPUController : Controller
    {
        private readonly ISocketCategoryService _socketCategoryService;
        private readonly IVendorCategoryService _vendorCategoryService;
        private readonly IBuilderService _builderService;
        private readonly ICPUService _cpuService;

        public CPUController(ISocketCategoryService socketCategoryService, IVendorCategoryService vendorCategoryService, IBuilderService builderService, ICPUService cpuService)
        {
            _socketCategoryService = socketCategoryService;
            _vendorCategoryService = vendorCategoryService;
            _builderService = builderService;
            _cpuService = cpuService;
        }



        [HttpGet]

        public async Task<IActionResult> Add()
        {

            bool isBuilder = await this._builderService.BuilderAlreadyExcistsByUserId(this.User.GetId()!);

            if (!isBuilder)
            {
                this.TempData["ErrorMessage"] = "You must be a builder to add PC components.";
                return this.RedirectToAction("Become", "Builder");
            }

            CPUFormViewModel model = new CPUFormViewModel()
            {

                SocketCategories = await this._socketCategoryService.GetAllSocketCategoriesAsync(),
                VendorCategories = await this._vendorCategoryService.GetAllVendorCategoriesAsync()
            };

            return View(model);






        }

        [HttpPost]

        public async Task<IActionResult> Add(CPUFormViewModel model)
        {

            bool isBuilder = await this._builderService.BuilderAlreadyExcistsByUserId(this.User.GetId()!);

            if (!isBuilder)
            {
                this.TempData["ErrorMessage"] = "You must be a builder to add PC components.";
                return this.RedirectToAction("Become", "Builder");
            }

            bool vendorExists = await this._vendorCategoryService.VendorExistsById(model.VendorId);
            bool socketExists = await this._socketCategoryService.SocketExistsById(model.SocketId);

            bool CPUExists = await this._cpuService.CPUExistsByModelName(model.ModelName);

            if (!vendorExists || !socketExists)
            {
                ModelState.AddModelError(nameof(model.VendorId), "CATEGORY DOES NOT EXIST!");
                TempData["ErrorMessage"] = "Please check the selected options!";
            }


            if (CPUExists)
            {
                ModelState.AddModelError(nameof(model.VendorId), "Model is alreay added.");
                TempData["ErrorMessage"] = "Model is already added!";

            }
            if (!ModelState.IsValid)
            {
                model.VendorCategories = await this._vendorCategoryService.GetAllVendorCategoriesAsync();
                model.SocketCategories = await this._socketCategoryService.GetAllSocketCategoriesAsync();
                return View(model);
            }

            try
            {

                await this._cpuService.CreateAsync(model,this.User.GetId()!);
            }
            catch (Exception)
            {
                this.TempData["ErrorMessage"] = "Error while saving. Please try again!";
            }


            this.TempData["SuccessMessage"] = "Successfully added CPU!";
            return RedirectToAction("All", "CPU");


        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            bool isBuilder = await this._builderService.BuilderAlreadyExcistsByUserId(this.User.GetId()!);

            if (!isBuilder)
            {
                this.TempData["ErrorMessage"] = "You must be a builder to add PC components.";
                return this.RedirectToAction("Become", "Builder");
            }
            IEnumerable<CPUFormViewModel> cpus = await _cpuService.GetAllAsync();

            return View(cpus);


        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            bool isBuilder = await this._builderService.BuilderAlreadyExcistsByUserId(this.User.GetId()!);

            if (!isBuilder)
            {
                this.TempData["ErrorMessage"] = "You must be a builder to add PC components.";
                return this.RedirectToAction("Become", "Builder");
            }
            CPUDetailsViewModel? cpus = await _cpuService.GetCPUDetailsAsync(id);

            return View(cpus);


        }

    }
}
