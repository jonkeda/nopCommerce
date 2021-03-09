﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Nop.Web.Components.Forms
{

    public class InputTextRow : NopInputText
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