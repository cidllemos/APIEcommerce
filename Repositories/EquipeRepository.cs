using APIEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEcommerce.Repositories
{
    public class EquipeRepository
    {
        public static void Salvar(Equipe equipe)
        {
            BaseRepository.Command(equipe);
        }

        public static void Editar(Equipe equipe)
        {
            BaseRepository.Command(equipe, true);
        }

        public static void Delete(int id)
        {
            BaseRepository.Delete<Equipe>(id);
        }

        public static List<Equipe> Buscar(int id = 0, string nome = "")
        {
            string sql = "select * from Equipe";

            if (id > 0)
            {
                sql += " where id = @idEquipe";
            }

            if (!string.IsNullOrEmpty(nome))
            {
                if (sql.Contains("where"))
                    sql += " and nome like @nomeEquipe";
                else
                    sql += " where nome like @nomeEquipe";
            }
            var retorno = BaseRepository.QuerySql<Equipe>(sql, new { idEquipe = id, nomeEquipe = "%" + nome + "%" });

            return retorno;
        }
    }
}
