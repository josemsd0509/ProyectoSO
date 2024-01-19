namespace WindowsFormsApplication1
{
    partial class Form3
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
            this.Deneg = new System.Windows.Forms.Button();
            this.Acept = new System.Windows.Forms.Button();
            this.Nom = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Deneg
            // 
            this.Deneg.Location = new System.Drawing.Point(381, 125);
            this.Deneg.Name = "Deneg";
            this.Deneg.Size = new System.Drawing.Size(75, 30);
            this.Deneg.TabIndex = 0;
            this.Deneg.Text = "Denegar";
            this.Deneg.UseVisualStyleBackColor = true;
            this.Deneg.Click += new System.EventHandler(this.Deneg_Click);
            // 
            // Acept
            // 
            this.Acept.Location = new System.Drawing.Point(29, 125);
            this.Acept.Name = "Acept";
            this.Acept.Size = new System.Drawing.Size(75, 30);
            this.Acept.TabIndex = 1;
            this.Acept.Text = "Aceptar";
            this.Acept.UseVisualStyleBackColor = true;
            this.Acept.Click += new System.EventHandler(this.Acept_Click);
            // 
            // Nom
            // 
            this.Nom.AutoEllipsis = true;
            this.Nom.BackColor = System.Drawing.Color.Transparent;
            this.Nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nom.Location = new System.Drawing.Point(29, 53);
            this.Nom.Name = "Nom";
            this.Nom.Size = new System.Drawing.Size(427, 39);
            this.Nom.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-3, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 174);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 174);
            this.Controls.Add(this.Nom);
            this.Controls.Add(this.Acept);
            this.Controls.Add(this.Deneg);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form3";
            this.Text = "Invitación";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Coral;
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Deneg;
        private System.Windows.Forms.Button Acept;
        private System.Windows.Forms.Label Nom;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}