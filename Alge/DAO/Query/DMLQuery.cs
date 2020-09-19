using Alge.Models;
using Alge.Performance;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Alge.DAO
{
    public class DMLQuery
    {
        public readonly CallDB Db;

        public DMLQuery(CallDB db)
        {
            Db = db;
        }

        public async void UpdateData(string table, List<string> columns, List<string> values, string condition)
        {

            string Operation = "";
            for (int i = 1; i <= columns.Count; i++)
            {
                values[i - 1] = values[i - 1] == null ? "" : values[i - 1];
                if (i != columns.Count)
                {
                    if (values[i - 1].Contains("NOW()") || values[i - 1].Contains("True") || values[i - 1].Contains("false"))
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
                    if (values[i - 1].Contains("NOW()") || values[i - 1].Contains("True") || values[i - 1].Contains("false"))
                    {
                        Operation += String.Format("{0} = {1}", columns[i - 1], values[i - 1]);
                    }
                    else
                    {
                        Operation += String.Format("{0} = '{1}'", columns[i - 1], values[i - 1]);
                    }
                }
            }
            var cmd = Db.Connection.CreateCommand();

            cmd.CommandText = String.Format("UPDATE {0} SET {1} WHERE {2}", table, Operation, condition);

            try
            {
                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception e)
            {
            }

        }
    }
}
