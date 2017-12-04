using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Modelo
{
    public class clsModelo
    {
        #region definicion de variables
        SqlConnection cnnBaseDatos = null;
        SqlCommand cmdConsCliente = null;
        SqlDataReader drConsCliente = null;
        SqlDataAdapter daCliente = null;
        DataTable dttConscliente = null;
        string strCadenaConexion = string.Empty;

        #endregion

        #region constructor

        public clsModelo()
        {
            strCadenaConexion = "Data Source=WILLIAMKHALIFA; Initial catalog=BD_Cliente; Integrated Security=True";
        }
        #endregion

        #region metodos

        //consulta cliente
        public DataTable mtdConsCli(Int32 intParCedula)
        {
            try
            {
                //conexion base de datos y preparacion de consulta
                cnnBaseDatos = new SqlConnection(strCadenaConexion);
                dttConscliente = new DataTable();
                cmdConsCliente = new SqlCommand();
                cmdConsCliente.Connection = cnnBaseDatos;
                cmdConsCliente.CommandType = CommandType.StoredProcedure;
                cmdConsCliente.CommandText = "SP_ConsultarCliente";
                cmdConsCliente.Parameters.Add("@cedula", SqlDbType.Int, 10).Value = intParCedula;

                //ejecutar la consulta y almacenar datos

                cnnBaseDatos.Open();
                drConsCliente = cmdConsCliente.ExecuteReader();
                dttConscliente.Load(drConsCliente);

                return dttConscliente;
            }
            catch (Exception ex)
            {
                //garbage collector
                cnnBaseDatos.Dispose();
                cmdConsCliente.Dispose();
                throw new Exception(ex.Message);
            }
            finally
            {
                //garbage collector
                cnnBaseDatos.Dispose();
                cmdConsCliente.Dispose();
            }

        }

        //insertar cliente
        public SqlDataReader mtdCrearCli(Int32 intParCedula, string parNombre, string parCelular, string parDireccion, string parEstadoCivil, string parCorreo)
        {
            try
            {
                //conexion base de datos y preparacion de consulta
                cnnBaseDatos = new SqlConnection(strCadenaConexion);
                cmdConsCliente = new SqlCommand();
                cmdConsCliente.Connection = cnnBaseDatos;
                cmdConsCliente.CommandType = CommandType.StoredProcedure;
                cmdConsCliente.CommandText = "SP_CrearCliente";
                cmdConsCliente.Parameters.Add("@cedula", SqlDbType.Int).Value = intParCedula;
                cmdConsCliente.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = parNombre;
                cmdConsCliente.Parameters.Add("@celular", SqlDbType.VarChar, 10).Value = parCelular;
                cmdConsCliente.Parameters.Add("@correo", SqlDbType.VarChar, 50).Value = parCorreo;
                cmdConsCliente.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = parDireccion;
                cmdConsCliente.Parameters.Add("@estadoCivil", SqlDbType.VarChar, 20).Value = parEstadoCivil;


                //ejecutar el comando
                cnnBaseDatos.Open();
                return drConsCliente = cmdConsCliente.ExecuteReader();

            }
            catch (Exception ex)
            {
                //garbage collector
                cnnBaseDatos.Dispose();
                cmdConsCliente.Dispose();
                throw new Exception(ex.Message);
            }
            finally
            {
                //garbage collector
                cnnBaseDatos.Dispose();
                cmdConsCliente.Dispose();
            }

        }

         //modificar cliente
          public SqlDataReader mtdMoficar(Int32 intParCedula, string parNombre, string parCelular, string parDireccion, string parEstadoCivil, string parCorreo)
          {
              try
              {
                  //conexion base de datos y preparacion de consulta
                  cnnBaseDatos = new SqlConnection(strCadenaConexion);
                  cmdConsCliente = new SqlCommand();
                  cmdConsCliente.Connection = cnnBaseDatos;
                  cmdConsCliente.CommandType = CommandType.StoredProcedure;
                  cmdConsCliente.CommandText = "SP_ActualizarCliente";
                  cmdConsCliente.Parameters.Add("@cedula", SqlDbType.Int).Value = intParCedula;
                  cmdConsCliente.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = parNombre;
                  cmdConsCliente.Parameters.Add("@celular", SqlDbType.VarChar, 10).Value = parCelular;
                  cmdConsCliente.Parameters.Add("@correo", SqlDbType.VarChar, 50).Value = parCorreo;
                  cmdConsCliente.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = parDireccion;
                  cmdConsCliente.Parameters.Add("@estadoCivil", SqlDbType.VarChar, 20).Value = parEstadoCivil;

                  //ejecutar el comando
                  cnnBaseDatos.Open();
                  return drConsCliente = cmdConsCliente.ExecuteReader();

              }
              catch (Exception ex)
              {
                  //garbage collector
                  cnnBaseDatos.Dispose();
                  cmdConsCliente.Dispose();
                  throw new Exception(ex.Message);
              }
              finally
              {
                  //garbage collector
                  cnnBaseDatos.Dispose();
                  cmdConsCliente.Dispose();
              }

          }

         //Eliminar cliente
        public void mtdBorrarCliente(Int32 intParCedula)
        {
            try
            {
                //conexion base de datos y preparacion de consulta
                cnnBaseDatos = new SqlConnection(strCadenaConexion);
                cmdConsCliente = new SqlCommand();
                cmdConsCliente.Connection = cnnBaseDatos;
                cmdConsCliente.CommandType = CommandType.StoredProcedure;
                cmdConsCliente.CommandText = "SP_BorrarCliente";
                cmdConsCliente.Parameters.Add("@cedula", SqlDbType.Int, 10).Value = intParCedula;

                //ejecutar el comando y abrir conexion

                cnnBaseDatos.Open();
                drConsCliente = cmdConsCliente.ExecuteReader();

            }
            catch (Exception ex)
            {
                //garbage collector
                cnnBaseDatos.Dispose();
                cmdConsCliente.Dispose();
                throw new Exception(ex.Message);
            }
            finally
            {
                //garbage collector
                cnnBaseDatos.Dispose();
                cmdConsCliente.Dispose();
            }

        }
         //consultar todos productos cliente
        public DataTable mtdRecuperarPrduc(Int32 intParCedula)
        {
            try
            {
                //conexion base de datos y preparacion de consulta
                cnnBaseDatos = new SqlConnection(strCadenaConexion);
                dttConscliente = new DataTable();
                cmdConsCliente = new SqlCommand();
                cmdConsCliente.Connection = cnnBaseDatos;
                cmdConsCliente.CommandType = CommandType.StoredProcedure;
                cmdConsCliente.CommandText = "SP_MostrarTodosProducto";
                cmdConsCliente.Parameters.Add("@cedula", SqlDbType.Int, 10).Value = intParCedula;

                //ejecutar la consulta y almacenar datos

                cnnBaseDatos.Open();
                drConsCliente = cmdConsCliente.ExecuteReader();
                dttConscliente.Load(drConsCliente);

                return dttConscliente;
            }
            catch (Exception ex)
            {
                //garbage collector
                cnnBaseDatos.Dispose();
                cmdConsCliente.Dispose();
                throw new Exception(ex.Message);
            }
            finally
            {
                //garbage collector
                cnnBaseDatos.Dispose();
                cmdConsCliente.Dispose();
            }

        }

        //consulta informacion financiera cliente
        public DataTable mtdInformaionCliente(Int32 intParCedula)
        {
            try
            {
                //conexion base de datos y preparacion de consulta
                cnnBaseDatos = new SqlConnection(strCadenaConexion);
                dttConscliente = new DataTable();
                cmdConsCliente = new SqlCommand();
                cmdConsCliente.Connection = cnnBaseDatos;
                cmdConsCliente.CommandType = CommandType.StoredProcedure;
                cmdConsCliente.CommandText = "SP_ConsultaInfoFinan";
                cmdConsCliente.Parameters.Add("@cedula", SqlDbType.Int, 10).Value = intParCedula;

                //ejecutar la consulta y almacenar datos

                cnnBaseDatos.Open();
                drConsCliente = cmdConsCliente.ExecuteReader();
                dttConscliente.Load(drConsCliente);

                return dttConscliente;
            }
            catch (Exception ex)
            {
                //garbage collector
                cnnBaseDatos.Dispose();
                cmdConsCliente.Dispose();
                throw new Exception(ex.Message);
            }
            finally
            {
                //garbage collector
                cnnBaseDatos.Dispose();
                cmdConsCliente.Dispose();
            }

        }

      
         //consulta informacion financiera cliente para generar carta
        public DataTable mtdrealizarCarta(Int32 intParCedula)
        {
            try
            {
                //conexion base de datos y preparacion de consulta
                cnnBaseDatos = new SqlConnection(strCadenaConexion);
                dttConscliente = new DataTable();
                cmdConsCliente = new SqlCommand();
                cmdConsCliente.Connection = cnnBaseDatos;
                cmdConsCliente.CommandType = CommandType.StoredProcedure;
                cmdConsCliente.CommandText = "SP_ExtraerDatosCarta";
                cmdConsCliente.Parameters.Add("@cedula", SqlDbType.Int, 10).Value = intParCedula;
                //ejecutar la consulta y almacenar datos

                cnnBaseDatos.Open();
                drConsCliente = cmdConsCliente.ExecuteReader();
                dttConscliente.Load(drConsCliente);

                return dttConscliente;
            }
            catch (Exception ex)
            {
                //garbage collector
                cnnBaseDatos.Dispose();
                cmdConsCliente.Dispose();
                throw new Exception(ex.Message);
            }
            finally
            {
                //garbage collector
                cnnBaseDatos.Dispose();
                cmdConsCliente.Dispose();
            }

        }

        public DataTable mdEntrarProgr(string usuario, string contraseña)
        {
            try
            {
                //conexion base de datos y preparacion de consulta
                cnnBaseDatos = new SqlConnection(strCadenaConexion);
                dttConscliente = new DataTable();
                cmdConsCliente = new SqlCommand();
                cmdConsCliente.Connection = cnnBaseDatos;
                cmdConsCliente.CommandType = CommandType.StoredProcedure;
                cmdConsCliente.CommandText = "SP_Login";
                cmdConsCliente.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = usuario;
                cmdConsCliente.Parameters.Add("@contraseña", SqlDbType.VarChar, 30).Value = contraseña;
                //ejecutar la consulta y almacenar datos

                cnnBaseDatos.Open();
                drConsCliente = cmdConsCliente.ExecuteReader();
                dttConscliente.Load(drConsCliente);

                return dttConscliente;
            }
            catch (Exception ex)
            {
                //garbage collector
                cnnBaseDatos.Dispose();
                cmdConsCliente.Dispose();
                throw new Exception(ex.Message);
            }
            finally
            {
                //garbage collector
                cnnBaseDatos.Dispose();
                cmdConsCliente.Dispose();
            }

        }
        #endregion
    }
}
