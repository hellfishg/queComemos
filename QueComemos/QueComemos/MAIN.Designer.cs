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
            this.pERFIL1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pERFIL2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aYUDAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aCERCADEQueComemosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lOGINOUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Recetas
            // 
            this.btn_Recetas.Location = new System.Drawing.Point(19, 82);
            this.btn_Recetas.Name = "btn_Recetas";
            this.btn_Recetas.Size = new System.Drawing.Size(186, 113);
            this.btn_Recetas.TabIndex = 0;
            this.btn_Recetas.Text = "RECETAS";
            this.btn_Recetas.UseVisualStyleBackColor = true;
            // 
            // btn_Comercios
            // 
            this.btn_Comercios.Location = new System.Drawing.Point(226, 82);
            this.btn_Comercios.Name = "btn_Comercios";
            this.btn_Comercios.Size = new System.Drawing.Size(186, 113);
            this.btn_Comercios.TabIndex = 1;
            this.btn_Comercios.Text = "COMERCIOS";
            this.btn_Comercios.UseVisualStyleBackColor = true;
            // 
            // btn_Perfil
            // 
            this.btn_Perfil.Location = new System.Drawing.Point(19, 217);
            this.btn_Perfil.Name = "btn_Perfil";
            this.btn_Perfil.Size = new System.Drawing.Size(186, 113);
            this.btn_Perfil.TabIndex = 2;
            this.btn_Perfil.Text = "PERFIL";
            this.btn_Perfil.UseVisualStyleBackColor = true;
            // 
            // btn_Datos
            // 
            this.btn_Datos.Location = new System.Drawing.Point(226, 217);
            this.btn_Datos.Name = "btn_Datos";
            this.btn_Datos.Size = new System.Drawing.Size(186, 113);
            this.btn_Datos.TabIndex = 3;
            this.btn_Datos.Text = "DATOS";
            this.btn_Datos.UseVisualStyleBackColor = true;
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
            this.pERFILLOGINToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pERFIL1ToolStripMenuItem,
            this.pERFIL2ToolStripMenuItem});
            this.pERFILLOGINToolStripMenuItem.Name = "pERFILLOGINToolStripMenuItem";
            this.pERFILLOGINToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.pERFILLOGINToolStripMenuItem.Text = "PERFIL LOGIN";
            // 
            // pERFIL1ToolStripMenuItem
            // 
            this.pERFIL1ToolStripMenuItem.Name = "pERFIL1ToolStripMenuItem";
            this.pERFIL1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pERFIL1ToolStripMenuItem.Text = "PERFIL 1";
            // 
            // pERFIL2ToolStripMenuItem
            // 
            this.pERFIL2ToolStripMenuItem.Name = "pERFIL2ToolStripMenuItem";
            this.pERFIL2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pERFIL2ToolStripMenuItem.Text = "PERFIL 2";
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
            // lOGINOUTToolStripMenuItem
            // 
            this.lOGINOUTToolStripMenuItem.Name = "lOGINOUTToolStripMenuItem";
            this.lOGINOUTToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.lOGINOUTToolStripMenuItem.Text = "LOGIN OUT";
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 406);
            this.Controls.Add(this.btn_Datos);
            this.Controls.Add(this.btn_Perfil);
            this.Controls.Add(this.btn_Comercios);
            this.Controls.Add(this.btn_Recetas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuPrincipal";
            this.Text = "Que Comemos?";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem pERFIL1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pERFIL2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aYUDAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aCERCADEQueComemosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lOGINOUTToolStripMenuItem;
    }
}

