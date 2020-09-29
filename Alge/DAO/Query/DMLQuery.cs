

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BancodeImagens.DAO.Query
{
    public class DMLQuery
    {
        public CallDB db;
       

        public DMLQuery(CallDB db)
        {
            this.db = db;
        }

        public DMLQuery()
        {
            this.db = new CallDB();
        }

        public void Increment(string column, int incrementNumber, string tableName, string whereClausule)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = ("UPDATE " + tableName + " SET " + column + " = " + column + " + " + incrementNumber.ToString() + " " + whereClausule);
            try
            {
                
                comm.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                db.conexao.Close();
            }
            finally
            {
                db.conexao.Close();
            }


        }

        
        public int GetLastID(string table, string database)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = (String.Format("SELECT AUTO_INCREMENT FROM information_schema.tables WHERE table_name = '{0}' AND table_schema = '{1}'", table, database));
            try
            {
                
                MySqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    return (reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader["AUTO_INCREMENT"]));
                }
                return 0;
            }
            catch (Exception e)
            {
                db.conexao.Close();
                return 0;
            }
            finally
            {
                db.conexao.Close(); //Fechando a conexão
            }
        }
        public void Cadastrar(string email, string pass, string country, string origem)
        {
            // MySqlCommand command = new MySqlCommand("INSERT INTO pessoa(id, nome) VALUES(2, 'Glaucio') ", db.conexao); //MYSqlCommand é o tipo que guarda a Query
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = "INSERT INTO CLIENTES_User(CLIENTES_User_email,CLIENTES_User_password_hash, CLIENTES_User_account_date_create, FK_CLIENTES_Paises,FK_SITE_Origem) VALUES(@email, @passwordHash, @accountDataCreate,@country,@origem)";
            comm.Parameters.AddWithValue("@email", email);
            comm.Parameters.AddWithValue("@passwordHash", pass);
            comm.Parameters.AddWithValue("@accountDataCreate", DateTime.UtcNow);
            comm.Parameters.AddWithValue("@country", country);
            comm.Parameters.AddWithValue("@origem", origem);

            try
            {
                
                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                db.conexao.Close();
            }
            finally
            {
                db.conexao.Close(); //Fechando a conexão
            }
        }
        public string getPassWordHash(string select, string from, string where)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = String.Format("SELECT {0} FROM {1} WHERE {2}", select, from, where);

            try
            {
                
                MySqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                return (string)reader[select];

            }
            catch (Exception e)
            {
                db.conexao.Close();
                return "";
            }
            finally
            {
                db.conexao.Close(); //Fechando a conexão
            }



        }
        public void InsertRecoveryCode(string table, string recoveryCodeFieldName, string recoveryCode, string paramFieldName, string paramFieldValue)
        {
            string QueryString = String.Format("UPDATE {0} set {1} = '{2}' WHERE {3} = '{4}'", table, recoveryCodeFieldName, recoveryCode, paramFieldName, paramFieldValue);
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = QueryString;

            try
            {
                
                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
               
            }
            finally
            {
                db.conexao.Close(); //Fechando a conexão
            }

        }
        public Tuple<int, bool, string> GetRecoveryData(string table, string IDFieldName, string EmailFieldName, string fieldFilterName, string fieldFilterValue)
        {
            string QueryString = String.Format("SELECT {0},{1} FROM {2} WHERE {3} = '{4}'", IDFieldName, EmailFieldName, table, fieldFilterName, fieldFilterValue);
            Debug.WriteLine(QueryString);
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = QueryString;

            if (ExistData(table, new List<string> { fieldFilterName }, new List<string> { fieldFilterValue }))
            {
                try
                {
                    

                    MySqlDataReader reader = comm.ExecuteReader();
                    reader.Read();
                    int userId = 0;
                    string userEmail = "";

                    userId = Convert.ToInt32(reader[IDFieldName]);
                    userEmail = Convert.ToString(reader[EmailFieldName]);
                    return new Tuple<int, bool, string>(userId, true, userEmail);

                }
                catch (Exception e)
                {
                    db.conexao.Close();
                    return new Tuple<int, bool, string>(0, false, "");
                }
                finally
                {
                    db.conexao.Close(); //Fechando a conexão
                }


            }
            else
            {
                return new Tuple<int, bool, string>(0, false, "");
            }

        }
        public void ChangePassword(string newpass, string table, string passwordFieldName, string fieldFilterName, string fieldFilterValue)
        {

            string QueryString = String.Format("UPDATE {0} set {1} = '{2}' WHERE {3} = '{4}'", table, passwordFieldName, newpass, fieldFilterName, fieldFilterValue);
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = QueryString;
            try
            {
                
                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                db.conexao.Close();
            }
            finally
            {
                db.conexao.Close(); //Fechando a conexão
            }

        }
        public void DeleteData(string table, string conditional)
        {
            string Query = String.Format("DELETE FROM {0} where {1}", table, conditional);

            using (MySqlCommand comm = new MySqlCommand(Query, db.conexao))
            {
                db.conexao.Open();
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    db.conexao.Close();
                  
                }
                finally
                {
                    db.conexao.Close();

                }
            }
        }
        public void Execute(string query)
        {
            MySqlCommand comm = new MySqlCommand(query, db.conexao);
            try
            {
                
                comm.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine(query);
                Debug.WriteLine(e);
            

            }
            catch (Exception e)
            {
                Debug.WriteLine(query);
                Debug.WriteLine(e);
              

            }
            finally
            {

                db.conexao.Close(); //Fechando a conexão
            }
        }
        public string InsertData(string table, List<string> columns, List<string> values)
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
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = Query;

            try
            {
                db.conexao.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                return reader.GetString("ID");
            }
            catch (Exception e)
            {
               
                return "Error";
            }
            finally
            {
                db.conexao.Close(); //Fechando a conexão
            }

        }
        public string InsertData(string table, List<string> columns, List<List<string>> values)
        {
            string valuesQuery = "";
            string columnsQuery = "(";
            for (int i = 1; i <= columns.Count; i++)
            {
                if (i != columns.Count)
                {
                    columnsQuery += columns[i - 1] + ",";
                }
                else
                {
                    columnsQuery += columns[i - 1];
                }
            }
            columnsQuery += ")";

            int numOfValuesGroup = values.Count;
            int numOfValuesforeachGroup = values.FirstOrDefault().Count;


            for (int i = 0; i < values.Count; i++)
            {
                valuesQuery += "(";
                for (int ii = 0; ii < values[0].Count; ii++)
                {
                    valuesQuery += "'" + values[i][ii] + "'";
                    valuesQuery += (ii != (values[i].Count - 1)) ? "," : "";
                };

                valuesQuery += ")";
                valuesQuery += (i != (values.Count - 1)) ? "," : "";

            }

            string Query = "INSERT INTO " + table + columnsQuery + " VALUES" + valuesQuery + ";";
            Query += "SELECT LAST_INSERT_ID() as ID;";

            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = Query;

            try
            {
                db.conexao.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                return reader.GetString("ID");

            }
            catch (MySqlException e)
            {
                Debug.WriteLine(Query);
                Debug.WriteLine(e);
                db.conexao.Close();
                return "Error";
            }
            catch (Exception e)
            {
                Debug.WriteLine(Query);
                Debug.WriteLine(e);
                db.conexao.Close();
                return "Error";
            }
            finally
            {
                db.conexao.Close(); //Fechando a conexão
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
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = ("SELECT " + columns[0] + " FROM " + table + " WHERE " + selectCondition + " " + aditionalCondition);
            try
            {
                db.conexao.Open();
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
                db.conexao.Close(); //Fechando a conexão
            }

        }
        public bool ExistDataLike(string select, string from, string where, string like)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = (String.Format("SELECT {0} FROM {1} WHERE {2} LIKE @_like", select, from, where));
            comm.Parameters.AddWithValue("@_like", like);

            try
            {
                

                MySqlDataReader reader = comm.ExecuteReader();
                reader.Read();

                if (reader.HasRows) { reader.Close(); return true; } else { reader.Close(); return false; }; //FALSE IF HAS //TRUE IF NO HAS

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                db.conexao.Close();
                return false;
            }
            finally
            {
                db.conexao.Close(); //Fechando a conexão
            }

        }
        public void UpdateData(string table, List<string> columns, List<string> values, string condition)
        {

            string Operation = "";
            for (int i = 1; i <= columns.Count; i++)
            {
                values[i - 1] = values[i - 1] == null ? "" : values[i - 1];
                if (i != columns.Count)
                {
                    if (values[i - 1].Contains("NOW()") || values[i - 1].Contains("True") || values[i - 1].Contains("FALSE"))
                    {
                        Operation += String.Format("{0} = {1},", columns[i - 1], values[i - 1]);
                    }
                    else
                    {
                        Operation += String.Format("{0} = '{1}',", columns[i - 1], values[i - 1]);
                    }
                }
                else
                {
                    if (values[i - 1].Contains("NOW()") || values[i - 1].Contains("True") || values[i - 1].Contains("FALSE"))
                    {
                        Operation += String.Format("{0} = {1}", columns[i - 1], values[i - 1]);
                    }
                    else
                    {
                        Operation += String.Format("{0} = '{1}'", columns[i - 1], values[i - 1]);
                    }
                }
            }
            string Query = String.Format("UPDATE {0} SET {1} WHERE {2}", table, Operation, condition);

            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = Query;

            try
            {
                db.conexao.Open();
                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
              
                db.conexao.Close();

            }
            finally
            {
                db.conexao.Close();
            }

        }
        public string GetData(string select, string from, string where, string equals, string aditionalCondition = "")
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = ("SELECT " + select + " from  " + from + " where " + where + " = '" + equals + "'" + " " + aditionalCondition);
            try
            {
                db.conexao.Open();
                MySqlDataReader reader = comm.ExecuteReader();

                Object data = new Object();

                reader.Read();

                data = reader.GetString(0);

                return Convert.ToString(data);

            }
            catch (Exception e)
            {

                Console.WriteLine("Erro na consulta", e.Message);
                db.conexao.Close();
                return null;

            }
            finally
            {
                db.conexao.Close(); //Fechando a conexão
            }
        }
        public string GetData(string select, string from, List<string> columns, List<string> columnsValues, string aditionalCondition = "")
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
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = ("SELECT " + select + " FROM " + from + " WHERE " + selectCondition + " " + aditionalCondition);
            try
            {
                db.conexao.Open();

                MySqlDataReader reader = comm.ExecuteReader();

                Object data = new Object();

                reader.Read();

                data = reader.GetString(0);

                return Convert.ToString(data);

            }
            catch (MySqlException e)
            {

                Console.WriteLine("Erro na consulta", e.Message);
                db.conexao.Close();
                return null;

            }
            finally
            {
                db.conexao.Close(); //Fechando a conexão
            }
        }
        public string GetLastRowData(string select, string from, string where, string equals, string primaryKey)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = ("SELECT ( " + select + ") FROM  " + from + " where " + where + " = " + equals + " ORDER BY " + primaryKey + " DESC LIMIT 1");

            try
            {
                

                MySqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                var data = reader.GetString(0);
                return Convert.ToString(data);

            }
            catch (Exception e)
            {
                db.conexao.Close();
                return "";
            }
            finally
            {
                db.conexao.Close(); //Fechando a conexão
            }
        }
        public List<string> GetRow(List<string> columns, string from, string where, string equals, string AdditionalQuery = "")
        {

            string columnsQuery = "";
            for (int i = 1; i <= columns.Count; i++)
            {
                if (i != columns.Count)
                {
                    columnsQuery += columns[i - 1] + ",";
                }
                else
                {
                    columnsQuery += columns[i - 1];
                }
            }

            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = ("SELECT " + columnsQuery + " FROM  " + from + " where " + where + " = '" + equals + "' " + AdditionalQuery);
            List<string> retorno = new List<string>();
            try
            {
                
                MySqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < columns.Count; i++)
                    {

                        var currentColumnValue = reader[columns[i]];
                        retorno.Add(Convert.ToString(currentColumnValue));
                    }

                }

            }
            catch (Exception e)
            {
                db.conexao.Close();
                return retorno;
            }
            finally
            {
                db.conexao.Close(); //Fechando a conexão
            }

            return retorno;

        }
        public List<string> ReturnColumn(string select, string from, string where, string orderby = "", string aditionalParameterSelect = "")
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = "SELECT " + aditionalParameterSelect + " " + select + " FROM " + from + " WHERE " + where + orderby;
            try
            {
                db.conexao.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                List<String> list = new List<String>();
                while (reader.Read())
                {
                    var item = reader[select];
                    list.Add(Convert.ToString(item));
                }
                return list;

            }
            catch (Exception e)
            {
                db.conexao.Close();
                return null;
            }
            finally
            {
                db.conexao.Close(); //Fechando a conexão
            }
        }


        public List<string> ReturnColumnView(string viewName, string column, string orderBy)
        {
            MySqlCommand comm = new MySqlCommand("", db.conexao);
            comm.CommandText = "SELECT " + column + " FROM " + viewName + " ORDER BY " + orderBy;

            try
            {
                db.conexao.Open();
                MySqlDataReader reader = comm.ExecuteReader();
                List<String> list = new List<String>();
                while (reader.Read())
                {
                    var item = reader[column];
                    list.Add(Convert.ToString(item));
                }
                return list;

            }
            catch (Exception e)
            {
                db.conexao.Close();
                return null;
            }
            finally
            {
                db.conexao.Close(); //Fechando a conexão
            }
        }

    }
}
