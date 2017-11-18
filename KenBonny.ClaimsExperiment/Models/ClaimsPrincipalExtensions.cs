using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using KenBonny.ClaimsExperiment.Models.PropertyViewModels;

namespace KenBonny.ClaimsExperiment.Models
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool CanBuyProperty(this ClaimsPrincipal user, Property property)
        {
            return user.HasClaim("buyer", property.Id.ToString());
        }

        public static bool CanSellProperty(this ClaimsPrincipal user, Property property)
        {
            return user.HasClaim("seller", property.Id.ToString());
        }

        public static IReadOnlyCollection<int> BuyableProperties(this ClaimsPrincipal user)
        {
            return user.Claims.Where(x => x.Type == "buyer").Select(x => x.Value).Select(int.Parse).ToList();
        }

        public static IReadOnlyCollection<int> SellableProperties(this ClaimsPrincipal user)
        {
            return user.Claims.Where(x => x.Type == "seller").Select(x => x.Value).Select(int.Parse).ToList();
        }
    }
}