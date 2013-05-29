using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSSLib.Model
{
    public class RssFeed
    {
        #region CONSTRUCTORS
        public RssFeed()
        {
        }//end default constructor

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="title">Title of the feed</param>
        /// <param name="location">Location of the feed</param>
        public RssFeed(string title, string location)
        {
            this.Title = title;
            this.Location = location;
        }
        #endregion

        #region GETTERS AND SETTERS
        public string Title { get; set; }
        public string Location { get; set; }
        public List<RssItem> Items { get; set; }
        #endregion
    }//end class
}//end namespace
