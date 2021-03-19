using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Framework.Components;

namespace Nop.Web.Areas.Admin.Components
{
    /// <summary>
    /// Represents a view component that displays a message
    /// </summary>
    public class MessageViewComponent : NopViewComponent
    {
        #region Methods

        /// <summary>
        /// Invoke view component
        /// </summary>
        /// <returns>View component result</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(null);
        }

        #endregion
    }
}