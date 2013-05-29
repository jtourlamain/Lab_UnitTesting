using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSSLib
{
    public class RssControllerException: ApplicationException
    {
        public RssControllerException(string message) : base(message) { }
        public RssControllerException(string message, Exception innerException) : base(message, innerException) { }

    }//end class
}//end namespace
