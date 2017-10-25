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
    }
}