using Projeto.Domain.Entidades;
using Projeto.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public void Adicionar(Aluno aluno)
        {
            Aluno buscaAluno = _alunoRepository
                .ObterPorCpf(aluno.cpf);
            if(buscaAluno != null)
            {
                throw new Exception("Já existe um aluno " +
                    "cadastrado com esse CPF.");
            }
            buscaAluno = _alunoRepository
                .ObterPorMatricula(aluno.matricula);
            if(buscaAluno != null)
            {
                throw new Exception("Já existe um aluno " +
                    "cadastrado com essa matrícula.");
            }
            _alunoRepository.Adicionar(aluno);
        }

        public void Atualizar(Aluno aluno)
        {
            Aluno buscaAluno = _alunoRepository
                .ObterPorId(aluno.idAluno);

            if(buscaAluno == null)
            {
                throw new Exception("Aluno não encontrado.");
            }

            buscaAluno = _alunoRepository
                .ObterPorCpf(aluno.cpf);

            if(buscaAluno != null &&
                buscaAluno.idAluno != aluno.idAluno)
            {
                throw new Exception("Já existe um aluno " +
                    "cadastrado com esse CPF.");
            }

            buscaAluno = _alunoRepository
                .ObterPorMatricula(aluno.matricula);
    
            if(buscaAluno != null &&
                buscaAluno.idAluno != aluno.idAluno)
            {
                throw new Exception("Já existe um aluno " +
                    "cadastrado com essa matrícula.");
            }
            _alunoRepository.Atualizar(aluno);
        }

        public void Deletar(int idAluno)
        {
            Aluno buscaAluno = _alunoRepository
                .ObterPorId(idAluno);
            if(buscaAluno == null)
            {
                throw new Exception("Aluno não encontrado.");
            }
            _alunoRepository.Deletar(idAluno);
        }

        public Aluno ObterPorCpf(string cpf)
        {
            return _alunoRepository.ObterPorCpf(cpf);
        }

        public Aluno ObterPorId(int idAluno)
        {
            return _alunoRepository.ObterPorId(idAluno);
        }

        public Aluno ObterPorMatricula(string matricula)
        {
           return _alunoRepository.ObterPorMatricula(matricula);
        }

        public List<Aluno> ObterTodos()
        {
           return _alunoRepository.ObterTodos();
        }
    }
}
