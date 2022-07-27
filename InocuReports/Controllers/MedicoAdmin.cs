using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InocuReports.Models;
using System.Data.SqlClient;
using inmobiscosts.Datos;

namespace InocuReports.Controllers
{
    public class MedicoAdmin:Conexion
    {
        public void Guardar(Medico modelo)
        {
            Conectar();
            try
            {
                

                SqlCommand comando = new SqlCommand("GuardarMedico", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@identificacion", modelo.Identificacion));
                comando.Parameters.Add(new SqlParameter("@codigo_profesional", modelo.Codigo_profesional));
                comando.Parameters.Add(new SqlParameter("@nombre_completo", modelo.Nombre_completo));
                comando.Parameters.Add(new SqlParameter("@email", modelo.Email));
                comando.Parameters.Add(new SqlParameter("@pais", modelo.Pais));
                comando.Parameters.Add(new SqlParameter("@estado_provincia", modelo.Estado_provincia));
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

        public IEnumerable<Medico> GetMedicoByCodigoProfesional(string Codigo_profesional)
        {
            List<Medico> lista = new List<Medico>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("GetMedicoByCodigoProfesional", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@codigo_profesional", Codigo_profesional));
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Medico modelo = new Medico()
                    {
                        Id = (int)reader[0],
                        Identificacion = reader[1] + "",
                        Codigo_profesional = reader[2] + "",
                        Nombre_completo = reader[3] + "",
                        Email = reader[4] + "",
                        Pais = reader[5] + "",
                        Estado_provincia = reader[6] + ""
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
        public IEnumerable<Medico> GetMedicoByIdentificacion(string Identificacion)
        {
            List<Medico> lista = new List<Medico>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("GetMedicoByIdentificacion", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@identificacion", Identificacion));
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Medico modelo = new Medico()
                    {
                        Id = (int)reader[0],
                        Identificacion = reader[1] + "",
                        Codigo_profesional = reader[2] + "",
                        Nombre_completo = reader[3] + "",
                        Email = reader[4] + "",
                        Pais = reader[5] + "",
                        Estado_provincia = reader[6] + ""
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

        public IEnumerable<Medico> GetMedicos()
        {
            List<Medico> lista = new List<Medico>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("GetMedicos", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Medico modelo = new Medico()
                    {
                        Id = (int)reader[0],
                        Identificacion = reader[1] + "",
                        Codigo_profesional = reader[2]+"",
                        Nombre_completo = reader[3] + "",
                        Email = reader[4] + "",
                        Pais = reader[5] + "",
                        Estado_provincia = reader[6] + ""
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