namespace Wumpus
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableroP = new System.Windows.Forms.Panel();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnRotate = new System.Windows.Forms.Button();
            this.btnDisparar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFlecha = new System.Windows.Forms.TextBox();
            this.txtAviso = new System.Windows.Forms.Label();
            this.txtPunteo = new System.Windows.Forms.Label();
            this.txtVidas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tableroP
            // 
            this.tableroP.BackColor = System.Drawing.Color.Gray;
            this.tableroP.Location = new System.Drawing.Point(613, 24);
            this.tableroP.Name = "tableroP";
            this.tableroP.Size = new System.Drawing.Size(578, 496);
            this.tableroP.TabIndex = 0;
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUp.Location = new System.Drawing.Point(187, 247);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(46, 42);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = " ^";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLeft.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLeft.Location = new System.Drawing.Point(127, 295);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(47, 42);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDown.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDown.Location = new System.Drawing.Point(186, 335);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(47, 45);
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "v";
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRight.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRight.Location = new System.Drawing.Point(241, 297);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(51, 38);
            this.btnRight.TabIndex = 4;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnRotate
            // 
            this.btnRotate.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRotate.Location = new System.Drawing.Point(55, 171);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(94, 37);
            this.btnRotate.TabIndex = 5;
            this.btnRotate.Text = "Girar";
            this.btnRotate.UseVisualStyleBackColor = false;
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // btnDisparar
            // 
            this.btnDisparar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDisparar.Location = new System.Drawing.Point(198, 175);
            this.btnDisparar.Name = "btnDisparar";
            this.btnDisparar.Size = new System.Drawing.Size(94, 29);
            this.btnDisparar.TabIndex = 6;
            this.btnDisparar.Text = "Disparo";
            this.btnDisparar.UseVisualStyleBackColor = false;
            this.btnDisparar.Click += new System.EventHandler(this.btnDisparar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(24, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Flechas";
            // 
            // txtFlecha
            // 
            this.txtFlecha.Location = new System.Drawing.Point(94, 15);
            this.txtFlecha.Name = "txtFlecha";
            this.txtFlecha.Size = new System.Drawing.Size(55, 27);
            this.txtFlecha.TabIndex = 8;
            this.txtFlecha.Text = "1";
            // 
            // txtAviso
            // 
            this.txtAviso.AutoSize = true;
            this.txtAviso.Location = new System.Drawing.Point(149, 460);
            this.txtAviso.Name = "txtAviso";
            this.txtAviso.Size = new System.Drawing.Size(0, 20);
            this.txtAviso.TabIndex = 9;
            // 
            // txtPunteo
            // 
            this.txtPunteo.AutoSize = true;
            this.txtPunteo.Location = new System.Drawing.Point(371, 24);
            this.txtPunteo.Name = "txtPunteo";
            this.txtPunteo.Size = new System.Drawing.Size(58, 20);
            this.txtPunteo.TabIndex = 10;
            this.txtPunteo.Text = "Punteo:";
            // 
            // txtVidas
            // 
            this.txtVidas.Location = new System.Drawing.Point(94, 66);
            this.txtVidas.Name = "txtVidas";
            this.txtVidas.Size = new System.Drawing.Size(55, 27);
            this.txtVidas.TabIndex = 12;
            this.txtVidas.Text = "2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(24, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Vidas";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1304, 740);
            this.Controls.Add(this.txtVidas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPunteo);
            this.Controls.Add(this.txtAviso);
            this.Controls.Add(this.txtFlecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDisparar);
            this.Controls.Add(this.btnRotate);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.tableroP);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel tableroP;
        private Button btnUp;
        private Button btnLeft;
        private Button btnDown;
        private Button btnRight;
        private Button btnRotate;
        private Button btnDisparar;
        private Label label1;
        private TextBox txtFlecha;
        private Label txtAviso;
        private Label txtPunteo;
        private TextBox txtVidas;
        private Label label2;
    }
}