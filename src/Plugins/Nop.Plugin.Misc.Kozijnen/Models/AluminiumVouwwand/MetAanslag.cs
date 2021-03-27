using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand
{
    public enum MetAanslag
    {
        [Display(Name = "Zonder aanslag")]
        ZonderAanslag = 0,

        [Display(Name = "Met aanslag")]
        MetAanslag = 1
    }
}