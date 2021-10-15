using APIEcommerce.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace APIEcommerce.Repositories
{
    public static class PedidoRepository
    {
        public static void Salvar(Pedido pedido)
        {
            BaseRepository.Command(pedido);
        }

        public static void Editar(Pedido pedido)
        {
            BaseRepository.Command(pedido, true);
        }

        public static void Delete(int id)
        {
            BaseRepository.Delete<Pedido>(id);
        }

        public static List<Pedido> Buscar(int idPedido = 0, int idCliente = 0)
        {
            string sql = @"select
                            p.id 
                            ,p.dataCriacao
                            ,p.dataEntrega
                            ,p.endereco
                            ,p.idEquipe
                            ,c.id
                            ,c.nome
                            ,c.contato               
                            from Pedido p
                            join cliente c
                            on p.idCliente = c.id";

            if (idPedido > 0)
            {
                sql += " where id = @idPedido";
            }

            if (idCliente > 0)
            {
                if (sql.Contains("where"))
                    sql += " and idCliente = @idCliente";
                else
                    sql += " where idCliente = @idCliente";
            }

            List<Pedido> orderDetail;
            using (var connection = new SqlConnection(BaseRepository.ConnectionString))
            {
                orderDetail = connection.Query<Pedido, Cliente, Equipe, Pedido>(sql, map: mapPropriedades, splitOn: "p.id", param: new { id = idPedido, idCliente = idCliente}).ToList();

            }

            const string sqlItem = @"select * from pedidoItem where idPedido = @idpedido";
            foreach(var item in orderDetail)
            {
                using (var connection = new SqlConnection(BaseRepository.ConnectionString))
                {
                    item.Itens.AddRange(connection.Query<PedidoItem>(sqlItem, param: new { idPedido = item.Id }).ToList());
                }
            }

            return orderDetail;
        }

        private static Pedido mapPropriedades(Pedido pedido, Cliente cliente, Equipe equipe)
        {
            pedido.Cliente = cliente;
            pedido.Equipe = equipe;
            return pedido;
        }
    }
}
