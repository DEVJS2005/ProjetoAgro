using ProjetoAgroCoops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAgroCoops.Controllers
{
    public class PessoaFisicaController : Controller
    {
        BDAgriculturaEntities db = new BDAgriculturaEntities();
        // GET: PessoaFisica
        public ActionResult editar(pessoa p1)
        {
            pessoa p_ = db.pessoa.ToList().Find(x => Equals(x.idPessoa,p1.idPessoa));
            return View(p_);
        }

        [HttpPost]
        public ActionResult cadastrar(int id,long cpf,string sexo,DateTime dataNascimento)
        {
            pessoaFisica pf = db.pessoaFisica.Find(id);

            pf.idPessoa = id;
            pf.cpf = cpf;
            pf.sexo = sexo;
            pf.dataNascimento = dataNascimento;

            db.SaveChanges();

            return RedirectToAction("Login","Pessoa");
        }
    }
}