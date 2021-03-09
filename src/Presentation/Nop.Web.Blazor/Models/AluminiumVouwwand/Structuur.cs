using System.ComponentModel.DataAnnotations;

namespace Nop.Web.Models.AluminiumVouwwand
{
    public enum Structuur
    {
        [Display(Name = "Glas lak")]
        GladdeLak,
        [Display(Name = "Structuur lak")]
        StructuurLak,
    }
}