using System.Collections.Generic;
using KenBonny.ClaimsExperiment.Models.PropertyViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KenBonny.ClaimsExperiment.Controllers
{
    [Authorize(Roles = "TestPolicy")]
    public class PropertyController : Controller
    {
        private List<Property> _properties;

        public PropertyController()
        {
            _properties = new List<Property>
            {
                new Property(1, "Beautifull house in the country"),
                new Property(2, "An appartment in the city"),
                new Property(3, "A cottage in a rural area"),
                new Property(4, "An ostentaneous castle"),
                new Property(5, "A rundown building in the middle of nowhere")
            };
        }

        // GET
        public IActionResult Index()
        {
            var availableProperty = new AvailableProperty
            {
                CanBuy = _properties,
                CanSell = _properties
            };
            return View(availableProperty);
        }
    }
}