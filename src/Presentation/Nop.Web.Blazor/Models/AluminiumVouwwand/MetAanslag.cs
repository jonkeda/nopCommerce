using System.ComponentModel.DataAnnotations;

namespace Nop.Web.Models.AluminiumVouwwand
{
    public enum MetAanslag
    {
        [Display(Name = "Zonder aanslag")]
        ZonderAanslag,
        [Display(Name = "Met aanslag")]
        MetAanslag
    }
}