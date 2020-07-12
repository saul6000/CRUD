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

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            TIC.DatosPersonas personas = new TIC.DatosPersonas();
            
            personas.Cedula = txtCedula.Text;
            if (personas.Cedula.Length == 0)
            {
                MessageBox.Show("Numero de cedula no ingresado");
                txtCedula.Focus();
            }
            personas.Apellidos = txtApellidos.Text;
            personas.Nombres = txtNombres.Text;
            personas.Sexo = cmbSexo.Text;
            personas.FechaNacimineto = dtFechaNacimineto.Value;
            
            personas.Correo = txtCorreo.Text;
            if (personas.Correo.Length == 0)
            {
                MessageBox.Show("correo no ingresado");
                txtCorreo.Focus();
            }
            personas.Estatura = int.Parse(txtEstatura.Text);
            personas.Peso = int.Parse(txtPeso.Text);
            int x = TIC.DatoPersonasDAO.creacion(personas);
            if (x > 0)

                MessageBox.Show("Registro Agregado..");

            else
                MessageBox.Show("No se pudo agregar el registro");
           
           

        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Tarea_ListaGénericas.validar.Numeros(e);
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Tarea_ListaGénericas.validar.letra(e);
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            Tarea_ListaGénericas.validar.letra(e);
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Tarea_ListaGénericas.validar.letra(e);
        }

        private void txtEstatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            Tarea_ListaGénericas.validar.Numeros(e);
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            Tarea_ListaGénericas.validar.Numeros(e);
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
            txtEstatura.Clear();
            txtCorreo.Clear();
            txtApellidos.Clear();
            txtNombres.Clear();
            txtCedula.Clear();
            txtPeso.Clear();
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
