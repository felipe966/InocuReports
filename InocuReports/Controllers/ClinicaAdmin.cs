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
        public int  Guardar(Clinica modelo)
        {
            int new_id = 404;
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
                new_id = (int)comando.ExecuteScalar();
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
            return new_id;
        }

        public IEnumerable<Clinica> GetClinicaByNombre(string Nombre)
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
            return lista.AsEnumerable();
        }
        public List<Clinica> GetClinicaByCedula(string Cedula_juridica)
        {
            List<Clinica> lista = new List<Clinica>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("GetClinicaByCedula", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@cedula_juridica", Cedula_juridica));
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

        public IEnumerable<Clinica> GetClinicas()
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
            return lista.AsEnumerable();
        }
        public Clinica GetById(int id)
        {
            Clinica modelo = new Clinica();
            Conectar();
            try
            {
                SqlCommand command = new SqlCommand("select * from Clinica where Clinica.id=" + id + ";", cnn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    modelo = new Clinica()
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
            return modelo;
        }
    }
}