using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand
{
    public enum Structuur
    {
        [Display(Name = "Glas lak")]
        GladdeLak,
        [Display(Name = "Structuur lak")]
        StructuurLak,
    }
}