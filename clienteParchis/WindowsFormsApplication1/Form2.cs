using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        Form1 ventana1;
        Socket server;
        string sms;
        int nForm;
       public Form2(int nForm ,Socket server,Form1 ventana)
        {
            InitializeComponent();
            this.server = server;
            this.nForm = nForm;
            ventana1 = ventana;
            ventana1.Invoke(new Action(() =>
            { ventana1.Visible = false; }));
            
        }
        public struct Datos
        {
            public string Nombre;
        }

     

        private void boton1_Click(object sender, EventArgs e)
        {
           
             sms = jnombre.Text;
             this.Hide();
             ventana1.Invoke(new Action(() =>
           { ventana1.Visible = true; }));
            ventana1.SetNombre(sms);

        }

    }
}
