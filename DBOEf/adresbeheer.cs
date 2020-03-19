using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;
// counter voor adres maken
// counter implementeren . executeScalar eindleijk fucking weg
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
        #region uitlezenbestand
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
                    postcode = (int)e.Element(agiv + "POSTCODE"),
                    herkomst = (string)e.Element(agiv + "HERKOMST"), //wordt wss niet gebruikt.
                    coord = e.Descendants(gml + "coord").Select(f => new { x = (double)f.Element(gml + "X"), y = (double)f.Element(gml + "Y") })
                });
            //aanmaken objecten
            List<Adres> adressen = new List<Adres>();
            double[] coord = new double[2];
            foreach (var e in query)
            {
                double x = e.coord.ElementAt(0).x;
                double y = e.coord.ElementAt(0).y;
                Gemeente gemeente = new Gemeente(e.NIScode, e.gemeente);
                Straatnaam straatnaam = new Straatnaam(e.straatnaamid, e.straatnaam, gemeente);
                Adres adres = new Adres(e.id, straatnaam, e.appartementnummer, e.busnummer, e.huisnummer, e.huisnummerlabel, -1, x, y);
                adressen.Add(adres);
            }
            return adressen;
        }
        #endregion
        #region bulk adresdoorgeven
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
            string queryLocatie = "SELECT * FROM dbo.adresLocatieTest";
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
            string queryGemeente = "SELECT * FROM dbo.gemeenteTest";
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
            string queryStraatnaam = "SELECT * FROM dbo.straatnaamTest";
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
            string queryAdres = "SELECT * FROM dbo.AdresTest";
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
        #region adres1per1
        public void voegAdresToe(Adres adres)
        {
            DbConnection connection = getConnection();
            string queryAdres = "INSERT INTO dbo.AdresTest(ID,straatnaamID,huisnummer,appartementnummer,busnummer,huisnummerlabel,adreslocatieID) output INSERTED.ID " +
                "VALUES(@ID,@straatnaamID,@huisnummer,@appartementnummer,@busnummer,@huisnummerlabel,@adreslocatieID)";
            string queryAdresLocatie = "INSERT INTO dbo.adreslocatieTest(Id,x,y) output INSERTED.Id " +
                "VALUES(@Id,@x,@y)";
            using (DbCommand commandAdres = connection.CreateCommand()) //difference between dbcommand and sqlcommand
            using (DbCommand commandLocatie = connection.CreateCommand())
            {
                connection.Open();
                int newLocatieID = NewLocatieID(connection);
                DbTransaction transaction = connection.BeginTransaction();
                commandAdres.Transaction = transaction;
                commandLocatie.Transaction = transaction;
                try
                {
                    #region Adreslocatie toevoegen
                    //ID
                    DbParameter parAdresLocatieID = sqlFactory.CreateParameter();
                    parAdresLocatieID.ParameterName = "@Id";
                    parAdresLocatieID.DbType = DbType.Int32;
                    commandLocatie.Parameters.Add(parAdresLocatieID);
                    //X
                    DbParameter parAdresLocatieX = sqlFactory.CreateParameter();
                    parAdresLocatieX.ParameterName = "@x";
                    parAdresLocatieX.DbType = DbType.Double;
                    commandLocatie.Parameters.Add(parAdresLocatieX);
                    //Y
                    DbParameter parAdresLocatieY = sqlFactory.CreateParameter();
                    parAdresLocatieY.ParameterName = "@y";
                    parAdresLocatieY.DbType = DbType.Double;
                    commandLocatie.Parameters.Add(parAdresLocatieY);
                    //
                    commandLocatie.CommandText = queryAdresLocatie;
                    //values toevoegen
                    commandLocatie.Parameters["@Id"].Value = newLocatieID;
                    commandLocatie.Parameters["@x"].Value = adres.locatie.x;
                    commandLocatie.Parameters["@y"].Value = adres.locatie.y;
                    commandLocatie.ExecuteNonQuery();
                    #endregion
                    #region adres toevoegen
                    //ID
                    DbParameter parID = sqlFactory.CreateParameter();
                    parID.ParameterName = "@Id";
                    parID.DbType = DbType.Int32;
                    commandAdres.Parameters.Add(parID);
                    //StraatnaamID
                    DbParameter parNaam = sqlFactory.CreateParameter();
                    parNaam.ParameterName = "@straatnaamID";
                    parNaam.DbType = DbType.Int32;
                    commandAdres.Parameters.Add(parNaam);
                    //huisnummer
                    DbParameter parHNummer = sqlFactory.CreateParameter();
                    parHNummer.ParameterName = "@huisnummer";
                    parHNummer.DbType = DbType.AnsiString;
                    commandAdres.Parameters.Add(parHNummer);
                    //appartementnummer
                    DbParameter parAppNummer = sqlFactory.CreateParameter();
                    parAppNummer.ParameterName = "@appartementnummer";
                    parAppNummer.DbType = DbType.AnsiString;
                    commandAdres.Parameters.Add(parAppNummer);
                    //busnummer
                    DbParameter parBusNr = sqlFactory.CreateParameter();
                    parBusNr.ParameterName = "@busnummer";
                    parBusNr.DbType = DbType.AnsiString;
                    commandAdres.Parameters.Add(parBusNr);
                    //huisnummerlabel
                    DbParameter parHNrLabel = sqlFactory.CreateParameter();
                    parHNrLabel.ParameterName = "@huisnummerlabel";
                    parHNrLabel.DbType = DbType.AnsiString;
                    commandAdres.Parameters.Add(parHNrLabel);
                    //adreslocatieID
                    DbParameter parAdresLoc = sqlFactory.CreateParameter();
                    parAdresLoc.ParameterName = "@adreslocatieID";
                    parAdresLoc.DbType = DbType.Int32;
                    commandAdres.Parameters.Add(parAdresLoc);
                    //
                    commandAdres.CommandText = queryAdres;
                    //parameters instellen
                    commandAdres.Parameters["@ID"].Value = adres.ID;
                    commandAdres.Parameters["@straatnaamID"].Value = adres.straatnaam.ID;
                    commandAdres.Parameters["@huisnummer"].Value = adres.huisnummer;
                    commandAdres.Parameters["@appartementnummer"].Value = adres.appartementnummer;
                    commandAdres.Parameters["@busnummer"].Value = adres.busnummer;
                    commandAdres.Parameters["@huisnummerlabel"].Value = adres.huisnummerlabel;
                    commandAdres.Parameters["@adreslocatieID"].Value = newLocatieID;
                    commandAdres.ExecuteNonQuery();
                    #endregion
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex);
                }
                finally 
                {
                    connection.Close();
                }
            }
        }
        #endregion
        #region hulpmethods
        private int NewLocatieID(DbConnection connection) 
        {
            string query = "SELECT COUNT(dbo.adresLocatieTest.Id) as count FROM dbo.adresLocatieTest";
            int toReturn = 0;
            using (DbCommand command = connection.CreateCommand()) 
            {
                command.CommandText = query;
                DbDataReader reader = command.ExecuteReader();
                reader.Read();
                toReturn = (int)reader["count"];
                reader.Close();
            }
            return toReturn + 1;
        }
        #endregion

    }
}
