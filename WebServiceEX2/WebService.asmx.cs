using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceEX2
{
    /// <summary>
    /// Descripción breve de WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public bool Guardar(double Numero, double Saldo)
        {
            var Conexion = new SqlConnection("Server=tcp:alvarom.database.windows.net,1433;Initial Catalog=Informacion;Persist Security Info=False;User ID=Alvaro;Password=Password01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var Insertar = new SqlCommand("EXECUTE Guardar '" + Numero + "','" + Saldo + "'", Conexion);

            try
            {
                Conexion.Open();
                Insertar.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                Conexion.Close();
                return false;
            }
        }

        [WebMethod]
        public DataSet Busqueda(double Numero)
        {
            var Conexion = new SqlConnection("Server=tcp:alvarom.database.windows.net,1433;Initial Catalog=Informacion;Persist Security Info=False;User ID=Alvaro;Password=Password01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var Consulta = new SqlDataAdapter("EXECUTE Buscar '" + Numero + "'", Conexion);
            var Conjunto = new DataSet();
            try
            {
                Conexion.Open();
                Consulta.Fill(Conjunto, "Datos");
                Conexion.Close();
                return Conjunto;
            }
            catch (System.Exception ex)
            {
                Conexion.Close();
                return Conjunto;
            }
        }

        [WebMethod]
        public bool Actualizar (double Numero, double Saldo)
        {
            var Conexion = new SqlConnection("Server=tcp:alvarom.database.windows.net,1433;Initial Catalog=Informacion;Persist Security Info=False;User ID=Alvaro;Password=Password01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var Insertar = new SqlCommand("EXECUTE Actualizar '" + Numero + "','" + Saldo + "'", Conexion);
            try
            {
                Conexion.Open();
                Insertar.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                Conexion.Close();
                return false;
            }
        }

        [WebMethod]
        public bool GuardarIMC(string Nombre, double Peso, double Estatura, double Resultado, string Estado)
        {
            var Conexion = new SqlConnection("Server=tcp:alvaromelesio.database.windows.net,1433;Initial Catalog =IMC;Persist Security Info=False;User ID=Alvaro;Password=Password01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;");
            var Insertar = new SqlCommand("EXECUTE Guardar '" + Nombre + "','" + Peso + "','" + Estatura + "','" + Resultado + "','" + Estado + "'", Conexion);

            try
            {
                Conexion.Open();
                Insertar.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                Conexion.Close();
                return false;
            }
        }

        [WebMethod]
        public DataSet BuscarIMC(string Nombre, int Dia, string Mes)
        {
            var Conexion = new SqlConnection("Server=tcp:alvaromelesio.database.windows.net,1433;Initial Catalog =IMC;Persist Security Info=False;User ID=Alvaro;Password=Password01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;");
            var Consulta = new SqlDataAdapter("EXECUTE Buscar '" + Nombre + "','" + Dia + "','" + Mes + "'", Conexion);
            var Conjunto = new DataSet();
            try
            {
                Conexion.Open();
                Consulta.Fill(Conjunto, "Datos");
                Conexion.Close();
                return Conjunto;
            }
            catch (System.Exception ex)
            {
                Conexion.Close();
                return Conjunto;
            }
        }

        [WebMethod]
        public bool GuardarLogin(string Nombre, string Domicilio, string Correo, int Edad, double Saldo)
        {
            //var Conexion = new SqlConnection("Data Source=ALVARO-THINK\\SQLEXPRESS; Initial Catalog = InfoMovil; User ID = sa; Password = 12345");
            var Conexion = new SqlConnection("Server=tcp:alvarom.database.windows.net,1433;Initial Catalog=Informacion;Persist Security Info=False;User ID=Alvaro;Password=Password01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var Insertar = new SqlCommand("INSERT INTO Login (Nombre, Domicilio, Correo, Edad, Saldo) VALUES ('" + Nombre + "','" + Domicilio + "','" + Correo + "','" + Edad + "','" + Saldo + "')", Conexion);

            try
            {
                Conexion.Open();
                Insertar.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                Conexion.Close();
                return false;
            }
        }

        [WebMethod]
        public DataSet BusquedaLogin(int Folio)
        {
            var Conexion = new SqlConnection("Server=tcp:alvarom.database.windows.net,1433;Initial Catalog=Informacion;Persist Security Info=False;User ID=Alvaro;Password=Password01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var Consulta = new SqlDataAdapter("SELECT * FROM Login WHERE Folio='" + Folio + "'", Conexion);
            var Conjunto = new DataSet();
            try
            {
                Conexion.Open();
                Consulta.Fill(Conjunto, "Login");
                Conexion.Close();
                return Conjunto;
            }
            catch (System.Exception ex)
            {
                Conexion.Close();
                return Conjunto;
            }
        }

        [WebMethod]
        public bool SignUp_ExF(string usr, string psw)
        {
            //var Conexion = new SqlConnection("Data Source=ALVARO-THINK\\SQLEXPRESS; Initial Catalog = InfoMovil; User ID = sa; Password = 12345");
            var Conexion = new SqlConnection("Server=tcp:alvarom.database.windows.net,1433;Initial Catalog=ExamenFinal;Persist Security Info=False;User ID=Alvaro;Password=Password01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var Insertar = new SqlCommand("Execute p_SignUp '" + usr + "','" + psw + "'", Conexion);

            try
            {
                Conexion.Open();
                Insertar.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                Conexion.Close();
                return false;
            }
        }

        [WebMethod]
        public DataSet CountLogin_ExF(string usr, string psw)
        {
            var Conexion = new SqlConnection("Server=tcp:alvarom.database.windows.net,1433;Initial Catalog=ExamenFinal;Persist Security Info=False;User ID=Alvaro;Password=Password01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var Consulta = new SqlDataAdapter("Execute p_Login '" + usr + "','" + psw + "'", Conexion);
            var Conjunto = new DataSet();
            try
            {
                Conexion.Open();
                Consulta.Fill(Conjunto, "Login");
                Conexion.Close();
                return Conjunto;
            }
            catch (System.Exception ex)
            {
                Conexion.Close();
                return Conjunto;
            }
        }

        [WebMethod]
        public DataSet NoSignUp_ExF(string usr)
        {
            var Conexion = new SqlConnection("Server=tcp:alvarom.database.windows.net,1433;Initial Catalog=ExamenFinal;Persist Security Info=False;User ID=Alvaro;Password=Password01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var Consulta = new SqlDataAdapter("Execute p_NoSignUp '" + usr + "'", Conexion);
            var Conjunto = new DataSet();
            try
            {
                Conexion.Open();
                Consulta.Fill(Conjunto, "NoSignUp");
                Conexion.Close();
                return Conjunto;
            }
            catch (System.Exception ex)
            {
                Conexion.Close();
                return Conjunto;
            }
        }

        [WebMethod]
        public bool Guardar_ExF(string Nombre, double Saldo, int Edad, string Direccion, string Correo)
        {
            //var Conexion = new SqlConnection("Data Source=ALVARO-THINK\\SQLEXPRESS; Initial Catalog = InfoMovil; User ID = sa; Password = 12345");
            var Conexion = new SqlConnection("Server=tcp:alvarom.database.windows.net,1433;Initial Catalog=ExamenFinal;Persist Security Info=False;User ID=Alvaro;Password=Password01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var Insertar = new SqlCommand("EXECUTE Agregar'" + Nombre + "','" + Saldo + "','" + Edad + "','" + Direccion + "','" + Correo + "'", Conexion);

            try
            {
                Conexion.Open();
                Insertar.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                Conexion.Close();
                return false;
            }
        }
    }
}
