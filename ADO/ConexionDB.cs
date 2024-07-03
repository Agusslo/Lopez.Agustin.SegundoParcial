using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Data.Sql;
using ClassLibrary;
using Microsoft.Data.SqlClient;
using Entidades;
using System.Data.SqlTypes;
using System.Data;

namespace ADO
{
    public class ConexionDB
    {
        private static string cadena_conexion;
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        static ConexionDB()
        {
            ConexionDB.cadena_conexion = Properties.Resources.miConexion;
        }

        public ConexionDB()
        {
            this.conexion = new SqlConnection(ConexionDB.cadena_conexion);
            this.comando = new SqlCommand();
        }

        #region prueba conexion y obtener coleccion
        public bool PruebaConexion()
        {
            bool retorno = false;
            try
            {
                this.conexion.Open();
                retorno = true;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al probar la conexión", ex);
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return retorno;
        }

        public Coleccion<Personaje> ObtenerColeccion()
        {
            Coleccion<Personaje> coleccion = new Coleccion<Personaje>();
            try
            {
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = "SELECT * FROM TablaPersonajes";
                this.comando.Connection = this.conexion;
                this.conexion.Open();
                using (SqlDataReader reader = this.comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tipo = reader["tipo"].ToString();
                        Personaje personaje = null;
                        switch (tipo)
                        {
                            case "Humano":
                                personaje = new Humano
                                {
                                    Nombre = reader["nombre"].ToString(),
                                    Edad = ParseEnum<EEdad>(reader["edad"].ToString()),
                                    Caracteristica = ParseEnum<ECaracteristica>(reader["caracteristica"].ToString()),
                                    Resucitado = reader["resucitado"] != DBNull.Value && Convert.ToBoolean(reader["resucitado"]),
                                    ColorPelo = ParseEnum<EColorPelo>(reader["colorPelo"].ToString()),
                                    ColorHumano = ParseEnum<EColorHumano>(reader["colorHumano"].ToString())
                                };
                                break;
                            case "Orco":
                                personaje = new Orco
                                {
                                    Nombre = reader["nombre"].ToString(),
                                    Edad = ParseEnum<EEdad>(reader["edad"].ToString()),
                                    Caracteristica = ParseEnum<ECaracteristica>(reader["caracteristica"].ToString()),
                                    Resucitado = reader["resucitado"] != DBNull.Value && Convert.ToBoolean(reader["resucitado"]),
                                    EspecieOrco = ParseEnum<EEspecieOrco>(reader["especie"].ToString()),
                                    Canibal = reader["canibal"] != DBNull.Value && Convert.ToBoolean(reader["canibal"])
                                };
                                break;
                            case "Elfo":
                                personaje = new Elfo
                                {
                                    Nombre = reader["nombre"].ToString(),
                                    Edad = ParseEnum<EEdad>(reader["edad"].ToString()),
                                    Caracteristica = ParseEnum<ECaracteristica>(reader["caracteristica"].ToString()),
                                    Resucitado = reader["resucitado"] != DBNull.Value && Convert.ToBoolean(reader["resucitado"]),
                                    EspecieElfo = ParseEnum<EEspecieElfo>(reader["especie"].ToString()),
                                    Inmortalidad = reader["inmortalidad"] != DBNull.Value && Convert.ToBoolean(reader["inmortalidad"])
                                };
                                break;
                        }
                        if (personaje != null)
                        {
                            coleccion.Personajes.Add(personaje);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return coleccion;
        }
        #endregion


        #region GUARDAR SQL
        public void GuardarColeccionSQL(Coleccion<Personaje> coleccion)
        {
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;

                this.comando.Connection = this.conexion;

                this.conexion.Open();

                foreach (var personaje in coleccion.Personajes)
                {
                    if (!this.CheckPersonaje(personaje))
                    {
                        if (personaje is Humano humano)
                        {
                            this.comando.CommandText = "INSERT INTO TablaPersonajes (tipo, nombre, edad, caracteristica, resucitado, colorHumano, colorPelo) " +
                                                        "VALUES (" + $"'{humano.GetType().Name}', '{humano.Nombre}', '{humano.Edad}', '{humano.Caracteristica}', '{humano.Resucitado}', '{humano.ColorHumano}', '{humano.ColorPelo}')";

                        }
                        else if (personaje is Orco orco)
                        {
                            this.comando.CommandText = "INSERT INTO TablaPersonajes (tipo, nombre, edad, caracteristica, resucitado, especieOrco, canibal) " +
                                                        "VALUES (" + $"'{orco.GetType().Name}', '{orco.Nombre}', '{orco.Edad}', '{orco.Caracteristica}', '{orco.Resucitado}', '{orco.EspecieOrco}', '{orco.Canibal}')";

                        }
                        else if (personaje is Elfo elfo)
                        {
                            this.comando.CommandText = "INSERT INTO TablaPersonajes (tipo, nombre, edad, caracteristica, resucitado, especieElfo, inmortalidad) " +
                                                        "VALUES (" + $"'{elfo.GetType().Name}', '{elfo.Nombre}', '{elfo.Edad}', '{elfo.Caracteristica}', '{elfo.Resucitado}', '{elfo.EspecieElfo}', '{elfo.Inmortalidad}')";
                        }
                        this.comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }
        #endregion

        #region Modificar SQL
        public void ModificarPersonaje(Personaje personajeOriginal, Personaje nuevoPersonaje)
        {
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;

                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.comando.Parameters.Clear();

                this.comando.Parameters.AddWithValue("@tipo", nuevoPersonaje.GetType().Name);
                this.comando.Parameters.AddWithValue("@nombre", nuevoPersonaje.Nombre);
                this.comando.Parameters.AddWithValue("@edad", nuevoPersonaje.Edad.ToString());
                this.comando.Parameters.AddWithValue("@caracteristica", nuevoPersonaje.Caracteristica.ToString());
                this.comando.Parameters.AddWithValue("@resucitado", nuevoPersonaje.Resucitado.ToString());
                this.comando.Parameters.AddWithValue("@nombreOriginal", personajeOriginal.Nombre);

                if (nuevoPersonaje is Humano humano)
                {
                    this.comando.CommandText = "UPDATE TablaPersonajes SET tipo=@tipo, nombre=@nombre, edad=@edad, caracteristica=@caracteristica, resucitado=@resucitado, colorHumano=@colorHumano, colorPelo=@colorPelo WHERE nombre=@nombreOriginal";
                    this.comando.Parameters.AddWithValue("@colorHumano", humano.ColorHumano.ToString());
                    this.comando.Parameters.AddWithValue("@colorPelo", humano.ColorPelo.ToString());
                }
                else if (nuevoPersonaje is Orco orco)
                {
                    this.comando.CommandText = "UPDATE TablaPersonajes SET tipo=@tipo, nombre=@nombre, edad=@edad, caracteristica=@caracteristica, resucitado=@resucitado, especieOrco=@especieOrco, canibal=@canibal WHERE nombre=@nombreOriginal";
                    this.comando.Parameters.AddWithValue("@especieOrco", orco.EspecieOrco.ToString());
                    this.comando.Parameters.AddWithValue("@canibal", orco.Canibal.ToString());
                }
                else if (nuevoPersonaje is Elfo elfo)
                {
                    this.comando.CommandText = "UPDATE TablaPersonajes SET tipo=@tipo, nombre=@nombre, edad=@edad, caracteristica=@caracteristica, resucitado=@resucitado, especieElfo=@especieElfo, inmortalidad=@inmortalidad WHERE nombre=@nombreOriginal";
                    this.comando.Parameters.AddWithValue("@especieElfo", elfo.EspecieElfo.ToString());
                    this.comando.Parameters.AddWithValue("@inmortalidad", elfo.Inmortalidad.ToString());
                }

                this.comando.ExecuteNonQuery();

                // Mensaje de éxito en consola
                Console.WriteLine("Modificación exitosa: El personaje ha sido actualizado en la base de datos.");
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }



        #endregion

        #region ELIMINAR SQL
        public bool EliminarSistema(Personaje personaje)
        {
            bool eliminacionExitosa = false;

            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@tipo", personaje.GetType().Name);
                this.comando.Parameters.AddWithValue("@nombre", personaje.Nombre);
                this.comando.Parameters.AddWithValue("@caracteristica", personaje.Caracteristica.ToString());
                this.comando.Parameters.AddWithValue("@edad", personaje.Edad.ToString()); // Edad como texto
                this.comando.Parameters.AddWithValue("@resucitado", personaje.Resucitado ? 1 : 0); // Suponiendo que Resucitado es un booleano

                string sql = "DELETE FROM TablaPersonajes ";
                sql += "WHERE tipo = @tipo AND nombre = @nombre AND caracteristica = @caracteristica AND edad = @edad AND resucitado = @resucitado";

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();
                int filasAfectadas = this.comando.ExecuteNonQuery();

                eliminacionExitosa = (filasAfectadas > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el personaje en la base de datos: " + ex.Message);
                eliminacionExitosa = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return eliminacionExitosa;
        }


        #endregion


        #region CheckPersonaje
        private bool CheckPersonaje(Personaje personaje)
        {
            //int? id = null;
            bool check = false;
            try
            {
                this.comando = new SqlCommand();
                this.comando.Connection = this.conexion;

                if (personaje is Humano humano)
                {
                    this.comando.CommandText = "SELECT * FROM TablaPersonajes WHERE nombre = @nombre AND edad = @edad AND caracteristica = @caracteristica AND resucitado = @resucitado AND colorHumano = @colorHumano AND colorPelo = @colorPelo";

                    this.comando.Parameters.AddWithValue("@nombre", humano.Nombre);
                    this.comando.Parameters.AddWithValue("@edad", humano.Edad.ToString());
                    this.comando.Parameters.AddWithValue("@caracteristica", humano.Caracteristica.ToString());
                    this.comando.Parameters.AddWithValue("@resucitado", humano.Resucitado);
                    this.comando.Parameters.AddWithValue("@colorHumano", humano.ColorHumano.ToString());
                    this.comando.Parameters.AddWithValue("@ColorPelo", humano.ColorPelo.ToString());
                }
                else if (personaje is Orco orco)
                {
                    this.comando.CommandText = "SELECT * FROM TablaPersonajes WHERE nombre = @nombre AND edad = @edad AND caracteristica = @caracteristica AND resucitado = @resucitado AND especieOrco = @especieOrco AND canibal = @canibal";
                    this.comando.Parameters.AddWithValue("@nombre", orco.Nombre);
                    this.comando.Parameters.AddWithValue("@edad", orco.Edad.ToString());
                    this.comando.Parameters.AddWithValue("@caracteristica", orco.Caracteristica.ToString());
                    this.comando.Parameters.AddWithValue("@resucitado", orco.Resucitado);
                    this.comando.Parameters.AddWithValue("@especieOrco", orco.EspecieOrco.ToString());
                    this.comando.Parameters.AddWithValue("@canibal", orco.Canibal.ToString());
                }
                else if (personaje is Elfo elfo)
                {
                    this.comando.CommandText = "SELECT * FROM TablaPersonajes WHERE nombre = @nombre AND edad = @edad AND caracteristica = @caracteristica AND resucitado = @resucitado AND EspecieElfo = @EspecieElfo AND inmortalidad = @inmortalidad";
                    this.comando.Parameters.AddWithValue("@nombre", elfo.Nombre);
                    this.comando.Parameters.AddWithValue("@edad", elfo.Edad.ToString());
                    this.comando.Parameters.AddWithValue("@caracteristica", elfo.Caracteristica.ToString());
                    this.comando.Parameters.AddWithValue("@resucitado", elfo.Resucitado);
                    this.comando.Parameters.AddWithValue("@especieElfo", elfo.EspecieElfo.ToString());
                    this.comando.Parameters.AddWithValue("@inmortalidad", elfo.Inmortalidad.ToString());
                }
                using (var reader = this.comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        check = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return check;
        }
        #endregion

        private T ParseEnum<T>(string value) where T : struct
        {
            Enum.TryParse(value, out T resultado);
            return resultado;
        }
        public int ObtenerIdDesdeBaseDeDatos()
        {
            int nuevoId = 0;

            using (SqlConnection connection = new SqlConnection(cadena_conexion))
            {
                connection.Open();
                string query = "SELECT ISNULL(MAX(Id), 0) + 1 FROM TablaPersonajes";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    nuevoId = (int)command.ExecuteScalar();
                }
            }
            return nuevoId;
        }
    }
}
