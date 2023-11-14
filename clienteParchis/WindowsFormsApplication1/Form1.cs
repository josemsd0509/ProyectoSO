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
    public partial class Form1 : Form
    {
        Socket server;
        Thread atender;

        public Form1(Form2.Datos info)
        {
            InitializeComponent();
            conectado1.Text = info.Nombre;
            CheckForIllegalCrossThreadCalls = false;//Necesario para acceder a threads de momento
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
          
        }


        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos mensaje del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string [] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje;
                switch (codigo)
                {  
                   case 1: //respuesta a gandor de la partida 
                   mensaje = trozos[1].Split('\0')[0];
                   MessageBox.Show("El nombre del ganador es: " + mensaje);
                   break;
                    
                    case 2://Jugadores hombres
                    mensaje = trozos[1].Split('\0')[0];
                    MessageBox.Show(mensaje);
                    break;
                      

                    case 3: //partida en la que jugaron juntos
                    mensaje = trozos[1].Split('\0')[0];
                    MessageBox.Show(mensaje);
                    break;
                    
                   case 4:     
                   listBox33.Items.Clear();
                   int i;
                   for (i=1; i < trozos.Length; i++)
                   {
                       if (i == 1)
                           listadeconectados.Text = trozos[1];
                       else
                     listBox33.Items.Add(Convert.ToString(trozos[i]));
                   }
                
                     break;

                }
            }
        }
        

        private void button1_Click(object sender, EventArgs e )
        {
     
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9040);           

            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {   
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");

      
          
                button1.Visible = false;
                button3.Visible = true;
            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
            //ponemos en marcha los threads
            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();
            listBox33.Visible = true;
            listadeconectados.Visible = true;
            string mensaje = "10/" + conectado1.Text;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);


        }

        private void button2_Click(object sender, EventArgs e)
        {    
            if ( Ganador.Checked)
            {
                string mensaje = "1/" + partida.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

               
            }
            else if (Hombres.Checked)
            {
                string mensaje = "2/" + partida.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                // Enviamos nombre y altura
                string mensaje = "3/" + jugador1.Text + "/" + jugador2.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
             
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexión
            string mensaje = "0/" + conectado1.Text;
        
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            atender.Abort();
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();

            listadeconectados.Visible = false;
            listBox33.Visible = false;
        
            button1.Visible = true;
            button3.Visible = false;
           


        }

      

     
    }
}
