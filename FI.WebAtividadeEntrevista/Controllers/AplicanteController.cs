using FI.AtividadeEntrevista.BLL;
using WebAtividadeEntrevista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FI.AtividadeEntrevista.DML;

namespace WebAtividadeEntrevista.Controllers
{
    public class AplicanteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Incluir(AplicanteModel model)
        {
            BllAplicante bo = new BllAplicante();

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }

            else
            {
                model.Id = bo.Incluir(new Aplicante()
                {
                    NomeCidade = model.NomeCidade,                   
                    Nome = model.Nome,              
                    Nota = model.Nota
                });

                return Json("Cadastro efetuado com sucesso");
            }

        }

        [HttpPost]
        public JsonResult Alterar(AplicanteModel model)
        {
            BllAplicante bo = new BllAplicante();

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                bo.Alterar(new Aplicante()
                {
                    Id = model.Id,
                    NomeCidade = model.NomeCidade,                
                    Nome = model.Nome,                    
                    Nota = model.Nota
                });
                return Json("Cadastro alterado com sucesso");
            }
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            BllAplicante bo = new BllAplicante();
            Aplicante aplicante = bo.Consultar(id);
            Models.AplicanteModel model = null;

            if (aplicante != null)
            {
                model = new AplicanteModel()
                {
                    Id = aplicante.Id,
                    NomeCidade = aplicante.NomeCidade,                    
                    Nome = aplicante.Nome,
                    Nota = aplicante.Nota
                };
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            BllAplicante bo = new BllAplicante();
            //Aplicante aplicante = bo.Excluir(id);

            bo.Excluir(id);

            Models.AplicanteModel model = null;

            //if (aplicante != null)
            //{
            //    model = new AplicanteModel()
            //    {
            //        Id = aplicante.Id,
            //        NomeCidade = aplicante.NomeCidade,
            //        Nome = aplicante.Nome,
            //        Nota = aplicante.Nota
            //    };
            //}

            return new HttpStatusCodeResult(204);
            //return Json("Cadastro Excluído com sucesso");

        }

        [HttpPost]
        public JsonResult AplicanteList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                int qtd = 0;
                string campo = string.Empty;
                string crescente = string.Empty;
                string[] array = jtSorting.Split(' ');

                if (array.Length > 0)
                    campo = array[0];

                if (array.Length > 1)
                    crescente = array[1];

                List<Aplicante> aplicantes = new BllAplicante().Pesquisa(jtStartIndex, jtPageSize, campo, crescente.Equals("ASC", StringComparison.InvariantCultureIgnoreCase), out qtd);

                //Return result to jTable
                return Json(new { Result = "OK", Records = aplicantes, TotalRecordCount = qtd });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}