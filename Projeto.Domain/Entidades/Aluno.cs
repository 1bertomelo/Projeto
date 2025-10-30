using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Entidades
{
    public class Aluno
    {
        public Aluno(int idAluno,string nome, string cpf, string matricula, string email)
        {
            this.idAluno = idAluno;
            this.nome = nome;
            this.cpf = cpf;
            this.matricula = matricula;
            this.email = email;
        }

        public int idAluno { get; private set; }
        public string nome { get; private set; }
        public string cpf { get; private set; }
        public string matricula { get; private set; }
        public string email { get; private set; }

    }
}
