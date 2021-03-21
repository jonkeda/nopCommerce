using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Web.Framework.Components;

namespace Nop.Web.Areas.Admin.Components
{
    /// <summary>
    /// Represents view component to embed tracking script on pages
    /// </summary>
    [ViewComponent(Name = "ProductConfigurationScript")]
    public class ProductConfigurationScriptViewComponent : NopViewComponent
    {
        #region Methods

        /// <summary>
        /// Invoke view component
        /// </summary>
        /// <param name="modelType">Additional data</param>
        /// <param name="initial">initial start</param>
        /// <returns>View component result</returns>
        public async Task<IViewComponentResult> InvokeAsync(Type modelType, bool initial)
        {
            var script = new StringBuilder();
            script.Append("productConfigurator.init(");
            if (modelType == null)
            {
                script.Append("0,");
            }
            else
            {
                script.Append("1,");
            }
            script.Append("[");
            if(modelType != null)
            {
                foreach (var info in modelType
                    .GetProperties()
                    .Where(p => p.PropertyType.IsAssignableTo(typeof(IProductConfiguratorField))))
                {
                    script.Append("'");
                    script.Append(info.Name);
                    script.Append("',");
                }
            }
            script.Append("],'");
            script.Append(Url.Action("Calculate", "ProductConfigurator", new { Area = "admin" }));
            script.Append("',");
            script.Append(initial ? "1" : "0");
            script.AppendLine(");");
            return new RawViewComponentResult(script.ToString());
        }

        #endregion
    }
}