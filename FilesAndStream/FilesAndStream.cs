using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndStream
{
    class FilesAndStream
    {
        public static void CopyFile(string originalFile, string copyFile)
        { try
            {
                string pathOriginalFile = @Path.GetFullPath("E:\\ХНУРЄ\\C#\\OOP\\testFileStore\\" + originalFile);
                string pathToCopyFile = @Path.GetFullPath("E:\\ХНУРЄ\\C#\\OOP\\testFileStore\\" + copyFile);
                File.Copy(pathOriginalFile, pathToCopyFile, true);
            } catch (Exception ex) when (ex is UnauthorizedAccessException || 
                                         ex is ArgumentException ||
                                         ex is ArgumentNullException ||
                                         ex is PathTooLongException ||
                                         ex is DirectoryNotFoundException ||
                                         ex is FileNotFoundException ||
                                         ex is IOException) 
            {
             Console.WriteLine(ex.Message);
            }

        }

        public static void copySymbolStreamToOtherStream(string file) { }
    }
}
