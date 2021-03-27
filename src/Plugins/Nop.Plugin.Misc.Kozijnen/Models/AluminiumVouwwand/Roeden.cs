using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand
{
    public enum Roeden
    {
        [Display(Name = "Geen")]
        Geen = 0,
        [Display(Name = "Glas roede 4 vlaks")]
        GlasRoede4Vaks = 1,
        [Display(Name = "Glas roede 6 vlaks")]
        GlasRoede6Vaks = 2
    }
}