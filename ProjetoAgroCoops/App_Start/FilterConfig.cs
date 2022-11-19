using System.Web;
using System.Web.Mvc;

namespace ProjetoAgroCoops
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
