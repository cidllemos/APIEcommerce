using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEcommerce.Models
{
    [Table("Cliente")]
    public class Cliente : BaseModel
    {
        [ExplicitKey]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Contato { get; set; }
    }
}
