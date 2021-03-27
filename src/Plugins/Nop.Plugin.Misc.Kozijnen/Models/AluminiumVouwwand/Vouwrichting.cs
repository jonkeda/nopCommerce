using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand
{
    public enum Vouwrichting
    {

        [Display(Name = "Naar buiten")]
        NaarBuiten = 0,

        [Display(Name = "Naar binnen")]
        NaarBinnen = 1
    }
}