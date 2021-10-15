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

        public static List<Pedido> Buscar(int idPedido = 0, int idEquipe = 0, int idCliente = 0)
        {
            string sql = @"select pe.idPedido, pe.dataCriacao, pe.dataEntrega, pe.endereco, pe.idEquipe, eq.idEquipe, eq.nome, eq.descricao, eq.placaVeiculo, pe.idCliente, c.idCliente, c.nome, c.contato from Pedido pe                                                        
                            join Equipe eq
                            on pe.idEquipe = eq.idEquipe
                            join Cliente c
                            on pe.idCliente = c.idCliente";

            if (idPedido > 0)
            {
                sql += " where idPedido = @idPedido";
            }

            if (idEquipe > 0)
            {
                if (sql.Contains("where"))
                    sql += " and idEquipe = @idEquipe";
                else
                    sql += " where idEquipe = @idEquipe";
            }

            if (idCliente > 0)
            {
                if (sql.Contains("where"))
                    sql += " and idEquipe = @idEquipe";
                else
                    sql += " where idEquipe = @idEquipe";
            }

            List<Pedido> orderDetail;
            using (var connection = new SqlConnection(BaseRepository.ConnectionString))
            {
                orderDetail = connection.Query<Pedido, Equipe, Cliente, Pedido>(sql, map: MapPropriedades, splitOn: "idEquipe, idCliente", param: new { idPedido = idPedido, idEquipe = idEquipe, idCliente = idCliente }).ToList();
            }

            const string sqlItem = @"select idPedidoItem, idPedido, valor, quantidade from pedidoItem where idPedido = @idpedido";

            foreach (var item in orderDetail)
            {
                using (var connection = new SqlConnection(BaseRepository.ConnectionString))
                {
                    var pedidoItem = (connection.Query<PedidoItem>(sqlItem, param: new { idPedido = item.IdPedido }).ToList());                    
                    item.Itens.AddRange(pedidoItem);

                    const string sqlProd = @"select pr.idProduto, pr.nome, pr.descricao, pr.valorUnitario from Produto pr 
                                            join PedidoItem pi on pr.idProduto = pi.idProduto join Pedido p on p.IdPedido = pi.idPedido where p.idPedido = @idPedido";
                    
                    foreach (var itemProd in pedidoItem)
                    {
                        Produto prodDetail = connection.Query<Produto>(sqlProd, new { idPedido = itemProd.IdPedido,  }).FirstOrDefault();
                        itemProd.Produto = prodDetail;
                    }
                }
            }
            
            return orderDetail;
        }

        private static Pedido MapPropriedades(Pedido pedido, Equipe equipe, Cliente cliente)
        {
            pedido.Equipe = equipe;
            pedido.Cliente = cliente;
            return pedido;
        }

    }
}
