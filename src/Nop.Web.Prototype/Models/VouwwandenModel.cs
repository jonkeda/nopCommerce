using System;

namespace Nop.Web.Prototype.Models
{
    public class VouwwandenModel : PublicConfiguratorModel
    {
        public PublicConfiguratorField<int> Length { get; set; }

        public PublicConfiguratorField<int> Width { get; set; }

        public PublicConfiguratorField<string> Name { get; set; }

        public PublicConfiguratorField<DateTime> Date { get; set; }

        public PublicConfiguratorField<Deuren> Deuren { get; set; }
    }
}
