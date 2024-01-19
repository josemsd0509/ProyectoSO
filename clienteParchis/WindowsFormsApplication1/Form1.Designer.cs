namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.partida = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.botton8 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.jugador2 = new System.Windows.Forms.TextBox();
            this.Hombres = new System.Windows.Forms.RadioButton();
            this.Relacion = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.jugador1 = new System.Windows.Forms.TextBox();
            this.Ganador = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.conectado1 = new System.Windows.Forms.TextBox();
            this.listadeconectados = new System.Windows.Forms.Label();
            this.listBox33 = new System.Windows.Forms.ListBox();
            this.invitar = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Partida";
            // 
            // partida
            // 
            this.partida.Location = new System.Drawing.Point(116, 31);
            this.partida.Name = "partida";
            this.partida.Size = new System.Drawing.Size(23, 20);
            this.partida.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(283, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 92);
            this.button1.TabIndex = 4;
            this.button1.Text = "conectar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(126, 157);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Enviar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.botton8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.jugador2);
            this.groupBox1.Controls.Add(this.Hombres);
            this.groupBox1.Controls.Add(this.Relacion);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.jugador1);
            this.groupBox1.Controls.Add(this.Ganador);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.partida);
            this.groupBox1.Location = new System.Drawing.Point(15, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 202);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticion";
            this.groupBox1.Visible = false;
            // 
            // botton8
            // 
            this.botton8.Location = new System.Drawing.Point(259, 155);
            this.botton8.Name = "botton8";
            this.botton8.Size = new System.Drawing.Size(75, 23);
            this.botton8.TabIndex = 23;
            this.botton8.Text = "Cerrar";
            this.botton8.UseVisualStyleBackColor = true;
            this.botton8.Click += new System.EventHandler(this.botton8_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Jugador2";
            // 
            // jugador2
            // 
            this.jugador2.Location = new System.Drawing.Point(17, 157);
            this.jugador2.Name = "jugador2";
            this.jugador2.Size = new System.Drawing.Size(62, 20);
            this.jugador2.TabIndex = 11;
            // 
            // Hombres
            // 
            this.Hombres.AutoSize = true;
            this.Hombres.Location = new System.Drawing.Point(116, 91);
            this.Hombres.Name = "Hombres";
            this.Hombres.Size = new System.Drawing.Size(218, 17);
            this.Hombres.TabIndex = 7;
            this.Hombres.TabStop = true;
            this.Hombres.Text = "Dime los jugadores hombres de la partida";
            this.Hombres.UseVisualStyleBackColor = true;
            // 
            // Relacion
            // 
            this.Relacion.AutoSize = true;
            this.Relacion.Location = new System.Drawing.Point(116, 119);
            this.Relacion.Name = "Relacion";
            this.Relacion.Size = new System.Drawing.Size(197, 17);
            this.Relacion.TabIndex = 7;
            this.Relacion.TabStop = true;
            this.Relacion.Text = "Jugador1 primero Jugador2 segundo";
            this.Relacion.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Jugador1";
            // 
            // jugador1
            // 
            this.jugador1.Location = new System.Drawing.Point(17, 106);
            this.jugador1.Name = "jugador1";
            this.jugador1.Size = new System.Drawing.Size(62, 20);
            this.jugador1.TabIndex = 9;
            // 
            // Ganador
            // 
            this.Ganador.AutoSize = true;
            this.Ganador.Location = new System.Drawing.Point(116, 68);
            this.Ganador.Name = "Ganador";
            this.Ganador.Size = new System.Drawing.Size(201, 17);
            this.Ganador.TabIndex = 8;
            this.Ganador.TabStop = true;
            this.Ganador.Text = "Dime el jugador ganador de la partida";
            this.Ganador.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(12, 505);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(147, 45);
            this.button3.TabIndex = 10;
            this.button3.Text = "desconectar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // conectado1
            // 
            this.conectado1.Location = new System.Drawing.Point(609, 154);
            this.conectado1.Name = "conectado1";
            this.conectado1.Size = new System.Drawing.Size(100, 20);
            this.conectado1.TabIndex = 11;
            this.conectado1.Visible = false;
            // 
            // listadeconectados
            // 
            this.listadeconectados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listadeconectados.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listadeconectados.Location = new System.Drawing.Point(557, 59);
            this.listadeconectados.Name = "listadeconectados";
            this.listadeconectados.Size = new System.Drawing.Size(34, 33);
            this.listadeconectados.TabIndex = 13;
            this.listadeconectados.Visible = false;
            // 
            // listBox33
            // 
            this.listBox33.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox33.FormattingEnabled = true;
            this.listBox33.ItemHeight = 18;
            this.listBox33.Location = new System.Drawing.Point(597, 59);
            this.listBox33.Name = "listBox33";
            this.listBox33.Size = new System.Drawing.Size(132, 184);
            this.listBox33.TabIndex = 14;
            this.listBox33.Visible = false;
            this.listBox33.SelectedIndexChanged += new System.EventHandler(this.listBox33_SelectedIndexChanged);
            // 
            // invitar
            // 
            this.invitar.Location = new System.Drawing.Point(476, 209);
            this.invitar.Name = "invitar";
            this.invitar.Size = new System.Drawing.Size(115, 34);
            this.invitar.TabIndex = 16;
            this.invitar.Text = "Invitar";
            this.invitar.UseVisualStyleBackColor = true;
            this.invitar.Visible = false;
            this.invitar.Click += new System.EventHandler(this.invitar_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(539, 316);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(190, 82);
            this.listBox1.TabIndex = 16;
            this.listBox1.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(649, 430);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 27);
            this.button4.TabIndex = 17;
            this.button4.Text = "Enviar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(539, 404);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 20);
            this.textBox1.TabIndex = 18;
            this.textBox1.Visible = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(476, 164);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(115, 34);
            this.button5.TabIndex = 19;
            this.button5.Text = "Chatear";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(539, 430);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(80, 27);
            this.button6.TabIndex = 20;
            this.button6.Text = "Cerrar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(743, 567);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(476, 124);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(115, 34);
            this.button7.TabIndex = 22;
            this.button7.Text = "Consultas";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 562);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.invitar);
            this.Controls.Add(this.listBox33);
            this.Controls.Add(this.listadeconectados);
            this.Controls.Add(this.conectado1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Parchis";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox partida;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Hombres;
        private System.Windows.Forms.RadioButton Ganador;
        private System.Windows.Forms.RadioButton Relacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox jugador1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox jugador2;
        private System.Windows.Forms.TextBox conectado1;
        private System.Windows.Forms.Label listadeconectados;
        private System.Windows.Forms.ListBox listBox33;
        private System.Windows.Forms.Button invitar;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button botton8;
    }
}

