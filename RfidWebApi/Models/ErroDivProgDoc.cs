using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RfidWebApi.Models
{
    public class ErroDivProgDoc
    {
        public string Sscc { get; set; }
        public int Programa { get; set; }
        public int Documento { get; set; }
        public int QtdAtual { get; set; }
        public int QtdEsperada { get; set; }
        public List<string> Etiquetas { get; set; }
    }
}