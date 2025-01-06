using Microsoft.AspNetCore.Mvc;

namespace BarsukTix.Web.Utils
{
    public static class UserExtensions
    {
        public static string GetUserId(this Controller controller)
        {
            //return "09e1584a-2cce-4b87-9db2-5b82ff3a249a";

            var userId = controller.User?.Claims?.FirstOrDefault(x => x.Type == System.IdentityModel.Claims.ClaimTypes.NameIdentifier)?.Value ?? "";
            return userId;
        }

        public static string GetUserEmail(this Controller controller)
        {
            var email = controller.User.Identity?.Name ?? "";
            return email;
        }
    }
}
