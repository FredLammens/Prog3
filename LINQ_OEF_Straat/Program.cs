using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace LINQ_OEF_Straat
{
    class Program
    {
        static void Main(string[] args)
        {
            //Unzipper(@"C:\Users\Biebem\Downloads");
            List<StraatInfo> strInf = FileSplitter(@"C:\Users\Biebem\Downloads\adresInfo.txt",',');
            Opgaves opgaves = new Opgaves();
            //opgaves.provincieAlf(strInf);
            //opgaves.straatVoGem(strInf, "Antwerpen");
            //opgaves.meestvorStraat(strInf);
            //opgaves.geefaantStraat(strInf,8);
            opgaves.gemStraatnam(strInf, "Antwerpen","Boom");
            opgaves.verschStraatnam(strInf, "Antwerpen");
        }
        public static void Unzipper(string zipPath)  //probeer eventueel zonder nieuwe map aan te maken 
        {
            ZipFile.ExtractToDirectory(zipPath + @"\adresInfo.zip", zipPath);
        }
        public static List<StraatInfo> FileSplitter(string fileToReadPath, char teken)
        {
            List<StraatInfo> splittedLines = new List<StraatInfo>();
            using (FileStream fs = File.Open(fileToReadPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] splitted = s.Split(teken);
                    splittedLines.Add(new StraatInfo(splitted[0],splitted[1],splitted[2])); //.split gebruikt intern een readonlyspan<char> s.Split(teken)
                }
            }
            return splittedLines;
        }
    }
}
