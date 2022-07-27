using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InocuReports.Models;
using System.Data.SqlClient;
using inmobiscosts.Datos;

namespace InocuReports.Controllers
{
    public class InyeccionAdmin:Conexion
    {
        public void Guardar(Inyeccion modelo)
        {
            Conectar();
            try
            {


                SqlCommand comando = new SqlCommand("GuardarInyeccion", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@nombre", modelo.Nombre));
                comando.Parameters.Add(new SqlParameter("@marca", modelo.Marca));
                comando.Parameters.Add(new SqlParameter("@fecha_aplicacion", modelo.Fecha_aplicacion));
                comando.Parameters.Add(new SqlParameter("@numero_lote", modelo.Numero_lote));
                comando.Parameters.Add(new SqlParameter("@fecha_vencimiento", modelo.Fecha_vencimiento));
                comando.Parameters.Add(new SqlParameter("@lugar_aplicacion", modelo.Lugar_aplicacion));
                comando.Parameters.Add(new SqlParameter("@observaciones", modelo.Observaciones));
                comando.Parameters.Add(new SqlParameter("@cuestionario", modelo.Cuestionario));
                comando.ExecuteNonQuery();
                comando.Dispose();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
        }
        public List<Inyeccion> GetInyeccionById(int Id)
        {
            List<Inyeccion> lista = new List<Inyeccion>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("GetInyeccionById", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@id", Id));
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Inyeccion modelo = new Inyeccion()
                    {
                        Id = (int)reader[0],
                        Nombre = reader[1] + "",
                        Marca = reader[2] + "",
                        Fecha_aplicacion = reader[3] + "",
                        Numero_lote = reader[4] + "",
                        Fecha_vencimiento = reader[5] + "",
                        Lugar_aplicacion = reader[6] + "",
                        Observaciones = reader[7] + "",
                        Cuestionario = reader[8] + ""
                    };
                    lista.Add(modelo);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();


            }
            return lista;
        }
    }
}