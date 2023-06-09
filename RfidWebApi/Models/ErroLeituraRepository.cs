using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RfidWebApi.Models
{
    public class ErroLeituraRepository
    {
        private static List<object> erros = new List<object>();
        private static readonly object lockObj = new object();


        

        public static void AdicionarErro(object erro)
        {
            lock (lockObj)
            {
                erros.Add(erro);
            }
        }

        public static void preencher()
        {
            erros.Add(new ErroDivergente
            {
                Sscc = "12876468876970497745984",
                EtiquetasLidas = new List<string> { "ETIQ1", "ETIQ2", "ETIQ3" },
                NumTam = new List<string> { "2324", "1223", "3435" },
                QtdAtual = 11,
                QtdEsperada = 12
            });
            erros.Add(new ErroDivergente
            {
                Sscc = "4554656764334343456",
                EtiquetasLidas = new List<string> { "ETIQ4", "ETIQ5", "ETIQ6" },
                NumTam = new List<string> { "1010", "1212", "2343" },
                QtdAtual = 10,
                QtdEsperada = 12
            });
        }
        public static List<object> ObterErros()
        {
            
            lock (lockObj)
            {
                return erros;
            }
        }

        public static void RemoveErro(object objetoEncontrado)
        {

            lock (lockObj)
            {
                erros.Remove(objetoEncontrado);
            }
        }
    }
}