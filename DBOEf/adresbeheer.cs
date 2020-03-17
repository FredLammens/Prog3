using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;

namespace DBOEf
{
    class AdresBeheer
    {
        #region basisshit
        private DbProviderFactory sqlFactory;
        private string connectionString;
        public AdresBeheer(DbProviderFactory sqlFactory, string connectionString)
        {
            this.sqlFactory = sqlFactory;
            this.connectionString = connectionString;
        }
        private DbConnection getConnection()
        {
            DbConnection connection = sqlFactory.CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }
        #endregion
        //uitlezen bestand
        private static List<Adres> GMLParser()
        {
            //loading from file, also able to load from stream
            XDocument doc = XDocument.Load(@"C:\Users\Biebem\Downloads\test.gml");
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
                    coord = e.Descendants(gml + "coord").Select(f => new { x = (double)f.Element(gml + "X"), y = (double)f.Element(gml + "Y") })
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
                Adres adres = new Adres(e.id, straatnaam, e.appartementnummer, e.busnummer, e.huisnummer, e.huisnummerlabel, hashcode, x, y);
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
        //bulk adresdoorgeven
        public void AddGMLAdressesDB()
        {
            List<Adres> adresses = GMLParser();
            DbConnection connection = getConnection();
            string queryLocatie = "SELECT * FROM dbo.adreslocatieSQL";
            //string queryAdres = "SELECT * FROM dbo.adresSQL";
            //string queryGemeente = "SELECT * FROM dbo.gemeenteSQL";
            //string queryStraatnaam = "SELECT * FROM dbo.straatnaamSQL";
            try
            {
                connection.Open();
                using (DbDataAdapter adapter = sqlFactory.CreateDataAdapter())
                {
                    DbCommand commandLocatie = sqlFactory.CreateCommand();
                    commandLocatie.CommandText = queryLocatie;
                    commandLocatie.Connection = connection;
                    //DbCommand commandGemeente = sqlFactory.CreateCommand();
                    //commandGemeente.CommandText = queryGemeente;
                    //commandGemeente.Connection = connection;
                    //DbCommand commandStraatnaam = sqlFactory.CreateCommand();
                    //commandStraatnaam.CommandText = queryStraatnaam;
                    //commandStraatnaam.Connection = connection;
                    //DbCommand commandAdres = sqlFactory.CreateCommand();
                    //commandAdres.CommandText = queryAdres;
                    //commandAdres.Connection = connection;
                    //Locatie insteken
                    adapter.SelectCommand = commandLocatie;
                    DbCommandBuilder builder = sqlFactory.CreateCommandBuilder();
                    builder.DataAdapter = adapter;
                    adapter.InsertCommand = builder.GetInsertCommand();
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    foreach (Adres adres in adresses)
                    {
                        DataRow row = table.NewRow();
                        row["Id"] = adres.locatie.ID;
                        row["x"] = adres.locatie.x;
                        row["y"] = adres.locatie.y;
                        table.Rows.Add(row);
                    }
                    adapter.Update(table);
                    //Gemeente
                    //Straatnaam
                    //Adres
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
        }
        //adres 1 per 1 doorgeven.
        public void AddAdresDB(Adres adres)
        {
        }

    }
}
