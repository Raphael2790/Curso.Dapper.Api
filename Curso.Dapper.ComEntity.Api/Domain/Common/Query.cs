namespace Curso.Dapper.ComEntity.Api.Domain.Common;

public abstract class Query
{
    public DateTime DataExecucao { get; private set; }

    protected Query()
    {
        DataExecucao = DateTime.Now;
    }
}
