using ECIT.GIS.Common;
using System.Web.Http;
using System.Web;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;
namespace ECIT.GIS.WebService.ApiControl
{
    [RoutePrefix("api/Filestream")]
    public class FilestreamController : ApiController
    {
        [Route("GetRandomCode"), HttpGet]
        public IHttpActionResult GetRandomCode()
        {
            ValidationCodeHelper helper = new ValidationCodeHelper();
            byte[] stream = helper.CreateImage(helper.CreateCode(2, 4));
            return new FileStreamContent(new MemoryStream(stream), "application/octet-stream");
        }
    }
}