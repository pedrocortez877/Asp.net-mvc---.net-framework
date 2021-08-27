using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiSelvagem.Aplicacao;
using TiSelvagem.Dominio;

namespace TiSelvagem.UI.Web.Controllers
{
    public class AlunoController : Controller
    {
        private AlunoAplicacao appAluno;

        public AlunoController()
        {
            appAluno = AlunoAplicacaoConstrutor.AlunoAplicacaoEF();
        }

        // GET: Default
        public ActionResult Index()
        {
            var listaDeAlunos = appAluno.Select();
            Console.WriteLine(listaDeAlunos);
            return View(listaDeAlunos);
        }

        //GET: Cadastrar
        public ActionResult Cadastrar()
        {
            return View();
        }

        //POST: Cadastrar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                appAluno.Salvar(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        //GET: Editar
        public ActionResult Editar(string id)
        {
            var aluno = appAluno.ListaAluno(id);

            if (aluno == null)
                return HttpNotFound();

            return View(aluno);
        }

        //POST: Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                appAluno.Salvar(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        //GET: Detalhes
        public ActionResult Detalhes(string id)
        {
            var aluno = appAluno.ListaAluno(id);

            if (aluno == null)
                return HttpNotFound();

            return View(aluno);
        }

        //GET: Excluir
        public ActionResult Excluir(string id)
        {
            var aluno = appAluno.ListaAluno(id);

            if (aluno == null)
                return HttpNotFound();

            return View(aluno);
        }

        //POST: Excluir
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(string id)
        {
            var aluno = appAluno.ListaAluno(id);
            appAluno.Delete(aluno);
            return RedirectToAction("Index");
        }
    }
}