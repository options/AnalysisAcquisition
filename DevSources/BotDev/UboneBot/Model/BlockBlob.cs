using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UboneBot.Model
{
    public class BlockBlob
    {
        public string Name { get; set; }
        public long ContentLength { get; set; }
        public string Uri { get; set; }
    }
}