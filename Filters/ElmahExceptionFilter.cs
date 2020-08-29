using Elmah;
using System.Web.Mvc;

namespace PersonelMVCUI.Filters
{
    public class ElmahExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                ErrorSignal.FromCurrentContext().Raise(filterContext.Exception);
            }
        }
    }
}
