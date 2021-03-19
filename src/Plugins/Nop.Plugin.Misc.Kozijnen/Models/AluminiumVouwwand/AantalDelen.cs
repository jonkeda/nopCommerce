using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand
{
    public enum AantalDelen
    {
        [Display( Name = "Delen 2")]
        Delen2 = 2,
        [Display(Name = "Delen 3")]
        Delen3 = 3,
        [Display(Name = "Delen 4")]
        Delen4 = 4,
        [Display(Name = "Delen 5")]
        Delen5 = 5,
        [Display(Name = "Delen 6")]
        Delen6 = 6
    }
}