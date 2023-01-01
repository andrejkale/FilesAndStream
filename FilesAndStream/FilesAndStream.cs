using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FilesAndStream
{
    class FilesAndStream
    {   // 1. Створіть статичний метод копіювання файлу з двома параметрами: ім'я оригінального файлу та ім'я файлу-копії.
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

        //2. Скопіюйте вміст одного символьного потоку в інший потік, одночасно роблячи заміну символів. Правила заміни вказати самостійно.
        public static void copySymbolStreamToOtherStream(string fileForReading, string fileForWriting) 
        {
            StreamReader fileIn;
            StreamWriter fileOut;
            try
            {
                fileIn = new StreamReader(new FileStream(fileForReading, FileMode.Open, FileAccess.Read));
                fileOut = new StreamWriter(new FileStream(fileForWriting, FileMode.Create, FileAccess.Write));
                string textIn = fileIn.ReadToEnd();
                string textOut = Regex.Replace(textIn, "\\s+", "-");
                fileOut.WriteLine(textOut);
                fileIn.Close();
                fileOut.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}
