namespace QueComemos {
    partial class MenuPrincipal {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.btn_Recetas = new System.Windows.Forms.Button();
            this.btn_Comercios = new System.Windows.Forms.Button();
            this.btn_Perfil = new System.Windows.Forms.Button();
            this.btn_Datos = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pERFILLOGINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lOGINOUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aYUDAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aCERCADEQueComemosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Recetas
            // 
            this.btn_Recetas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Recetas.Location = new System.Drawing.Point(15, 144);
            this.btn_Recetas.Name = "btn_Recetas";
            this.btn_Recetas.Size = new System.Drawing.Size(186, 113);
            this.btn_Recetas.TabIndex = 0;
            this.btn_Recetas.Text = "RECETAS";
            this.btn_Recetas.UseVisualStyleBackColor = true;
            this.btn_Recetas.Click += new System.EventHandler(this.btn_Recetas_Click);
            // 
            // btn_Comercios
            // 
            this.btn_Comercios.Location = new System.Drawing.Point(222, 144);
            this.btn_Comercios.Name = "btn_Comercios";
            this.btn_Comercios.Size = new System.Drawing.Size(186, 113);
            this.btn_Comercios.TabIndex = 1;
            this.btn_Comercios.Text = "COMERCIOS";
            this.btn_Comercios.UseVisualStyleBackColor = true;
            this.btn_Comercios.Click += new System.EventHandler(this.btn_Comercios_Click);
            // 
            // btn_Perfil
            // 
            this.btn_Perfil.Location = new System.Drawing.Point(15, 279);
            this.btn_Perfil.Name = "btn_Perfil";
            this.btn_Perfil.Size = new System.Drawing.Size(186, 113);
            this.btn_Perfil.TabIndex = 2;
            this.btn_Perfil.Text = "PERFIL";
            this.btn_Perfil.UseVisualStyleBackColor = true;
            this.btn_Perfil.Click += new System.EventHandler(this.btn_Perfil_Click);
            // 
            // btn_Datos
            // 
            this.btn_Datos.Location = new System.Drawing.Point(222, 279);
            this.btn_Datos.Name = "btn_Datos";
            this.btn_Datos.Size = new System.Drawing.Size(186, 113);
            this.btn_Datos.TabIndex = 3;
            this.btn_Datos.Text = "DATOS";
            this.btn_Datos.UseVisualStyleBackColor = true;
            this.btn_Datos.Click += new System.EventHandler(this.btn_Datos_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pERFILLOGINToolStripMenuItem,
            this.lOGINOUTToolStripMenuItem,
            this.aYUDAToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(435, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pERFILLOGINToolStripMenuItem
            // 
            this.pERFILLOGINToolStripMenuItem.Name = "pERFILLOGINToolStripMenuItem";
            this.pERFILLOGINToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.pERFILLOGINToolStripMenuItem.Text = "PERFIL LOGIN";
            this.pERFILLOGINToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.pERFILLOGINToolStripMenuItem_DropDownItemClicked);
            // 
            // lOGINOUTToolStripMenuItem
            // 
            this.lOGINOUTToolStripMenuItem.Name = "lOGINOUTToolStripMenuItem";
            this.lOGINOUTToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.lOGINOUTToolStripMenuItem.Text = "LOGOUT";
            this.lOGINOUTToolStripMenuItem.Click += new System.EventHandler(this.lOGINOUTToolStripMenuItem_Click);
            // 
            // aYUDAToolStripMenuItem
            // 
            this.aYUDAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aCERCADEQueComemosToolStripMenuItem});
            this.aYUDAToolStripMenuItem.Name = "aYUDAToolStripMenuItem";
            this.aYUDAToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.aYUDAToolStripMenuItem.Text = "AYUDA";
            // 
            // aCERCADEQueComemosToolStripMenuItem
            // 
            this.aCERCADEQueComemosToolStripMenuItem.Name = "aCERCADEQueComemosToolStripMenuItem";
            this.aCERCADEQueComemosToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.aCERCADEQueComemosToolStripMenuItem.Text = "ACERCA DE queComemos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(132, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "ANONIMO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(132, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "NO CONECTADO";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(87, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 111);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PERFIL";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(435, 403);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Datos);
            this.Controls.Add(this.btn_Perfil);
            this.Controls.Add(this.btn_Comercios);
            this.Controls.Add(this.btn_Recetas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Que Comemos?";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuPrincipal_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.MenuPrincipal_VisibleChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Recetas;
        private System.Windows.Forms.Button btn_Comercios;
        private System.Windows.Forms.Button btn_Perfil;
        private System.Windows.Forms.Button btn_Datos;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pERFILLOGINToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aYUDAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aCERCADEQueComemosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lOGINOUTToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

