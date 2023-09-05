using Curso.Dapper.ComEntity.Api.Application.Interfaces;
using Curso.Dapper.ComEntity.Api.Domain.Commands.Curso;
using Curso.Dapper.ComEntity.Api.Domain.Services.Interfaces;

namespace Curso.Dapper.ComEntity.Api.Application.Handlers.Commands.Curso;

public class CadastrarCursoCommandHandler : ICommandHandler<CadastrarCursoCommand>
{
    private readonly ICursoDapperDomainService _cursoDapperDomainService;

    public CadastrarCursoCommandHandler(ICursoDapperDomainService cursoDapperDomainService) 
        => _cursoDapperDomainService = cursoDapperDomainService;

    public async Task Handle(CadastrarCursoCommand command, CancellationToken cancellationToken)
    {
        //Validacao do command

        //Mapper para converter o command em entidade
        var curso = new Domain.Entities.Curso
        {
            Nome = command.Nome,
            Descricao = command.Descricao,
            Coordenador = command.Coordenador,
            Professor = command.Professor,
            TipoCurso = command.TipoCurso,
            DataCriacao = DateTime.Now
        };

        //Validacao do curso

        await _cursoDapperDomainService.CadastrarCurso(curso);
    }
}
