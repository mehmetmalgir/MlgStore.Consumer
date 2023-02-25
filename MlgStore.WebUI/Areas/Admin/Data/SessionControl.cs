using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MlgStore.WebUI.Areas.Admin.Data
{
    public class SessionControl
    {
        private readonly HttpContext _context;
        private readonly ControllerBase _controller;

        
        public SessionControl(HttpContext context, ControllerBase controller)
        {
            _context = context;
            _controller = controller;
        }

        public RedirectResult ControlSession()
        {
            var jsonStr = _context.Session.GetString("LoggedAdminUser");                

            if (string.IsNullOrEmpty(jsonStr))
                return _controller.Redirect("Admin/Authentication/LogIn");
            else
                return null;
                
        }

    }
}
