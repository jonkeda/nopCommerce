using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using Nop.Web.Models.Media;

namespace Nop.Web.Components
{
    ///  NEWMEDIA
    public class PictureViewComponent : NopViewComponent
    {
        public PictureViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(PictureModel model)
        {
            return View(model);
        }
    }
}