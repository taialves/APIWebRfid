using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RfidWebApi.Models
{
    public class ErroGrade
    {
        public string Sscc { get; set; }
        public List<string> GradeEsperada { get; set; }
        public List<string> GradeAtual { get; set; }
    }
}