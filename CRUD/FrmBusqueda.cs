using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class FrmBusqueda : Form
    {
        public FrmBusqueda()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void cargarComboPersonas()
        {
            DataTable dt = TIC.DatoPersonasDAO.GetpersonasEdad();
            this.cmCedula.DataSource = dt;
            this.cmCedula.ValueMember= "Cédula";
            this.cmCedula.DisplayMember = "Nombre Completo";
          
          
        }
        private void FrmBusqueda_Load(object sender, EventArgs e)
        {
            this.cmCedula.SelectedIndexChanged-=new System.EventHandler(this.cmCedula_SelectedIndexChanged);
            this.cargarComboPersonas();
            this.cmCedula.SelectedIndexChanged += new System.EventHandler(this.cmCedula_SelectedIndexChanged);
        }
        private void cargarPersona(TIC.DatosPersonas personas)
        {



            //cargar los datos en los texbox
          
            this.txtCedula.Text = personas.Cedula;
            this.txtApellidos.Text = personas.Apellidos;
            this.txtNombres.Text = personas.Nombres;

           

            if (personas.Sexo == "Masculino")
            {
                this.cmbSexo.Text = "Masculino";
            }
            else
            {
                this.cmbSexo.Text = "Femenino";
            }
           
           
                this.dtFechaNacimiento.Value = personas.FechaNacimineto; 
           
            this.txtCorreo.Text = personas.Correo;
            this.txtEstatura.Text = personas.Estatura.ToString();
            this.txtPeso.Text = personas.Peso.ToString();
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {

            string cedula = this.cmCedula.SelectedValue.ToString();
            TIC.DatosPersonas personas = new TIC.DatosPersonas();
            personas = TIC.DatoPersonasDAO.getPersona(cedula);
            cargarPersona(personas);
        }

        private void cmCedula_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cedula = this.cmCedula.SelectedValue.ToString();
            if (this.cmCedula.SelectedIndex < 0)
            {
                return ;
            }
           
                if (cedula.Length > 0)
            {
                TIC.DatosPersonas persona = new TIC.DatosPersonas();
                persona = TIC.DatoPersonasDAO.getPersona(cedula);
                this.cargarPersona(persona);

            }
        }
    }
}
