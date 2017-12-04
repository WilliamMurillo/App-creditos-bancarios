using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Control
{
    public class clsVariables
    {
        #region variables get; set;

        //variable control de errores

        public int ComprobarCed { get; set; }
        public bool ComprobarError { get; set; }

        //parametro para el storeprocedure

        public Int32 intParCedula { get; set; }

        public string parNom { get; set; }

        public string parCelular { get; set; }

        public string parCorreo { get; set; }

        public string parDireccion { get; set; }

        public string parEstCivil { get; set; }

        //datos extraidos de model
        public int intCedula { get; set; }

        public string strNombre { get; set; }

        public string strCelular { get; set; }

        public string strCorreo { get; set; }

        public string strDireccion { get; set; }

        public string strEstadoCivil { get; set; }

        public int parNumeroCuenta { get; set; }
        public int NumeroCuenta { get; set; }
        public string strTipoProducto { get; set; }
        public double doubleDeuda { get; set; }
        public double doubleinteres { get; set; }
        public string strCuotas { get; set; }
        public string strPeriodicidad { get; set; }
        public double doubleDeudaTotal { get; set; }


        public int intScore { get; set; }
        public double DoubleIngresos { get; set; }
        public double DoubleEgresos { get; set; }
        public string strCapacende { get; set; }
        public double dblSalario { get; set; }


        public string parUsuario { get; set; }
        public string parContraseña { get; set; }
        public string strUsuario { get; set; }
        public string strContraseña { get; set; }

        #endregion

    }
}
