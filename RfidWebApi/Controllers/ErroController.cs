using Newtonsoft.Json;
using RfidWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RfidWebApi.Controllers
{
    [RoutePrefix("api/erros")]
    public class ErroController : ApiController
    {
        // Adicionar um objeto
        [HttpPost]
        [Route("")]
        public IHttpActionResult AdicionarObjeto(Object obj)
        {
            if( obj is ErroDivergente)
                    ErroLeituraRepository.AdicionarErro((ErroDivergente)obj);
            else
            if (obj is ErroDuplicado)
                ErroLeituraRepository.AdicionarErro((ErroDuplicado)obj);
            else
            if (obj is ErroGrade)
                ErroLeituraRepository.AdicionarErro((ErroGrade)obj);
            else
            if (obj is ErroReutilizado)
                ErroLeituraRepository.AdicionarErro((ErroReutilizado)obj);
            else
            if (obj is ErroDivProgDoc)
                ErroLeituraRepository.AdicionarErro((ErroDivProgDoc)obj);
            return StatusCode(HttpStatusCode.Created);
        }

        // Consultar todos os objetos
        [HttpGet]
        [Route("")]
        public IHttpActionResult ConsultarObjetos()
        {

            var erros = ErroLeituraRepository.ObterErros();
            var errosJson = JsonConvert.SerializeObject(erros);
            return Ok(errosJson);
        }

        // Deletar um objeto por Sscc
        [HttpDelete]
        [Route("{sscc}")]
        public IHttpActionResult DeletarObjeto(string sscc)
        {
            var errosAll = ErroLeituraRepository.ObterErros();

            var objetoEncontrado = errosAll.Find(obj => obj.GetType().GetProperty("Sscc")?.GetValue(obj)?.ToString() == sscc);

            if (objetoEncontrado == null)
                return NotFound();

            ErroLeituraRepository.RemoveErro(objetoEncontrado);
            return Ok();
        }
    }
}
