using System;
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


   



