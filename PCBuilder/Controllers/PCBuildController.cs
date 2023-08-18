
namespace PCBuilder.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Build.Framework;
    using PCBuilder.Data;
    using PCBuilder.Data.Models;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.Infrastructure.Extensions;
    using PCBuilder.Web.ViewModels.ComputerCase;
    using PCBuilder.Web.ViewModels.CPU;
    using PCBuilder.Web.ViewModels.GPU;
    using PCBuilder.Web.ViewModels.Motherboard;
    using PCBuilder.Web.ViewModels.PCConfiguration;
    using static PCBuilder.Web.Infrastructure.Extensions.ClaimsPrincipalExtensions;

    [Authorize]
    public class PCBuildController : Controller
    {

        private readonly IBuilderService _builderService;
        private readonly IPCBuildService _pcBuildService;
        private readonly ICPUService _cpusService;
        private readonly IGPUService _gpusService;
        private readonly IComputerCaseService _computerCaseService;
        private readonly IMotherBoardService _motherBoardService;

        public PCBuildController(IBuilderService builderService, IPCBuildService pCBuildService, ICPUService cPUService, IGPUService gPUService, IComputerCaseService computerCaseService, IMotherBoardService motherBoardService)
        {
            this._builderService = builderService;
            this._pcBuildService = pCBuildService;
            this._cpusService = cPUService;
            this._gpusService = gPUService;
            this._computerCaseService = computerCaseService;
            this._motherBoardService = motherBoardService;
        }

        public async Task<IActionResult> Sell(int id)
        {

            PCBuildDetailsViewModel? gpu = await _pcBuildService.GetPCDetailsAsync(id);


            if (gpu != null)
            {
                var builderGuid = await this._builderService.BuilderIdByUserId(User.GetId()!);

                if (builderGuid != null)
                {
                    if (gpu.CreatorId == Guid.Parse(builderGuid!))
                    {

                        if (gpu.HighestBidderId == Guid.Parse(this.User.GetId()!))
                        {
                            this.TempData["ErrorMessage"] = "You cannot sell this PC! There are no other bids yet!";
                        }
                        else
                        {

                            await this._pcBuildService.SellPcAsync(id, this.User.GetId()!);
                            this.TempData["SuccessMessage"] = "Congratulations! You sold the PC!";
                        }

                    }
                    if (this.User.IsAdmin())
                    {
                        await this._pcBuildService.SellPcAsync(id, this.User.GetId()!);
                        this.TempData["SuccessMessage"] = "Congratulations! You sold the PC!";
                    }
                }


            }

            gpu = await _pcBuildService.GetPCDetailsAsync(id);
            int helper = id;

            return RedirectToAction("Details", "PCBuild", new { id = helper });
        }



        public async Task<IActionResult> Bid(int id)
        {


            PCBuildDetailsViewModel? gpu = await _pcBuildService.GetPCDetailsAsync(id);

            if (gpu != null)
            {
                if (gpu.HighestBidderId == Guid.Parse(this.User.GetId()!))
                {
                    this.TempData["ErrorMessage"] = "You already hold the highest bid!";
                }
                else
                {
                    await this._pcBuildService.BidForPcAsync(id, this.User.GetId()!);
                    this.TempData["SuccessMessage"] = "Congratulations! You hold the current highest bid!";

                }
            }

            gpu = await _pcBuildService.GetPCDetailsAsync(id);
            int helper = id;
            // return View("Details", gpu);
            return RedirectToAction("Details", "PCBuild", new { id = helper });
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {

            if (this.User.GetId()==null)
            {
                return RedirectToAction("Index", "Home");
            }
            var check = await _pcBuildService.CheckifPCExistsByIdAsync(id);

            if (!check)
            {
                return RedirectToAction("Index", "Home");
            }

            PCBuildDetailsViewModel? gpu = await _pcBuildService.GetPCDetailsAsync(id);


            return View(gpu);
        }



        public async Task<IActionResult> OwnedPCDetails(int id)
        {
           

            PCBuildDetailsViewModel? gpu = await _pcBuildService.GetPCDetailsAsync(id);


            return View(gpu);
        }



        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<PCBuildDetailsViewModel> pcs = await this._pcBuildService.AllBuildsAsync();

            return View(pcs);
        }


        [HttpGet]

        public async Task<IActionResult> Owned()
        {
            IEnumerable<PCBuildDetailsViewModel> pcs = await this._pcBuildService.AllOwnedBuildsAsync(this.User.GetId()!);

            return View(pcs);
        }

        [HttpGet]

        public async Task<IActionResult> Create()
        {
            bool isBuilder = await this._builderService.BuilderAlreadyExcistsByUserId(this.User.GetId()!);

            if (!this.User.IsAdmin())
            {
                if (!isBuilder)
                {
                    this.TempData["ErrorMessage"] = "You must be a builder to add PC components.";
                    return this.RedirectToAction("Become", "Builder");
                }
            }
            PCBuildCreateFormViewModel model = new PCBuildCreateFormViewModel()
            {

                CpuCategories = await this._cpusService.GetAllCPUCategoriesAsync(),
                GPUCategories = await this._gpusService.GetAllAsync(),
                MotherboardCategories = await this._motherBoardService.GetAllAsync(),
                CaseCategories = await this._computerCaseService.GetAllAsync()

            };

            return View(model);

        }


        [HttpPost]
        public async Task<IActionResult> Create(PCBuildCreateFormViewModel model)
        {
            bool isBuilder = await this._builderService.BuilderAlreadyExcistsByUserId(this.User.GetId()!);
            if (!this.User.IsAdmin())
            {
                if (!isBuilder)
                {
                    this.TempData["ErrorMessage"] = "You must be a builder to add PC components.";
                    return this.RedirectToAction("Become", "Builder");
                }
            }

            CPUDetailsViewModel? cpuExists = await this._cpusService.GetCPUByIdAsync(model.CPUId);
            GPUFormViewModel? gpuExists = await this._gpusService.GetGPUByIdAsync(model.GPUId);
            ComputerCaseFormViewModel? caseExists = await this._computerCaseService.GetCaseByIdAsync(model.ComputerCaseId);
            MBDetailsViewModel? mbExists = await this._motherBoardService.GetMBByIdAsync(model.MotherboardId);

            if (cpuExists == null)
            {
                ModelState.AddModelError(nameof(model.Name), "CATEGORY DOES NOT EXIST!");
                TempData["ErrorMessage"] = "Please check the selected options!";
            }

            if (caseExists == null)
            {
                ModelState.AddModelError(nameof(model.Name), "CATEGORY DOES NOT EXIST!");
                TempData["ErrorMessage"] = "Please check the selected options!";
            }
            if (mbExists == null)
            {
                ModelState.AddModelError(nameof(model.Name), "CATEGORY DOES NOT EXIST!");
                TempData["ErrorMessage"] = "Please check the selected options!";
            }
            if (cpuExists != null && mbExists != null)
            {

                if (cpuExists.VendorName != mbExists.VendorName)
                {
                    ModelState.AddModelError(nameof(model.CpuCategories), "CPU and Motherboard types missmatch!");
                    TempData["ErrorMessage"] = "CPU and Motherboard types missmatch!";

                }
                if (cpuExists.SocketName != mbExists.SocketName)
                {
                    ModelState.AddModelError(nameof(model.CpuCategories), "CPU and Motherboard types missmatch!");
                    TempData["ErrorMessage"] = "CPU and Motherboard types missmatch!";

                }
            }
            if (cpuExists != null)
            {
                model.CPUPower = cpuExists.MaxWattage;
            }
            if (gpuExists != null)
            {
                model.GpuPower = gpuExists.MaxWattage;
            }

            if (!ModelState.IsValid)
            {
                model.CaseCategories = await this._computerCaseService.GetAllAsync();
                model.CpuCategories = await this._cpusService.GetAllCPUCategoriesAsync();
                model.GPUCategories = await this._gpusService.GetAllAsync();
                model.MotherboardCategories = await this._motherBoardService.GetAllAsync();

                return View(model);
            }

            try
            {
                string? builderId = await this._builderService.BuilderIdByUserId(this.User.GetId()!);

                if (builderId != null)
                {
                    await this._pcBuildService.CreateAsync(model, builderId, this.User.GetId()!);
                }
            }
            catch (Exception e)
            {

                var messageText = "Error while saving!";
                if (e.InnerException != null)
                {
                    messageText = e.InnerException.Message;
                }

                this.TempData["ErrorMessage"] = messageText;
            }

            this.TempData["SuccessMessage"] = "Successfully added New PC!";
            return RedirectToAction("Index", "Home");
        }

    }
}
