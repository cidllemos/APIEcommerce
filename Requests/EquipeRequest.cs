﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEcommerce.Requests
{
    public class EquipeRequest
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string PlacaVeiculo { get; set; }
    }
}
