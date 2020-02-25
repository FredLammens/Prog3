using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;
using System.IO;
using System.Threading.Tasks;

namespace FILIO_Oef_Straat
{
    class BackEndClasses
    {
        public static void Dataverwerker(string path) 
        {
            Console.WriteLine("Folder unzipping.");
            Unzipper(path, "unziptData");
            Console.WriteLine("Folder unzipt.");
            //alle parsers
            Console.WriteLine("Analyzing files...");
            Dictionary<int, string> straatNamen = Parsers.StraatParser(path + @"\unziptData\WRstraatnamen.csv");
            Console.WriteLine("Streats analized.");
            Dictionary<int, int> stratenInGemeente = Parsers.StratenInGemeentenParser(path + @"\unziptData\StraatnaamID_gemeenteID.csv"); //voor lookups
            Dictionary<int, string> gemeenteNamen = Parsers.GemeenteEnProvincieParser(path + @"\unziptData\WRGemeentenaam.csv"); //gemeentenaam gemeenteNaamID mag weg wordt niet gebruikt , taalcode wordt in code zelf gebruikt mag ook weg .
            Console.WriteLine("Municipality name analized.");
            Dictionary<int, string> provincieNamen = Parsers.GemeenteEnProvincieParser(path + @"\unziptData\ProvincieInfo.csv");
            Console.WriteLine("Provincial name analized.");
            List<int> provincieID = Parsers.ProvincieParser(path + @"\unziptData\ProvincieIDsVlaanderen.csv"); // voor lookups
            Console.WriteLine("All files analized.");
        }
        public static void Unzipper(string zipPath, string filename)  //probeer eventueel zonder nieuwe map aan te maken 
        {
            ZipFile.ExtractToDirectory(zipPath, zipPath + @"\{filename}");
        }

        public static List<string[]> FileSplitter(string fileToReadPath, char teken) 
        {
            List<string[]> splittedLines = new List<string[]>();
            //---------------------------1e manier---------------------------
            //using (StreamReader file = new StreamReader(fileToReadPath))
            //{
            //    string ln;
            //    while ((ln = file.ReadLine()) != null)
            //    {
            //        splittedLines.Add(ln.Split(teken));
            //    }
            //    return splittedLines;
            //}
            //----------------------2e manier in dotNet ingebouwd (traagste)
            //splittedLines.Add(File.ReadAllLines(fileToReadPath));
            //return splittedLines;
            //----------------------3e snelste manier-----------------------------
            using (FileStream fs = File.Open(fileToReadPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    splittedLines.Add(s.Split(teken)); //.split gebruikt intern een readonlyspan<char>
                }
            }
            return splittedLines;
        }
        public static void Clean(string path)
        {
            //get all files
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles("*", SearchOption.TopDirectoryOnly);
            DirectoryInfo[] directories = dir.GetDirectories("*", SearchOption.TopDirectoryOnly);
            // get the file attributes for file or directory
            //detect whether its a directory or file
            Console.WriteLine(files.Length);
            if (directories.Length != 0)
            {
                foreach (DirectoryInfo file in directories)
                {
                    Clean(file.FullName);
                }
            }
            for (int i = 0; i < files.Length; i++)
            {
                files[i].Delete();
                Console.WriteLine("File verwijderd");

            }
            Console.WriteLine($"Alle files Verwijderd , {path}");

            Directory.Delete(path);
            Console.WriteLine("Alle directories verwijderd.");
        }
        public static void BestandenMaker(List<int> provincieIDs , Dictionary<int,string> provincienamen,Dictionary<> ,string path) 
        {
            foreach (string naam in namen)
            {
                if (!Directory.Exists(path + "\\" + naam))
                    Directory.CreateDirectory(path + "\\" + naam);
            }
        }
    }

}
