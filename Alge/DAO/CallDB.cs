using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;



    public class CallDB : IDisposable
    {
       
        public MySqlConnection conexao;
         
        public CallDB()
        {
            try
            {
                var config = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .Build();

                conexao = new MySqlConnection(config.GetConnectionString("Alge_db"));
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao Conectar com o Banco ",e.Message);
            }

        }
    public bool InsertData(string table, List<string> columns, List<string> values)
    {

        string valuesQuery = "(";
        string columnsQuery = "(";
        for (int i = 1; i <= columns.Count; i++)
        {
            bool noSingleQuote = values[i - 1].Contains("NOW()") || values[i - 1].Contains("True") || values[i - 1].Contains("False");

            if (i != columns.Count)
            {
                values[i] = values[i] == null ? "" : values[i].Replace('\u0027', ' ');

                valuesQuery += noSingleQuote == true ? values[i - 1] + "," : "'" + values[i - 1] + "'" + ",";

                columnsQuery += columns[i - 1] + ",";
            }
            else
            {
                valuesQuery += noSingleQuote == true ? values[i - 1] : "'" + values[i - 1] + "'";
                columnsQuery += columns[i - 1];
            }
        }
        valuesQuery += ")";
        columnsQuery += ")";

        string Query = "INSERT INTO " + table + columnsQuery + " VALUES" + valuesQuery + ";";
        Query += "SELECT LAST_INSERT_ID() as ID;";
        MySqlCommand comm = new MySqlCommand("", conexao);
        comm.CommandText = Query;

        try
        {
            conexao.Open();
            MySqlDataReader reader = comm.ExecuteReader();
            reader.Read();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error on InsertData Message =  {0} \n  Query = {1}", e.Message, Query);
            return false;
        }
        finally
        {
            conexao.Close(); //Fechando a conexão
        }

    }
    public bool ExistData(string table, List<string> columns, List<string> columnsValues, string aditionalCondition = "")
    {

        string selectCondition = "";
        for (int i = 1; i <= columns.Count; i++)
        {
            if (i != columns.Count)
            {
                selectCondition += columns[i - 1] + "='" + columnsValues[i - 1] + "'" + " AND ";
            }
            else
            {
                selectCondition += columns[i - 1] + "='" + columnsValues[i - 1] + "'";
            }
        }
        MySqlCommand comm = new MySqlCommand("", conexao);
        comm.CommandText = ("SELECT " + columns[0] + " FROM " + table + " WHERE " + selectCondition + " " + aditionalCondition);
        try
        {
            conexao.Open();
            MySqlDataReader reader = comm.ExecuteReader();
            reader.Read();

            if (reader.HasRows) { reader.Close(); return true; } else { reader.Close(); return false; }; //FALSE IF HAS //TRUE IF NO HAS

        }
        catch (Exception e)
        {
            return false;
        }
        finally
        {
            conexao.Close(); //Fechando a conexão
        }

    }
    public CallDB(DBSource dbSource)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .Build();

            string connString = "";
            if (dbSource == DBSource.Alge_db) //FoxxstockCore A2
            {
                connString = "ALge_DB";
            }

            conexao = new MySqlConnection(config.GetConnectionString(connString));
        }

        public void Dispose()
        {
            conexao.Close();
        }
    public enum DBSource
    {
        Alge_db,

    }
    }


   



