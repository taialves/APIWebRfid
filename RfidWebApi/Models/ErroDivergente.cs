using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RfidWebApi.Models
{
    public class ErroDivergente
    {
        public int QtdEsperada { get; set; }
        public int QtdAtual { get; set; }
        public List<string> EtiquetasLidas { get; set; }
        public List<string> NumTam { get; set; }
        public string Sscc { get; set; }
    }
}