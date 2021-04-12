using System;
using System.Collections.Generic;
using Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand;
using Nop.Plugin.Misc.Kozijnen.Services;
using Nop.Services.Catalog;

namespace Nop.Plugin.Misc.Kozijnen.Imports.Vouwwanden.AluminiumVouwwanden
{
    public class AluminiumVouwwandenImportDefinition : IProductImportDefinition, IProductConfiguratorDefinition
    {
        public string ProductFileName { get; set; } = "Products.xml";

        public Type GetProductImportType()
        {
            return typeof(AluminiumVouwwandImports);
        }

        public IProductConfiguratorProvider GetConfigurator()
        {
            return new AluminiumVouwwandProductConfigurator();
        }

        public ProductImport GetProduct()
        {
            return new AluminiumVouwwandImport
            {
                Name = "Vouwwand",
                Published = true,
                AantalDelen = AantalDelen.Delen2,
                BreedteKozijn = 1700,
                CategoryName = null,
                DisplayOrder = 0,
                HoogteKozijn = 2000,
                KleurBinnenkant = "RAL9010",
                KleurBuitenkant = "RAL9010"
            };
        }

        public IEnumerable<PictureImport> GetPictures()
        {
            yield return new PictureImport($"{AantalDelen.Delen2}_{Verdeling2.LinksVouwend}",
                "2_delig_links_vouwend.PNG");
            yield return new PictureImport($"{AantalDelen.Delen2}_{Verdeling2.RechtsVouwend}",
                  "2_delig_rechts_vouwend.PNG");

            yield return new PictureImport($"{AantalDelen.Delen3}_{Verdeling3.LinksVouwendDeurMeevouwend}",
                "3_delig_links_vouwend_deur_meevouwend.PNG");
            yield return new PictureImport($"{AantalDelen.Delen3}_{Verdeling3.RechtsVouwendDeurMeevouwend}",
                "3_delig_rechts_vouwend_deur_meevouwend.PNG");
            yield return new PictureImport($"{AantalDelen.Delen3}_{Verdeling3.LinksVouwendDeurvast}",
                "3_delig_links_vouwend_deurvast.PNG");
            yield return new PictureImport($"{AantalDelen.Delen3}_{Verdeling3.RechtsVouwendDeurVast}",
                "3_delig_rechts_vouwend_deur_vast.PNG");

            yield return new PictureImport($"{AantalDelen.Delen4}_{Verdeling4.LinksVouwend}",
                "4_delig_links_vouwend.PNG");
            yield return new PictureImport($"{AantalDelen.Delen4}_{Verdeling4.RechtsVouwend}",
                "4_delig_rechts_vouwend.PNG");
            yield return new PictureImport($"{AantalDelen.Delen4}_{Verdeling4.LinksVouwendDubbeleDeurRechts}",
                "4_delig_links_vouwend_dubbele_deur_rechts.PNG");
            yield return new PictureImport($"{AantalDelen.Delen4}_{Verdeling4.RechtsVouwendDubbeleDeurLinks}",
                "4_delig_rechts_vouwend_dubbele_deur_links.PNG");
            yield return new PictureImport($"{AantalDelen.Delen4}_{Verdeling4.SymmetrischVouwend}",
                "4_delig_symmetrisch_vouwend.PNG");

            yield return new PictureImport($"{AantalDelen.Delen5}_{Verdeling5.LinksVouwendDeurMeevouwend}",
                "5_delig_links_vouwend_deur_meevouwend.PNG");
            yield return new PictureImport($"{AantalDelen.Delen5}_{Verdeling5.RechtsVouwendDeurMeevouwend}",
                "5_delig_rechts_vouwend_deur_meevouwend.PNG");
            yield return new PictureImport($"{AantalDelen.Delen5}_{Verdeling5.LinksVouwendDeurvast}",
                "5_delig_links_vouwend_deurvast.PNG");
            yield return new PictureImport($"{AantalDelen.Delen5}_{Verdeling5.RechtsVouwendDeurVast}",
                "5_delig_rechts_vouwend_deur_vast.PNG");
            yield return new PictureImport($"{AantalDelen.Delen5}_{Verdeling5.Symmetrisch2Rechts3Links}",
                "5_delig_symmetrisch_2_rechts_3_links.PNG");
            yield return new PictureImport($"{AantalDelen.Delen5}_{Verdeling5.Symmetrisch3Rechts2Links}",
                "5_delig_symmetrisch_3_rechts_2_links.PNG");

            yield return new PictureImport($"{AantalDelen.Delen6}_{Verdeling6.LinksVouwend}",
                "6_delig_links_vouwend.PNG");
            yield return new PictureImport($"{AantalDelen.Delen6}_{Verdeling6.RechtsVouwend}",
                "6_delig_rechts_vouwend.PNG");
            yield return new PictureImport($"{AantalDelen.Delen6}_{Verdeling6.LinksVouwendDubbeleDeurRechts}",
                "6_delig_links_vouwend_dubbele_deur_rechts.PNG");
            yield return new PictureImport($"{AantalDelen.Delen6}_{Verdeling6.RechtsVouwendDubbeleDeurLinks}",
                "6_delig_rechts_vouwend_dubbele_deur_links.PNG");
            yield return new PictureImport($"{AantalDelen.Delen6}_{Verdeling6.Symmetrisch2Rechts4Links}",
                "6_delig_symmetrisch_2_rechts_3_links.PNG");
            yield return new PictureImport($"{AantalDelen.Delen6}_{Verdeling6.Symmetrisch4Rechts2Links}",
                "6_delig_symmetrisch_3_rechts_2_links.PNG");
        }
    }
}
