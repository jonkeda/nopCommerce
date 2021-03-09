using System.ComponentModel.DataAnnotations;

namespace Nop.Web.Models.AluminiumVouwwand
{
    public enum Deuren
    {
        [Display(Name = "Zonder deur")]
        Zonder,
        [Display(Name = "Enkele deur")]
        Enkel,
        [Display(Name = "Dubbel")]
        Dubbel
    }
}