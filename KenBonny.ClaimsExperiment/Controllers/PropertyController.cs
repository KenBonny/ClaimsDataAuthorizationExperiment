using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
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
        private readonly ClaimsPrincipal _injectedUser;
        private List<Property> _properties;

        public PropertyController(ClaimsPrincipal user)
        {
            _injectedUser = user;
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
                // User property can check relevant claims
                CanBuy = _properties.Where(User.CanBuyProperty),
                // threads current principal can also check the relevant claims
                CanSell = _properties.Where(_injectedUser.CanSellProperty)
            };
            return View(availableProperty);
        }
    }
}