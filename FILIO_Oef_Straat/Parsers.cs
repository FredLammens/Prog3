using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace FILIO_Oef_Straat
{
    class Parsers
    {
        public static Dictionary<int, string> StraatParser(string fileToReadPath)//straatnamen
        {
            Dictionary<int, string> straat = new Dictionary<int, string>();
            List<string[]> lines = BackEndClasses.FileSplitter(fileToReadPath, ';');
            Parallel.ForEach(lines, line =>
            {
                int key;
                int.TryParse(line[0], out key);
                if (key > 0)
                    straat.Add(key, line[1]);
            });
            straat = straat.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return straat;
        }
        public static Dictionary<int, int> StratenInGemeentenParser(string fileToReadPath) //straatnaamID_gemeenteID
        {
            Dictionary<int, int> stratenInGemeenten = new Dictionary<int, int>();
            List<string[]> lines = BackEndClasses.FileSplitter(fileToReadPath,';');
            //foreach (string[] line in lines)
            //{
            //    int key;
            //    int value;
            //    int.TryParse(line[0], out key);
            //    int.TryParse(line[1], out value);
            //    if(key > 0)
            //    stratenInGemeenten.Add(key, value);
            //}//moet niet gesorteerd worden = soort van lookup table
            Parallel.ForEach(lines, line =>
            {
                int key;
                int value;
                int.TryParse(line[0], out key);
                int.TryParse(line[1], out value);
                if (key > 0)
                    stratenInGemeenten.Add(key, value);
            });
            return stratenInGemeenten;
        }
        public static Dictionary<int, string> GemeenteEnProvincieParser(string fileToReadPath)  //provincieInfo
        {
            Dictionary<int, string> gemeente = new Dictionary<int, string>();
            List<string[]> lines = BackEndClasses.FileSplitter(fileToReadPath,';');
            Parallel.ForEach(lines, line =>
             {
                 if (line[2] == "nl")
                 {
                     int key;
                     int.TryParse(line[1], out key);
                     gemeente.Add(key, line[3]);
                 }
             });
                return gemeente.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }
        public static List<int> GemeenteInProvincieParser(string fileToReadPath) 
        {
            List<int> ProvincieIDs = new List<int>();
            List<string[]> lines = BackEndClasses.FileSplitter(fileToReadPath, ',');
            Parallel.ForEach(lines, line =>
             {
                 int id;
                 int.TryParse(line[0], out id);
                 ProvincieIDs.Add(id);
             });
            return ProvincieIDs;        
        }
       // public static Dictionary<int, int> GemeenteInProvincieLinker() 
       // {

        //}


    }
}
