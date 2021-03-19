using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand
{
    public enum MetAanslag
    {
        [Display(Name = "Zonder aanslag")]
        ZonderAanslag,
        [Display(Name = "Met aanslag")]
        MetAanslag
    }
}