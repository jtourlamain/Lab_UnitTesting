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
    /// This class handles the IO to the fileserver to read and write to the siteList and guidCache files.
    /// The siteList file is needed to remember all the different RSS feeds.
    /// The guidCache is needed to remeber the RSS items that have been read.
    /// /// For testing purpose methods weren't made static
    /// </summary>
    class FileController : IFileController
    {
        public List<string> LoadRowsFromFile(string strFilePath)
        {
            List<string> lstResult = new List<string>();
            string strLine;
            if (File.Exists(strFilePath))
            {
                StreamReader streamReader = new StreamReader(strFilePath);
                while((strLine = streamReader.ReadLine()) != null)
                {
                    if((strLine.Trim() != ""))
                    lstResult.Add(strLine);
                }
                streamReader.Close();
            }
            else
            {
                throw new FileNotFoundException("File could not be found.", strFilePath);
            }
            return lstResult;
        }//end LoadRssFeedsFromFile

        public void AppendTextToFile(string strFilePath, string strText)
        {
            File.AppendAllText(strFilePath, strText + "\n");
        }//end WriteRssItemToCache

        public void DeleteFile(string strFilePath)
        {
            File.Delete(strFilePath);
        }
    }//end class
}//end namespace
