using ProjetoAgroCoops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAgroCoops.Controllers
{
    public class AgricultorController : Controller
    {
        BDAgriculturaEntities db = new BDAgriculturaEntities();
        // GET: Agricultor
        public ActionResult Index()
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
        public ActionResult verificarCpf(long cpf)
        {
            pessoaFisica pf = db.pessoaFisica.ToList().Find(x => x.cpf == cpf);
            if(pf != null)
            {
                return RedirectToAction("cadastrar", "Agricultor", pf);
            }


            Session["LoginPessoa"] = null;
            return RedirectToAction("Login","Pessoa");

        }

        public ActionResult cadastrar(pessoaFisica pf)
        {
            if (Session["LoginPessoa"] != null)
            {
                return View(pf);
            }
            else
            {
                return RedirectToAction("login", "Pessoa");
            }
        }

        [HttpPost]
        public ActionResult cadastrar(int id, long carteiraProdutor) 
        {
            produtor produtor = new produtor();

            produtor.idPessoaFisica = id;
            produtor.carteiraProdutor = carteiraProdutor;

            db.produtor.Add(produtor);
            db.SaveChanges();

            return RedirectToAction("index","Home");
        }
    }
}