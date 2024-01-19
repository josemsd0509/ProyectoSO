namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.boton1 = new System.Windows.Forms.Button();
            this.jnombre = new System.Windows.Forms.TextBox();
            this.n = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // boton1
            // 
            this.boton1.BackColor = System.Drawing.Color.Transparent;
            this.boton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton1.Location = new System.Drawing.Point(94, 168);
            this.boton1.Name = "boton1";
            this.boton1.Size = new System.Drawing.Size(107, 38);
            this.boton1.TabIndex = 0;
            this.boton1.Text = "continuar";
            this.boton1.UseVisualStyleBackColor = false;
            this.boton1.Click += new System.EventHandler(this.boton1_Click);
            // 
            // jnombre
            // 
            this.jnombre.Location = new System.Drawing.Point(83, 35);
            this.jnombre.Name = "jnombre";
            this.jnombre.Size = new System.Drawing.Size(139, 20);
            this.jnombre.TabIndex = 1;
            // 
            // n
            // 
            this.n.AutoSize = true;
            this.n.BackColor = System.Drawing.Color.Transparent;
            this.n.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.n.Location = new System.Drawing.Point(12, 35);
            this.n.Name = "n";
            this.n.Size = new System.Drawing.Size(65, 20);
            this.n.TabIndex = 2;
            this.n.Text = "Nombre";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 263);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.n);
            this.Controls.Add(this.jnombre);
            this.Controls.Add(this.boton1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form2";
            this.Text = "LogIn";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button boton1;
        private System.Windows.Forms.TextBox jnombre;
        private System.Windows.Forms.Label n;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}