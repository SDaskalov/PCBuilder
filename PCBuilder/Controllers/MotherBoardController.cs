using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Services.Contracts;
using PCBuilder.Web.Infrastructure.Extensions;
using PCBuilder.Web.ViewModels.CPU;
using PCBuilder.Web.ViewModels.Motherboard;

namespace PCBuilder.Controllers
{
    [Authorize]
    public class MotherBoardController : Controller
    {

        private readonly IMotherBoardService _mbService;
        private readonly IBuilderService _builderService;
        private readonly ISocketCategoryService _socketCategoryService;
        private readonly IVendorCategoryService _vendorCategoryService;

        public MotherBoardController(IMotherBoardService mbService, IBuilderService builderService, ISocketCategoryService socketCategoryService, IVendorCategoryService vendorCategoryService)
        {
            _mbService = mbService;
            _builderService = builderService;
            _socketCategoryService = socketCategoryService;
            _vendorCategoryService = vendorCategoryService;
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

            MBFormViewModel model = new MBFormViewModel()
            {

                SocketCategories = await this._socketCategoryService.GetAllSocketCategoriesAsync(),
                VendorCategories = await this._vendorCategoryService.GetAllVendorCategoriesAsync()
            };

            return View(model);


        }



        [HttpPost]
        public async Task<IActionResult> Add(MBFormViewModel model)
        {

            bool isBuilder = await this._builderService.BuilderAlreadyExcistsByUserId(this.User.GetId()!);

            if (!isBuilder)
            {
                this.TempData["ErrorMessage"] = "You must be a builder to add PC components.";
                return this.RedirectToAction("Become", "Builder");
            }

            bool vendorExists = await this._vendorCategoryService.VendorExistsById(model.VendorId);
            bool socketExists = await this._socketCategoryService.SocketExistsById(model.SocketId);

            bool MBExists = await this._mbService.MBExistsByModelName(model.Name);

            if (!vendorExists || !socketExists)
            {
                ModelState.AddModelError(nameof(model.VendorId), "CATEGORY DOES NOT EXIST!");
                TempData["ErrorMessage"] = "Please check the selected options!";
            }


            if (MBExists)
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

                await this._mbService.CreateAsync(model, this.User.GetId()!);
            }
            catch (Exception)
            {
                this.TempData["ErrorMessage"] = "Error while saving. Please try again!";
            }


            this.TempData["SuccessMessage"] = "Successfully added Motherboard!";
            return RedirectToAction("All", "MotherBoard");


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
            IEnumerable<MBFormViewModel> mbs = await _mbService.GetAllAsync();

            return View(mbs);
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
            MBDetailsViewModel? mb = await _mbService.GetMBDetailsAsync(id);

            return View(mb);

        }

    }
}
