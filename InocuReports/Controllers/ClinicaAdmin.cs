using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InocuReports.Models;
using System.Data.SqlClient;
using inmobiscosts.Datos;

namespace InocuReports.Controllers
{
    public class ClinicaAdmin:Conexion
    {
        public void Guardar(Clinica modelo)
        {
            Conectar();
            try
            {


                SqlCommand comando = new SqlCommand("GuardarClinica", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@nombre", modelo.Nombre));
                comando.Parameters.Add(new SqlParameter("@cedula_juridica", modelo.Cedula_juridica));
                comando.Parameters.Add(new SqlParameter("@distrito", modelo.Distrito));
                comando.Parameters.Add(new SqlParameter("@email", modelo.Email));
                comando.Parameters.Add(new SqlParameter("@pais", modelo.Pais));
                comando.Parameters.Add(new SqlParameter("@estado_provincia", modelo.Estado_provincia));
                comando.Parameters.Add(new SqlParameter("@telefono", modelo.Telefono));
                comando.Parameters.Add(new SqlParameter("@sitio_web", modelo.Sitio_web));
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

        public List<Clinica> GetClinicaByNombre(string Nombre)
        {
            List<Clinica> lista = new List<Clinica>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("GetClinicaByNombre", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@nombre", Nombre));
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Clinica modelo = new Clinica()
                    {
                        Id = (int)reader[0],
                        Nombre = reader[1] + "",
                        Cedula_juridica = reader[2] + "",
                        Pais = reader[3] + "",
                        Estado_provincia = reader[4] + "",
                        Distrito = reader[5] + "",
                        Telefono = reader[6] + "",
                        Email = reader[5] + "",
                        Sitio_web = reader[5] + ""
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
        public List<Clinica> GetClinicasByIdentificacion(string Identificacion)
        {
            List<Clinica> lista = new List<Clinica>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("GetClinicasByIdentificacion", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@identificacion", Identificacion));
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Clinica modelo = new Clinica()
                    {
                        Id = (int)reader[0],
                        Nombre = reader[1] + "",
                        Cedula_juridica = reader[2] + "",
                        Pais = reader[3] + "",
                        Estado_provincia = reader[4] + "",
                        Distrito = reader[5] + "",
                        Telefono = reader[6] + "",
                        Email = reader[5] + "",
                        Sitio_web = reader[5] + ""
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

        public List<Clinica> GetClinicas()
        {
            List<Clinica> lista = new List<Clinica>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("GetClinicas", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Clinica modelo = new Clinica()
                    {
                        Id = (int)reader[0],
                        Nombre = reader[1] + "",
                        Cedula_juridica = reader[2] + "",
                        Pais = reader[3] + "",
                        Estado_provincia = reader[4] + "",
                        Distrito = reader[5] + "",
                        Telefono = reader[6] + "",
                        Email = reader[5] + "",
                        Sitio_web = reader[5] + ""
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