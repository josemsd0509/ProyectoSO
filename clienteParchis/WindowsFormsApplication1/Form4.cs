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
        int numero;
        string jugador1;
        string jugador2;
        string jugador3;
        string jugador4;
        string turno;
        int ficha;
        int pasos;
        int count=0;
        bool mover = true;
        int opcion = 0;
        int fichasbaser=4;
        bool lanzar=false;
        int x, y;
        string color;
        bool ganador=false;
        int entradas;
        string col;
        bool findelturno;
        int t;
        

       
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
            pictureBox1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\fondo.jpg");
           pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
          

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
                {   JugadorParchis1.Text = trozos[1];
                    jugador1 = JugadorParchis1.Text; }));
                JugadorParchis2.Invoke(new Action(() =>
                {   JugadorParchis2.Text = trozos[2];
                    jugador2 = JugadorParchis2.Text;}));
                t = 2;
            }
            else if (i == 3)
            {
                JugadorParchis1.Invoke(new Action(() =>
                {  JugadorParchis1.Text = trozos[1];
                    jugador1 = JugadorParchis1.Text;}));
                JugadorParchis2.Invoke(new Action(() =>
                {   JugadorParchis2.Text = trozos[2];
                    jugador2 = JugadorParchis2.Text;}));
                JugadorParchis3.Invoke(new Action(() =>
                {    JugadorParchis3.Text = trozos[3];
                    jugador3 = JugadorParchis3.Text;}));
            t=3;
            }
            else
            {
                JugadorParchis1.Invoke(new Action(() =>
                { JugadorParchis1.Text = trozos[1];
                jugador1 =JugadorParchis1.Text;}));
                JugadorParchis2.Invoke(new Action(() =>
                { JugadorParchis2.Text = trozos[2];
                jugador2=JugadorParchis2.Text;}));
                JugadorParchis3.Invoke(new Action(() =>
                { JugadorParchis3.Text = trozos[3];
                jugador3 =JugadorParchis3.Text ;}));
                JugadorParchis4.Invoke(new Action(() =>
                { JugadorParchis4.Text = trozos[4];
                  jugador4 =JugadorParchis4.Text;}));
                t = 4;
            }
            turno = jugador1;
         IniciarFichas();
        }

        public void PonerMensaje(string mensaje)
        {
            chats = mensaje;
           
            string[] trozos = mensaje.Split('^');
    listBox1.Invoke(new Action(() =>
            {
                listBox1.Items.Clear();

                for (int i = 0; i < trozos.Length; i++)
                {
                   
                    listBox1.Items.Add(Convert.ToString(trozos[i]));
                    if (i==3)
                    { chats = null; }
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
       
      
        private void generarCosas()
        {
            if (t == 2)
            {
                amarillo1.Invoke(new Action(() =>
                { amarillo1.Visible = false; }));
                amarillo2.Invoke(new Action(() =>
                { amarillo2.Visible = false; }));
                amarillo3.Invoke(new Action(() =>
                { amarillo3.Visible = false; }));
                amarillo4.Invoke(new Action(() =>
                { amarillo4.Visible = false; }));
                verde1.Invoke(new Action(() =>
                { verde1.Visible = false; }));
                verde2.Invoke(new Action(() =>
                { verde2.Visible = false; }));
                verde3.Invoke(new Action(() =>
                { verde3.Visible = false; }));
                verde4.Invoke(new Action(() =>
                { verde4.Visible = false; }));
            
            }
            else if (t == 3)
            {
                amarillo1.Invoke(new Action(() =>
                { amarillo1.Visible = false; }));
                amarillo2.Invoke(new Action(() =>
                { amarillo2.Visible = false; }));
                amarillo3.Invoke(new Action(() =>
                { amarillo3.Visible = false; }));
                amarillo4.Invoke(new Action(() =>
                { amarillo4.Visible = false; }));
               
            }
            
        }
        public void SeleccionarColor()
        {
            if (jugador1 == nombrechat)
            {
                col = "rojo";
            }
            if (jugador2 == nombrechat)
            {
                col = "azul";
            }
            if (jugador3 == nombrechat)
            {
                col = "verde";
            }
            if (jugador4 == nombrechat)
            {
                col = "amarillo";
            }
        }
        private void ajustaresquinas()
        { 
            
           if((x>21)&&(63<x)&&(y>213)&&(y<314))
           {
               x = 44;
               y = 267;
           }
           if ((x >223) && (  x < 265) && (y > 407) && (y <497))
           {
               x = 247;
               y = 455;
           }

           if ((x > 266) && (x<380) && (y > 664) && (y <698))
           {
               x = 322;
               y = 685;
           }
           if ((x > 487) && (x < 597) && (y >499) && (y < 532))
           {
               x = 540;
               y = 515;
           }
           if ((x > 798) && (x < 839) && (y >500) && (y < 532))
           {
               x = 822;
               y = 453;
           }
           if ((x >596 ) && (x < 637) && (y >227) && (y < 313))
           {
               x = 619;
               y = 269;
           }
           if ((x > 487) && (x < 603) && (y >12) && (y < 48))
           {
               x = 544;
               y = 35;
           }
           if ((x > 264) && (x < 378) && (y > 182) && (y < 222))
           {
               x = 320;
               y = 205;
           } 

                  
                             
        }//ajusta cada ficha al centro
        private void IniciarFichas()
        {
            if (t == 3)
            {
                amarillo1.Invoke(new Action(() =>
                { amarillo1.Visible = false; }));

                amarillo2.Invoke(new Action(() =>
                { amarillo2.Visible = false; }));

                amarillo3.Invoke(new Action(() =>
                { verde3.Visible = false; }));

                amarillo4.Invoke(new Action(() =>
                { verde4.Visible = false; }));


            }
            else if (t == 2)
            {
                verde1.Invoke(new Action(() =>
                  { verde1.Visible = false; }));

                verde2.Invoke(new Action(() =>
                { verde2.Visible = false; }));

                verde3.Invoke(new Action(() =>
                { verde3.Visible = false; }));

                verde4.Invoke(new Action(() =>
                { verde4.Visible = false; }));
                
                amarillo1.Invoke(new Action(() =>
                { amarillo1.Visible = false; }));

                amarillo2.Invoke(new Action(() =>
                { amarillo2.Visible = false; }));

                amarillo3.Invoke(new Action(() =>
                { verde3.Visible = false; }));

                amarillo4.Invoke(new Action(() =>
                { verde4.Visible = false; }));

            }
        }





     
               

        public void ActualizarPosiciones(string colre,int posx,int posy,int fich)
        {
            ficha = fich;
            x = posx;
            y = posy;
            color = colre;
            Point punto = new Point(x, y);
            
            if (color == "rojo")
            {
                if (ficha == 1)
                {
                    
                    rojo1.Invoke(new Action(() =>
                    { rojo1.Location = punto; }));
                }
                else if (ficha == 2)
                {
                    rojo2.Invoke(new Action(() =>
                    { rojo2.Location = punto; }));
                }
                else if (ficha == 3)
                {
                    rojo3.Invoke(new Action(() =>
                    { rojo3.Location = punto; }));
                }
                else
                {
                    rojo4.Invoke(new Action(() =>
                    { rojo4.Location = punto; }));
                }

            }
            else if (color == "azul")
            {
                if (ficha == 1)
                {
                    azul1.Invoke(new Action(() =>
                    { azul1.Location = punto; }));
                }
                else if (ficha == 2)
                {
                    azul2.Invoke(new Action(() =>
                    { azul2.Location = punto; }));
                }
                else if (ficha == 3)
                {
                    azul3.Invoke(new Action(() =>
                    { azul3.Location = punto; }));
                }
                else
                {
                    azul4.Invoke(new Action(() =>
                    { azul4.Location = punto; }));
                }
            }
            else if (color == "amarillo")
            {
                if (ficha == 1)
                {
                    amarillo1.Invoke(new Action(() =>
                    { amarillo1.Location = punto; }));
                }
                else if (ficha == 2)
                {
                    amarillo2.Invoke(new Action(() =>
                    { amarillo2.Location = punto; }));
                }
                else if (ficha == 3)
                {
                    amarillo3.Invoke(new Action(() =>
                    { amarillo3.Location = punto; }));
                }
                else
                {
                    amarillo4.Invoke(new Action(() =>
                    { amarillo4.Location = punto; }));
                }
            }
            else
            {
                if (ficha == 1)
                {
                    verde1.Invoke(new Action(() =>
                    { verde1.Location = punto; }));
                }
                else if (ficha == 2)
                {
                    verde2.Invoke(new Action(() =>
                    { verde2.Location = punto; }));
                }
                else if (ficha == 3)
                {
                    verde3.Invoke(new Action(() =>
                    { verde3.Location = punto; }));
                }
                else
                {
                    verde4.Invoke(new Action(() =>
                    { verde4.Location = punto; }));
                }
            }
        }
        public void LanzarDados(int dados)
        {
            numero=dados;
            if (numero == 2)//Dos
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara1.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara1.jpg");
                
            }


            if (numero == 3)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara1.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara2.jpg");
            }
            if (numero == 13)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara2.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara1.jpg");
            }



            if (numero == 4)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara2.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara2.jpg");
              
            }
            if (numero == 14)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara3.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara1.jpg");
            }
            if (numero == 15)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara1.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara3.jpg");
            }



            if (numero == 5)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara3.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara2.jpg");
            }
            if (numero == 16)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara2.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara3.jpg");
            }
            if (numero == 17)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara4.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara1.jpg");
            }
            if (numero == 18)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara1.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara4.jpg");
            }





            if (numero == 6)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara3.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara3.jpg");
            
            }
            if (numero == 19)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara4.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara2.jpg");
            }
            if (numero == 20)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara2.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara4.jpg");
            }
            if (numero == 21)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara5.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara1.jpg");
            }
            if (numero == 22)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara1.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara5.jpg");
            }




            if (numero == 7)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara3.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara4.jpg");
            }
            if (numero == 23)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara3.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara4.jpg");
            }
            if (numero == 24)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara5.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara2.jpg");
            }

            if (numero == 25)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara2.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara5.jpg");
            }


            if (numero == 26)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara6.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara1.jpg");
            }
            if (numero == 27)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara1.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara6.jpg");
            }





            if (numero == 8)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara4.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara4.jpg");
                
            }

            if (numero == 28)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara5.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara3.jpg");
            }
            if (numero == 29)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara3.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara5.jpg");
            }
            if (numero == 30)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara6.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara2.jpg");
            }
            if (numero == 31)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara2.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara6.jpg");
            }





            if (numero == 9)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara5.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara4.jpg");
            }

            if (numero == 32)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara4.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara5.jpg");
            }


            if (numero == 33)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara6.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara3.jpg");
            }

            if (numero == 34)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara3.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara6.jpg");
            }




            if (numero == 10)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara5.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara5.jpg");
              
            }

            if (numero == 35)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara6.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara4.jpg");
            }

            if (numero == 36)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara4.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara6.jpg");
            }




            if (numero == 11)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara6.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara5.jpg");
            }

            if (numero == 37)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara5.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara6.jpg");
            }



            if (numero == 12)
            {
                Dado1.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara6.jpg");
                Dado2.Image = Image.FromFile(@"C:\ProyectoSO\clienteParchis\Imagenes\cara6.jpg");
                
            }
        }//selecionar cara del dado


        public void MovimientoFichas()
        {

            if (count <= 1)// elgir que ficha moveremos
            {
                if (color == "rojo")
                {
                    if (ficha == 1)
                    {
                        x = rojo1.Location.X;
                        y = rojo1.Location.Y;
                    }
                    else if (ficha == 2)
                    {
                        x = rojo2.Location.X;
                        y = rojo2.Location.Y;
                    }
                    else if (ficha == 3)
                    {
                        x = rojo3.Location.X;
                        y = rojo3.Location.Y;
                    }
                    else
                    {
                        x = rojo4.Location.X;
                        y = rojo4.Location.Y;
                    }

                }
                else if (color == "azul")
                {
                    if (ficha == 1)
                    {
                        x = azul1.Location.X;
                        y = azul1.Location.Y;
                    }
                    else if (ficha == 2)
                    {
                        x = azul2.Location.X;
                        y = azul2.Location.Y;
                    }
                    else if (ficha == 3)
                    {
                        x = azul3.Location.X;
                        y = azul3.Location.Y;
                    }
                    else
                    {
                        x = azul4.Location.X;
                        y = azul4.Location.Y;
                    }
                }
                else if (color == "amarillo")
                {
                    if (ficha == 1)
                    {
                        x = amarillo1.Location.X;
                        y = amarillo1.Location.Y;
                    }
                    else if (ficha == 2)
                    {
                        x = amarillo2.Location.X;
                        y = amarillo2.Location.Y;
                    }
                    else if (ficha == 3)
                    {
                        x = amarillo3.Location.X;
                        y = amarillo3.Location.Y;
                    }
                    else
                    {
                        x = amarillo4.Location.X;
                        y = amarillo4.Location.Y;
                    }
                }
                else
                {
                    if (ficha == 1)
                    {
                        x = verde1.Location.X;
                        y = verde1.Location.Y;
                    }
                    else if (ficha == 2)
                    {
                        x = verde2.Location.X;
                        y = verde2.Location.Y;
                    }
                    else if (ficha == 3)
                    {
                        x = verde3.Location.X;
                        y = verde3.Location.Y;
                    }
                    else
                    {
                        x = verde4.Location.X;
                        y = verde4.Location.Y;
                    }
                }
            }


                    if (((x > 38) && (x < 212) && (y > 28) && (y < 190))||((x >622) && (x < 861) && (y >28) && (y < 190))||((x >38) && (x < 212) && (y >526) && (y <707))// salida de casillas
                        ||((x >622) && (x < 861) && (y >526) && (y <707)))//Salida de las fichas
                    {
                        if (((numero == 5) || (numero == 16) || (numero == 17) || (numero == 18) || (numero == 21) || (numero == 22)
                            || (numero == 24) || (numero == 25) || (numero == 28) || (numero == 29) || (numero == 9) || (numero == 32)
                            || (numero == 10) || (numero == 11) || (numero == 37)))
                        {
                            if (color == "rojo")
                            {
                                y = 137;
                                x = 323;
                            }
                            else if (color == "azul")
                            {
                                y = 137;
                                x = 544;
                            }
                            else if (color == "verde")
                            {
                                y = 450;
                                x = 165;
                            }
                            else
                            {
                                y = 582;
                                x = 540;
                            }


                            if (((numero == 5) || (numero == 16) || (numero == 17) || (numero == 18))&&(opcion==0))
                            {
                                pasos = 0;
                                count = 2;

                            }
                            else if (((numero == 21) || (numero == 22))&&(opcion==0))
                            {
                                pasos = 1;
                                count = 25;


                            }
                            else if (((numero == 28) || (numero == 29))&&(opcion==0))
                            {
                                pasos = 3;
                                count = 25;

                            }
                            else if (((numero == 24) || (numero == 25))&&(opcion==0))
                            {
                                pasos = 2;
                                count = 25;


                            }
                            else if (((numero == 9) || (numero == 32))&&(opcion==0))
                            {
                                pasos = 4;
                                count = 25;


                            }
                            else if ((numero == 10)&&(opcion==0))
                            {
                                if (fichasbaser == 1)
                                {
                                    lanzar = true;
                                }



                            }
                            else if (((numero == 11) || (numero == 37))&&(opcion==0))
                            {
                                pasos = 6;
                                count = 25;

                            }

                            mover = false;
                            opcion = 1;
                            fichasbaser--;

                        }
                        else
                            count = 2;

                    }
                    if ((y <= 150) && (y >= -16) && (x >= 487) && (x <= 600) && (mover == true)&&(color=="rojo"))//tunel rojo
                    {
                        if (y - 34 * pasos >= -17)
                        {
                            while ((y >= 40) && (pasos != 0))
                            {
                               
                                 ajustaresquinas();
                                 y = y - 34;
                                pasos--;

                            }

                            y = 1;
                            x =436;
                        }
                        else
                        {
                       
                                y = y - pasos * 34;
                        }
                      
                    }
                    if ((y <= 498) && (y >=410) && (x >= 677) && (x <= 875) && (mover == true) && (color == "azul"))//tunel azul
                    {
                        if (x+ 40 * pasos >=875)
                        {
                            while ((x <= 835) && (pasos != 0))
                            {

                                ajustaresquinas();
                                x = x + 40;
                                pasos--;

                            }

                            y = 361;
                            x = 864;
                        }
                        else
                        {

                            x= x +pasos * 40;
                        }

                    }
                    if ((y <= 313) && (y >= 213) && (x >= -17) && (x <= 186) && (mover == true) && (color == "verde"))//tunel azul
                    {
                        if (x - 40 * pasos <= -17)
                        {
                            while ((x >= 23) && (pasos != 0))
                            {

                                ajustaresquinas();
                                x = x - 40;
                                pasos--;

                            }

                            y = 359;
                            x = 2;
                        }
                        else
                        {

                            x = x - pasos * 40;
                        }

                    }
                    if ((y <= 728) && (y >= 567) && (x >= 266) && (x <= 375) && (mover == true) && (color == "amarillo"))//tunel amarillo
                    {
                        if (y+ 35 * pasos >= 728)
                        {
                            while ((y <= 690) && (pasos != 0))
                            {

                                ajustaresquinas();
                                y = y - 35;
                                pasos--;

                            }

                            y = 719;
                            x = 437;
                        }
                        else
                        {

                            y = y + pasos * 35;
                        }

                    }























                    if ((x >= 487) && (x <= 596) && (y >= 703) && (y <= 735))//casilla 1
                    {
                        x = 538;
                        y = 685;
                        pasos--;
                    }

                    if ((x >= 266) && (x <= 378)&&(y >= 215) && (y <= 254))//casilla 42
                    {
                        x = 286;
                        y = 274;
                        pasos--;
                    }

                    if ((x >= 267) && (x <= 313) && (y >= 225) && (y <= 307))//casilla 43
                    {
                        x = 245;
                        y = 266;
                        pasos--;
                    }
                    if ((x >= -22) && (x <= 24) && (y >= 223) && (y <= 314))//casilla 50
                    {
                        x = 2;
                        y = 361;
                        pasos--;
                    }
                    if ((x >=267) && (x <=313) && (y >= 406) && (y <= 488))//casilla 59
                    {
                        x = 326;
                        y = 482;
                        pasos--;
                    }
                    if ((x >= 267) && (x <= 378) && (y >= 703) && (y <= 730))//casilla 67
                    {
                        x = 432;
                        y = 719;
                        pasos--;
                    }
                    if ((x >= 488) && (x <= 600) && (y >= 460) && (y <= 500))//casilla 8
                    {
                        x = 540;
                        y = 480;
                        pasos--;
                    }
                    if ((x >= 555) && (x <= 600) && (y >= 403) && (y <= 488))//casilla 9
                    {
                        x = 579;
                        y = 449;
                        pasos--;
                    }
                    if ((x >= 843) && (x <= 889) && (y >= 403) && (y <= 498))//casilla 16
                    {
                        x = 864;
                        y = 359;
                        pasos--;
                    }
                    if ((x >= 554) && (x <= 600) && (y >= 233) && (y <= 309))//casilla 25
                    {
                        x = 818;
                        y = 124;
                        pasos--;
                    }
                    if ((x >= 484) && (x <= 600) && (y >= -18) && (y <= 22))//casilla 33
                    {
                        x = 432;
                        y = 1;
                        pasos--;
                    }
                   if ((y >= 315) && (y <= 400) && (x >= -17) && (x <= 365) && (mover == true))//Entrada de los verdes
                    {
                        if (color == "verde")
                        {
                            if (x + 40 * pasos > 362)
                            {
                                mover = false;

                            }
                            else
                            {
                                x = x + 40 * pasos;
                                if ((x >= 325) && (entradas == 0))
                                {
                                    x = 398;
                                    y = 358;
                                }
                                if ((x >= 325) && (entradas == 1))
                                {
                                    x = 336;
                                    y = 359;
                                }
                                if ((x >= 325) && (entradas == 2))
                                {
                                    x = 336;
                                    y = 300;
                                }
                                if ((x >= 325) && (entradas == 3))
                                {
                                    x = 336;
                                    y = 413;
                                    ganador = true;
                                }
                                pasos = 0;
                                entradas++;
                            }




                        }
                        else
                        {
                            y =450;
                            x = 2;

                            pasos--;
                        }

                    }


                    if ((y >= 406) && (y <= 734) && (x >= 380) && (x <= 488) && (mover == true))// Entrada de las amarillas
                    {
                        if (color == "amarillo")
                        {
                            if (y - 34 * pasos < 425)
                            {
                                mover = false;

                            }
                            else
                            {
                                y = y - 35 * pasos;
                                if ((y <= 430) && (entradas == 0))
                                {
                                    x = 434;
                                    y = 389;
                                }
                                if ((y <= 430) && (entradas == 1))
                                {
                                    x = 434;
                                    y = 429;
                                }
                                if ((y <= 430) && (entradas == 2))
                                {
                                    x = 388;
                                    y = 429;
                                }
                                if ((y <= 430) && (entradas == 3))
                                {
                                    x = 480;
                                    y = 429;
                                    ganador = true;
                                }
                                pasos = 0;
                                entradas++;
                            }
                        }
                        else
                        {
                            x = 542;
                            y = 719;
                            pasos--;
                        }

                    }
                    if ((y >= 310) && (y <= 406) && (x <= 882) && (x >= 518) && (mover == true))//entrada azul
                    {
                        if (color == "azul")
                        {
                            if (x - 40 * pasos < 508)
                            {
                                mover = false;

                            }
                            else
                            {
                                x = x - 40 * pasos;
                                if ((x <= 525) && (entradas == 0))
                                {
                                    x = 470;
                                    y = 360;
                                }
                                if ((y <= 525) && (entradas == 1))
                                {
                                    x = 516;
                                    y = 360;
                                }
                                if ((y <= 525) && (entradas == 2))
                                {
                                    x = 516;
                                    y = 320;
                                }
                                if ((y <= 525) && (entradas == 3))
                                {
                                    x = 516;
                                    y = 400;
                                    ganador = true;
                                }
                                pasos = 0;
                                entradas++;
                            }
                        }
                        else
                        {
                            x=862;
                            y=268;
                        pasos--;
                        }
                         

                    }
                    if ((y >= -19) && (y <= 330) && (x >= 378) && (x <= 480) && (mover == true))//Entrada de las rojas
                    {
                        if (color == "rojo")
                        {
                            if (y + 34 * pasos > 290)
                            {
                                mover = false;
                                
                            }
                            else
                            {
                                y = y + 34 * pasos;
                                if ((y >= 254) && (entradas == 0))
                                {
                                    x = 434;
                                    y = 336;
                                }
                                if ((y >= 254) && (entradas == 1))
                                {
                                    x = 393;
                                    y = 305;
                                }
                                if ((y >= 254) && (entradas == 2))
                                {
                                    x = 463;
                                    y = 305;
                                }
                                if ((y >= 254) && (entradas == 3))
                                {
                                    x = 434;
                                    y = 266;
                                    ganador = true;
                                }
                                pasos = 0;
                                entradas++;
                            }

                     


                        }
                        else
                        {
                            x = 322;
                            y = 1;
                            pasos--;
                        }
                    }


                        if ((y <= 224) && (y >= -16) && (x >= 265) && (x <= 374) && (mover == true))//cuadrante rojo superior
                        {
                            if (y + 34 * pasos >= 260)
                            {
                                while ((y <= 205) && (pasos != 0))
                                {    
                                    if ((y>=188)&&(y<=222))
                                    {ajustaresquinas();}
                                    y = y + 34;
                                    pasos--;

                                }
                             
                                y = y + 34;
                                x = x - 40 * pasos;
                            }
                            else
                            {
                                if (((y + pasos * 34) >= 215) && ((y + pasos * 34) <= 254))
                                {
                                    x = 319;
                                    y = 239;
                                }
                                else
                                    y = y + pasos * 34;
                            }
                            pasos = 0;
                            mover = false;
                        }



                        if ((x >= 23) && (x <= 267) && (y <= 310) && (y >= 223) && (mover == true)) //cuadrante rojo inferior
                        {
                            if (x - 40 * pasos <= -15)
                            {
                                while ((x >= 18) && (pasos != 0))
                                {
                                    if ((x >= 23) && (x <= 69))
                                    { ajustaresquinas(); }
                                    x = x - 40;
                                    pasos--;

                                }
                                if (pasos > 2)
                                {
                                    y = y + 92 * 2; 
                                    x = x + 40 * (pasos - 2);

                                }
                                else
                                {
                                    y = y + 92 * pasos;

                                }
                            }
                            else
                                x = x - pasos * 40;
                            pasos = 0;
                            mover = false; 

                        }

                        if ((x >= 0) && (x <= 267) && (y >= 400) && (y <= 490) && (mover == true))// cuadrante verde superior
                        {
                            if (x + 40 * pasos >= 285)
                            {
                                while ((x <= 243) && (pasos != 0))
                                {
                                    if ((x >= 23) && (x <= 69))
                                    { ajustaresquinas(); }
                                    x = x + 40;
                                    pasos--;

                                }
                                y = y + 34 * pasos;
                                x = x + 40;

                            }
                            else
                            {
                                if (((x + pasos * 40) >= 266) && ((x + pasos * 40) <= 308))
                                {
                                    x = 288;
                                    y = 450;
                                }
                                else
                                    x = x + pasos * 40;
                            }
                            pasos = 0;
                            mover = false; 
                        }

                        if ((x >= 267) && (x <= 370) && (y >= 475) && (y <= 703) && (mover == true))// cuadrante verde inferior
                        {
                            if (y + 34 * pasos >= 730)
                            {
                                while ((y <= 695) && (pasos != 0))
                                {
                                    if ((y >= 606) && (y <= 703))
                                    { ajustaresquinas(); }
                                    y = y + 34;
                                    pasos--;
                                }
                                if (pasos > 2)
                                {
                                    x = x + 112 * 2;
                                    y = y - (pasos - 2) * 34;

                                }
                                else
                                
                                    
                                    x = x + 112 * pasos;
                                
                            }
                            else
                                y = y + 34 * pasos;
                            pasos = 0;
                            mover = false;

                        }

                        if ((x >= 485) && (x <= 600) && (y >= 498) && (y <= 703) && (mover == true)) // cuadrante amarillo inferior
                        {
                            if (y - 34 * pasos <= 475)
                            {
                                while ((y >= 510) && (pasos != 0))
                                {
                                    if ((y >= 493) && (y <= 533))
                                    { ajustaresquinas(); }
                                    y = y - 34;
                                    pasos--;
                                }
                                x = x + 40 * pasos;
                                y = y + 34;
                            }
                            else

                                if (((y - pasos * 34) >= 458) && ((y - pasos * 34) <= 498))
                                {
                                    x = 319;
                                    y = 239;
                                }
                                else                           
                                y = y - pasos * 34;
                            pasos = 0;
                            mover = false; 
                        }



                        if ((x >= 601) && (x <= 843) && (y >= 403) && (y <= 500) && (mover == true)) //cuadrante amarillo superior
                        {
                            if (x + 40 * pasos >= 870)
                            {
                                while ((x <= 828) && (pasos != 0))
                                {
                                    if ((x >= 795) && (x <= 841))
                                    { ajustaresquinas(); }
                                    x = x + 40;
                                    pasos--;
                                }
                                if (pasos > 2)
                                {
                                    y = y - 92 * 2;
                                    x = x - (pasos - 2) * 40;

                                }
                            }
                            else
                                x = x+40* pasos;
                            pasos = 0;
                            mover = false;
                        }




                        if ((x >= 597) && (x <= 870) && (y >= 230) && (y <= 310) && (mover == true)) //cuadrante azul inferior
                        {
                            if (x - 40 * pasos <= 575)
                            {
                                while ((x >= 617) && (pasos != 0))
                                {
                                    if ((x >= 592) && (x <= 638))
                                    { ajustaresquinas(); }
                                    x = x - 40;
                                    pasos--;
                                }

                                y = y - 34 * pasos;
                                x = x - 40;
                            }
                            else

                                if (((x - pasos * 40) >= 552) && ((x - pasos * 40) <= 602))
                                {
                                    x = 580;
                                    y = 272;
                                }
                                else
                                x = x - pasos * 40;
                            pasos = 0;
                            mover = false; 
                        }





                        if ((x >= 484) && (x <= 602) && (y >= 12) && (y <= 223) && (mover == true)) // cuadrante azul superior
                        {
                            if (y - 34 * pasos <= 1)
                            {
                                while ((y >= 20) && (pasos != 0))
                                {
                                    ajustaresquinas();
                                    y = y - 34;
                                    pasos--;
                                }
                                if (pasos > 2)
                                {
                                    x = x - 114 * 2;
                                    y = y + (pasos - 2) * 34;

                                }
                                else
                                    x = x - 114 * pasos;

                              
                            }
                            else
                                y = y - 34*pasos;
                               pasos = 0;
                                mover = false;
                        }



                    }


















            public void Pasos()
            {  if ((numero==2)&&(count<2))
               {    pasos=1;
               lanzar = true;
               }
                if ((numero==3)&&(count==0))
               {    pasos=1;
               }
                 if ((numero==3)&&(count==1))
               {    pasos=2;
               }
                  if ((numero==4)&&(count<2))
               {    pasos=2;
                    lanzar = true;
               }
                  if ((numero==5)&&(count==0))
               {    pasos=3;
               }
                  if ((numero==5)&&(count==1))
               {    pasos=2;
               }
                  if ((numero==6)&&(count<2))
               {    pasos=3;
                    lanzar = true;
               }
              if ((numero==7)&&(count==0))
               {    pasos=3;
               }
                  if ((numero==7)&&(count==1))
               {    pasos=4;
               }
              if ((numero==8)&&(count<2))
               {    pasos=4;
               lanzar = true;
               }
                  if ((numero==9)&&(count==0))
               {    pasos=5;
               }
              if ((numero==9)&&(count==1))
               {    pasos=4;
               }
                  if ((numero==10)&&(count<2))
               {    pasos=5;
               lanzar = true;
               }
                  if ((numero==11)&&(count==0))
               {    pasos=6;
               }
                  if ((numero==11)&&(count==1))
               {    pasos=5;
               }
                   if ((numero==12)&&(count<2))
               {    pasos=6;
               lanzar = true;
               }
                   if ((numero==13)&&(count==0))
               {    pasos=2;
               }
                  if ((numero==13)&&(count==1))
               {    pasos=1;
               }
                   if ((numero==14)&&(count==0))
               {    pasos=3;
               }
                  if ((numero==14)&&(count==1))
               {    pasos=1;
               }
                   if ((numero==15)&&(count==0))
               {    pasos=1;
               }
                  if ((numero==15)&&(count==1))
               {    pasos=3;
               }
                  if ((numero==16)&&(count==0))
               {    pasos=2;
               }
                  if ((numero==16)&&(count==1))
               {    pasos=3;
               }
                  if ((numero==17)&&(count==0))
               {    pasos=4;
               }
                  if ((numero==17)&&(count==1))
               {    pasos=1;
               }
                    if ((numero==18)&&(count==0))
               {    pasos=1;
               }
                  if ((numero==18)&&(count==1))
               {    pasos=4;
               }
               if ((numero==19)&&(count==0))
               {    pasos=4;
               }
                  if ((numero==19)&&(count==1))
               {    pasos=2;
               }
                if ((numero==20)&&(count==0))
               {    pasos=2;
               }
                  if ((numero==20)&&(count==1))
               {    pasos=4;
               }
              if ((numero==21)&&(count==0))
               {    pasos=5;
               }
                  if ((numero==21)&&(count==1))
               {    pasos=1;
               }
                    if ((numero==22)&&(count==0))
               {    pasos=1;
               }
                  if ((numero==22)&&(count==1))
               {    pasos=5;
               }
                   if ((numero==23)&&(count==0))
               {    pasos=3;
               }
                  if ((numero==23)&&(count==1))
               {    pasos=4;
               }
                    if ((numero==24)&&(count==0))
               {    pasos=5;
               }
                  if ((numero==24)&&(count==1))
               {    pasos=2;
               }
                    if ((numero==25)&&(count==0))
               {    pasos=2;
               }
                  if ((numero==25)&&(count==1))
               {    pasos=5;
               }
                    if ((numero==26)&&(count==0))
               {    pasos=6;
               }
                  if ((numero==26)&&(count==1))
               {    pasos=1;
               }
                    if ((numero==27)&&(count==0))
               {    pasos=1;
               }
                  if ((numero==27)&&(count==1))
               {    pasos=6;
               }
                 if ((numero==28)&&(count==0))
               {    pasos=5;
               }
                  if ((numero==28)&&(count==1))
               {    pasos=3;
               }
                 if ((numero==29)&&(count==0))
               {    pasos=3;
               }
                  if ((numero==29)&&(count==1))
               {    pasos=5;
               }
                 if ((numero==30)&&(count==0))
               {    pasos=6;
               }
                  if ((numero==30)&&(count==1))
               {    pasos=2;
               }
                     if ((numero==31)&&(count==0))
               {    pasos=2;
               }
                  if ((numero==31)&&(count==1))
               {    pasos=6;
               }
                 if ((numero==32)&&(count==0))
               {    pasos=4;
               }
                  if ((numero==32)&&(count==1))
               {    pasos=5;
               }
                 if ((numero==33)&&(count==0))
               {    pasos=6;
               }
                  if ((numero==33)&&(count==1))
               {    pasos=3;
               }
                  if ((numero==34)&&(count==0))
               {    pasos=3;
               }
                  if ((numero==34)&&(count==1))
               {    pasos=6;
               }
                    if ((numero==35)&&(count==0))
               {    pasos=6;
               }
                  if ((numero==35)&&(count==1))
               {    pasos=4;
               }
                    if ((numero==36)&&(count==0))
               {    pasos=4;
               }
                  if ((numero==36)&&(count==1))
               {    pasos=6;
               }
                if ((numero==37)&&(count==0))
               {    pasos=5;
               }
                  if ((numero==37)&&(count==1))
               {    pasos=6;
                  }
                  count++;
            }

        public void Comparador(string trn)
            {
                turno = trn;
            if (turno == nombrechat)
            {
                color = col;
                label1.Invoke(new Action(() =>
                    { label1.Text = "Es tu turno "; }));

                tirardados.Invoke(new Action(() =>
                { tirardados.Visible = true; }));
                if (col == "rojo")
                {
                    turno = jugador2; 
                }
                else  if ((col == "azul")&&(t==2))
                {
                    turno = jugador1;
                }
                else if ((col == "azul") && ((t ==3)||(t==4)))
                {
                    turno = jugador3;
                }
                else if ((col == "verde")&&(t==3))
                {
                    turno = jugador1;
                }
                else if ((col == "verde") && (t == 4))
                {
                    turno = jugador4;
                }
                else 
                {
                    turno = jugador1;
                }
            }
            else
            {
                label1.Invoke(new Action(() =>
                      { label1.Text = "Es el turno de " + turno; }));
            }
           
            
        }



       
      


        private void button7_Click(object sender, EventArgs e)
        {
            opcion = 0;
        }

        private void tirardados_Click(object sender, EventArgs e)
        {
            findelturno = false;
            count = 0;
            Random rnd = new Random();
            int Num = rnd.Next(2, 37);
            LanzarDados(Num);
            string mensaje = "30/"+partida1+"/" +nForm  +"/"+nombrechat + "/" + Num + "/"  ;
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            tirardados.Invoke(new Action(() =>
            { tirardados.Visible = false;}));
           
        }

        private void ActivarMovimiento(int fich)
        {
            opcion = 0;
            mover = true;
            ficha = fich;
            string mensaje;

            if (count < 2)
            {
                Pasos();
                MovimientoFichas();
            }
            if (count == 25)
            {
                mover = true;
                MovimientoFichas();
                count++;
            }
            if (count >= 2)
            {




                if (lanzar == true)
                    turno = nombrechat;

                if (pasos != 0)
                {
                    mensaje = "32/" + partida1 + "/" + nForm + "/" + turno + "/";

                }
                else
                    mensaje = "31/" + partida1 + "/" + nForm + "/" + col + "/" + ficha + "/" + turno + "/" + x + "/" + y;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                // Enviamos al servidor el nombre tecleado
                server.Send(msg);
                lanzar = false;
            }
            else
            {
                mensaje = "33/" + partida1 + "/" + nForm + "/" + col + "/" + ficha + "/" + x + "/" + y;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            } 
        }
        private void rojo1_Click(object sender, EventArgs e)
        {    int f =1;
           ActivarMovimiento(f);
          
        }

        private void rojo2_Click(object sender, EventArgs e)
        {
            int f = 2;
            ActivarMovimiento(f);
          
        }

        private void rojo3_Click(object sender, EventArgs e)
        {
            int f = 3;
            ActivarMovimiento(f);
          
        }

        private void rojo4_Click(object sender, EventArgs e)
        {
            int f = 4;
            ActivarMovimiento(f);
          

        }

        private void verde1_Click(object sender, EventArgs e)
        {
            int f = 1;
            ActivarMovimiento(f);
          
        }

        private void verde2_Click(object sender, EventArgs e)
        {
            int f = 2;
            ActivarMovimiento(f);
          
        }

        private void verde3_Click(object sender, EventArgs e)
        {
            int f = 3;
            ActivarMovimiento(f);
          
        }

        private void verde4_Click(object sender, EventArgs e)
        {
            int f = 4;
            ActivarMovimiento(f);
          
        }

        private void azul1_Click(object sender, EventArgs e)
        {
            int f = 1;
            ActivarMovimiento(f);
          

        }

        private void azul2_Click(object sender, EventArgs e)
        {
            int f = 2;
            ActivarMovimiento(f);
          
        }

        private void azul3_Click(object sender, EventArgs e)
        {
            int f = 3;
            ActivarMovimiento(f);
          
        }

        private void azul4_Click(object sender, EventArgs e)
        {
            int f = 4;
            ActivarMovimiento(f);
          
        }

        private void amarillo1_Click(object sender, EventArgs e)
        {
            int f = 1;
            ActivarMovimiento(f);
          
        }

        private void amarillo2_Click(object sender, EventArgs e)
        {
            int f = 2;
            ActivarMovimiento(f);
          
        }

        private void amarillo3_Click(object sender, EventArgs e)
        {
            int f = 3;
            ActivarMovimiento(f);
          
        }

        private void amarillo4_Click(object sender, EventArgs e)
        {
            int f = 4;
            ActivarMovimiento(f);
          
        }

       
        
       

   
      






    
        
    }
}
