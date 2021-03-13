using System.ComponentModel.DataAnnotations;

namespace Nop.Web.Prototype.Models
{
    public enum Deuren
    {
        [Display(Name = "Zonder deur")]
        Zonder,
        [Display(Name = "Enkele deur")]
        Enkel,
        [Display(Name = "Dubbele deur")]
        Dubbel
    }
}