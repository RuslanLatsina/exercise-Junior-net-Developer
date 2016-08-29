using System.Web;
using System.Web.Mvc;

namespace Тест_Junior_net_Developer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
