using Microsoft.AspNetCore.Mvc;

namespace BarsukTix.Web.Utils
{
    public static class UserExtensions
    {
        public static string GetUserId(this Controller controller)
        {
            var userId = controller.User.Identity?.Name ?? "";
            return userId;
        }
    }
}
