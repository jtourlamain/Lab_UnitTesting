using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSSLib;
using RSSLib.Interfaces;
using System.IO;

namespace RSSLib.Test.Stubs
{
    class StubFileController : IFileController 
    {
        private bool _blSimulateFileNotFoundException = false;

        public bool SimulateFileNotFoundException
        {
            get { return _blSimulateFileNotFoundException; }
            set { _blSimulateFileNotFoundException = value; }
        }

        #region IFileController Members

        public List<string> LoadRowsFromFile(string strFilePath)
        {
            List<string> lstResult = new List<string>();
            lstResult.Add("http://newsrss.bbc.co.uk/rss/newsonline_world_edition/front_page/rss.xml");
            if (_blSimulateFileNotFoundException)
                throw new FileNotFoundException("Testfile not found");
            return lstResult;
        }

        public void AppendTextToFile(string strFilePath, string strText)
        {
            throw new NotImplementedException();
        }

        public void DeleteFile(string strFilePath)
        {
            throw new NotImplementedException();
        }

        #endregion
    }//end class
}//end namespace
