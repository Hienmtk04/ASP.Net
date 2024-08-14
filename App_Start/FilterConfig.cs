using System.Web;
using System.Web.Mvc;

namespace MaiThiKimHien_2122110261
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
