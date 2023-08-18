
namespace PCBuilder.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.ViewModels.GPU;
    using static PCBuilder.Web.Infrastructure.Extensions.ClaimsPrincipalExtensions;
    using static PCBuilder.Common.NotificationMessagesConstants;

    [Authorize]
    public class GraphicsCardController : Controller
    {
        private readonly IBuilderService _builderService;
        private readonly IGPUService _gpuService;

        public GraphicsCardController(IGPUService gPUService, IBuilderService builderService)
        {
            this._gpuService = gPUService;
            _builderService = builderService;
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
            IEnumerable<GPUFormViewModel> gpus = await _gpuService.GetAllAsync();

            return View(gpus);
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
            GPUFormViewModel? gpu = await _gpuService.GetGPUDetailsAsync(id);

            return View(gpu);
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
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(GPUFormViewModel model)
        {

            bool isBuilder = await this._builderService.BuilderAlreadyExcistsByUserId(this.User.GetId()!);

            if (!isBuilder)
            {
                this.TempData["ErrorMessage"] = "You must be a builder to add PC components.";
                return this.RedirectToAction("Become", "Builder");
            }

            bool GPUExists = await this._gpuService.GPUExistsByModelName(model.ModelName);

            if (GPUExists)
            {
                ModelState.AddModelError(nameof(model.ModelName), "Model is alreay added.");
                TempData["ErrorMessage"] = "Model is already added!";
            }
            if (!ModelState.IsValid)
            {

                return View(model);
            }

            try
            {

                await this._gpuService.CreateAsync(model, this.User.GetId()!);
            }
            catch (Exception)
            {
                this.TempData["ErrorMessage"] = "Error while saving. Please try again!";
            }


            this.TempData["SuccessMessage"] = "Successfully added GPU!";
            return RedirectToAction("All", "GraphicsCard");

        }

    }
}
