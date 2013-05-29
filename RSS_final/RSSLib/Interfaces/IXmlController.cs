using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSSLib.Model;

namespace RSSLib.Interfaces
{
    public interface IXmlController
    {
        List<RssItem> GetRssItemsFromFeed(string strFeedLocation);
        string GetTitleFromRssFeed(string strFeedLocation);
    }//end interface
}//end namespace
