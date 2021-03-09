using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nop.Web.ViewModels.AluminiumVouwwand;

namespace Nop.Web.Pages.AluminiumVouwwand
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
