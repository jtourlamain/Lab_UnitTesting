using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using RSSLib.Model;

namespace RSSLib
{
    /// <summary>
    /// This class is used to handle and load the XMLs for the RSSController.
    /// For testing purpose methods weren't made static
    /// </summary>
    class XmlController 
    {
        public List<RssItem> GetRssItemsFromFeed(string strFeedLocation)
        {
            List<RssItem> lstResult = new List<RssItem>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFeedLocation);
            XmlNodeList nodeLst = xmlDoc.SelectNodes("//item");
            foreach (XmlNode node in nodeLst)
            {
                RssItem rssItem = new RssItem();
                rssItem.Title = node.SelectSingleNode("title").InnerText;
                rssItem.Description = node.SelectSingleNode("description").InnerText;
                rssItem.Link = node.SelectSingleNode("link").InnerText;
                rssItem.Guid = node.SelectSingleNode("guid").InnerText;
                lstResult.Add(rssItem);
            }
            return lstResult;
        }//end GetItemsFromFeed

        public string GetTitleFromRssFeed(string strFeedLocation)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFeedLocation);
            return xmlDoc.SelectSingleNode("/rss/channel/title").InnerText;
        }
    }//end class
}//end namespace
