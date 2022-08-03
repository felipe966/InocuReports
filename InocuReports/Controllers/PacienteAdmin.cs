using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InocuReports.Models;
using System.Data.SqlClient;
using inmobiscosts.Datos;

namespace InocuReports.Controllers
{
    public class PacienteAdmin:Conexion
    {
        public int Guardar(Paciente modelo)
        {
            int new_id = 404;
            Conectar();
            try
            {


                SqlCommand comando = new SqlCommand("GuardarPaciente", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@identificacion", modelo.Identificacion));
                comando.Parameters.Add(new SqlParameter("@nombre", modelo.Nombre));
                comando.Parameters.Add(new SqlParameter("@primer_apellido", modelo.Primer_apellido));
                comando.Parameters.Add(new SqlParameter("@segundo_apellido", modelo.Segundo_apellido));
                comando.Parameters.Add(new SqlParameter("@fecha_nacimiento", modelo.Fecha_nacimiento));
                comando.Parameters.Add(new SqlParameter("@sexo_natural", modelo.Sexo_natural));
                comando.Parameters.Add(new SqlParameter("@telefono_contacto", modelo.Telefono_contacto));
                comando.Parameters.Add(new SqlParameter("@pais", modelo.Pais));
                comando.Parameters.Add(new SqlParameter("@estado_provincia", modelo.Estado_provincia));
                comando.Parameters.Add(new SqlParameter("@distrito", modelo.Distrito));
                comando.Parameters.Add(new SqlParameter("@estado_civil", modelo.Estado_civil));
                comando.Parameters.Add(new SqlParameter("@telefono_personal", modelo.Telefono_personal));
                comando.Parameters.Add(new SqlParameter("@email", modelo.Email));
                //comando.Parameters.Add(new SqlParameter("@fecha_registro", modelo.Fecha_registro));
                comando.Parameters.Add(new SqlParameter("@ocupacion", modelo.Ocupacion));
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

        public IEnumerable<Paciente> GetPacienteByIdentificacion(string Identificacion)
        {
            List<Paciente> lista = new List<Paciente>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("GetPacienteByIdentificacion", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@identificacion", Identificacion));
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Paciente modelo = new Paciente()
                    {
                        Id = (int)reader[0],
                        Identificacion = reader[1] + "",
                        Nombre = reader[2] + "",
                        Primer_apellido = reader[3] + "",
                        Segundo_apellido = reader[4] + "",
                        Fecha_nacimiento = reader[5] + "",
                        Sexo_natural = reader[6] + "",
                        Telefono_contacto = reader[7] + "",
                        Pais = reader[8] + "",
                        Estado_provincia = reader[9] + "",
                        Distrito = reader[10] + "",
                        Estado_civil = reader[11] + "",
                        Telefono_personal = reader[12] + "",
                        Email = reader[13] + "",
                        Fecha_registro = reader[14] + "",
                        Ocupacion = reader[15] + ""
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

        public IEnumerable<Paciente> GetPacientes()
        {
            List<Paciente> lista = new List<Paciente>();
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("GetPacientes", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Paciente modelo = new Paciente()
                    {
                        Id = (int)reader[0],
                        Identificacion = reader[1] + "",
                        Nombre = reader[2] + "",
                        Primer_apellido = reader[3] + "",
                        Segundo_apellido = reader[4] + "",
                        Fecha_nacimiento = reader[5] + "",
                        Sexo_natural = reader[6] + "",
                        Telefono_contacto = reader[7] + "",
                        Pais = reader[8] + "",
                        Estado_provincia = reader[9] + "",
                        Distrito = reader[10] + "",
                        Estado_civil = reader[11] + "",
                        Telefono_personal = reader[12] + "",
                        Email = reader[13] + "",
                        Fecha_registro = reader[14] + "",
                        Ocupacion = reader[15] + ""
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

        public Paciente GetById(int id)
        {
            Paciente modelo = new Paciente();
            Conectar();
            try
            {
                SqlCommand command = new SqlCommand("select * from Paciente where Paciente.id=" + id + ";", cnn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    modelo = new Paciente()
                    {
                        Id = (int)reader[0],
                        Identificacion = reader[1] + "",
                        Nombre = reader[2] + "",
                        Primer_apellido = reader[3] + "",
                        Segundo_apellido = reader[4] + "",
                        Fecha_nacimiento = reader[5] + "",
                        Sexo_natural = reader[6] + "",
                        Telefono_contacto = reader[7] + "",
                        Pais = reader[8] + "",
                        Estado_provincia = reader[9] + "",
                        Distrito = reader[10] + "",
                        Estado_civil = reader[11] + "",
                        Telefono_personal = reader[12] + "",
                        Email = reader[13] + "",
                        Fecha_registro = reader[14] + "",
                        Ocupacion = reader[15] + ""
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