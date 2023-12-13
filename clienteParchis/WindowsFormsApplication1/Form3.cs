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
    public partial class Form3 : Form
    {
        Socket server;
        string sms;
        int nForm;
        Form1 ventana1;
        int partida;
        public Form3(int nForm ,Socket server,Form1 ventana)
        {
            InitializeComponent();
            this.server = server;
            this.nForm = nForm;
            ventana1 = ventana;
            sms = ventana1.mensaje();
            Nom.Text = sms;
            partida = ventana1.part;
        }
       


        private void Acept_Click(object sender, EventArgs e)
        {    //1 aceptado
            string mensaje = "13/"+nForm+"/"+partida+ "/1/";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            this.Close();

        }

        private void Deneg_Click(object sender, EventArgs e)
        { //0 no pacepto la partida
            string mensaje = "13/" + nForm +"/"+partida+ "/0/" ;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            this.Close();

        }

    }
}
