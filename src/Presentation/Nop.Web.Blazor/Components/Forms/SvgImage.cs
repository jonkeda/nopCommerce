using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Nop.Web.Components.Forms
{
    public class SvgImage : ComponentBase
    {
        [Parameter]
        public string Svg { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.AddMarkupContent(0, Svg);
        }
    }
}
