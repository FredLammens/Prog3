using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
                    postcode = (int)e.Element(agiv + "POSTCODE"),
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
                //AdresLocatie locatie = new AdresLocatie(x,y); //maakt lijst van object(x,y) aan en roept hierop de x en y
                Gemeente gemeente = new Gemeente(e.NIScode, e.gemeente);
                Straatnaam straatnaam = new Straatnaam(e.straatnaamid, e.straatnaam, gemeente);
                Adres adres = new Adres(e.id, straatnaam, e.appartementnummer, e.busnummer, e.huisnummer, e.huisnummerlabel, e.postcode, x, y);
                adressen.Add(adres);
            }
            return adressen;
        }
        //bulk adresdoorgeven
        #region bulkgmladdresses
        public void AddGMLAdressesDB()
        {
            List<Adres> adresses = GMLParser();
            DbConnection connection = getConnection();
            try
            {
                connection.Open();
                using (DbDataAdapter adapter = sqlFactory.CreateDataAdapter())
                {
                    //Locatie insteken
                    AddLocaties(connection, adapter, adresses);
                    //Gemeente
                    AddGemeente(connection, adapter, adresses);
                    //Straatnaam
                    AddStraatnaam(connection, adapter, adresses);
                    //Adres
                    AddAdres(connection, adapter, adresses);
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
        private void AddLocaties(DbConnection connection, DbDataAdapter adapter, List<Adres> adresses)
        {
            string queryLocatie = "SELECT * FROM dbo.adreslocatieSQL";
            DbCommand commandLocatie = sqlFactory.CreateCommand();
            commandLocatie.CommandText = queryLocatie;
            commandLocatie.Connection = connection;
            adapter.SelectCommand = commandLocatie;
            DbCommandBuilder builder = sqlFactory.CreateCommandBuilder();
            builder.DataAdapter = adapter;
            adapter.InsertCommand = builder.GetInsertCommand();
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataColumn[] keyColumns = new DataColumn[1]; // primary key voor deze kolom instellen
            keyColumns[0] = table.Columns["Id"]; //idem
            table.PrimaryKey = keyColumns; //idem
            foreach (Adres adres in adresses)
            {
                if (!table.Rows.Contains(adres.locatie.ID))
                {
                    DataRow row = table.NewRow();
                    row["Id"] = adres.locatie.ID;
                    row["x"] = adres.locatie.x;
                    row["y"] = adres.locatie.y;
                    table.Rows.Add(row);
                }
            }
            adapter.Update(table);
        }
        private void AddGemeente(DbConnection connection, DbDataAdapter adapter, List<Adres> adresses)
        {
            string queryGemeente = "SELECT * FROM dbo.gemeenteSQL";
            DbCommand commandGemeente = sqlFactory.CreateCommand();
            commandGemeente.CommandText = queryGemeente;
            commandGemeente.Connection = connection;
            adapter.SelectCommand = commandGemeente;
            DbCommandBuilder builder = sqlFactory.CreateCommandBuilder();
            builder.DataAdapter = adapter;
            adapter.InsertCommand = builder.GetInsertCommand();
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataColumn[] keyColumns = new DataColumn[1]; // primary key voor deze kolom instellen
            keyColumns[0] = table.Columns["NIScode"]; //idem
            table.PrimaryKey = keyColumns; //idem
            foreach (Adres adres in adresses)
            {
                if (!table.Rows.Contains(adres.straatnaam.gemeente.NIScode))
                {
                    DataRow row = table.NewRow();
                    row["NIScode"] = adres.straatnaam.gemeente.NIScode;
                    row["gemeentenaam"] = adres.straatnaam.gemeente.gemeentenaam;
                    table.Rows.Add(row);
                }
            }
            adapter.Update(table);
        }
        private void AddStraatnaam(DbConnection connection, DbDataAdapter adapter, List<Adres> adresses)
        {
            string queryStraatnaam = "SELECT * FROM dbo.straatnaamSQL";
            DbCommand commandStraatnaam = sqlFactory.CreateCommand();
            commandStraatnaam.CommandText = queryStraatnaam;
            commandStraatnaam.Connection = connection;
            adapter.SelectCommand = commandStraatnaam;
            DbCommandBuilder builder = sqlFactory.CreateCommandBuilder();
            builder.DataAdapter = adapter;
            adapter.InsertCommand = builder.GetInsertCommand();
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataColumn[] keyColumns = new DataColumn[1]; // primary key voor deze kolom instellen
            keyColumns[0] = table.Columns["ID"]; //idem
            table.PrimaryKey = keyColumns; //idem
            foreach (Adres adres in adresses)
            {
                if (!table.Rows.Contains(adres.straatnaam.ID))
                {
                    DataRow row = table.NewRow();
                    row["ID"] = adres.straatnaam.ID;
                    row["straatnaam"] = adres.straatnaam.straatnaam;
                    row["NIScode"] = adres.straatnaam.gemeente.NIScode;
                    table.Rows.Add(row);
                }
            }
            adapter.Update(table);
        }
        private void AddAdres(DbConnection connection, DbDataAdapter adapter, List<Adres> adresses)
        {
            string queryAdres = "SELECT * FROM dbo.adresSQL";
            DbCommand commandAdres = sqlFactory.CreateCommand();
            commandAdres.CommandText = queryAdres;
            commandAdres.Connection = connection;
            adapter.SelectCommand = commandAdres;
            DbCommandBuilder builder = sqlFactory.CreateCommandBuilder();
            builder.DataAdapter = adapter;
            adapter.InsertCommand = builder.GetInsertCommand();
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataColumn[] keyColumns = new DataColumn[1]; // primary key voor deze kolom instellen
            keyColumns[0] = table.Columns["ID"]; //idem
            table.PrimaryKey = keyColumns; //idem
            foreach (Adres adres in adresses)
            {
                if (!table.Rows.Contains(adres.ID))
                {
                    DataRow row = table.NewRow();
                    row["ID"] = adres.ID;
                    row["straatnaamID"] = adres.straatnaam.ID;
                    row["huisnummer"] = adres.huisnummer;
                    row["appartementnummer"] = adres.appartementnummer;
                    row["busnummer"] = adres.busnummer;
                    row["huisnummerlabel"] = adres.huisnummerlabel;
                    row["adreslocatieID"] = adres.locatie.ID;
                    table.Rows.Add(row);
                }
            }
            adapter.Update(table);
        }
        #endregion
        //adres 1 per 1 doorgeven.
        public void AddAdresDB(Adres adres)
        {
        }

    }
}
