
using APIEcommerce.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIEcommerce.Repositories
{
    public static class BaseRepository
    {
        public const string ConnectionString = "Server = .\\SQLEXPRESS; Database = ApiEcommerce; Trusted_Connection = True;";
        public static List<T> QuerySql<T>(string sql, Object parameter = null)
        {
            List<T> orderDetail;
            using (var connection = new SqlConnection(ConnectionString))
            {
                orderDetail = connection.Query<T>(sql, parameter).ToList();
            }

            return orderDetail;
        }

        public static void Delete<T>(int id) where T : BaseModel
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var tabela = typeof(T).Name;
                string query = $"select * from {tabela} where {BuscaColunaChave(tabela)} = @id";
                var objeto = connection.Query<T>(query, new { id });
                connection.Delete(objeto);
            }
        }

        public static void Command<T>(T objeto, bool editar = false, Object parameter = null) where T : BaseModel
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                if (editar)
                    connection.Update(objeto);
                else
                    connection.Insert(objeto);
            }
        }

        private static string BuscaColunaChave(string nomeTabela)
        {
            string query = @"select Col.Column_Name from
                             INFORMATION_SCHEMA.TABLE_CONSTRAINTS Tab
                             INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE Col
                             WHERE 
                             Col.Constraint_Name = Tab.Constraint_Name
                             AND Col.Table_Name = Tab.Table_Name
                             AND Constraint_Type = 'PRIMARY KEY'
                             AND Col.Table_Name = @tableName";

            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<string>(query, new { tableName = nomeTabela }).FirstOrDefault();
            }
        }
    }
}
