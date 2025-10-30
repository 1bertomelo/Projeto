using Projeto.Domain.Entidades;
using Projeto.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Repositorios
{
    public class AlunoRepository : IAlunoRepository
    {
        public void Adicionar(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idAluno)
        {
            throw new NotImplementedException();
        }

        public Aluno ObterPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public Aluno ObterPorId(int idAluno)
        {
            throw new NotImplementedException();
        }

        public Aluno ObterPorMatricula(string matricula)
        {
            throw new NotImplementedException();
        }

        public List<Aluno> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
