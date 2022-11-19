using ProjetoAgroCoops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAgroCoops.Controllers
{
    public class ProdutorController : Controller
    {
        BDAgriculturaEntities db = new BDAgriculturaEntities(); 
        // GET: Produtor
        public ActionResult cadastrar()
        {
            if (Session["LoginPessoa"] != null)
            {
                pessoaFisica pf = (pessoaFisica)Session["LoginPF"];
                return View(pf);
            }
            else
            {
                return RedirectToAction("login", "Pessoa");
            }
        }

        [HttpPost]
        public ActionResult cadastrar(int idPessoa,long carteiraProdutor)
        {
            produtor produtor = new produtor();
            pessoaFisica pf = db.pessoaFisica.Find(idPessoa);

            if (pf != null)
            {
                produtor.idPessoaFisica = idPessoa;
                produtor.carteiraProdutor = carteiraProdutor;
                produtor.pessoaFisica = pf;

                db.produtor.Add(produtor);
                db.SaveChanges();
                
            }
            return RedirectToAction("listar","Produtor",idPessoa);
        }
        public ActionResult listar(int idPessoa)
        {
            if (Session["LoginPessoa"] != null)
            {
                return View(db.produtor.Find(idPessoa));
            }
            else
            {
                return RedirectToAction("login", "Pessoa");
            }
        }
    }
}