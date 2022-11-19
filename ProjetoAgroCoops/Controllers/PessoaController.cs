using Microsoft.Ajax.Utilities;
using ProjetoAgroCoops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAgroCoops.Controllers
{
    public class PessoaController : Controller
    {
        BDAgriculturaEntities db = new BDAgriculturaEntities();
        // GET: Pessoa
        
        public ActionResult Index()
        {
            if (Session["LoginPessoa"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login","Pessoa");
            }
            
        }
        public ActionResult Login() 
        {
            return View();
        
        }

        public ActionResult verificarLogin(string email, string senha) 
        {
            pessoa p = db.pessoa.ToList().Find(x => Equals(x.email,email));


            if(p != null & Equals(p.email,email) & Equals(p.senha,senha)  )
            {
                if(p.tipoPessoa == "F")
                {
                    pessoaFisica pf = db.pessoaFisica.Find(p.idPessoa);
                    Session.Add("LoginPF", pf);
                }
                else if(p.tipoPessoa == "J")
                {
                    pessoaJuridica pj = db.pessoaJuridica.Find(p.idPessoa);
                    Session.Add("LoginPJ", pj);
                }
                Session["LoginPessoa"] = "Liberado";
                return RedirectToAction("Index","Pessoa");
            }
            else
            {
                @ViewBag.errologin = " Login inválido ou usuario não enconstrado ";
                return RedirectToAction("Login","Pessoa");
            }
        }


        public ActionResult cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult cadastrar(string nome,long telefone,string email,string senha,string tipoPessoa)
        {
            pessoa p = db.pessoa.ToList().Find(x => Equals(x.nome, nome));
            pessoa p1 = new pessoa();

            if (p != null)
            {
                ViewBag.erroLogin = "Já existe um usuario com essas informações!!";
                return RedirectToAction("login", "Pessoa");
            }
                p1.nome = nome;
                p1.email = email;
                p1.telefone = telefone;
                p1.email = email;
                p1.senha = senha;
                p1.tipoPessoa = tipoPessoa;

                db.pessoa.Add(p1);
                db.SaveChanges();
            
                if (tipoPessoa == "F")
                {
                    return RedirectToAction("editar", "PessoaFisica",p1);
                }
                else
                {
                    return RedirectToAction("editar", "PessoaJuridica",p1);
                }
        }

    }
}