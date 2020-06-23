using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
namespace ECIT.GIS.WebService
{
    public class FileStreamContent : IHttpActionResult
    {
        private readonly Stream mStream;
        private readonly string mMediaType;
        public FileStreamContent(Stream stream,string mediatype)
        {
            mStream = stream;
            mMediaType = mediatype;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
           return Task.FromResult<HttpResponseMessage>(Execute());
        }
        private HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            response.Content = new StreamContent(mStream);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(mMediaType);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            return response;
        }
    }
}