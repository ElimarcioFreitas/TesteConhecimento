using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questao5.Modelo
{
    public class Movimento
    {

        public int idmovimento {get; set; }
        public int idcontacorrente {get; set; }
        public datetime datamovimento {get; set; }
        public string tipomovimento {get; set; }
        public double valor {get; set; }

    }

}