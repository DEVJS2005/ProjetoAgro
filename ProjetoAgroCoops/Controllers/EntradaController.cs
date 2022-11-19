using ProjetoAgroCoops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAgroCoops.Controllers
{
    public class EntradaController : Controller
    {
        BDAgriculturaEntities db = new BDAgriculturaEntities();
        // GET: Entrada
        public ActionResult cadastrar()
        {
            if (Session["LoginPessoa"] != null)
            {
                return View(db.produto.ToList());
            }
            else
            {
                return RedirectToAction("login", "Pessoa");
            }
        }


        public ActionResult adicionarCoop()
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

        [HttpPost]
        public ActionResult adicionarCoop(int id)
        {
            Session["idCoop"] = id;
            return RedirectToAction("cadastrar","Entrada");
        }

        [HttpPost]
        public ActionResult cadastrar(int carteiraProdutor, int quantidadeEntrada,int idProduto)
        {

            if (Session["LoginPessoa"] != null)
            {
                int idCoop = (int)Session["idCoop"];
                pessoaFisica pf = (pessoaFisica)Session["LoginPF"];
                produtor produtor = db.produtor.ToList().Find(x => x.idPessoaFisica == pf.idPessoa);
                entrada entrada = new entrada();
                entrada.quantidadeEntrada = quantidadeEntrada;
                entrada.idProduto = idProduto;
                entrada.idProdutor = produtor.idPessoaFisica;
                entrada.produtor = produtor;
                

                db.entrada.Add(entrada);
                db.SaveChanges();
                return View("listar");
            }
            else
            {
                return RedirectToAction("login", "Pessoa");
            }
        }
    }
}