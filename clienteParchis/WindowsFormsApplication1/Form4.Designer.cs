namespace WindowsFormsApplication1
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Dado2 = new System.Windows.Forms.Label();
            this.Dado1 = new System.Windows.Forms.Label();
            this.Tablero = new System.Windows.Forms.Label();
            this.JugadorParchis1 = new System.Windows.Forms.Label();
            this.JugadorParchis2 = new System.Windows.Forms.Label();
            this.JugadorParchis3 = new System.Windows.Forms.Label();
            this.JugadorParchis4 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Chat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1073, 689);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(147, 20);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1226, 689);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 20);
            this.button1.TabIndex = 4;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Dado2
            // 
            this.Dado2.Image = global::WindowsFormsApplication1.Properties.Resources.cara5;
            this.Dado2.Location = new System.Drawing.Point(1114, 28);
            this.Dado2.Name = "Dado2";
            this.Dado2.Size = new System.Drawing.Size(183, 155);
            this.Dado2.TabIndex = 5;
            // 
            // Dado1
            // 
            this.Dado1.Image = global::WindowsFormsApplication1.Properties.Resources.cara3;
            this.Dado1.Location = new System.Drawing.Point(830, 28);
            this.Dado1.Name = "Dado1";
            this.Dado1.Size = new System.Drawing.Size(183, 155);
            this.Dado1.TabIndex = 2;
            // 
            // Tablero
            // 
            this.Tablero.Image = global::WindowsFormsApplication1.Properties.Resources.TableroParchis;
            this.Tablero.Location = new System.Drawing.Point(12, 9);
            this.Tablero.Name = "Tablero";
            this.Tablero.Size = new System.Drawing.Size(889, 735);
            this.Tablero.TabIndex = 0;
            // 
            // JugadorParchis1
            // 
            this.JugadorParchis1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.JugadorParchis1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JugadorParchis1.Location = new System.Drawing.Point(167, 115);
            this.JugadorParchis1.Name = "JugadorParchis1";
            this.JugadorParchis1.Size = new System.Drawing.Size(100, 33);
            this.JugadorParchis1.TabIndex = 8;
            this.JugadorParchis1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // JugadorParchis2
            // 
            this.JugadorParchis2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.JugadorParchis2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JugadorParchis2.Location = new System.Drawing.Point(645, 115);
            this.JugadorParchis2.Name = "JugadorParchis2";
            this.JugadorParchis2.Size = new System.Drawing.Size(100, 33);
            this.JugadorParchis2.TabIndex = 9;
            this.JugadorParchis2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // JugadorParchis3
            // 
            this.JugadorParchis3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.JugadorParchis3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JugadorParchis3.Location = new System.Drawing.Point(167, 600);
            this.JugadorParchis3.Name = "JugadorParchis3";
            this.JugadorParchis3.Size = new System.Drawing.Size(100, 33);
            this.JugadorParchis3.TabIndex = 10;
            this.JugadorParchis3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // JugadorParchis4
            // 
            this.JugadorParchis4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.JugadorParchis4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JugadorParchis4.Location = new System.Drawing.Point(645, 596);
            this.JugadorParchis4.Name = "JugadorParchis4";
            this.JugadorParchis4.Size = new System.Drawing.Size(100, 33);
            this.JugadorParchis4.TabIndex = 11;
            this.JugadorParchis4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(1073, 514);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(224, 173);
            this.listBox1.TabIndex = 12;
            // 
            // Chat
            // 
            this.Chat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chat.Location = new System.Drawing.Point(1070, 488);
            this.Chat.Name = "Chat";
            this.Chat.Size = new System.Drawing.Size(227, 23);
            this.Chat.TabIndex = 13;
            this.Chat.Text = "Chat";
            this.Chat.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 753);
            this.Controls.Add(this.Chat);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.JugadorParchis4);
            this.Controls.Add(this.JugadorParchis3);
            this.Controls.Add(this.JugadorParchis2);
            this.Controls.Add(this.JugadorParchis1);
            this.Controls.Add(this.Dado2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Dado1);
            this.Controls.Add(this.Tablero);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Tablero;
        private System.Windows.Forms.Label Dado1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Dado2;
        public System.Windows.Forms.Label JugadorParchis1;
        public System.Windows.Forms.Label JugadorParchis2;
        public System.Windows.Forms.Label JugadorParchis3;
        public System.Windows.Forms.Label JugadorParchis4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label Chat;
    }
}