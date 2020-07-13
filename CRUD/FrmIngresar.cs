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
        private void cargarGridPersonas()
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
                txtApellidos.Focus();
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

            int x = TIC.DatoPersonasDAO.creacion(personas);
            try {   
            if (x > 0)

                MessageBox.Show("Registro Agregado..");

            else
                MessageBox.Show("No se pudo agregar el registro");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            this.txtCedula.Clear();
            this.txtApellidos.Clear();
            this.txtNombres.Clear();
            this.txtCorreo.Clear();
            this.txtEstatura.Clear();
            this.txtPeso.Clear();

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
            this.errorP.Clear();

            foreach (char letra in this.txtEstatura.Text)
            {
                if (!char.IsDigit(letra))
                {
                    this.errorP.SetError(this.txtEstatura, "El campo sólo acepta campos numéricos");
                    break;
                }
               
                
            }
        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {
            this.errorP.Clear();

            foreach (char letra in this.txtEstatura.Text)
            {
                if (!char.IsDigit(letra))
                {
                    this.errorP.SetError(this.txtEstatura, "El campo sólo acepta campos numéricos");
                    break;
                }


            }
        }
    }
}
