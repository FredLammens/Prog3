using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace DBOEf
{
    class Adresbeheer
    {
        //uitlezen bestand
        private static List<Adres> GMLParser() 
        {
            //loading from file, also able to load from stream
            XDocument doc = XDocument.Load(@"C:\Users\Biebem\Downloads\CrabAdr.gml");
            XNamespace gml = "http://www.opengis.net/gml";
            XNamespace agiv = "http://www.agiv.be/agiv";
            //Query data 
            var query = doc.Descendants(agiv + "CrabAdr")
                .Select(e => new
                {
                    id = (int)e.Element(agiv + "ID"), //adresID
                    straatnaamid = (int)e.Element(agiv + "STRAATNMID"),
                    straatnaam = (string)e.Element(agiv + "STRAATNM"),
                    huisnummer = (string)e.Element(agiv + "HUISNR"),
                    appartementnummer = (string)e.Element(agiv + "APPTNR"),
                    busnummer = (string)e.Element(agiv + "BUSNR"),
                    huisnummerlabel = (string)e.Element(agiv + "HNRLABEL"),
                    NIScode = (int)e.Element(agiv + "NISCODE"),
                    gemeente = (string)e.Element(agiv + "GEMEENTE"),
                    postcode = (int)e.Element(agiv + "POSTCODE"), //wordt mss gebrruikt
                    herkomst = (string)e.Element(agiv + "HERKOMST"), //wordt wss niet gebruikt.
                    coord = e.Descendants(gml + "coord").Select( f => new {x = (double)f.Element(gml + "X"),y =(double)f.Element(gml + "Y") })
                });
            //aanmaken obejcten
            List<Adres> adressen = new List<Adres>();
            double[] coord = new double[2];
            foreach (var e in query)
            {
                double x = e.coord.ElementAt(0).x;
                double y = e.coord.ElementAt(0).y;
                int hashcode = Math.Abs(HashCode.Combine(x.GetHashCode(), y.GetHashCode()));
                //AdresLocatie locatie = new AdresLocatie(x,y); //maakt lijst van object(x,y) aan en roept hierop de x en y
                Gemeente gemeente = new Gemeente(e.NIScode, e.gemeente);
                Straatnaam straatnaam = new Straatnaam(e.straatnaamid, e.straatnaam, gemeente);
                Adres adres = new Adres(e.id, straatnaam, e.appartementnummer, e.busnummer, e.huisnummer, e.huisnummerlabel, hashcode,x,y);
                adressen.Add(adres);
            }
            //print query
            //foreach (var e in query)
            //{
            //    double x = e.coord.ElementAt(0).x;
            //    double y = e.coord.ElementAt(0).y;
            //    int hashcode = HashCode.Combine(x.GetHashCode(), y.GetHashCode());
            //    Console.WriteLine(Math.Abs(hashcode));
            //}
            return adressen;
        }
        //importeer in databank
        private string connectionString;
        public Adresbeheer(string conenctionString)
        {
            this.connectionString = connectionString;
        }
        private SqlConnection getConnection()
        {
            SqlConnection conenction = new SqlConnection(connectionString);
            return conenction;
        }
        //bulk adresdoorgeven
        public void AddGMLAdressesDB() 
        {
            List<Adres> adresses = GMLParser();
            SqlConnection connection = getConnection();
            
            using (SqlCommand command = connection.CreateCommand()) 
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                try 
                { 

                }
                catch (Exception e) 
                { 

                }
                finally 
                {
                    connection.Close(); 
                }
            }
        }
        private void AddGMLAdres(Adres adres)
        {
            AddGMLStraatnaam(adres.straatnaam);
            AddGMLLocatie(adres.locatie);
        }
        private void AddGMLStraatnaam(Straatnaam straatnaam)
        {
            AddGMLGemeente(straatnaam.gemeente);
        }
        private void AddGMLGemeente(Gemeente gemeente)
        {
        }
        private void AddGMLLocatie(AdresLocatie locatie)
        { 
        }
        //adres 1 per 1 doorgeven.
        public void AddAdresDB(Adres adres) 
        {
        }

    }
}
