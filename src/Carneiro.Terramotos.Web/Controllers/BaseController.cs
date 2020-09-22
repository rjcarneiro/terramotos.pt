using Carneiro.Terramotos.Web.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Carneiro.Terramotos.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected string Theme => Request.Cookies[WebConstants.Theme] ?? ThemesConstants.Default;

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ViewData[WebConstants.Theme] = Theme;

            base.OnActionExecuted(context);
        }
    }
}