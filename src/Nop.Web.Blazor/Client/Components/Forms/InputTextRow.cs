using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace Nop.Web.Blazor.Client.Components.Forms
{
    public class InputTextRow : InputText
    {
        [Parameter]
        public string Label { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            this.BuilderRenderBefore(builder, Label);
            base.BuildRenderTree(builder);
            this.BuilderRenderAfter(builder);
        }
    }
}