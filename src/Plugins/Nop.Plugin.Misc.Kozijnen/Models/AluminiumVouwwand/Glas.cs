using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand
{
    public enum Glas
    {
        [Display(Name = "Zonder glas")]
        ZonderGlas = 0,

        [Display(Name = "HR++ Dubbel glas")]
        HrPpDubbelGlas = 1,

        [Display(Name = "HR+++ Triple glas")]
        HrPppTripleGlas = 2
    }
}