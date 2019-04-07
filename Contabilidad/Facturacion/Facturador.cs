using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContabilidadDAO;
using ContabilidadDTO;
using System.Windows.Forms;
using System.Net;

namespace Contabilidad
{
    public partial class Facturador : Form
    {
   
        public Facturador()
        {
            InitializeComponent();
            webBrowser1.Navigate(new Uri("http://www.google.com"));
        }

      
    }
}
