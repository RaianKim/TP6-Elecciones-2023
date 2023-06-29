using System.Data.SqlClient;
using Dapper;
namespace TP6.Models;
public static class BD
{
    private static string ConnectionString = @"Server=localhost; DataBase=Elecciones2023; Trusted_Connection=True";
    public static void AgregarCandidato(Candidato can)
    {
        string sql = "INSERT INTO Candidato(Apellido,Nombre,FechaNacimiento,Foto,Postulacion) VALUES (@apellido, @nombre, @fechanacimiento, @foto. @postulacion)";
        using(SqlConnection db = new SqlConnection(ConnectionString))
        {
            db.Execute(sql, new{apellido = can.Apellido ,nombre = can.Nombre, fechaNacimiento = can.FechaNacimiento ,can.Foto, postulacion = can.Postulacion});
        }
    }
    public static void EliminarCandidato(int idCandidato)
    {
        string sql = "DELETE FROM Candidato WHERE IdCandidato = @iidCandidato";
        using(SqlConnection db = new SqlConnection(ConnectionString))
        {
            db.Execute(sql, new{iidCandidato = idCandidato});
        }
    }
    public static Partido VerInfoPartido(int idPartido)
    {
        Partido partido = null;
        string sql = "SELECT * FROM Partido WHERE IdParido = @iidPartido";
        using(SqlConnection db = new SqlConnection(ConnectionString))
        {
            partido = db.QueryFirstOrDefault<Partido>(sql, new { iidPartido = idPartido});
        }
        return partido;
    }
    public static Candidato VerInfoCandidato(int idCandidato)
    {
        Candidato candidato = null;
        string sql = "SELECT * FROM Partido WHERE IdParido = @iidPartido";
        using(SqlConnection db = new SqlConnection(ConnectionString))
        {
            candidato = db.QueryFirstOrDefault<Candidato>(sql, new { iidcandidato = idCandidato});
        }
        return candidato;
    }
    public static List<Partido> ListarPartidos()
    {
        List<Partido> listapartido = new List<Partido>();
        string sql = "SELECT * FROM Partido";
        using(SqlConnection db = new SqlConnection(ConnectionString))
        {
            listapartido = db.Query<Partido>(sql).ToList();
        }
        return listapartido;
    }
    public static List<Candidato> ListarCandidatos(int idPartido)
    {
        List<Candidato> listarpartidos = new List<Candidato>();
        string sql = "SELECT * FROM Partido WHERE IdPartido = @iidPartido";
        using(SqlConnection db = new SqlConnection(ConnectionString))
        {
            
            listarpartidos = db.Query<Candidato>(sql, new{iidPartido = idPartido}).ToList();
        }
        return listarpartidos;
    }
}
