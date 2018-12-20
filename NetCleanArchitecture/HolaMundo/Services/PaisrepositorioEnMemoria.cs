using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CustomerApp.Infrastructure.Data.SqlHelper;
using HolaMundo.Models;


namespace HolaMundo.Services
{
    public class PaisrepositorioEnMemoria : IRepositorioPais
    {
        private IDbSqlConnection _connection;

        public PaisrepositorioEnMemoria(IDbSqlConnection connection)
        {
            _connection = connection;
        }


        public List<Pais> ObtenerTodos()
        {
            
            var paises = new List<Pais>();

            var pars = new SqlHelper.Params();
            pars.Add("Id", 5);

            //var connectionSql = new SqlHelper(_connection.ConnectionString);
            var procedure = "dbo.GetPaises";

            using (var reader = SqlHelper.ExecuteReader(_connection.ConnectionString, procedure))
            {
                while (reader.Read())
                {
                    var pais = new Pais();

                    if (reader.IsColumnExists("Id"))
                        pais.Id = SqlParse.GetNullableInt32(reader, "Id");

                    if (reader.IsColumnExists("Nombre"))
                        pais.Nombre = SqlParse.GetNullableString(reader, "Nombre");

                    paises.Add(pais);

                }
            }
                          
            //connectionSql.CloseConnection();

            return paises;

        }
    }
}
