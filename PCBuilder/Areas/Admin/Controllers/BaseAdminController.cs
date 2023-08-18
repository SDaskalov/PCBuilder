
namespace PCBuilder.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static PCBuilder.Common.GeneralConstants;

    [Area(AdminAreaName)]
    [Authorize(Roles =AdminRole)]
    public class BaseAdminController : Controller
    {

    }
}
