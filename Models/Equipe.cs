using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEcommerce.Models
{
    [Table("Equipe")]
    public class Equipe : BaseModel
    {        
        [ExplicitKey]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string PlacaVeiculo { get; set; }
    }
}
