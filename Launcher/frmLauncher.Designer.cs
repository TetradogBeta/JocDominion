namespace dominion
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
            this.btbMazoPred = new System.Windows.Forms.Button();
            this.btnEscollirCartes = new System.Windows.Forms.Button();
            this.btnRandom = new System.Windows.Forms.Button();
            this.pnlEleccioPrimera = new System.Windows.Forms.Panel();
            this.pnlEleccioCartes = new System.Windows.Forms.Panel();
            this.btnBorrarCarta = new System.Windows.Forms.Button();
            this.btnAfegirCarta = new System.Windows.Forms.Button();
            this.lstBxLlistaMazos = new System.Windows.Forms.ListBox();
            this.pbImatgeCarta = new System.Windows.Forms.PictureBox();
            this.lstLlistaMazoPersonalitzat = new System.Windows.Forms.ListBox();
            this.btnComençar = new System.Windows.Forms.Button();
            this.lstBxLlistaCartes = new System.Windows.Forms.ListBox();
            this.lstBxLlistaJugador = new System.Windows.Forms.ListBox();
            this.txtBxNom = new System.Windows.Forms.TextBox();
            this.btnAfegirJugador = new System.Windows.Forms.Button();
            this.btnEsborrrar = new System.Windows.Forms.Button();
            this.pnlEleccioPrimera.SuspendLayout();
            this.pnlEleccioCartes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImatgeCarta)).BeginInit();
            this.SuspendLayout();
            // 
            // btbMazoPred
            // 
            this.btbMazoPred.Location = new System.Drawing.Point(45, 23);
            this.btbMazoPred.Name = "btbMazoPred";
            this.btbMazoPred.Size = new System.Drawing.Size(103, 41);
            this.btbMazoPred.TabIndex = 0;
            this.btbMazoPred.Text = "Mazos Predeterminats";
            this.btbMazoPred.UseVisualStyleBackColor = true;
            this.btbMazoPred.Click += new System.EventHandler(this.btbMazoPred_Click);
            // 
            // btnEscollirCartes
            // 
            this.btnEscollirCartes.Location = new System.Drawing.Point(232, 23);
            this.btnEscollirCartes.Name = "btnEscollirCartes";
            this.btnEscollirCartes.Size = new System.Drawing.Size(100, 41);
            this.btnEscollirCartes.TabIndex = 1;
            this.btnEscollirCartes.Text = "Escollir Cartes";
            this.btnEscollirCartes.UseVisualStyleBackColor = true;
            this.btnEscollirCartes.Click += new System.EventHandler(this.btnEscollirCartes_Click);
            // 
            // btnRandom
            // 
            this.btnRandom.Location = new System.Drawing.Point(399, 23);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(75, 41);
            this.btnRandom.TabIndex = 2;
            this.btnRandom.Text = "Random";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // pnlEleccioPrimera
            // 
            this.pnlEleccioPrimera.Controls.Add(this.btnRandom);
            this.pnlEleccioPrimera.Controls.Add(this.btbMazoPred);
            this.pnlEleccioPrimera.Controls.Add(this.btnEscollirCartes);
            this.pnlEleccioPrimera.Location = new System.Drawing.Point(192, 24);
            this.pnlEleccioPrimera.Name = "pnlEleccioPrimera";
            this.pnlEleccioPrimera.Size = new System.Drawing.Size(510, 100);
            this.pnlEleccioPrimera.TabIndex = 3;
            // 
            // pnlEleccioCartes
            // 
            this.pnlEleccioCartes.Controls.Add(this.btnBorrarCarta);
            this.pnlEleccioCartes.Controls.Add(this.btnAfegirCarta);
            this.pnlEleccioCartes.Controls.Add(this.lstBxLlistaMazos);
            this.pnlEleccioCartes.Controls.Add(this.pbImatgeCarta);
            this.pnlEleccioCartes.Controls.Add(this.lstLlistaMazoPersonalitzat);
            this.pnlEleccioCartes.Controls.Add(this.btnComençar);
            this.pnlEleccioCartes.Controls.Add(this.lstBxLlistaCartes);
            this.pnlEleccioCartes.Location = new System.Drawing.Point(21, 178);
            this.pnlEleccioCartes.Name = "pnlEleccioCartes";
            this.pnlEleccioCartes.Size = new System.Drawing.Size(746, 271);
            this.pnlEleccioCartes.TabIndex = 3;
            // 
            // btnBorrarCarta
            // 
            this.btnBorrarCarta.Location = new System.Drawing.Point(302, 81);
            this.btnBorrarCarta.Name = "btnBorrarCarta";
            this.btnBorrarCarta.Size = new System.Drawing.Size(75, 23);
            this.btnBorrarCarta.TabIndex = 7;
            this.btnBorrarCarta.Text = "Borrar carta";
            this.btnBorrarCarta.UseVisualStyleBackColor = true;
            this.btnBorrarCarta.Click += new System.EventHandler(this.btnBorrarCarta_Click);
            // 
            // btnAfegirCarta
            // 
            this.btnAfegirCarta.Location = new System.Drawing.Point(302, 52);
            this.btnAfegirCarta.Name = "btnAfegirCarta";
            this.btnAfegirCarta.Size = new System.Drawing.Size(75, 23);
            this.btnAfegirCarta.TabIndex = 6;
            this.btnAfegirCarta.Text = "Afegir carta";
            this.btnAfegirCarta.UseVisualStyleBackColor = true;
            this.btnAfegirCarta.Click += new System.EventHandler(this.btnAfegirCarta_Click);
            // 
            // lstBxLlistaMazos
            // 
            this.lstBxLlistaMazos.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstBxLlistaMazos.FormattingEnabled = true;
            this.lstBxLlistaMazos.Location = new System.Drawing.Point(148, 0);
            this.lstBxLlistaMazos.Name = "lstBxLlistaMazos";
            this.lstBxLlistaMazos.Size = new System.Drawing.Size(148, 271);
            this.lstBxLlistaMazos.TabIndex = 5;
            this.lstBxLlistaMazos.SelectedIndexChanged += new System.EventHandler(this.lstBxLlistaMazos_SelectedIndexChanged);
            // 
            // pbImatgeCarta
            // 
            this.pbImatgeCarta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbImatgeCarta.Location = new System.Drawing.Point(436, 13);
            this.pbImatgeCarta.Name = "pbImatgeCarta";
            this.pbImatgeCarta.Size = new System.Drawing.Size(165, 255);
            this.pbImatgeCarta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImatgeCarta.TabIndex = 4;
            this.pbImatgeCarta.TabStop = false;
            // 
            // lstLlistaMazoPersonalitzat
            // 
            this.lstLlistaMazoPersonalitzat.FormattingEnabled = true;
            this.lstLlistaMazoPersonalitzat.Location = new System.Drawing.Point(171, 52);
            this.lstLlistaMazoPersonalitzat.Name = "lstLlistaMazoPersonalitzat";
            this.lstLlistaMazoPersonalitzat.Size = new System.Drawing.Size(117, 160);
            this.lstLlistaMazoPersonalitzat.TabIndex = 3;
            this.lstLlistaMazoPersonalitzat.SelectedIndexChanged += new System.EventHandler(this.lstLlistaMazoPersonalitzat_SelectedIndexChanged);
            // 
            // btnComençar
            // 
            this.btnComençar.Location = new System.Drawing.Point(627, 218);
            this.btnComençar.Name = "btnComençar";
            this.btnComençar.Size = new System.Drawing.Size(107, 41);
            this.btnComençar.TabIndex = 1;
            this.btnComençar.Text = "Comença";
            this.btnComençar.UseVisualStyleBackColor = true;
            this.btnComençar.Click += new System.EventHandler(this.btnComençar_Click);
            // 
            // lstBxLlistaCartes
            // 
            this.lstBxLlistaCartes.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstBxLlistaCartes.FormattingEnabled = true;
            this.lstBxLlistaCartes.Items.AddRange(new object[] {
            "Totes les cartes menys ",
            "les cartes escollides"});
            this.lstBxLlistaCartes.Location = new System.Drawing.Point(0, 0);
            this.lstBxLlistaCartes.Name = "lstBxLlistaCartes";
            this.lstBxLlistaCartes.Size = new System.Drawing.Size(148, 271);
            this.lstBxLlistaCartes.TabIndex = 0;
            this.lstBxLlistaCartes.Visible = false;
            this.lstBxLlistaCartes.SelectedIndexChanged += new System.EventHandler(this.lstBxLlistaCartes_SelectedIndexChanged);
            this.lstBxLlistaCartes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstBxLlistaCartes_MouseDoubleClick);
            // 
            // lstBxLlistaJugador
            // 
            this.lstBxLlistaJugador.FormattingEnabled = true;
            this.lstBxLlistaJugador.Location = new System.Drawing.Point(21, 24);
            this.lstBxLlistaJugador.Name = "lstBxLlistaJugador";
            this.lstBxLlistaJugador.Size = new System.Drawing.Size(100, 95);
            this.lstBxLlistaJugador.TabIndex = 5;
            this.lstBxLlistaJugador.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstBxLlistaJugador_MouseDoubleClick);
            // 
            // txtBxNom
            // 
            this.txtBxNom.Location = new System.Drawing.Point(21, 126);
            this.txtBxNom.Name = "txtBxNom";
            this.txtBxNom.Size = new System.Drawing.Size(100, 20);
            this.txtBxNom.TabIndex = 6;
            this.txtBxNom.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtBxNom_MouseDoubleClick);
            // 
            // btnAfegirJugador
            // 
            this.btnAfegirJugador.Location = new System.Drawing.Point(128, 125);
            this.btnAfegirJugador.Name = "btnAfegirJugador";
            this.btnAfegirJugador.Size = new System.Drawing.Size(39, 21);
            this.btnAfegirJugador.TabIndex = 3;
            this.btnAfegirJugador.Text = "ADD";
            this.btnAfegirJugador.UseVisualStyleBackColor = true;
            this.btnAfegirJugador.Click += new System.EventHandler(this.btnAfegirJugador_Click);
            // 
            // btnEsborrrar
            // 
            this.btnEsborrrar.Location = new System.Drawing.Point(128, 24);
            this.btnEsborrrar.Name = "btnEsborrrar";
            this.btnEsborrrar.Size = new System.Drawing.Size(39, 21);
            this.btnEsborrrar.TabIndex = 7;
            this.btnEsborrrar.Text = "Bor.";
            this.btnEsborrrar.UseVisualStyleBackColor = true;
            this.btnEsborrrar.Click += new System.EventHandler(this.btnEsborrrar_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(779, 461);
            this.Controls.Add(this.btnEsborrrar);
            this.Controls.Add(this.btnAfegirJugador);
            this.Controls.Add(this.txtBxNom);
            this.Controls.Add(this.lstBxLlistaJugador);
            this.Controls.Add(this.pnlEleccioCartes);
            this.Controls.Add(this.pnlEleccioPrimera);
            this.Name = "frmMain";
            this.Text = "Launcher";
            this.pnlEleccioPrimera.ResumeLayout(false);
            this.pnlEleccioCartes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImatgeCarta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btbMazoPred;
        private System.Windows.Forms.Button btnEscollirCartes;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Panel pnlEleccioPrimera;
        private System.Windows.Forms.Panel pnlEleccioCartes;
        private System.Windows.Forms.Button btnComençar;
        private System.Windows.Forms.ListBox lstBxLlistaCartes;
        private System.Windows.Forms.ListBox lstLlistaMazoPersonalitzat;
        private System.Windows.Forms.ListBox lstBxLlistaJugador;
        private System.Windows.Forms.TextBox txtBxNom;
        private System.Windows.Forms.Button btnAfegirJugador;
        private System.Windows.Forms.Button btnEsborrrar;
        private System.Windows.Forms.Button btnBorrarCarta;
        private System.Windows.Forms.Button btnAfegirCarta;
        private System.Windows.Forms.ListBox lstBxLlistaMazos;
        public System.Windows.Forms.PictureBox pbImatgeCarta;
    }
}

