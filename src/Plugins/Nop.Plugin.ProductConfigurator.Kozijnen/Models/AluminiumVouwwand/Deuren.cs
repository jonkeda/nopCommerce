using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.ProductConfigurator.Kozijnen.Models.AluminiumVouwwand
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