using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RfidWebApi.Models
{
    public class ErroReutilizado
    {
        public string SsccAtual { get; set; }
        public string SsccJaEmbalado { get; set; }
        public string CodEpc { get; set; }
        public string NumTam { get; set; }
    }
}