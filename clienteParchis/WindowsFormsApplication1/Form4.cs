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
    public partial class Form4 : Form
    {
        Socket server;
        int nForm;
        int partida1;
        string chats;
        string nombrechat;

        public Form4(int nForm ,Socket server)
        {
            InitializeComponent();
            this.server = server;
            this.nForm = nForm;
            
           
           
        }
        //usaremos codigo 20 para todas las peticiones
       
        public void EmpezarPartida(int partida)
        {
            partida1 = partida;
            string mensaje = "20/"+nForm +"/"+ partida1+"/";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
           

        }
        public void TomaNombre(string nombre)
        {
            nombrechat=nombre; 
        }
        public void InicializarPartida(string mensaje)
        {
            string sms = mensaje;
            string[] trozos = sms.Split('-');
            int i = Convert.ToInt32(trozos[0]);
            if (i == 2)
            {
                JugadorParchis1.Invoke(new Action(() =>
                { JugadorParchis1.Text = trozos[1]; }));
                JugadorParchis2.Invoke(new Action(() =>
                { JugadorParchis2.Text = trozos[2]; }));
            }
            else if (i == 3)
            {
                JugadorParchis1.Invoke(new Action(() =>
                { JugadorParchis1.Text = trozos[1]; }));
                JugadorParchis2.Invoke(new Action(() =>
                { JugadorParchis2.Text = trozos[2]; }));
                JugadorParchis3.Invoke(new Action(() =>
                { JugadorParchis3.Text = trozos[3]; }));
            }
            else
            {
                JugadorParchis1.Invoke(new Action(() =>
                { JugadorParchis1.Text = trozos[1]; }));
                JugadorParchis2.Invoke(new Action(() =>
                { JugadorParchis2.Text = trozos[2]; }));
                JugadorParchis3.Invoke(new Action(() =>
                { JugadorParchis3.Text = trozos[3]; }));
                JugadorParchis4.Invoke(new Action(() =>
                { JugadorParchis4.Text = trozos[4]; }));
            }
        }

        public void PonerMensaje(string mensaje)
        {
            chats = mensaje;
           
            string[] trozos = mensaje.Split('^');
            listBox1.Invoke(new Action(() =>
            {
                listBox1.Items.Clear();
                
                for (int i=0; i < trozos.Length; i++)
                {
                        listBox1.Items.Add(Convert.ToString(trozos[i]));
                }
            }));

        }

        private void button1_Click(object sender, EventArgs e)
        {  
            string mensaje = "21/" + partida1  + "/" +nForm + "/" + chats + "^" +nombrechat+": "+ textBox1.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            textBox1.Invoke(new Action(() =>
            { textBox1.Clear(); }));
            
        }



        
    }
}
