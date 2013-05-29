using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSSLib.Model
{
    /// <summary>
    /// Class contains all subitems from a RSS Item
    /// </summary>
    public class RssItem
    {
        #region GETTERS AND SETTERS
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Guid { get; set; }
        #endregion

        public override string ToString()
        {
            return this.Title;
        }
    }//end class
}//end namespace
