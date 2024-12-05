using System.Web;
using System.Web.Mvc;

namespace LTUDDN_NguyenMinhDuc_21103100549_RestaurentOrder
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
