using ProjetoAgroCoops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAgroCoops.Controllers
{
    public class CooperativaController : Controller
    {
        BDAgriculturaEntities db = new BDAgriculturaEntities();
        // GET: Cooperativa
        public ActionResult cadastrar()
        {
            if (Session["LoginPessoa"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login", "Pessoa");
            }
        }

        [HttpPost]
        public ActionResult cadastrar(string nome,string telefone,string email,long cnpj,string cidade,string estado,string regiao)
        {
            if (Session["LoginPessoa"] != null)
            {
                cooperativa coop = new cooperativa();

                coop.nomeCooperativa = nome;
                coop.cnpjCooperativo = cnpj;
                coop.email = email;
                coop.cidade = cidade;
                coop.estado = estado;
                coop.regiao = regiao;

                db.cooperativa.Add(coop);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("login", "Pessoa");
            }
            
        }
        public ActionResult listar()
        {
            if (Session["LoginPessoa"] != null)
            {
                return View(db.cooperativa.ToList());
            }
            else
            {
                return RedirectToAction("login", "Pessoa");
            }
        }
    }
}