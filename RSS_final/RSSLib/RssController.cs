using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using RSSLib.Model;
using RSSLib.Interfaces;

namespace RSSLib
{
    /// <summary>
    /// Class contains all functionality to process RSS feeds
    /// </summary>
    public class RssController
    {
        private List<string> _lstCacheRssItems;
        private IFileController _fileController;
        private IXmlController _xmlController;

        #region CONSTRUCTORS
        /// <summary>
        /// Default constructor reads values from configuration file and initialise file- and xmlController
        /// </summary>
        public RssController(): this("","")
        {
        }//end default constructor

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="pathSiteList">Path to the SiteList file</param>
        /// <param name="pathGuidCache">Path to the GuidCache file</param>
        public RssController(string pathSiteList, string pathGuidCache)
        {
          _fileController = new FileController();
          _xmlController = new XmlController();
           
          this.PathSiteList = pathSiteList;
          this.PathGuidCache = pathGuidCache;
        }
        #endregion

        #region GETTERS AND SETTERS
        /// <summary>
        /// The path to the file which contains the list with all the locations to the RssFeeds
        /// </summary>
        public string PathSiteList { get;  set; }
        /// <summary>
        /// The path to the file which contains the list of all RssItems that have been read.
        /// </summary>
        public string PathGuidCache { get;  set; }
        #endregion

        #region DEBUG GETTERS AND SETTERS
        #if DEBUG
        public IFileController FileController
        {
            get { return _fileController; }
            set { _fileController = value; }
        }

        public IXmlController XmlController
        {
            get { return _xmlController; }
            set { _xmlController = value; }
        }
        #endif
        #endregion
        /// <summary>
        /// Loads the url's from the SiteList
        /// </summary>
        /// <exception cref="RSSLib.RSSControllerException">Throws an exception when SiteList is not found.</exception>
        public List<RssFeed> LoadRssFeeds()
        {
            List<RssFeed> lstResult = new List<RssFeed>();
            List<string> lstFeedLocations = new List<string>();
            try
            {
                lstFeedLocations = _fileController.LoadRowsFromFile(this.PathSiteList);
            }
            catch (FileNotFoundException ex)
            {
                throw new RssControllerException("SiteList was not found on the specified location: " + ex.FileName);
            }
            foreach (string strFeedLocation in lstFeedLocations)
            {
                lstResult.Add(new RssFeed(_xmlController.GetTitleFromRssFeed(strFeedLocation), strFeedLocation));
            }
            return lstResult;
        }//end LoadRssFeeds
       
        /// <summary>
        /// Loads the RssItems from a particular RssFeed
        /// </summary>
        /// <param name="rssFeed">The RssFeed for which you want the RssItems</param>
        /// <returns>A list of RssItems</returns>
        public List<RssItem> GetRssItemsFromFeed(RssFeed rssFeed)
        {
            List<RssItem> lstResult = new List<RssItem>();
            if (_lstCacheRssItems == null || _lstCacheRssItems.Count == 0)
                LoadGuidCache();
            foreach (RssItem rssItem in _xmlController.GetRssItemsFromFeed(rssFeed.Location))
            {
                if (!_lstCacheRssItems.Contains(rssItem.Guid))
                    lstResult.Add(rssItem);
            }
            return lstResult;
        }

        /// <summary>
        /// Mark a RssItem as read.
        /// </summary>
        /// <param name="rssItem">The RssItem</param>
        public void MarkRssItemAsRead(RssItem rssItem)
        {
            _lstCacheRssItems.Add(rssItem.Guid);
            _fileController.AppendTextToFile(PathGuidCache, rssItem.Guid);
        }

        public bool IsRssItemRead(string rssGuid)
        {
            bool blResult = false;
            if (_lstCacheRssItems.Contains(rssGuid))
                blResult = true;
            return blResult;
        }

        /// <summary>
        /// Delete the list with the RSSItems marked as read
        /// </summary>
        public void ResetReadRssItems()
        {
            _lstCacheRssItems.Clear();
            _fileController.DeleteFile(PathGuidCache);
        }

        private void LoadGuidCache()
        {
            _lstCacheRssItems = _fileController.LoadRowsFromFile(this.PathGuidCache);
        }

    }//end class
}//end namespace
