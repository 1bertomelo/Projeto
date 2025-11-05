using Microsoft.AspNetCore.Mvc;
using Projeto.API.Dto.Request;
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
            return _alunoService.ObterTodos();
        }

        [HttpPost("api/aluno/adicionar")]
        public IActionResult Adicionar(NovoAlunoRequest novoAlunoRequest) 
        {
            _alunoService.Adicionar(
                new Domain.Entidades.Aluno(
                    0,
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
            _alunoService.Atualizar(new Domain.Entidades.Aluno(
                    atualizarAlunoRequest.idAluno,
                    atualizarAlunoRequest.nome,
                    atualizarAlunoRequest.cpf,
                    atualizarAlunoRequest.matricula,
                    atualizarAlunoRequest.email)
               );
            return Ok("Aluno atualizado com sucesso");

        }
    }
}
