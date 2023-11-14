﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApplication1
{   
    public partial class Form1 : Form
    {
        Socket server;


        public Form1(Form2.Datos info)
        {
            InitializeComponent();
            conectado1.Text = info.Nombre;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
          
        }
        

        private void button1_Click(object sender, EventArgs e )
        {
     
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9090);
            

            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {   
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");

               string mensaje = "10/" + conectado1.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                BotonConectados.Visible = true;
                button1.Visible = false;
                button3.Visible = true;
            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {    
            if ( Ganador.Checked)
            {
                string mensaje = "1/" + partida.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split ('\0')[0];
                MessageBox.Show("El nombre del ganador es: " + mensaje);
            }
            else if (Hombres.Checked)
            {
                string mensaje = "2/" + partida.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

                    MessageBox.Show(mensaje);

            }
            else
            {
                // Enviamos nombre y altura
                string mensaje = "3/" + jugador1.Text + "/" + jugador2.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show(mensaje);
            }
             
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexión
            string mensaje = "0/" + conectado1.Text;
        
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
            listadeconectados.Visible = false;
            BotonConectados.Visible = false;
            listBox33.Visible = false;
            BotonConectados.Text = "Jugadores Conectados";
            button1.Visible = true;
            button3.Visible = false;
           


        }

        private void BotonConectados_Click(object sender, EventArgs e)
        {
            listBox33.Items.Clear();
            string mensaje = "11/";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Recibimos la respuesta del servidor
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            int i;
            char[] delimitador ={'/'};
            string[] trozos =mensaje.Split(delimitador);
            for (i = 0; i < trozos.Length; i++)
            {
                if (i == 0)
                    listadeconectados.Text = trozos[i];
                else
                listBox33.Items.Add(trozos[i]);
            }

            listBox33.Visible = true;
            listadeconectados.Visible=true;
            BotonConectados.Text = "Actualizar";
           
        }

     
    }
}
