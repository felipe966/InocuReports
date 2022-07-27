using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InocuReports.Models;
using System.Data.SqlClient;
using inmobiscosts.Datos;

namespace InocuReports.Controllers
{
    public class ReporteAdmin:Conexion
    {
        public void Guardar(Reporte modelo)
        {
            Conectar();
            try
            {


                SqlCommand comando = new SqlCommand("GuardarReporte", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@codigo_registro", modelo.Codigo_registro));
                comando.Parameters.Add(new SqlParameter("@id_medico", modelo.Id_medico));
                comando.Parameters.Add(new SqlParameter("@id_clinica", modelo.Id_clinica));
                comando.Parameters.Add(new SqlParameter("@id_paciente", modelo.Id_paciente));
                comando.Parameters.Add(new SqlParameter("@id_inyeccion", modelo.Id_inyeccion));
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

        public IEnumerable<Reporte> GetReporteByCodigoRegistro(string Codigo_registro)
        {
            List<Reporte> lista = new List<Reporte>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("GetReporteByCodigoRegistro", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@codigo_registro", Codigo_registro));
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Reporte modelo = new Reporte()
                    {
                        Id = (int)reader[0],
                        Codigo_registro = reader[1] + "",
                        Id_medico = (int)reader[2],
                        Id_clinica = (int)reader[3],
                        Id_paciente = (int)reader[4],
                        Id_inyeccion = (int)reader[5],
                        Cuestionario = reader[6] + ""
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
            return lista.AsEnumerable();
        }

        public IEnumerable<Reporte> GetReporteById(int Id)
        {
            List<Reporte> lista = new List<Reporte>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("GetReporteById", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@id", Id));
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Reporte modelo = new Reporte()
                    {
                        Id = (int)reader[0],
                        Codigo_registro = reader[1] + "",
                        Id_medico = (int)reader[2],
                        Id_clinica = (int)reader[3],
                        Id_paciente = (int)reader[4],
                        Id_inyeccion = (int)reader[5],
                        Cuestionario = reader[6] + ""
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
            return lista.AsEnumerable();
        }


        public IEnumerable<Reporte> GetReportes()
        {
            List<Reporte> lista = new List<Reporte>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("GetReportes", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Reporte modelo = new Reporte()
                    {
                        Id = (int)reader[0],
                        Codigo_registro = reader[1] + "",
                        Id_medico = (int)reader[2],
                        Id_clinica = (int)reader[3],
                        Id_paciente = (int)reader[4],
                        Id_inyeccion = (int)reader[5],
                        Cuestionario = reader[6] + ""
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
            return lista.AsEnumerable();
        }
    }
}