﻿using System.ComponentModel.DataAnnotations;

namespace Nop.Plugin.ProductConfigurator.Kozijnen.Models.AluminiumVouwwand
{
    public enum Glas
    {
        [Display(Name = "Zonder glas")]
        ZonderGlas,
        [Display(Name = "HR++ Dubbel glas")]
        HrPpDubbelGlas,
        [Display(Name = "HR+++ Triple glas")]
        HrPppTripleGlas,
    }
}