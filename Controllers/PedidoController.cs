using ProjetoAgroCoops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAgroCoops.Controllers
{
    public class PedidoController : Controller
    {
        BDAgriculturaEntities bd = new BDAgriculturaEntities();
        // GET: Pedido

        public ActionResult addProduto(int id)
        {
            bool objProduto = false;

            pedido pedido = Session["carrinho"] != null ? (pedido)Session["carrinho"] : new pedido();

            produto produto = bd.produto.Find(id);

            if (produto != null)
            {
                pedidoEstoque pedProd = new pedidoEstoque();
                pedProd.produto = produto;
                pedProd.quantidade = 1;

                foreach (var obj in pedido.pedidoEstoque)
                {
                    if (obj.produto.idProduto == produto.idProduto)
                    {
                        obj.quantidade += 1;
                        objProduto = true;
                        break;
                    }

                }

                if (objProduto == false)
                {
                    pedido.pedidoEstoque.Add(pedProd);
                }



                Session["carrinho"] = pedido;

            }

            return RedirectToAction("Carrinho");
        }

        public ActionResult Carrinho()
        {
            pedido pedido = Session["carrinho"] != null ? (pedido)Session["carrinho"] : new pedido();
            return View(pedido);
        }

        public ActionResult finalizarPedido(int id)
        {
            produto prod = bd.produto.ToList().Find(x => x.idProduto == id);
            pessoa p = bd.pessoa.ToList().Find(x => x.idPessoa == (int)Session["idUsuario"]);
            pedido pedido = new pedido();
            pedido.idPessoa = p.idPessoa;
            pedido.dataPedido = DateTime.Now;
            pedido.status = "N";
            bd.pedido.Add(pedido);
            return View("TelaFinalizado");
        }
    }
}