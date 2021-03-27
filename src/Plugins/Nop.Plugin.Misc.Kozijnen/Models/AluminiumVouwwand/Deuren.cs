using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand
{
    public enum Deuren
    {
        [Display(Name = "Zonder deur")]
        Zonder = 0,
        [Display(Name = "Enkele deur")]
        Enkel = 1,
        [Display(Name = "Dubbel")]
        Dubbel = 2
    }
}