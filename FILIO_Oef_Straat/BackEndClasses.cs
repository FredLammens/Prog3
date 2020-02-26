using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace FILIO_Oef_Straat
{
    class BackEndClasses
    {
        public static void Dataverwerker(string path)
        {
            Console.WriteLine("Folder unzipping.");
            Unzipper(path);
            Console.WriteLine("Folder unzipt.");
            //alle parsers
            Console.WriteLine("Analyzing files...");
            Dictionary<int, string> straatNamen = Parsers.StraatParser(path + @"\DirFileOefening\WRstraatnamen.csv");
            Console.WriteLine("Streats analized.");
            Dictionary<int, List<int>> stratenIDs = Parsers.StratenInGemeentenParser(path + @"\DirFileOefening\StraatnaamID_gemeenteID.csv"); //voor lookups
            Dictionary<int, string> gemeenteNamen = Parsers.GemeenteEnProvincieParser(path + @"\DirFileOefening\WRGemeentenaam.csv"); //gemeentenaam gemeenteNaamID mag weg wordt niet gebruikt , taalcode wordt in code zelf gebruikt mag ook weg .
            Console.WriteLine("Municipality name analized.");
            Dictionary<int, string> provincieNamen = Parsers.GemeenteEnProvincieParser(path + @"\DirFileOefening\ProvincieInfo.csv");
            Console.WriteLine("Provincial name analized.");
            List<int> provincieID = Parsers.ProvincieParser(path + @"\DirFileOefening\ProvincieIDsVlaanderen.csv"); // voor lookups
            Dictionary<int, List<int>> gemeenteIDs = Parsers.GemeentenInProvincieParser(path + @"\DirFileOefening\ProvincieInfo.csv"); //voor lookups
            Console.WriteLine("All files analized.");
            BestandenMaker(provincieID, gemeenteIDs, stratenIDs, provincieNamen, gemeenteNamen, straatNamen, path + @"\data");
        }
        public static void Unzipper(string zipPath)  //probeer eventueel zonder nieuwe map aan te maken 
        {
            ZipFile.ExtractToDirectory(zipPath + @"\DirFileOefening.zip", zipPath);
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
        public static void BestandenMaker(List<int> provincieIDs, Dictionary<int, List<int>> gemeenteIDs, Dictionary<int, List<int>> stratenIDs, Dictionary<int, string> provincieNamen, Dictionary<int, string> gemeenteNamen, Dictionary<int, string> straatNamen, string path)
        {
            Console.WriteLine("Start bestanden maken...");
            foreach (int provincieID in provincieIDs)//provincieIDs afgaan
            {
                provincieNamen.TryGetValue(provincieID, out string provincie);
                Directory.CreateDirectory(path + @"\" + provincie);//proviciemappen aanmaken.
                Console.Write("provinciemap gemaakt ");
                //----------hier loopt het fout---------------------------------------
                List<int> alleGemeenteIDs = gemeenteIDs[provincieID];
                foreach (int gemeenteID in alleGemeenteIDs)
                {
                    using (StreamWriter sw = new StreamWriter(path + @"\" + provincie + @"\" + gemeenteNamen[gemeenteID])) // aanmaken text file
                    {//grotere buffer geven voor sneller te laten werken . path,false,Encoding.UTF8,65536
                        List<int> straatIDs = stratenIDs[gemeenteID];
                        foreach (int straatID in straatIDs)
                        {
                            sw.WriteLine(straatNamen[straatID]); //straatid
                        }
                    }
                }
            }
            Console.WriteLine("Klaar met bestanden aan te maken.");
        }
    }

}
