using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UboneBot.Model;

namespace UboneBot.Controllers
{

    public class BlobController : ApiController
    {
        public IEnumerable<BlockBlob> GetAllBlobs()
        {
            Utils.Upload2ASS up = new Utils.Upload2ASS();
            return up.ListBlobs();
        }
    }
}
