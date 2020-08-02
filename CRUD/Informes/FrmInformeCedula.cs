using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD.Informes
{
    public partial class FrmInformeCedula : Form
    {
        public FrmInformeCedula()
        {
            InitializeComponent();
        }

        private void FrmInformeCedula_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsCedula.Datos_Personas' Puede moverla o quitarla según sea necesario.
            this.datos_PersonasTableAdapter.Fill(this.dsCedula.Datos_Personas);

            this.reportViewer1.RefreshReport();
        }
    }
}
