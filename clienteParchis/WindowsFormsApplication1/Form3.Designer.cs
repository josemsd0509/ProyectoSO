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
            this.SuspendLayout();
            // 
            // Deneg
            // 
            this.Deneg.Location = new System.Drawing.Point(357, 125);
            this.Deneg.Name = "Deneg";
            this.Deneg.Size = new System.Drawing.Size(75, 23);
            this.Deneg.TabIndex = 0;
            this.Deneg.Text = "Denegar";
            this.Deneg.UseVisualStyleBackColor = true;
            this.Deneg.Click += new System.EventHandler(this.Deneg_Click);
            // 
            // Acept
            // 
            this.Acept.Location = new System.Drawing.Point(45, 125);
            this.Acept.Name = "Acept";
            this.Acept.Size = new System.Drawing.Size(75, 23);
            this.Acept.TabIndex = 1;
            this.Acept.Text = "Aceptar";
            this.Acept.UseVisualStyleBackColor = true;
            this.Acept.Click += new System.EventHandler(this.Acept_Click);
            // 
            // Nom
            // 
            this.Nom.AutoEllipsis = true;
            this.Nom.AutoSize = true;
            this.Nom.Location = new System.Drawing.Point(174, 53);
            this.Nom.Name = "Nom";
            this.Nom.Size = new System.Drawing.Size(0, 13);
            this.Nom.TabIndex = 2;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 174);
            this.Controls.Add(this.Nom);
            this.Controls.Add(this.Acept);
            this.Controls.Add(this.Deneg);
            this.Name = "Form3";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Coral;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Deneg;
        private System.Windows.Forms.Button Acept;
        private System.Windows.Forms.Label Nom;
    }
}