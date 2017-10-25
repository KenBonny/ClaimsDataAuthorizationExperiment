using System.Collections.Generic;
using System.Linq;
using KenBonny.ClaimsExperiment.Models;
using KenBonny.ClaimsExperiment.Models.PropertyViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KenBonny.ClaimsExperiment.Controllers
{
    [Authorize("Property")]
    public class PropertyController : Controller
    {
        private List<Property> _properties;
        private readonly UserManager<ApplicationUser> _userManager;

        public PropertyController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
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
                CanBuy = _properties.Where(User.CanBuyProperty),
                CanSell = _properties.Where(User.CanSellProperty)
            };
            return View(availableProperty);
        }
    }
}