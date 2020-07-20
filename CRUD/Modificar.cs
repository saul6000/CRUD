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
using CRUD.Modelo;
namespace CRUD
{
    public partial class Modificar : Form
    {
        public Modificar(DatosPersonas info)
        {
            InitializeComponent();
            txtcedula.Text = info.Cedula;
            txtApellidos.Text = info.Apellidos;
            txtNombres.Text = info.Nombres;
          cmbGenero.Text = info.Sexo;
            dtFechaNacimiento.Text = info.FechaNacimineto.ToString();
            txtCorreo.Text = info.Correo;
            txtEstatura.Text =string.Concat( info.Estatura);
            txtPeso.Text = string.Concat(info.Peso);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TIC.DatosPersonas personas = new TIC.DatosPersonas();
           

            if (txtApellidos.Text.Trim() == "")
            {
                error1.SetError(txtApellidos, "Introduzca el apellido...");
                txtApellidos.Focus();
                return;
            }

            else
            {
                error1.Clear();
            }
            if (txtNombres.Text.Trim() == "")
            {
                error1.SetError(txtNombres, "Introduzca el Nombre...");
                txtNombres.Focus();
                return;
            }
            else
            {
                error1.Clear();
            }
            if (cmbGenero.Text.Trim() == "")
            {
                error1.SetError(cmbGenero, "Introduzca el sexo ");
                this.cmbGenero.Focus();
                return;
            }
            else
            {
                error1.Clear();
            }

            if (this.cmbGenero.Text == "Femenino")
            {
                this.cmbGenero.Text = "Femenino";
            }
            else
            {
                this.cmbGenero.Text = "Masculino";
            }
            personas.Cedula = txtcedula.Text;
            personas.Apellidos = txtApellidos.Text;
            personas.Nombres = txtNombres.Text;
            personas.Sexo = cmbGenero.Text;
            personas.FechaNacimineto = dtFechaNacimiento.Value;
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
                

            }
            personas.Correo = txtCorreo.Text;
            try
            {
            personas.Estatura = int.Parse(txtEstatura.Text);
            personas.Peso = decimal.Parse(txtPeso.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            int x = 0;
           
            
            try
            {
               

                x = TIC.DatoPersonasDAO.update(personas);
                if (x > 0)

                    MessageBox.Show("Actualizacion completa");
                

                else
                    MessageBox.Show("No se pudo agregar el registro");
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                  
                this.Close();
            }
            


        }

        public void Modificar_Load(object sender, EventArgs e)
        {
            

        }

        private void btbcerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
