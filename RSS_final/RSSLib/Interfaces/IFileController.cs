using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSSLib.Interfaces
{
    public interface IFileController
    {
        List<string> LoadRowsFromFile(string strFilePath);
        void AppendTextToFile(string strFilePath, string strText);
        void DeleteFile(string strFilePath);
    }//end interface
}//end namespace
