using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TiSelvagem.Dominio;
using TiSelvagem.Dominio.contrato;
using TiSelvagem.Repositorio;
using TiSelvagem.RepositorioADO;

namespace TiSelvagem.Aplicacao
{
    public class AlunoAplicacao
    {
        private readonly IRepositorio<Aluno> repositorio;

        public AlunoAplicacao(IRepositorio<Aluno> repo)
        {
            repositorio = repo;
        }

        public IEnumerable<Aluno> Select()
        {
            return repositorio.Select();
        }

        public Aluno ListaAluno(string id)
        {
            return repositorio.ListarPorId(id);
        }

        public void Salvar(Aluno aluno)
        {
            repositorio.Salvar(aluno);
        }

        public void Delete(Aluno aluno)
        {
            repositorio.Excluir(aluno);
        }

    }
}
