using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DBOEf
{
    class AdresRequest
    {
        private DbProviderFactory sqlFactory;
        private string connectionString;
        public AdresRequest(DbProviderFactory sqlFactory, string connectionString)
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


        public Adres GetAdres(int ID)
        {
            DbConnection connection = getConnection();
            string query = "SELECT dbo.adresSQL.*, dbo.adreslocatieSQL.x, dbo.adreslocatieSQL.y, dbo.straatnaamSQL.straatnaam, dbo.straatnaamSQL.NIScode, dbo.gemeenteSQL.gemeentenaam " +
                           "FROM dbo.adresSQL " +
                           "JOIN dbo.adreslocatieSQL " +
                           "ON dbo.adresSQL.adreslocatieID = dbo.adreslocatieSQL.ID " +
                           "JOIN dbo.straatnaamSQL " +
                           "ON dbo.adresSQL.straatnaamID = dbo.straatnaamSQL.ID " +
                           "JOIN dbo.gemeenteSQL " +
                           "ON dbo.straatnaamSQL.NIScode = dbo.gemeenteSQL.NIScode " +
                           "WHERE adresSQL.ID = @ID;";
            
            using(DbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                DbParameter paramID = sqlFactory.CreateParameter();
                paramID.ParameterName = "@ID";
                paramID.DbType = DbType.Int32;
                paramID.Value = ID;
                command.Parameters.Add(paramID);
                connection.Open();
                try
                {
                    
                    DbDataReader reader = command.ExecuteReader();
                    reader.Read();
                    Gemeente Test = new Gemeente((int)reader["NIScode"], (string) reader["gemeentenaam"]);
                    Straatnaam Testie = new Straatnaam((int)reader["straatnaamID"],(string)reader["straatnaam"], Test);
                    Adres adres = new Adres((int)reader["ID"], Testie, (string)reader["appartementnummer"],
                        (string)reader["busnummer"], (string)reader["huisnummer"],
                        (string)reader["huisnummerlabel"], 9120, (double)reader["x"], (double)reader["y"]
                        );
                    reader.Close();
                    return adres;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
                finally
                {
                    connection.Close();
                }

            }

        }

        public List<Straatnaam> getStraatnamen() 
        {
        }
    }
}
