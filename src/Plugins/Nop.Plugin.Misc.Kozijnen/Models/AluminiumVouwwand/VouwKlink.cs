using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand
{
    public enum VouwKlink
    {
        [Display(Name = "Met cilinder")]
        MetCilinder = 0,

        [Display(Name = "Zonder cilinder")]
        ZonderCilinder = 1
    }
}