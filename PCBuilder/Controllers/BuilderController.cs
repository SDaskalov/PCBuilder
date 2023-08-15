namespace PCBuilder.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.Infrastructure.Extensions;
    using System.Security.Claims;

    [Authorize]
    public class BuilderController : Controller
    {
        private readonly IBuilderService builderService;

        public BuilderController(IBuilderService builderService)
        {
            this.builderService = builderService;
        }   

        [HttpGet]
        public async Task<IActionResult> Become()
        {

            string? userId = this.User.GetId();

            bool isAlreadyBuilder= await this.builderService.BuilderAlreadyExcistsByUserId(userId);
            if (isAlreadyBuilder)
            {
               // TempData[ErrorMessage] = "You are already an agent!";

                return RedirectToAction("Index", "Home");
            }

            return View();


        }
    }
}
