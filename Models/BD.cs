using System.Data.SqlClient;
using Dapper;
namespace TP6.Models;
public static class BD
{
    private static string ConnectionString = @"Server=localhost; DataBase=Elecciones2023; Trusted_Connection=True";
    public static void AgregarCandidato(Candidato can)
    {
        string sql = "Insert into Candidato(Apellido,Nombre,FechaNacimiento,Foto,Postulacion) values (@apellido, @nombre, @fechanacimiento, @foto. @postulacion)";
        using(SqlConnection db = new SqlConnection(ConnectionString))
        {
            db.Execute(sql, new{apellido = can.Apellido ,nombre = can.Nombre, fechaNacimiento = can.FechaNacimiento ,can.Foto, postulacion = can.Postulacion});
        }
    }
} 
