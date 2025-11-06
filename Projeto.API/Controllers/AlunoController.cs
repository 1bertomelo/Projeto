using Microsoft.AspNetCore.Mvc;
using Projeto.API.Dto.Request;
using Projeto.Domain.Entidades;
using Projeto.Domain.Interfaces;

namespace Projeto.API.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet("api/aluno/obter-todos")]
        public IActionResult ObterTodos()
        {
            var listaAlunos = _alunoService.ObterTodos();
           
            if(listaAlunos is null) return NotFound("Nenhum aluno encontrado");
            
            return Ok(listaAlunos);
        }

        [HttpGet("api/aluno/obter-por-id/{id}")]
        public IActionResult ObterPorId(int idAluno)
        {
           var aluno = _alunoService.ObterPorId(idAluno);

            if(aluno is null) return NotFound("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpGet("api/aluno/obter-por-cpf/{cpf}")]
        public IActionResult ObterPorCpf(string cpf)
        {
            var aluno = _alunoService.ObterPorCpf(cpf);

            if(aluno is null) return NotFound("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpGet("api/aluno/obter-por-matricula/{matricula}")]
        public IActionResult ObterPorMatricula(string matricula)
        {
            Aluno aluno = _alunoService.ObterPorMatricula(matricula);

            if(aluno is null) return NotFound("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpDelete("api/aluno/remover")]
        public IActionResult Remover(int idAluno)
        {
            var aluno = _alunoService.ObterPorId(idAluno);

            if(aluno is null) return NotFound("Aluno não encontrado");

            _alunoService.Deletar(idAluno);

            return NoContent();
        }


        [HttpPost("api/aluno/adicionar")]
        public IActionResult Adicionar(NovoAlunoRequest novoAlunoRequest) 
        {
            _alunoService.Adicionar(
                AlunoFactory.NovoAluno(
                    novoAlunoRequest.nome, 
                    novoAlunoRequest.cpf, 
                    novoAlunoRequest.matricula, 
                    novoAlunoRequest.email
                ));

            return Ok("Aluno inserido com sucesso");        
        }

        [HttpPut("api/aluno/atualizar")]
        public IActionResult Atualizar(AtualizarAlunoRequest atualizarAlunoRequest)
        {
            _alunoService.Atualizar(
                AlunoFactory.AlunoExistente(
                    atualizarAlunoRequest.idAluno,
                    atualizarAlunoRequest.nome,
                    atualizarAlunoRequest.cpf,
                    atualizarAlunoRequest.matricula,
                    atualizarAlunoRequest.email
                )
               );
            return Ok("Aluno atualizado com sucesso");

        }
    }
}
