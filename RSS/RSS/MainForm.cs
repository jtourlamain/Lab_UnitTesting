using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using RSSLib;
using RSSLib.Model;


namespace RSS
{
    public partial class MainForm : Form
    {
        private RssController _rssController;
        //private Dictionary<string, RssFeed> _dicRssFeed;
        private List<RssFeed> _lstRssFeed;

        public MainForm()
        {
            InitializeComponent();
            this.lstFeeds.DrawItem += new DrawItemEventHandler(lstFeeds_DrawItem);
        }

        void lstFeeds_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Brush myBrush = Brushes.Black;
            if (_rssController.IsRssItemRead(((RssItem)(((ListBox)sender).Items[e.Index])).Guid))
                myBrush = Brushes.Red;
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _rssController = new RssController();
            _rssController.PathSiteList = ConfigurationManager.AppSettings["SiteList"].ToString();
            _rssController.PathGuidCache = ConfigurationManager.AppSettings["GuidCache"].ToString();
            _lstRssFeed = _rssController.LoadRssFeeds();
            ddlRssFeeds.DataSource = _lstRssFeed;
            ddlRssFeeds.ValueMember = "Location";
            ddlRssFeeds.DisplayMember = "Title";
        }

        private void lstFeeds_DoubleClick(object sender, EventArgs e)
        {
            webBrowser.Navigate(((RssItem)((((ListBox)sender).SelectedItem))).Link);
            _rssController.MarkRssItemAsRead((RssItem)(((ListBox)sender).SelectedItem));
            tabRss.SelectedIndex = 1;
        }

        private void btnLoadFeed_Click(object sender, EventArgs e)
        {
            lstFeeds.Items.Clear();
            RssFeed selectedFeed = (RssFeed)ddlRssFeeds.SelectedItem;
            selectedFeed.Items = _rssController.GetRssItemsFromFeed(selectedFeed);
            foreach (RssItem rssItem in selectedFeed.Items)
            {
                lstFeeds.Items.Add(rssItem);
            }
        }

    }//end class
}//end namespace
