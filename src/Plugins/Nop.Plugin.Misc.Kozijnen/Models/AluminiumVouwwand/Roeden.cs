using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand
{
    public enum Roeden
    {
        [Display(Name = "Geen")]
        Geen,
        [Display(Name = "Glas roede 4 vlaks")]
        GlasRoede4Vaks,
        [Display(Name = "Glas roede 6 vlaks")]
        GlasRoede6Vaks,
    }
}