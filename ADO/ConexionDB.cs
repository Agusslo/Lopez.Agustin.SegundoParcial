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

        public void ModificarPersonaje(Personaje personaje, Personaje personaje2)
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
                    sql += ", EspecieOrco = @especieOrco, canibal = @canibal";
                }
                else if (personaje is Elfo elfo)
                {
                    this.comando.Parameters.AddWithValue("@especieElfo", elfo.EspecieElfo.ToString());
                    this.comando.Parameters.AddWithValue("@inmortalidad", elfo.Inmortalidad.ToString());
                    sql += ", EspecieElfo = @especieElfo, inmortalidad = @inmortalidad";
                }

                // Agregar parámetros del segundo personaje para la cláusula WHERE
                this.comando.Parameters.AddWithValue("@tipo2", personaje2.GetType().Name);
                this.comando.Parameters.AddWithValue("@nombre2", personaje2.Nombre);
                this.comando.Parameters.AddWithValue("@caracteristica2", personaje2.Caracteristica.ToString());
                this.comando.Parameters.AddWithValue("@edad2", personaje2.Edad.ToString());
                this.comando.Parameters.AddWithValue("@resucitado2", personaje2.Resucitado);

                sql += " WHERE tipo = @tipo2 AND nombre = @nombre2 AND caracteristica = @caracteristica2 AND edad = @edad2 AND resucitado = @resucitado2";

                if (personaje2 is Humano humano2)
                {
                    this.comando.Parameters.AddWithValue("@colorHumano2", humano2.ColorHumano.ToString());
                    this.comando.Parameters.AddWithValue("@colorPelo2", humano2.ColorPelo.ToString());
                    sql += " AND colorHumano = @colorHumano2 AND colorPelo = @colorPelo2";
                }
                else if (personaje2 is Orco orco2)
                {
                    this.comando.Parameters.AddWithValue("@especieOrco2", orco2.EspecieOrco.ToString());
                    this.comando.Parameters.AddWithValue("@canibal2", orco2.Canibal.ToString());
                    sql += " AND EspecieOrco = @especieOrco2 AND canibal = @canibal2";
                }
                else if (personaje2 is Elfo elfo2)
                {
                    this.comando.Parameters.AddWithValue("@especieElfo2", elfo2.EspecieElfo.ToString());
                    this.comando.Parameters.AddWithValue("@inmortalidad2", elfo2.Inmortalidad.ToString());
                    sql += " AND EspecieElfo = @especieElfo2 AND inmortalidad = @inmortalidad2";
                }

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();
                int filasAfectadas = this.comando.ExecuteNonQuery();
                Console.WriteLine($"{filasAfectadas} filas afectadas.");
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
                this.comando.Connection = this.conexion;

                this.comando.Parameters.AddWithValue("@tipo", personaje.GetType().Name);
                this.comando.Parameters.AddWithValue("@nombre", personaje.Nombre);
                this.comando.Parameters.AddWithValue("@edad", personaje.Edad.ToString());
                this.comando.Parameters.AddWithValue("@caracteristica", personaje.Caracteristica.ToString());
                this.comando.Parameters.AddWithValue("@resucitado", personaje.Resucitado);

                string sql = "DELETE FROM TablaPersonajes WHERE tipo = @tipo AND nombre = @nombre AND edad = @edad AND caracteristica = @caracteristica AND resucitado = @resucitado";

                if (personaje is Humano humano)
                {
                    this.comando.Parameters.AddWithValue("@colorHumano", humano.ColorHumano.ToString());
                    this.comando.Parameters.AddWithValue("@colorPelo", humano.ColorPelo.ToString());
                    sql += " AND colorHumano = @colorHumano AND colorPelo = @colorPelo";
                }
                else if (personaje is Orco orco)
                {
                    this.comando.Parameters.AddWithValue("@especieOrco", orco.EspecieOrco.ToString());
                    this.comando.Parameters.AddWithValue("@canibal", orco.Canibal);
                    sql += " AND especieOrco = @especieOrco AND canibal = @canibal";
                }
                else if (personaje is Elfo elfo)
                {
                    this.comando.Parameters.AddWithValue("@especieElfo", elfo.EspecieElfo.ToString());
                    this.comando.Parameters.AddWithValue("@inmortalidad", elfo.Inmortalidad);
                    sql += " AND especieElfo = @especieElfo AND inmortalidad = @inmortalidad";
                }

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    Console.WriteLine("No se encontró el personaje para eliminar.");
                }
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
