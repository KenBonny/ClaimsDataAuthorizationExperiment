using System.Collections.Generic;

namespace KenBonny.ClaimsExperiment.Models.PropertyViewModels
{
    public class AvailableProperty
    {
        public IEnumerable<Property> CanSell { get; set; }

        public IEnumerable<Property> CanBuy { get; set; }
    }
}