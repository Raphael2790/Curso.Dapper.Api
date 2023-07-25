﻿using Curso.Dapper.Api.Entidades;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Curso.Dapper.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TurnosController : ControllerBase
{
    public readonly string _connectionString;

    public TurnosController(IConfiguration configuration)
        => _connectionString = configuration.GetConnectionString("DefaultConnection")!;

    [HttpGet(Name = "ObterTurnosComProcedure")]
    public async Task<IActionResult> Obter()
    {
        using var connection = new SqlConnection(_connectionString);
        var nomeProc = "dbo.ObterTurnos";

        var turnos = await connection.QueryAsync<Turno>(nomeProc, commandType: CommandType.StoredProcedure);
        return Ok(turnos);
    }

    [HttpGet("{id}", Name = "ObterTurnoPorIdProcedure")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var nomeProc = "dbo.ObterTurnoPorId";

        var turno = await connection.QueryFirstOrDefaultAsync<Turno>(nomeProc, new { id }, 
            commandType: CommandType.StoredProcedure);
        return Ok(turno);
    }

    [HttpPost(Name = "InserirTurnoProcedure")]
    public async Task<IActionResult> Inserir(Turno turno)
    {
        using var connection = new SqlConnection(_connectionString);
        var nomeProc = "dbo.InserirTurno";

        var id = await connection.ExecuteScalarAsync<int>(nomeProc, new { turno.Nome }, 
            commandType: CommandType.StoredProcedure);
        return CreatedAtRoute("ObterPorId", new { id }, turno);
    }

    [HttpPut("{id}", Name = "AtualizarTurnoProcedure")]
    public async Task<IActionResult> Atualizar(int id, Turno turno)
    {
        using var connection = new SqlConnection(_connectionString);
        var nomeProc = "dbo.AtualizarTurno";

        var linhasAfetadas = await connection.ExecuteScalarAsync<int>(nomeProc, new { id, turno.Nome },
            commandType: CommandType.StoredProcedure);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "ExcluirTurnoProcedure")]
    public async Task<IActionResult> Excluir(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        var nomeProc = "dbo.ExcluirTurno";

        var linhasAfetadas = await connection.ExecuteScalarAsync<int>(nomeProc, new { id },
                       commandType: CommandType.StoredProcedure);
        return NoContent();
    }
}
