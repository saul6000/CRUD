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

        private void txtcedula_TextChanged(object sender, EventArgs e)
        {

           



        }

        private void button1_Click(object sender, EventArgs e)
        {
            TIC.DatosPersonas personas = new TIC.DatosPersonas();
            DataTable dt = TIC.DatoPersonasDAO.getAll();
            
            FrmIngresar ps =new  FrmIngresar();
            
            personas.Cedula = txtcedula.Text;
            personas.Apellidos = txtApellidos.Text;
            personas.Nombres = txtNombres.Text;
            personas.Sexo = cmbGenero.Text;
            personas.FechaNacimineto = dtFechaNacimiento.Value;
            
            personas.Correo = txtCorreo.Text;
            personas.Estatura = int.Parse(txtEstatura.Text);
            personas.Peso = decimal.Parse(txtPeso.Text);
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
    }
}
