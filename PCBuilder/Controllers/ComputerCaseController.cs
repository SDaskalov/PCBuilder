namespace PCBuilder.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.Infrastructure.Extensions;
    using PCBuilder.Web.ViewModels.ComputerCase;
    using PCBuilder.Web.ViewModels.GPU;

    [Authorize]
    public class ComputerCaseController : Controller
    {

        private readonly IComputerCaseService _caseService;
        private readonly IBuilderService _builderService;

        public ComputerCaseController(IBuilderService builderService, IComputerCaseService caseService)
        {
            _builderService = builderService;
            _caseService = caseService;
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
            IEnumerable<ComputerCaseFormViewModel> gpus = await _caseService.GetAllAsync();

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
            ComputerCaseFormViewModel? gpu = await _caseService.GetCaseDetailsAsync(id);

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
        public async Task<IActionResult> Add(ComputerCaseFormViewModel model)
        {

            bool isBuilder = await this._builderService.BuilderAlreadyExcistsByUserId(this.User.GetId()!);

            if (!isBuilder)
            {
                this.TempData["ErrorMessage"] = "You must be a builder to add PC components.";
                return this.RedirectToAction("Become", "Builder");
            }
            bool CaseExists = await this._caseService.CaseExistsByModelName(model.ModelName);

            if (CaseExists)
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
                await this._caseService.CreateAsync(model, this.User.GetId()!);
            }
            catch (Exception)
            {
                this.TempData["ErrorMessage"] = "Error while saving. Please try again!";
            }

            this.TempData["SuccessMessage"] = "Successfully added new computer case!";
            return RedirectToAction("All", "ComputerCase");
        }
    }
}
