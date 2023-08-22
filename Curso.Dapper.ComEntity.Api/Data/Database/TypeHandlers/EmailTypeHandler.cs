using Curso.Dapper.ComEntity.Api.Domain.ValueObjects;
using Dapper;
using System.Data;

namespace Curso.Dapper.ComEntity.Api.Data.Database.TypeHandlers;

public class EmailTypeHandler : SqlMapper.TypeHandler<Email>
{
    public override Email Parse(object value)
    {
        return new Email(value.ToString()!);
    }

    public override void SetValue(IDbDataParameter parameter, Email value)
    {
        parameter.Value = value.Endereco;
    }
}