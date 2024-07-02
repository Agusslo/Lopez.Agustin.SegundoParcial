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

        public Coleccion ObtenerColeccion()
        {
            Coleccion coleccion = new Coleccion();
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
                                    EspecieOrco = ParseEnum<EEspecieOrco>(reader["especieOrco"].ToString()),
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
                                    EspecieElfo = ParseEnum<EEspecieElfo>(reader["especieElfo"].ToString()),
                                    Inmortalidad = reader["inmortalidad"] != DBNull.Value && Convert.ToBoolean(reader["inmortalidad"])
                                };
                                Console.WriteLine("Elfo cargado: " + personaje.Nombre);  // Mensaje de depuración
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

        public void GuardarColeccionSQL(Coleccion coleccion)
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
                                                        "VALUES (@tipo, @nombre, @edad, @caracteristica, @resucitado, @colorHumano, @colorPelo)";
                            this.comando.Parameters.AddWithValue("@tipo", "Humano");
                            this.comando.Parameters.AddWithValue("@nombre", humano.Nombre);
                            this.comando.Parameters.AddWithValue("@edad", humano.Edad.ToString());
                            this.comando.Parameters.AddWithValue("@caracteristica", humano.Caracteristica.ToString());
                            this.comando.Parameters.AddWithValue("@resucitado", humano.Resucitado);
                            this.comando.Parameters.AddWithValue("@colorHumano", humano.ColorHumano.ToString());
                            this.comando.Parameters.AddWithValue("@colorPelo", humano.ColorPelo.ToString());
                        }
                        else if (personaje is Orco orco)
                        {
                            this.comando.CommandText = "INSERT INTO TablaPersonajes (tipo, nombre, edad, caracteristica, resucitado, especieOrco, canibal) " +
                                                        "VALUES (@tipo, @nombre, @edad, @caracteristica, @resucitado, @especieOrco, @canibal)";
                            this.comando.Parameters.AddWithValue("@tipo", "Orco");
                            this.comando.Parameters.AddWithValue("@nombre", orco.Nombre);
                            this.comando.Parameters.AddWithValue("@edad", orco.Edad.ToString());
                            this.comando.Parameters.AddWithValue("@caracteristica", orco.Caracteristica.ToString());
                            this.comando.Parameters.AddWithValue("@resucitado", orco.Resucitado);
                            this.comando.Parameters.AddWithValue("@especieOrco", orco.EspecieOrco.ToString());
                            this.comando.Parameters.AddWithValue("@canibal", orco.Canibal);
                        }
                        else if (personaje is Elfo elfo)
                        {
                            this.comando.CommandText = "INSERT INTO TablaPersonajes (tipo, nombre, edad, caracteristica, resucitado, especieElfo, inmortalidad) " +
                                                        "VALUES (@tipo, @nombre, @edad, @caracteristica, @resucitado, @especieElfo, @inmortalidad)";
                            this.comando.Parameters.AddWithValue("@tipo", "Elfo");
                            this.comando.Parameters.AddWithValue("@nombre", elfo.Nombre);
                            this.comando.Parameters.AddWithValue("@edad", elfo.Edad.ToString());
                            this.comando.Parameters.AddWithValue("@caracteristica", elfo.Caracteristica.ToString());
                            this.comando.Parameters.AddWithValue("@resucitado", elfo.Resucitado);
                            this.comando.Parameters.AddWithValue("@especieElfo", elfo.EspecieElfo.ToString());
                            this.comando.Parameters.AddWithValue("@inmortalidad", elfo.Inmortalidad);

                            // Mensaje de depuración
                            Console.WriteLine($"Guardando Elfo: {elfo.Nombre}, {elfo.Edad}, {elfo.Caracteristica}, {elfo.Resucitado}, {elfo.EspecieElfo}, {elfo.Inmortalidad}");
                        }
                        this.comando.ExecuteNonQuery();
                        this.comando.Parameters.Clear();
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


        public void ModificarCarnivoro(Personaje personaje, Personaje personaje2)
        {
            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@tipo", personaje.GetType().Name);
                this.comando.Parameters.AddWithValue("@nombre", personaje.Nombre);
                this.comando.Parameters.AddWithValue("@caracteristica", personaje.Caracteristica.ToString());
                this.comando.Parameters.AddWithValue("@edad", personaje.Edad.ToString());
                this.comando.Parameters.AddWithValue("@resucitado", personaje.Resucitado);
                string sql = "UPDATE TablaPersonajes ";
                sql += "SET tipo = @tipo, edad = @edad, nombre = @nombre, caracteristica = @caracteristica, resucitado = @resucitado ";
                if (personaje is Humano humano)
                {
                    this.comando.Parameters.AddWithValue("@colorHumano", humano.ColorHumano.ToString());
                    this.comando.Parameters.AddWithValue("@colorPelo", humano.ColorPelo.ToString());
                    sql += ", colorHumano = @colorHumano, colorPelo = @colorPelo";
                }
                else if (personaje is Orco orco)
                {
                    this.comando.Parameters.AddWithValue("@especieOrco", orco.EspecieOrco.ToString());
                    this.comando.Parameters.AddWithValue("@canibal", orco.Canibal.ToString());
                    sql += ", EspecieOrco = @EspecieOrco, canibal = @canibal";
                }
                else if (personaje is Elfo elfo)
                {
                    this.comando.Parameters.AddWithValue("@especieElfo", elfo.EspecieElfo.ToString());
                    this.comando.Parameters.AddWithValue("@inmortalidad", elfo.Inmortalidad.ToString());
                    sql += ", EspecieElfo = @EspecieElfo, inmortalidad = @inmortalidad";
                }
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;
                this.conexion.Open();
                int filasAfectadas = this.comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }

        public void EliminarSistema(Personaje personaje)
        {
            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@tipo", personaje.GetType().Name);
                this.comando.Parameters.AddWithValue("@nombre", personaje.Nombre);
                this.comando.Parameters.AddWithValue("@caracteristica", personaje.Caracteristica.ToString());
                this.comando.Parameters.AddWithValue("@edad", personaje.Edad.ToString());
                this.comando.Parameters.AddWithValue("@resucitado", personaje.Resucitado);
                string sql = "DELETE FROM TablaPersonajes ";
                sql += "WHERE tipo = @tipo AND nombre = @nombre AND caracteristica = @caracteristica AND edad = @edad AND resucitado = @resucitado";
                if (personaje is Humano humano)
                {
                    this.comando.Parameters.AddWithValue("@colorHumano", humano.ColorHumano.ToString());
                    this.comando.Parameters.AddWithValue("@colorPelo", humano.ColorPelo.ToString());
                    sql += " AND colorHumano = @colorHumano AND colorPelo = @colorPelo";
                }
                else if (personaje is Orco orco)
                {
                    this.comando.Parameters.AddWithValue("@especieOrco", orco.EspecieOrco.ToString());
                    this.comando.Parameters.AddWithValue("@canibal", orco.Canibal.ToString());
                    sql += " AND especieOrco = @especieOrco AND canibal = @canibal";
                }
                else if (personaje is Elfo elfo)
                {
                    this.comando.Parameters.AddWithValue("@especieElfo", elfo.EspecieElfo.ToString());
                    this.comando.Parameters.AddWithValue("@inmortalidad", elfo.Inmortalidad.ToString());
                    sql += " AND especieElfo = @especieElfo AND inmortalidad = @inmortalidad";
                }
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;
                this.conexion.Open();
                int filasAfectadas = this.comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }

        private bool CheckPersonaje(Personaje personaje)
        {
            bool exists = false;
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.Connection = this.conexion;
                if (personaje is Humano humano)
                {
                    this.comando.CommandText = "SELECT * FROM TablaPersonajes WHERE nombre = @nombre AND edad = @edad AND caracteristica = @caracteristica AND resucitado = @resucitado AND colorHumano = @colorHumano AND colorPelo = @colorPelo";
                    this.comando.Parameters.AddWithValue("@nombre", humano.Nombre);
                    this.comando.Parameters.AddWithValue("@edad", humano.Edad.ToString());
                    this.comando.Parameters.AddWithValue("@caracteristica", humano.Caracteristica.ToString());
                    this.comando.Parameters.AddWithValue("@resucitado", humano.Resucitado);
                    this.comando.Parameters.AddWithValue("@colorHumano", humano.ColorHumano.ToString());
                    this.comando.Parameters.AddWithValue("@colorPelo", humano.ColorPelo.ToString());
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
                    this.comando.CommandText = "SELECT * FROM TablaPersonajes WHERE nombre = @nombre AND edad = @edad AND caracteristica = @caracteristica AND resucitado = @resucitado AND especieElfo = @especieElfo AND inmortalidad = @inmortalidad";
                    this.comando.Parameters.AddWithValue("@nombre", elfo.Nombre);
                    this.comando.Parameters.AddWithValue("@edad", elfo.Edad.ToString());
                    this.comando.Parameters.AddWithValue("@caracteristica", elfo.Caracteristica.ToString());
                    this.comando.Parameters.AddWithValue("@resucitado", elfo.Resucitado);
                    this.comando.Parameters.AddWithValue("@especieElfo", elfo.EspecieElfo.ToString());
                    this.comando.Parameters.AddWithValue("@inmortalidad", elfo.Inmortalidad.ToString());
                }
                this.conexion.Open();
                using (SqlDataReader reader = this.comando.ExecuteReader())
                {
                    exists = reader.HasRows;
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
            return exists;
        }

        private TEnum ParseEnum<TEnum>(string value)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value);
        }
    }
}
