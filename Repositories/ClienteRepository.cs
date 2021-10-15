using APIEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEcommerce.Repositories
{
    public static class ClienteRepository
    {
        public static void Salvar(Cliente cliente)
        {
            BaseRepository.Command(cliente); 
        }

        public static void Editar(Cliente cliente)
        {
            BaseRepository.Command(cliente, true);
        }

        public static void Delete(int id)
        {
            BaseRepository.Delete<Cliente>(id);
        }

        public static List<Cliente> Buscar(int id = 0, string nome = "")
        {
            string sql = "select * from Cliente";

            if (id > 0)
            {
                sql += " where id = @idCliente";
            }

            if (!string.IsNullOrEmpty(nome))
            {
                if (sql.Contains("where"))
                    sql += " and nome like @nomeCliente";
                else
                    sql += " where nome like @nomeCliente";
            }
            var retorno = BaseRepository.QuerySql<Cliente>(sql, new { idCliente = id, nomeCliente = "%" + nome + "%"});

            return retorno;
        }
    }
}
