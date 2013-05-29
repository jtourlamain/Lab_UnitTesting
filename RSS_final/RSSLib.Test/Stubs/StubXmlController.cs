using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSSLib;
using RSSLib.Interfaces;

namespace RSSLib.Test.Stubs
{
    class StubXmlController : IXmlController
    {
        #region IXmlController Members

        public List<RSSLib.Model.RssItem> GetRssItemsFromFeed(string strFeedLocation)
        {
          throw new NotImplementedException();
        }

        public string GetTitleFromRssFeed(string strFeedLocation)
        {
            return "APO Rss";
        }

        #endregion
    }//end class
}//end namespace
