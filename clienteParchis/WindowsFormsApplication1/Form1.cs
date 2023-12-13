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
    {   string Nombre;
        string invitacion;
        int value;
        int partidaparchis;
        Socket server;
        Thread atender;
        string jugadores;
       public  int part;
       public string chatsms;
       string jugadoresP;
       int nform4;
       string suma;
   
        delegate void DelegadoParaPonerTexto(string texto);

        List<Form3> formularios = new List<Form3>();
        List<Form2> formularios2 = new List<Form2>();
        List<Form4> formularios4 = new List<Form4>();

        public Form1()
        {
            InitializeComponent();
        }
           
           




        private void Form1_Load(object sender, EventArgs e)
        {  
            LogIn();
            value = 0;
        }

        
       private void LogIn()
       {      
            ThreadStart ts = delegate {  int cont = formularios.Count;
            Form2 f2 = new Form2(cont,server,this);
            formularios2.Add(f2);
            f2.ShowDialog();; };
            Thread T = new Thread(ts);
            T.Start();
        }

        private void AtenderServidor()
        {
            while (true)
            {
                string mensaje;
                //Recibimos mensaje del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                string[] trozos = mensaje.Split('/');
                int nform3;
      
                int codigo = Convert.ToInt32(trozos[0]);

                switch (codigo)
                {
                    case 1: //respuesta a gandor de la partida 

                        MessageBox.Show("El nombre del ganador es: " + mensaje);
                        break;

                    case 2://Jugadores hombres
                        mensaje = trozos[1];
                        MessageBox.Show(mensaje);
                        break;


                    case 3: //partida en la que jugaron juntos
                        mensaje = trozos[1];
                        MessageBox.Show(mensaje);
                        break;

                    case 4:
                        listBox33.Invoke(new Action(() =>
                        {
                            listBox33.Items.Clear();
                            int i;
                            for (i = 1; i < trozos.Length; i++)
                            {
                                if (i == 1)
                                    listadeconectados.Text = trozos[1];
                                else
                                    listBox33.Items.Add(Convert.ToString(trozos[i]));
                            }
                        }));


                        break;

                    case 5: //Enviar invitacion
                        ThreadStart ts = delegate { PonerEnMarchaFormulario(); };
                        Thread T = new Thread(ts);
                         T.Start();
                        nform3 = Convert.ToInt32(trozos[1]);
                        invitacion = "El jugador " + Convert.ToString(trozos[3]) + " te invita a la partida" + Convert.ToString(trozos[2])+".";
                        part = Convert.ToInt32(trozos[2]);
                        break;

                case 6://todo sobre aceptar o no la partida
                    int aceptado;
                    
                     aceptado=Convert.ToInt32(trozos[2]);
                     if (aceptado == 1)
                     {
                         mensaje = "Jugador " + trozos[4] + "ha rechazado la partida.";
                         MessageBox.Show(mensaje);
                     }

                     else
                     {
                         ThreadStart ts4 = delegate { PonerEnMarchaFormulario4(); };
                         Thread T4 = new Thread(ts4);
                         T4.Start();
                             mensaje = "Has sido agregado a la partida numero " + trozos[1] + " todo esta listo para empezar";
                             MessageBox.Show(mensaje);
                             partidaparchis = Convert.ToInt32(trozos[1]);
                             formularios4[nform4].EmpezarPartida(partidaparchis);
                            
                         
                     }


                        break;

                    case 7://inicializar partida
                          nform4 = Convert.ToInt32(trozos[1]);
                          part = Convert.ToInt32(trozos[2]);
                          jugadoresP = trozos[3];
                          formularios4[nform4].InicializarPartida(jugadoresP);
                          formularios4[nform4].TomaNombre(Nombre);
                   
                      



                        break;
                case 8://atender mensajes del chat
                        nform4 = Convert.ToInt32(trozos[1]);
                        chatsms = Convert.ToString(trozos[2]);
                        formularios4[nform4].PonerMensaje(chatsms);
                    
                    break;

                }
            }
        }

        public void SetNombre(string t)
        {
            Nombre = t; 
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenido "+ Nombre);

            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9075);

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




            string mensaje = "10/" + Nombre+"/";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Ganador.Checked)
            {
                string mensaje = "1/" + partida.Text+"/";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);


            }
            else if (Hombres.Checked)
            {
                string mensaje = "2/" + partida.Text+"/";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                // Enviamos nombre y altura
                string mensaje = "3/" + jugador1.Text + "/" + jugador2.Text+"/";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexión
            string mensaje = "0/" + Nombre;

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
            value = 0;

        }

        private void PonerEnMarchaFormulario()
        { 
            int cont = formularios.Count;
            Form3 f = new Form3(cont ,server,this);
            formularios.Add(f);
            f.ShowDialog();


        }


        private void PonerEnMarchaFormulario4()
        {    
            int cont = formularios4.Count;
            nform4 = cont;
            Form4 f4 = new Form4(cont,server);
            formularios4.Add(f4);
            f4.ShowDialog();


        }

        private void listBox33_SelectedIndexChanged(object sender, EventArgs e)
        {   int cont = formularios.Count;
            bool result;
            result = Nombre.Equals(listBox33.Text);
            if (result)
            {
               
                MessageBox.Show("No puedes auto invitarte");
              
            }
            else
            {
                invitar.Visible = true;
                if (value == 0)
                {
                    jugadores = "11/" + cont + "/" + Nombre + "/";
                    jugadores = jugadores +  listBox33.Text;
                    listBox33.BackColor = Color.Blue;
                    value++;
                }
                else
                {
                    listBox33.BackColor = Color.Blue;
                     suma = "-" + listBox33.Text;
                    jugadores = jugadores + suma;
                    
                }
            }

        }

        private void invitar_Click(object sender, EventArgs e)
        {
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(jugadores+"/");
            server.Send(msg);
            value = 0;
        }
        public string mensaje()
        {
            string t;
            t=invitacion;
            return t;
        }

        public string ActualizarChat()
        {
           string sms;
            sms=chatsms;
            return sms;

        }

        public string JugadoresParchis()
        {
            string jugparchis;
            jugparchis = jugadoresP;
            return jugparchis;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Mensaje de desconexión
            string mensaje = "0/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            atender.Abort();
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();

        }

   
    }
}
