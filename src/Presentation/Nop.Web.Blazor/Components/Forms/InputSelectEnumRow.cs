using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Nop.Web.Components.Forms
{
    public class InputSelectEnumRow<T> : NopInputSelectEnum<T> 
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