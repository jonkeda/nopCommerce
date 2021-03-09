using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Nop.Web.Components.Forms
{
    public static class InputFormRowExtension
    {
        public static void BuilderRenderBefore(this ComponentBase component, RenderTreeBuilder builder, string label)
        {
            builder.OpenElement(1, "div");
            builder.AddAttribute(2,"class", "form-group row");
            builder.OpenElement(1, "label");
            builder.AddAttribute(2, "class", "col-sm-5");
            if (!string.IsNullOrEmpty(label))
            {
                builder.AddContent(3, label);
            }
            // label
            builder.CloseElement();
        }

        public static void BuilderRenderAfter(this ComponentBase component, RenderTreeBuilder builder)
        {
            // div
            builder.CloseElement();
        }
    }
}
