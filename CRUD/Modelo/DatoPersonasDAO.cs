using CRUD;
using CRUD.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
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
            string sql = "select  Cedula Cédula,Apellidos,Nombres,Sexo Género," + "FechaNacimineto,Correo,Estatura_Cm,Peso " + "from Datos_Personas " +
                "order by apellidos,nombres";
            //2.1 Definir un adptador de datos: es un puente que permite pasa los datos de muestra , hacia el datatable
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            //3 recuperamos los datos 
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }
        public static DataTable GetpersonasEdad()
        {

            //1. definir y configurar conexión
            SqlConnection conn = new SqlConnection(cadenaConexion);
            //2. Definir y Cinfigurar la operacion a realizar en el motor de BDD 
            //escribir sentencia sql
            string sql = "select  Cedula Cédula" +
                ",upper(Apellidos+' '+Nombres)+'('+ltrim(str(DATEDIFF(year,FechaNacimineto,GETDATE()))) +' años)'[Nombre Completo],Sexo Género," + "FechaNacimineto,Correo,Estatura_Cm,Peso " + "from Datos_Personas " +
                "order by Apellidos,Nombres";
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
        public static int btbdelete(string scedula)

        {
            SqlConnection conn = new SqlConnection(cadenaConexion);
          
      
            string sql = "delete from Datos_Personas  where Cedula=@Cedula";
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.Parameters.AddWithValue("@Cedula", scedula);
            conn.Open();
          int  x = comando.ExecuteNonQuery();
            conn.Close();
            return x;

        }
        public static DatosPersonas getPersona(String scedula)
        {
           
            SqlConnection conn = new SqlConnection(cadenaConexion);
          
            string sql = "select Cedula,Apellidos,Nombres,Sexo,Correo,FechaNacimineto,Estatura_Cm,Peso " +
                "from Datos_Personas " + 
                "where Cedula=@Cedula "+ 
                "order by Apellidos,Nombres" ;
          
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            ad.SelectCommand.Parameters.AddWithValue("@Cedula", scedula);
        
            DataTable dt = new DataTable();
            ad.Fill(dt);
            DatosPersonas persona = new DatosPersonas();
            if (dt.Rows.Count > 0) 
            {
                foreach (DataRow fila in dt.Rows)
                {
                   
                    persona.Cedula = fila["Cedula"].ToString();
                    persona.Apellidos = fila["Apellidos"].ToString();
                    persona.Nombres = fila["Nombres"].ToString();
                    persona.Sexo = fila["Sexo"].ToString();
                    persona.FechaNacimineto =DateTime.Parse( fila["FechaNacimineto"].ToString());
                    persona.Correo = fila["Correo"].ToString();
                    persona.Estatura = int.Parse(fila["Estatura_Cm"].ToString());
                    persona.Peso = decimal.Parse(fila["Peso"].ToString());
                    break; //abandonar bucle


                }
            }
                return persona;
        }
        public static int update (DatosPersonas datosPersonas)
        {
            SqlConnection conn = new SqlConnection(cadenaConexion);


           string sql = " UPDATE Datos_Personas SET Apellidos=@Apellidos, Nombres=@Nombres, Sexo=@Sexo, FechaNacimineto=@FechaNacimineto, Correo=@Correo, Estatura_Cm=@Estatura_Cm, Peso=@Peso WHERE Cedula=@Cedula";
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.Parameters.AddWithValue("@Cedula", datosPersonas.Cedula);
            comando.Parameters.AddWithValue("@Apellidos", datosPersonas.Apellidos);
            comando.Parameters.AddWithValue("@Nombres", datosPersonas.Nombres);
            comando.Parameters.AddWithValue("@Sexo", datosPersonas.Sexo);
            comando.Parameters.AddWithValue("@FechaNacimineto", datosPersonas.FechaNacimineto.Date);
            comando.Parameters.AddWithValue("@Correo", datosPersonas.Correo);
            comando.Parameters.AddWithValue("@Estatura_Cm", datosPersonas.Estatura);
            comando.Parameters.AddWithValue("@Peso", datosPersonas.Peso);
            conn.Open();
            int x = comando.ExecuteNonQuery();
            conn.Close();
            return x;
        }


    }
    
    }

