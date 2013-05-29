using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using RSSLib;
using RSSLib.Interfaces;


namespace RSSLib.Test
{
    [TestFixture]
    public class RSSControllerTests
    {
        private RssController _rssController;

        [SetUp]
        public void Setup()
        {
            _rssController = new RssController();
        }

        [Test]
        [Category("Easy tests")]
        public void RssController_PathSiteList_Empty()
        {
            Assert.AreEqual("", _rssController.PathSiteList, "PathSiteList should be initialized by constructor");
        }

        [Test]
        [Category("Easy tests")]
        public void RssController_PathGuidCache_Empty()
        {
            Assert.AreEqual("", _rssController.PathGuidCache, "PathGuidCache should be initialized by constructor");
        }

        [Test]
        [Category("Stub tests")]
        public void LoadRssFeeds_CorrectInput_ReturnsRssFeed()
        {
            IFileController stubFileController = new Stubs.StubFileController();
            IXmlController stubXmlController = new Stubs.StubXmlController();

            _rssController.FileController = stubFileController;
            _rssController.XmlController = stubXmlController;

            Assert.AreEqual("APO Rss", _rssController.LoadRssFeeds()[0].Title, "Title of the first RssFeed does not match.");
        }

        [Test]
        [Category("Stub tests")]
        [ExpectedException(typeof(RssControllerException))]
        public void LoadRssFeeds_WrongInputFile_ThrowsException()
        {
            Stubs.StubFileController stubFileController = new Stubs.StubFileController();
            stubFileController.SimulateFileNotFoundException = true;
            List<RSSLib.Model.RssFeed> lstResult = _rssController.LoadRssFeeds();
        }

        [Test]
        [Category("Mock tests")]
        public void LoadRssFeeds_CorrectInputWithMock_ReturnsRssFeed()
        {
          MockRepository mocks = new MockRepository();
          IXmlController iXmlController = mocks.DynamicMock<IXmlController>();
          IFileController iFileController = mocks.Stub<IFileController>();
          
          List<string> lstFeed = new List<string>();
          lstFeed.Add("FakeRssLocation");

          using (mocks.Record())
          {
            Expect.Call(iFileController.LoadRowsFromFile(_rssController.PathSiteList)).Return(lstFeed);
            //you can write the statement above in two statements if you want:
            //Expect.Call(iFileController.LoadRowsFromFile(_rssController.PathSiteList));
            //LastCall.Return(lstFeed);
            Expect.Call(iXmlController.GetTitleFromRssFeed(lstFeed[0])).Return("APO RSS");
          }//end mocks.Record
          _rssController.FileController = iFileController;
          _rssController.XmlController = iXmlController;
          List<RSSLib.Model.RssFeed> lstResult = _rssController.LoadRssFeeds();
          mocks.VerifyAll();
        }

      
        [Test]
        [Category("Mock tests")]
        public void GetRssItemsFromFeed_GuidCacheIsOnlyLoadedFirstTime_True()
        {
          MockRepository mocks = new MockRepository();
          IFileController iFileController = mocks.StrictMock<IFileController>();
          IXmlController iXmlController = mocks.Stub<IXmlController>();
          List<string> lstGuidItems = new List<string>();
          lstGuidItems.Add("GuidItem1");
          lstGuidItems.Add("GuidItem2");

          List<RSSLib.Model.RssItem> lstRssItems = new List<RSSLib.Model.RssItem>();
          lstRssItems.Add(new RSSLib.Model.RssItem { Title = "Item1", Guid = "GuidItem1", Link = "LinkItem1" });
          lstRssItems.Add(new RSSLib.Model.RssItem { Title = "Item2", Guid = "GuidItem2", Link = "LinkItem2" });

          using (mocks.Record())
          {
            //The first time we call the GetRssItemsFromFeed the following thow methods will be called form our mock
            Expect.Call(iFileController.LoadRowsFromFile(_rssController.PathGuidCache)).Return(lstGuidItems);
            Expect.Call(iXmlController.GetRssItemsFromFeed("FakeRssLocation")).Return(lstRssItems);
            //The second time we call the GetRssItemsFromFeed, only on method will be called (the cache doesn't need to be loaded from the files
            //system because it is cashed already.
            Expect.Call(iXmlController.GetRssItemsFromFeed("FakeRssLocation")).Return(lstRssItems);
          }
          _rssController.FileController = iFileController;
          _rssController.XmlController = iXmlController;
          _rssController.GetRssItemsFromFeed(new RSSLib.Model.RssFeed { Title = "APO Test", Location = "FakeRssLocation" });
          _rssController.GetRssItemsFromFeed(new RSSLib.Model.RssFeed { Title = "APO Test", Location = "FakeRssLocation" });
          mocks.VerifyAll();
        }
    }//end class RSSControllerTests
}//end namespace
