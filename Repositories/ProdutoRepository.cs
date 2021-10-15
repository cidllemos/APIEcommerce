using APIEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEcommerce.Repositories
{
    public class ProdutoRepository
    {
        public static void Salvar(Produto produto)
        {
            BaseRepository.Command(produto);
        }

        public static void Editar(Produto produto)
        {
            BaseRepository.Command(produto, true);
        }

        public static void Delete(int id)
        {
            BaseRepository.Delete<Produto>(id);
        }

        public static List<Produto> Buscar(int id = 0, string nome = "")
        {
            string sql = "select * from Produto";

            if (id > 0)
            {
                sql += " where id = @idProduto";
            }

            if (!string.IsNullOrEmpty(nome))
            {
                if (sql.Contains("where"))
                    sql += " and nome like @nomeProduto";
                else
                    sql += " where nome like @nomeProduto";
            }
            var retorno = BaseRepository.QuerySql<Produto>(sql, new { idProduto = id, nomeProduto = "%" + nome + "%" });

            return retorno;
        }
    }
}
