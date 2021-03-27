using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Nop.Plugin.Misc.Kozijnen.Models.AluminiumVouwwand;
using Nop.Services.Catalog;

namespace Nop.Plugin.Misc.Kozijnen.Services
{
    public static class EnumHelper
    {
        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="enumVal">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        /// <example><![CDATA[string desc = myEnumVariable.GetAttributeOfType<DescriptionAttribute>().Description;]]></example>
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        public static string ToText(this Enum enumVal)
        {
            var attribute = GetAttributeOfType<DisplayAttribute>(enumVal);
            if (attribute == null)
            {
                return enumVal.ToString();
            }

            return attribute.Name;
        }

        public static void AddLine(this StringBuilder sb, Enum enumVal)
        {
            sb.AppendLine(enumVal.ToText());
        }

        public static void AddLine(this StringBuilder sb, string field, Enum enumVal)
        {
            sb.AppendLine($"{field} {enumVal.ToText()}");
        }
    }

    public class AluminiumVouwwandProductConfigurator : ProductConfiguratorBase<AluminiumVouwwandModel>
    {
        public AluminiumVouwwandProductConfigurator() 
            : base("AluminiumVouwwand")
        { }

        protected override (AluminiumVouwwandModel, bool) Validate(AluminiumVouwwandModel model)
        {
            var isValid = true;

            return (model, isValid);
        }

        protected override string CreateDescription(AluminiumVouwwandModel model)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{(int)model.AantalDelen.Value.GetValueOrDefault(AantalDelen.Delen3)} delige aluminium vouwwand");
            
            if (model.Deuren.Value != Deuren.Zonder)
            {
                sb.AddLine(model.Deuren.Value);
                sb.AddLine("Locatie loopdeuren: ", model.LocatieLoopdeuren.Value);
            }

            sb.AddLine("Schuifrichting: ", model.Schuifrichting.Value);
            sb.AddLine("Vouwrichting: ", model.Vouwrichting.Value);

            sb.AppendLine($"Breedte kozijn: {model.BreedteKozijn.Value}mm");
            sb.AppendLine($"Hoogte kozijn: {model.HoogteKozijn.Value}mm");

            sb.AddLine("Type profiel: ", model.TypeProfiel.Value);
            sb.AddLine("Met aanslag: ", model.MetAanslag.Value);

            sb.AddLine("Glas: ", model.Glas.Value);

            sb.AddLine("Roeden: ", model.Roeden.Value);

            sb.AddLine("Structuur: ", model.Structuur.Value);

            if (model.KleurBinnenkant == model.KleurBuitenkant)
            {
                sb.AppendLine($"Kleur: {model.KleurBinnenkant.Value}");
            }
            else
            {
                sb.AppendLine($"Kleur binnenkant: {model.KleurBinnenkant.Value}");
                sb.AppendLine($"Kleur buitenkant: {model.KleurBuitenkant.Value}");
            }
            sb.AddLine("Kleur afstandshouder: ", model.KleurAfstandHouders.Value);
            sb.AddLine("Vouwklink: ", model.VouwKlink.Value);

            return sb.ToString();
        }

        protected override AluminiumVouwwandModel CreateDefaultModel()
        {
            var defaultModel = new AluminiumVouwwandModel
            {
                AantalDelen = { Value = AantalDelen.Delen3 },
                HoogteKozijn = { Value = 2000 },
                BreedteKozijn = { Value = 1700 }
            };
            return defaultModel;
        }

        protected override (AluminiumVouwwandModel model, decimal price)  CalculatePrice(AluminiumVouwwandModel model)
        {
            decimal price = (model.BreedteKozijn.Value * model.HoogteKozijn.Value) / 10000;
            return (model, price);
        }
    }

}
