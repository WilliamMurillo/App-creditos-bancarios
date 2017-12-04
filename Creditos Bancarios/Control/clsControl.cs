using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data;
using System.Data.SqlClient;


namespace Control
{
    public class clsControl
    {

        #region definicion de variables
        clsModelo clsDatos = null;
        clsVariables objtCont = null;
        DataTable dttDatos = null;
        private bool miBool = false;
        public double doubleFlujoCajaLibre { get; set; }
        public double doubleCapacEndeu { get; set; }
        private double double_FlujoCajaLibre = 0;
        private double double_CapacEndeu = 0;
        private double double_Salariop = 0;
        #endregion

        #region constructor

        public clsControl(clsVariables parObjCont)
        {
            objtCont = parObjCont;
        }
        #endregion

        #region metodos

    
        public void mtconsCliente()
        {
            try
            {
                clsDatos = new clsModelo();
                dttDatos = clsDatos.mtdConsCli(objtCont.intParCedula);

                objtCont.intCedula = Convert.ToInt32(dttDatos.Rows[0]["int_CedulaPK"].ToString());
                objtCont.strNombre = dttDatos.Rows[0]["var_Nombre"].ToString();
                objtCont.strCelular = dttDatos.Rows[0]["varchar_Celular"].ToString();
                objtCont.strCorreo = dttDatos.Rows[0]["var_Correo_Electronico"].ToString();
                objtCont.strDireccion = dttDatos.Rows[0]["var_Direccion"].ToString();
                objtCont.strEstadoCivil = dttDatos.Rows[0]["var_Estado_Civil"].ToString();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
           public void mtNueClienteBD()
           {
               try
               {
                   clsDatos = new clsModelo();

                   clsDatos.mtdCrearCli(objtCont.intParCedula, objtCont.parNom, objtCont.parCelular, objtCont.parDireccion, objtCont.parEstCivil, objtCont.parCorreo);

               }
               catch (Exception e)
               {

                   throw new Exception(e.Message);

               }
           }


          public void mtActualizarCliente()
          {
              try
              {
                  clsDatos = new clsModelo();

                  clsDatos.mtdMoficar(objtCont.intParCedula, objtCont.parNom, objtCont.parCelular, objtCont.parDireccion, objtCont.parEstCivil, objtCont.parCorreo);

              }
              catch (Exception e)
              {
                  throw new Exception(e.Message);

              }
          }
       
         public void mteliminarClienteCon()
         {
             try
             {
                 clsDatos = new clsModelo();
                 clsDatos.mtdBorrarCliente(objtCont.intParCedula);

             }
             catch (Exception ex)
             {

                 throw new Exception(ex.Message);
             }
         }

         public DataTable mtProdCliente()
         {
             try
             {
                 clsDatos = new clsModelo();
                 dttDatos = new DataTable();
                 return clsDatos.mtdRecuperarPrduc(objtCont.intParCedula);

             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
         }

         public void mtfinancieraCliente()
         {
             try
             {
                 clsDatos = new clsModelo();
                 dttDatos = clsDatos.mtdInformaionCliente(objtCont.intParCedula);

                 objtCont.intCedula = Convert.ToInt32(dttDatos.Rows[0]["int_CedulaFK1"].ToString());
                 objtCont.intScore = Convert.ToInt32(dttDatos.Rows[0]["int_Score"].ToString());
                 objtCont.DoubleIngresos = double.Parse(dttDatos.Rows[0]["float_Ingresos"].ToString());
                 objtCont.DoubleEgresos = double.Parse(dttDatos.Rows[0]["float_Egresos"].ToString());
                 objtCont.strCapacende = dttDatos.Rows[0]["var_CapacidadEndeudamiento"].ToString();
                 objtCont.dblSalario = double.Parse(dttDatos.Rows[0]["salario"].ToString());

             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
         }

        
  
      
         public bool mtGenerarCarta()
         {
             try
             {
                 clsDatos = new clsModelo();
                 dttDatos = clsDatos.mtdrealizarCarta(objtCont.intParCedula);


                 objtCont.intScore = Convert.ToInt32(dttDatos.Rows[0]["int_Score"].ToString());
                 objtCont.DoubleIngresos = double.Parse(dttDatos.Rows[0]["float_Ingresos"].ToString());
                 objtCont.DoubleEgresos = double.Parse(dttDatos.Rows[0]["float_Egresos"].ToString());
                 objtCont.strCapacende = dttDatos.Rows[0]["var_CapacidadEndeudamiento"].ToString();
                 objtCont.dblSalario = double.Parse(dttDatos.Rows[0]["salario"].ToString());

                 doubleFlujoCajaLibre = objtCont.DoubleIngresos - objtCont.DoubleEgresos;
                 doubleCapacEndeu = (objtCont.DoubleIngresos * 0.2);
                 double_Salariop = objtCont.dblSalario * 15;

                 if (objtCont.intScore >= 400 && doubleFlujoCajaLibre > 0 && doubleFlujoCajaLibre > doubleCapacEndeu && objtCont.DoubleEgresos < double_Salariop)
                 {
                     miBool = true;
                 }

                 return miBool;
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message);
             }
         }

        public void mtloginSesion()
        {
            try
            {
                clsDatos = new clsModelo();
                dttDatos = new DataTable();
                dttDatos = clsDatos.mdEntrarProgr(objtCont.parUsuario, objtCont.parContraseña);
               
                objtCont.strUsuario = dttDatos.Rows[0]["var_Usuario"].ToString();
                objtCont.strContraseña = dttDatos.Rows[0]["var_Contraseña"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion


       
    }
}
