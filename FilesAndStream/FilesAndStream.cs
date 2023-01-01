using System;
using System.Collections.Generic;
using System.IO;
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
        public static void CopySymbolStreamToOtherStream(string fileForReading, string fileForWriting) 
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

        // 3. Виведіть на екран імена файлів, які знаходяться в заданому каталозі та всіх його підкаталогах.
        public static void ShowFileNameInDirectory(string path, string pattern) 
        {
            try
            {
                IEnumerable<string> allFiles = Directory.EnumerateFiles(path, pattern, SearchOption.AllDirectories);
                foreach (string fileName in allFiles)
                {
                    Console.WriteLine(fileName);
                }
            } 
            catch (IOException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        // 4. Написати програму, яка створить текстовий файл та запише в нього список файлів (шлях, ім'я, дата створення) із заданого каталогу.

        public static void CreateFileWithListOfFilesInDirectory(string fileName, string dirPath) 
        {
            try
            {
                StreamWriter fileWriter = new StreamWriter(new FileStream(fileName, FileMode.Create, FileAccess.Write));
                FileInfo fileInfo;
                StringBuilder fileNameWithDate = new StringBuilder();

                IEnumerable<string> allFiles = Directory.EnumerateFiles(dirPath, "*", SearchOption.TopDirectoryOnly);
                foreach (string file in allFiles)
                {
                    fileInfo = new FileInfo(file);
                    fileNameWithDate.Append(file).Append(" ").Append(fileInfo.CreationTime).Append("\n");
                }

                fileWriter.WriteLine(fileNameWithDate);
                fileWriter.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // 5. Дано текстовий файл. Вивести кількість символів і рядків, що містяться в ньому.

        public static void CountLinesAndSymbolsInTextFile(string path)
        {
            int linesCount = 0;
            int nextLine = '\n';
            int symbolCount = 0;

            StreamReader streamReaderLines = new StreamReader(new BufferedStream(File.OpenRead(path), 10 * 1024 * 1024));
            StreamReader streamReaderSymbols = new StreamReader(new BufferedStream(File.OpenRead(path), 10 * 1024 * 1024));

            while (!streamReaderLines.EndOfStream)
            {
                if (streamReaderLines.Read() == nextLine) 
                {
                    linesCount++;
                }
            }

            while (!streamReaderSymbols.EndOfStream)
            {
                symbolCount += streamReaderSymbols.ReadLine().Length;

            }

            streamReaderLines.Close();
            streamReaderSymbols.Close();

            Console.WriteLine("Lines in text file = " + linesCount);
            Console.WriteLine("Symbols in text file = " + symbolCount);

        }
    }


}
