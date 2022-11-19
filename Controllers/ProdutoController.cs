using ProjetoAgroCoops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAgroCoops.Controllers
{
    public class ProdutoController : Controller
    {
        BDAgriculturaEntities db = new BDAgriculturaEntities();
        // GET: Produto
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
        public ActionResult cadastrar(string descricaoProduto)
        {
            produto prod = new produto();

            prod.descricaoProduto = descricaoProduto;

            db.produto.Add(prod);
            db.SaveChanges();

            return View("listar",db.produto.ToList());
        }

        public ActionResult listar()
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

        public ActionResult excluir(int id)
        {
            if (Session["LoginPessoa"] != null)
            {
                estoque estoque = db.estoque.ToList().Find(x => x.idProduto == id);
                db.estoque.Remove(estoque);
                db.SaveChanges();

                return View("listar",db.produto.ToList());
            }
            else
            {
                return RedirectToAction("login", "Pessoa");
            }
        }

        public ActionResult adicionarEstoque(int id)
        {
            if (Session["LoginPessoa"] != null)
            {
                estoque estoque = db.estoque.ToList().Find(x => x.idProduto == id);
                return View(estoque);
            }
            else
            {
                return RedirectToAction("login", "Pessoa");
            }
        }

        [HttpPost]
        public ActionResult adicionarEstoque(int id,string descricaoProduto,int quantidadeProduto)
        {
            if (Session["LoginPessoa"] != null)
            {
                estoque prodEstoque = db.estoque.ToList().Find(x => x.idProduto == id);
                produto prod = db.produto.ToList().Find(x => x.idProduto == id); 

                prodEstoque.idProduto = id; 
                prodEstoque.quantidadeEstoque = quantidadeProduto;

                if (Equals(prod.descricaoProduto, descricaoProduto))
                {
                }
                else
                {
                    prod.idProduto = id;
                    prod.descricaoProduto = descricaoProduto;
                }

                db.SaveChanges();
                return View("lista",db.produto.ToList());

            }
            else
            {
                return RedirectToAction("login", "Pessoa");
            }
        }

    }
}