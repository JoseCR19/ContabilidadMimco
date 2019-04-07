namespace Contabilidad
{
    partial class ListaRetencion
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
            this.grd_Facturas = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Ruc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dpickerFin = new System.Windows.Forms.DateTimePicker();
            this.dpickerInicio = new System.Windows.Forms.DateTimePicker();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btn_Reporte = new System.Windows.Forms.Button();
            this.btn_pdf = new System.Windows.Forms.Button();
            this.btn_excel = new System.Windows.Forms.Button();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.btn_Nuevo = new System.Windows.Forms.Button();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.btn_ver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Facturas)).BeginInit();
            this.SuspendLayout();
            // 
            // grd_Facturas
            // 
            this.grd_Facturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_Facturas.Location = new System.Drawing.Point(4, 115);
            this.grd_Facturas.Name = "grd_Facturas";
            this.grd_Facturas.RowHeadersVisible = false;
            this.grd_Facturas.Size = new System.Drawing.Size(796, 240);
            this.grd_Facturas.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 72;
            this.label3.Text = "RUC :";
            // 
            // txt_Ruc
            // 
            this.txt_Ruc.Location = new System.Drawing.Point(101, 74);
            this.txt_Ruc.Name = "txt_Ruc";
            this.txt_Ruc.Size = new System.Drawing.Size(121, 20);
            this.txt_Ruc.TabIndex = 71;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(477, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 69;
            this.label2.Text = "Hasta : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(270, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Desde : ";
            // 
            // dpickerFin
            // 
            this.dpickerFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpickerFin.Location = new System.Drawing.Point(544, 73);
            this.dpickerFin.Name = "dpickerFin";
            this.dpickerFin.Size = new System.Drawing.Size(100, 20);
            this.dpickerFin.TabIndex = 67;
            // 
            // dpickerInicio
            // 
            this.dpickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpickerInicio.Location = new System.Drawing.Point(347, 73);
            this.dpickerInicio.Name = "dpickerInicio";
            this.dpickerInicio.Size = new System.Drawing.Size(100, 20);
            this.dpickerInicio.TabIndex = 66;
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Image = global::Contabilidad.Properties.Resources.lupa;
            this.btn_Buscar.Location = new System.Drawing.Point(682, 55);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(57, 38);
            this.btn_Buscar.TabIndex = 70;
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_Reporte
            // 
            this.btn_Reporte.Image = global::Contabilidad.Properties.Resources.report;
            this.btn_Reporte.Location = new System.Drawing.Point(594, 13);
            this.btn_Reporte.Name = "btn_Reporte";
            this.btn_Reporte.Size = new System.Drawing.Size(43, 43);
            this.btn_Reporte.TabIndex = 65;
            this.btn_Reporte.UseVisualStyleBackColor = true;
            // 
            // btn_pdf
            // 
            this.btn_pdf.Image = global::Contabilidad.Properties.Resources.iconPdf;
            this.btn_pdf.Location = new System.Drawing.Point(488, 13);
            this.btn_pdf.Name = "btn_pdf";
            this.btn_pdf.Size = new System.Drawing.Size(43, 43);
            this.btn_pdf.TabIndex = 64;
            this.btn_pdf.UseVisualStyleBackColor = true;
            // 
            // btn_excel
            // 
            this.btn_excel.Image = global::Contabilidad.Properties.Resources.excel1;
            this.btn_excel.Location = new System.Drawing.Point(378, 13);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(51, 43);
            this.btn_excel.TabIndex = 63;
            this.btn_excel.UseVisualStyleBackColor = true;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Image = global::Contabilidad.Properties.Resources.print1;
            this.btn_imprimir.Location = new System.Drawing.Point(259, 12);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(54, 44);
            this.btn_imprimir.TabIndex = 62;
            this.btn_imprimir.UseVisualStyleBackColor = true;
            // 
            // btn_Nuevo
            // 
            this.btn_Nuevo.Image = global::Contabilidad.Properties.Resources.new1;
            this.btn_Nuevo.Location = new System.Drawing.Point(139, 12);
            this.btn_Nuevo.Name = "btn_Nuevo";
            this.btn_Nuevo.Size = new System.Drawing.Size(59, 44);
            this.btn_Nuevo.TabIndex = 61;
            this.btn_Nuevo.UseVisualStyleBackColor = true;
            this.btn_Nuevo.Click += new System.EventHandler(this.btn_Nuevo_Click);
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Image = global::Contabilidad.Properties.Resources.close;
            this.btn_Cerrar.Location = new System.Drawing.Point(734, 365);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(49, 43);
            this.btn_Cerrar.TabIndex = 75;
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // btn_ver
            // 
            this.btn_ver.Location = new System.Drawing.Point(552, 362);
            this.btn_ver.Name = "btn_ver";
            this.btn_ver.Size = new System.Drawing.Size(116, 26);
            this.btn_ver.TabIndex = 74;
            this.btn_ver.Text = "Ver";
            this.btn_ver.UseVisualStyleBackColor = true;
            this.btn_ver.Click += new System.EventHandler(this.btn_ver_Click);
            // 
            // ListaRetencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 416);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.btn_ver);
            this.Controls.Add(this.grd_Facturas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Ruc);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dpickerFin);
            this.Controls.Add(this.dpickerInicio);
            this.Controls.Add(this.btn_Reporte);
            this.Controls.Add(this.btn_pdf);
            this.Controls.Add(this.btn_excel);
            this.Controls.Add(this.btn_imprimir);
            this.Controls.Add(this.btn_Nuevo);
            this.Name = "ListaRetencion";
            this.Text = "ListaRetencion";
            ((System.ComponentModel.ISupportInitialize)(this.grd_Facturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grd_Facturas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Ruc;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpickerFin;
        private System.Windows.Forms.DateTimePicker dpickerInicio;
        private System.Windows.Forms.Button btn_Reporte;
        private System.Windows.Forms.Button btn_pdf;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.Button btn_Nuevo;
        private System.Windows.Forms.Button btn_Cerrar;
        private System.Windows.Forms.Button btn_ver;
    }
}