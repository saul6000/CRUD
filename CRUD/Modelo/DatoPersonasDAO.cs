using CRUD.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TIC
{
    public static class DatoPersonasDAO
    {
        private static string cadenaConexion = "Server=JOHNDAY;database=TI2020;user id=sa; password=123456;";
        public static int creacion(DatosPersonas datosPersonas)
        {
       
            
            //1 Configurar la  conexion de datos con una fuente de datos 
           // string cadenaConexion = "Server=JOHNDAY;database=TI2020;user id=sa; password=123456;";
            //definir un objeto tipo conexion 
            SqlConnection conn = new SqlConnection(cadenaConexion);
            //2 Definir la opercion a realizar en el motor BDD
            //Escribir sentecia SQL
            string sql = "insert into Datos_Personas(Cedula,Apellidos,Nombres,Sexo," + "FechaNacimineto,Correo,Estatura_Cm,Peso) values(@Cedula,@Apellidos,@Nombres,@Sexo,@FechaNacimineto,@Correo,@Estatura_Cm,@Peso)";
            // definir un comando para ejecutar esa sentencia sql (operacion a realizar)
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.CommandType = System.Data.CommandType.Text; //valor por defecto 
            comando.Parameters.AddWithValue("@Cedula", datosPersonas.Cedula);
            comando.Parameters.AddWithValue("@Apellidos", datosPersonas.Apellidos);
            comando.Parameters.AddWithValue("@Nombres", datosPersonas.Nombres);
            comando.Parameters.AddWithValue("@Sexo", datosPersonas.Sexo);
            comando.Parameters.AddWithValue("@FechaNacimineto", datosPersonas.FechaNacimineto.Date);
            comando.Parameters.AddWithValue("@Correo", datosPersonas.Correo);
            comando.Parameters.AddWithValue("@Estatura_Cm", datosPersonas.Estatura);
            comando.Parameters.AddWithValue("@Peso", datosPersonas.Peso);
            //3 Se habre la conexion y se ejecuta el comando 
            conn.Open();

                int x = comando.ExecuteNonQuery();
            //4 cerra la conexion 
            conn.Close();

            return x;
            }

        // public static int crear2 (DatosPersonas datosPersonas) 
        public static DataTable getAll()
        {

            //1. definir y configurar conexión
            SqlConnection conn = new SqlConnection(cadenaConexion);
            //2. Definir y Cinfigurar la operacion a realizar en el motor de BDD 
            //escribir sentencia sql
            string sql = "select Cedula Cédula,Apellidos + ' ' + Nombres [NombreCompleto],Sexo Género," + "FechaNacimineto,Correo,Estatura_Cm " + "from Datos_Personas " +
                "order by apellidos,nombres";
            //2.1 Definir un adptador de datos: es un puente que permite pasa los datos de muestra , hacia el datatable
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            //3 recuperamos los datos 
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }
        public static Boolean existeCedula(string scedula)
        {
        
            //1. definir y configurar conexión
            SqlConnection conn = new SqlConnection(cadenaConexion);
            //2. Definir y Cinfigurar la operacion a realizar en el motor de BDD 
            //escribir sentencia sql
            string sql = "select Cedula " +"from Datos_Personas " + "where Cedula=@Cedula";
            //2.1 Definir un adptador de datos: es un puente que permite pasa los datos de muestra , hacia el datatable
            SqlDataAdapter ad = new SqlDataAdapter(sql,conn);
            ad.SelectCommand.Parameters.AddWithValue("@Cedula",scedula);
            //3 recuperamos los datos 
            DataTable dt = new DataTable();
            ad.Fill(dt);
            Boolean existe = false;
            if (dt.Rows.Count > 0)
                existe = true;
            return existe;

        }
      

    }
    
    }

