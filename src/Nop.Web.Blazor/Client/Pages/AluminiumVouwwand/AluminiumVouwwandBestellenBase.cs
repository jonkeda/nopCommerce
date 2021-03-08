using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nop.Web.Blazor.Client.ViewModels.AluminiumVouwwand;

namespace Nop.Web.Blazor.Client.Pages.AluminiumVouwwand
{
    public class AluminiumVouwwandBestellenBase : ComponentBase
    {
        public AluminiumVouwwandViewModel Ctx { get; set; } = new AluminiumVouwwandViewModel();


        protected override async Task OnInitializedAsync()
        {

        }

        protected async Task HandleValidSubmit()
        {
        }

        protected void HandleInvalidSubmit()
        {
        }

    }
}
