using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nop.Web.ViewModels.AluminiumVouwwand;

namespace Nop.Web.Pages.AluminiumVouwwand
{
    public class AluminiumVouwwandBestellenBase : ComponentBase
    {
        public AluminiumVouwwandViewModel Ctx { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            Ctx = new AluminiumVouwwandViewModel();
            Ctx.ChangeConfiguration();
        }

        protected async Task HandleValidSubmit()
        {
        }

        protected void HandleInvalidSubmit()
        {
        }

    }
}
