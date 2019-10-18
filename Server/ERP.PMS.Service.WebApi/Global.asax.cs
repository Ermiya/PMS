using ERP.PMS.Facade.Mappers;
using System.Web.Http;

namespace ERP.PMS.Service.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
