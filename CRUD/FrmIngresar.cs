using CRUD.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIC;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Data.SqlClient;


namespace CRUD
{
    public partial class FrmIngresar : Form
    {
       

        public FrmIngresar()
        {
            InitializeComponent();
           
        }

        private void FrmIngresar_Load(object sender, EventArgs e)
        {

            //  this.datos_PersonasTableAdapter.Fill(this.tI2020DataSet.Datos_Personas);
            this.cargarGridPersonas();
            

        }
       public void cargarGridPersonas()
        {
            DataTable dt = TIC.DatoPersonasDAO.getAll();
            this.dgPersonas.DataSource = dt;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            TIC.DatosPersonas personas = new TIC.DatosPersonas();

            if (txtCedula.Text.Trim() == "")
            {
                errorP.SetError(txtCedula, "Introduzca Numero de Cedula...");
                txtCedula.Focus();
                return;
            }

            else
            {
                errorP.Clear();
            }

            if (txtApellidos.Text.Trim() == "")
            {
                errorP.SetError(txtApellidos, "Introduzca el apellido...");
                txtApellidos.Focus();
                return;
            }

            else
            {
                errorP.Clear();
            }
            if (txtNombres.Text.Trim() == "")
            {
                errorP.SetError(txtNombres, "Introduzca el Nombre...");
                txtNombres.Focus();
                return;
            }
            else
            {
                errorP.Clear();
            }
            if (cmbSexo.Text.Trim() == "")
            {
                errorP.SetError(cmbSexo, "Introduzca el sexo ");
                this.cmbSexo.Focus();
                return;
            }
            else
            {
                errorP.Clear();
            }
 
            if (this.cmbSexo.Text == "Femenino")
            {
                this.cmbSexo.Text = "Femenino";
            }
            else
            {
                this.cmbSexo.Text = "Masculino";
            }
            personas.Cedula = txtCedula.Text;                                  
            personas.Apellidos = txtApellidos.Text;         
            personas.Nombres = txtNombres.Text;          
            personas.Sexo = cmbSexo.Text;
            personas.FechaNacimineto = dtFechaNacimineto.Value;

            validar_correo ps = new validar_correo();
            if (ps.Email_Valido(this.txtCorreo.Text) == false)
            {
                error1.SetError(this.txtCorreo, " Ingrese un Email Válido");
                this.txtCorreo.Focus();
                return;
            }
            else
            {
                error1.Clear();
                btnGuardar.Visible = true;

            }
            personas.Correo = txtCorreo.Text;
            try
            {
                personas.Estatura = int.Parse(txtEstatura.Text);
            }
            catch
            {
                MessageBox.Show("Parametro de Estatura no ingresada");
                
            }
            

          try{  
                personas.Peso = decimal.Parse(txtPeso.Text);
            }
            catch {

                MessageBox.Show("Parametro de Peso no Ingresado");
            }

          //  
            int x = 0;
            try {   
                if (TIC.DatoPersonasDAO.existeCedula(this.txtCedula.Text))
                {
                    MessageBox.Show("Esa Cedula ya exite...");
                    return; //abandonar;
                }
                x = TIC.DatoPersonasDAO.creacion(personas);
                if (x > 0)

                MessageBox.Show("Registro Agregado..");

            else
                MessageBox.Show("No se pudo agregar el registro");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                this.cargarGridPersonas();
            }




        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Tarea_ListaGénericas.validar.Numeros(e);
        }

      

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            Tarea_ListaGénericas.validar.letra(e);
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtEstatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            Tarea_ListaGénericas.validar.Numeros(e);
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {

            Tarea_ListaGénericas.validar.ValidarCampoDecimal((TextBox)sender);
        }

        private void cmbSexo_KeyPress(object sender, KeyPressEventArgs e)
        {
              
            if (cmbSexo.MaxLength == 0)
            {
                Tarea_ListaGénericas.validar.Numeros(e);
            }
            if (cmbSexo.Text == "") { 
                Tarea_ListaGénericas.validar.letra(e); 
            }
         

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtdelete.Clear();
            txtCorreo.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtCedula.Clear();
            txtPeso.Clear();
            txtEstatura.Clear();
            

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEstatura_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {
          

           
        }

        private void btbdelete_Click(object sender, EventArgs e)
        {
            int x = 0;
           
            try {
                x = TIC.DatoPersonasDAO.btbdelete(txtdelete.Text);
                if (x == 1)
            {
              
                MessageBox.Show("Registro Borrado");
                    

            }
            else
            {
                MessageBox.Show("Numero de Cedula no registrado ");
                 
                }
            }
            catch 
            {
                MessageBox.Show("Este campo no es el numero de cedula por favor solo ingrese su numero de cedula");
            }
            finally
            {
                this.cargarGridPersonas();
            }
        }

        private void dgPersonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {

         /*try{  
                txtdelete.Text = dgPersonas.CurrentCell.Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("");
            }*/
            

        }

       private void dgPersonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
           // MessageBox.Show("Fila: " + fila.ToString() + ", col: " + col.ToString());
           
           
            DataGridView grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex].Name == "linkEliminar")
            {
               
                int fila = e.RowIndex;
                
                // MessageBox.Show("Fila: " + fila.ToString() + ", col: " + col.ToString());
                string cedula = dgPersonas[2, fila].Value.ToString();
                
                string confirmMessage = string.Format("¿Está seguro de que desea eliminar a la persona de numero de cedula {0}?"
                    , grid.Rows[fila].Cells[2].Value);
                if (MessageBox.Show(confirmMessage, "Eliminar Persona", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MessageBox.Show("Registro Eliminado Exitosamente");
                    grid.Rows.RemoveAt(fila);
                    int x = TIC.DatoPersonasDAO.btbdelete(cedula);
                  
                    
                }

               

                   

            }
            if (grid.Columns[e.ColumnIndex].Name == "linkModificar")
            {

                int fila = e.RowIndex;

                // MessageBox.Show("Fila: " + fila.ToString() + ", col: " + col.ToString());
                string cedula = dgPersonas[2, fila].Value.ToString();

                string confirmMessage = string.Format("¿Está seguro que quiere modificar el registro de numero de cedula {0}?"
                    , grid.Rows[fila].Cells[2].Value);
                if (MessageBox.Show(confirmMessage, "Modificar Persona", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    
                    
                    DatosPersonas x = TIC.DatoPersonasDAO.getPersona(cedula);
                    Modificar asereje = new Modificar(x);
                    asereje.ShowDialog();
                    cargarGridPersonas();


                }



            }
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
