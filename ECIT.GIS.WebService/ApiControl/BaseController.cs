using System.Web.Http;

namespace ECIT.GIS.WebService.ApiControl
{
    [WebAuthorAttribute]
    [ActionFilter]
    public class BaseController : ApiController
    {
    }
}