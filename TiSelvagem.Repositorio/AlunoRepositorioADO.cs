using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TiSelvagem.Dominio;
using TiSelvagem.Dominio.contrato;
using TiSelvagem.Repositorio;

namespace TiSelvagem.RepositorioADO
{
    public class AlunoRepositorioADO:IRepositorio<Aluno>
    {
        private Contexto contexto;

        private void Insert(Aluno aluno)
        {
            var strQuery = "";
            strQuery += "INSERT INTO ALUNO (Nome, Mae, DataNascimento)";
            strQuery += string.Format("VALUES ('{0}', '{1}', '{2}')", aluno.Nome, aluno.Mae, aluno.DataNascimento);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public IEnumerable<Aluno> Select()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "SELECT * FROM ALUNO";
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmLista(retornoDataReader);
            }
        }

        public Aluno ListarPorId(string id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format("SELECT * FROM ALUNO WHERE AlunoId = {0}", id);
                var retornoDataReader = contexto.ExecutaComandoComRetorno(strQuery);
                return TransformaReaderEmLista(retornoDataReader).FirstOrDefault();
            }
        }

        private void Update(Aluno aluno)
        {
            var strQuery = "";
            strQuery += string.Format
                ("UPDATE ALUNO SET Nome = '{0}', Mae = '{1}', DataNascimento = '{2}' WHERE AlunoId = {3}", aluno.Nome, aluno.Mae, aluno.DataNascimento, aluno.Id);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Aluno aluno)
        {
            if (aluno.Id > 0)
            {
                Update(aluno);
            }
            else
            {
                Insert(aluno);
            }
        }

        public void Excluir(Aluno aluno)
        {
            var strQuery = string.Format("DELETE FROM ALUNO WHERE AlunoId = {0}", aluno.Id);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        private List<Aluno> TransformaReaderEmLista(SqlDataReader reader)
        {
            var alunos = new List<Aluno>();
            while (reader.Read())
            {
                var temObjeto = new Aluno()
                {
                    Id = int.Parse(reader["AlunoId"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Mae = reader["Mae"].ToString(),
                    DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString())
                };
                alunos.Add(temObjeto);
            }
            return alunos;
        }
    }
}
