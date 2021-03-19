using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Misc.Kozijnen.Components
{
    [ViewComponent(Name = "AluminiumVouwwand")]
    public class AluminiumVouwwandViewComponent : NopViewComponent
    {

        public IViewComponentResult Invoke(object model)
        {
            //return View("AluminiumVouwwand");
            return View("~/Plugins/Nop.Plugin.Misc.Kozijnen/Views/AluminiumVouwwand.cshtml", model);
        }
    }
}
