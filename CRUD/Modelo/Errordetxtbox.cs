using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD.Modelo
{
    public partial class Errordetxtbox : TextBox
    {
        public Errordetxtbox()
        {
            InitializeComponent();
        }
        public Boolean validar      {
            set;
            get;
            
        }
    }
}
