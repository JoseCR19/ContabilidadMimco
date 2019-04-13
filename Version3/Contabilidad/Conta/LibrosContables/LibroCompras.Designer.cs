namespace Conta.RegistroCompras
{
    partial class LibroCompras
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
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.btn_Txt = new System.Windows.Forms.Button();
            this.btn_Reporte = new System.Windows.Forms.Button();
            this.btn_excel = new System.Windows.Forms.Button();
            this.btn_Cargar = new System.Windows.Forms.Button();
            this.grd_Ventas = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_anho = new System.Windows.Forms.Label();
            this.cmb_Mes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Ventas)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Image = global::Contabilidad.Properties.Resources.close;
            this.btn_Cerrar.Location = new System.Drawing.Point(951, 356);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(49, 43);
            this.btn_Cerrar.TabIndex = 59;
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // btn_Txt
            // 
            this.btn_Txt.Image = global::Contabilidad.Properties.Resources.txt2;
            this.btn_Txt.Location = new System.Drawing.Point(796, 12);
            this.btn_Txt.Name = "btn_Txt";
            this.btn_Txt.Size = new System.Drawing.Size(43, 43);
            this.btn_Txt.TabIndex = 58;
            this.btn_Txt.UseVisualStyleBackColor = true;
            this.btn_Txt.Click += new System.EventHandler(this.btn_Txt_Click);
            // 
            // btn_Reporte
            // 
            this.btn_Reporte.Image = global::Contabilidad.Properties.Resources.report;
            this.btn_Reporte.Location = new System.Drawing.Point(672, 12);
            this.btn_Reporte.Name = "btn_Reporte";
            this.btn_Reporte.Size = new System.Drawing.Size(43, 43);
            this.btn_Reporte.TabIndex = 57;
            this.btn_Reporte.UseVisualStyleBackColor = true;
            this.btn_Reporte.Click += new System.EventHandler(this.btn_Reporte_Click);
            // 
            // btn_excel
            // 
            this.btn_excel.Image = global::Contabilidad.Properties.Resources.excel1;
            this.btn_excel.Location = new System.Drawing.Point(535, 12);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(51, 43);
            this.btn_excel.TabIndex = 56;
            this.btn_excel.UseVisualStyleBackColor = true;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // btn_Cargar
            // 
            this.btn_Cargar.Location = new System.Drawing.Point(350, 29);
            this.btn_Cargar.Name = "btn_Cargar";
            this.btn_Cargar.Size = new System.Drawing.Size(75, 23);
            this.btn_Cargar.TabIndex = 55;
            this.btn_Cargar.Text = "Cargar";
            this.btn_Cargar.UseVisualStyleBackColor = true;
            this.btn_Cargar.Click += new System.EventHandler(this.btn_Cargar_Click);
            // 
            // grd_Ventas
            // 
            this.grd_Ventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_Ventas.Location = new System.Drawing.Point(10, 77);
            this.grd_Ventas.Name = "grd_Ventas";
            this.grd_Ventas.ReadOnly = true;
            this.grd_Ventas.Size = new System.Drawing.Size(990, 264);
            this.grd_Ventas.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Mes :";
            // 
            // lbl_anho
            // 
            this.lbl_anho.AutoSize = true;
            this.lbl_anho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_anho.Location = new System.Drawing.Point(237, 33);
            this.lbl_anho.Name = "lbl_anho";
            this.lbl_anho.Size = new System.Drawing.Size(39, 20);
            this.lbl_anho.TabIndex = 52;
            this.lbl_anho.Text = "año";
            // 
            // cmb_Mes
            // 
            this.cmb_Mes.FormattingEnabled = true;
            this.cmb_Mes.Location = new System.Drawing.Point(78, 32);
            this.cmb_Mes.Name = "cmb_Mes";
            this.cmb_Mes.Size = new System.Drawing.Size(135, 21);
            this.cmb_Mes.TabIndex = 51;
            // 
            // LibroCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 411);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.btn_Txt);
            this.Controls.Add(this.btn_Reporte);
            this.Controls.Add(this.btn_excel);
            this.Controls.Add(this.btn_Cargar);
            this.Controls.Add(this.grd_Ventas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_anho);
            this.Controls.Add(this.cmb_Mes);
            this.Name = "LibroCompras";
            this.Text = "LibroCompras";
            ((System.ComponentModel.ISupportInitialize)(this.grd_Ventas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cerrar;
        private System.Windows.Forms.Button btn_Txt;
        private System.Windows.Forms.Button btn_Reporte;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.Button btn_Cargar;
        private System.Windows.Forms.DataGridView grd_Ventas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_anho;
        private System.Windows.Forms.ComboBox cmb_Mes;
    }
}