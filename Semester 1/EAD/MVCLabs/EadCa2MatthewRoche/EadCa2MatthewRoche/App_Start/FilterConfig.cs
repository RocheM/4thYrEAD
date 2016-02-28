using System.Web;
using System.Web.Mvc;

namespace EadCa2MatthewRoche
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
