using ProjetoAgroCoops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAgroCoops.Controllers
{
    public class PessoaJuridicaController : Controller
    {
        BDAgriculturaEntities db = new BDAgriculturaEntities();
        // GET: PessoaJuridica
        public ActionResult editar(pessoa p1)
        {
            pessoa p_ = db.pessoa.ToList().Find(x => Equals(x.idPessoa, p1.idPessoa));
            return View(p_);
        }

        [HttpPost]
        public ActionResult cadastrar(int id,long cnpj,string nomeFantasia)
        {
            pessoaJuridica pj = db.pessoaJuridica.ToList().Find(x => Equals(x.idPessoa, id));


            pj.cnpj = cnpj;
            pj.nomeFantasia = nomeFantasia; 

            db.SaveChanges();

            return RedirectToAction("Login", "Pessoa");
        }
    }
}