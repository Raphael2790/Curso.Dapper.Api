namespace Curso.Dapper.ComEntity.Api.Domain.Common;

public abstract class Command
{
    public DateTime DataExecucao { get; private set; }

    protected Command()
    {
        DataExecucao = DateTime.Now;
    }
}
