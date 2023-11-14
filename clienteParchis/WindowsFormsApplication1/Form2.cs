using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public struct Datos
        {
            public string Nombre;
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            Datos info;
            info.Nombre = jnombre.Text;
            this.Hide();
            Form1 v1 = new Form1(info);
            v1.Show();
        }

    }
}
