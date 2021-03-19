using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand
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