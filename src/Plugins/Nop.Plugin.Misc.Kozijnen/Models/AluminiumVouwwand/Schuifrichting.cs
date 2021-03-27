using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand
{
    public enum Schuifrichting
    {
        [Display(Name = "Naar rechts")]
        NaarRechts = 0,

        [Display(Name = "Naar links")]
        NaarLinks = 1
    }
}