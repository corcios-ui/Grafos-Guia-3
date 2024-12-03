namespace Grafos
{
    partial class Simulator
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
            this.components = new System.ComponentModel.Container();
            this.Pizarra = new System.Windows.Forms.Panel();
            this.CMSCrearVertice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Agregar = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarVerticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarArcoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lbNodoInicial = new System.Windows.Forms.Label();
            this.btnAncho = new System.Windows.Forms.Button();
            this.btnProfundidad = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVerticeOrigen = new System.Windows.Forms.TextBox();
            this.CMSCrearVertice.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pizarra
            // 
            this.Pizarra.BackColor = System.Drawing.Color.SteelBlue;
            this.Pizarra.Location = new System.Drawing.Point(16, 81);
            this.Pizarra.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Pizarra.Name = "Pizarra";
            this.Pizarra.Size = new System.Drawing.Size(732, 540);
            this.Pizarra.TabIndex = 0;
            this.Pizarra.Paint += new System.Windows.Forms.PaintEventHandler(this.Pizarra_Paint);
            this.Pizarra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseDown);
            this.Pizarra.MouseLeave += new System.EventHandler(this.Pizarra_MouseLeave);
            this.Pizarra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseMove);
            this.Pizarra.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseUp);
            // 
            // CMSCrearVertice
            // 
            this.CMSCrearVertice.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.CMSCrearVertice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Agregar,
            this.eliminarVerticeToolStripMenuItem,
            this.eliminarArcoToolStripMenuItem});
            this.CMSCrearVertice.Name = "CMSCrearVertice";
            this.CMSCrearVertice.Size = new System.Drawing.Size(182, 76);
            // 
            // Agregar
            // 
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(181, 24);
            this.Agregar.Text = "Nuevo Vertice";
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // eliminarVerticeToolStripMenuItem
            // 
            this.eliminarVerticeToolStripMenuItem.Name = "eliminarVerticeToolStripMenuItem";
            this.eliminarVerticeToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.eliminarVerticeToolStripMenuItem.Text = "Eliminar Vertice";
            this.eliminarVerticeToolStripMenuItem.Click += new System.EventHandler(this.eliminarVerticeToolStripMenuItem_Click);
            // 
            // eliminarArcoToolStripMenuItem
            // 
            this.eliminarArcoToolStripMenuItem.Name = "eliminarArcoToolStripMenuItem";
            this.eliminarArcoToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.eliminarArcoToolStripMenuItem.Text = "Eliminar Arco";
            this.eliminarArcoToolStripMenuItem.Click += new System.EventHandler(this.eliminarArcoToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Simulador de Grafos";
            // 
            // lbNodoInicial
            // 
            this.lbNodoInicial.AutoSize = true;
            this.lbNodoInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNodoInicial.Location = new System.Drawing.Point(813, 77);
            this.lbNodoInicial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNodoInicial.Name = "lbNodoInicial";
            this.lbNodoInicial.Size = new System.Drawing.Size(141, 29);
            this.lbNodoInicial.TabIndex = 4;
            this.lbNodoInicial.Text = "Nodo Inicial";
            // 
            // btnAncho
            // 
            this.btnAncho.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAncho.Location = new System.Drawing.Point(786, 232);
            this.btnAncho.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAncho.Name = "btnAncho";
            this.btnAncho.Size = new System.Drawing.Size(184, 70);
            this.btnAncho.TabIndex = 6;
            this.btnAncho.Text = "ANCHO";
            this.btnAncho.UseVisualStyleBackColor = true;
            this.btnAncho.Click += new System.EventHandler(this.btnAncho_Click);
            // 
            // btnProfundidad
            // 
            this.btnProfundidad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnProfundidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfundidad.Location = new System.Drawing.Point(974, 232);
            this.btnProfundidad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnProfundidad.Name = "btnProfundidad";
            this.btnProfundidad.Size = new System.Drawing.Size(170, 70);
            this.btnProfundidad.TabIndex = 7;
            this.btnProfundidad.Text = "PROFUNDIDAD";
            this.btnProfundidad.UseVisualStyleBackColor = true;
            this.btnProfundidad.Click += new System.EventHandler(this.btnProfundidad_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(906, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tipo de recorrido";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtVerticeOrigen
            // 
            this.txtVerticeOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVerticeOrigen.Location = new System.Drawing.Point(786, 117);
            this.txtVerticeOrigen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVerticeOrigen.Multiline = true;
            this.txtVerticeOrigen.Name = "txtVerticeOrigen";
            this.txtVerticeOrigen.Size = new System.Drawing.Size(358, 41);
            this.txtVerticeOrigen.TabIndex = 22;
            this.txtVerticeOrigen.TextChanged += new System.EventHandler(this.txtVerticeOrigen_TextChanged);
            // 
            // Simulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1228, 636);
            this.Controls.Add(this.txtVerticeOrigen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnProfundidad);
            this.Controls.Add(this.btnAncho);
            this.Controls.Add(this.lbNodoInicial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pizarra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Simulator";
            this.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador";
            this.Load += new System.EventHandler(this.Simulator_Load);
            this.CMSCrearVertice.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Pizarra;
        private System.Windows.Forms.ContextMenuStrip CMSCrearVertice;
        private System.Windows.Forms.ToolStripMenuItem Agregar;
        private System.Windows.Forms.ToolStripMenuItem eliminarVerticeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarArcoToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbNodoInicial;
        private System.Windows.Forms.Button btnAncho;
        private System.Windows.Forms.Button btnProfundidad;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtVerticeOrigen;
    }
}