using System;
using System.Collections.Generic;
using RfidWebApi.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RfidWebApi.Controllers
{
    public class CaixaController : ApiController
    {
        // GET: api/Caixa
        public IHttpActionResult Get()
        {
            var erros = ErroLeituraRepository.ObterErros();
            var errosJson = JsonConvert.SerializeObject(erros);
            return Ok(errosJson);
        }

        // GET: api/Caixa/5
        public string Get(string id)
        {
            ErroLeituraRepository.preencher();
            return "caixas populadas";
        }

        // POST: api/Caixa
        public IHttpActionResult Post([FromBody] JObject jsonObject)
        {
            var tipoProp = jsonObject["tipo"].Value<string>();
            var objeto = jsonObject["objeto"];

            switch (tipoProp)
            {
                case "ErroDivergente":
                    var erroDivergente = objeto.ToObject<ErroDivergente>();
                    ErroLeituraRepository.AdicionarErro(erroDivergente);
                    break;
                case "ErroDuplicado":
                    var erroDuplicado = objeto.ToObject<ErroDuplicado>();
                    ErroLeituraRepository.AdicionarErro(erroDuplicado);
                    break;
                case "ErroGrade":
                    var erroGrade = objeto.ToObject<ErroGrade>();
                    ErroLeituraRepository.AdicionarErro(erroGrade);
                    break;
                case "ErroReutilizado":
                    var erroReutilizado = objeto.ToObject<ErroReutilizado>();
                    ErroLeituraRepository.AdicionarErro(erroReutilizado);
                    break;
                case "ErroDivProgDoc":
                    var erroDivProgDoc = objeto.ToObject<ErroDivProgDoc>();
                    ErroLeituraRepository.AdicionarErro(erroDivProgDoc);
                    break;
                default:
                    // Tipo de objeto não suportado, tratar o erro aqui
                    return BadRequest("Tipo de objeto não suportado.");
            }

            return StatusCode(HttpStatusCode.Created);
        }

        // PUT: api/Caixa/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Caixa/5
        public IHttpActionResult Delete(string sscc)
        {
            var errosAll = ErroLeituraRepository.ObterErros();
            object objRemove = null;
            foreach(var obj in errosAll)
            {
                var tipo = obj.GetType();

                var prop =tipo.GetProperty("Sscc");
                var valor = prop.GetValue(obj);
                if (valor.ToString() == sscc)
                    objRemove = obj;
            }
            ErroLeituraRepository.RemoveErro(objRemove);

            // if (objetoEncontrado == null)
            //   return NotFound();


            return Ok();
        }
    }
}
//{
//    "tipo": "ErroDivergente",
//    "objeto": {
//        "QtdEsperada":5,
//        "QtdAtual":2,
//        "EtiquetasLidas":["ETIQA","ETIQB","ETIQC"],
//        "NumTam":["2324","1223","3435"],
//        "Sscc":"11111111133311112233"
//    }

//}