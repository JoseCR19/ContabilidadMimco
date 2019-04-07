namespace Contabilidad
{
    partial class ListaFactura
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
            this.dpickerInicio = new System.Windows.Forms.DateTimePicker();
            this.dpickerFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Ruc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_ver = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_Anular = new System.Windows.Forms.Button();
            this.btn_EnviarSunat = new System.Windows.Forms.Button();
            this.btn_Reporte = new System.Windows.Forms.Button();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.btn_pdf = new System.Windows.Forms.Button();
            this.btn_excel = new System.Windows.Forms.Button();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.btn_Nuevo = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btn_Consultar = new System.Windows.Forms.Button();
            this.btn_ConAnulacion = new System.Windows.Forms.Button();
            this.lbl_Sunat = new System.Windows.Forms.Label();
            this.btn_ConsultarMasivo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_TotalDolares = new System.Windows.Forms.TextBox();
            this.txt_TotalSoles = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_Estado = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Facturas)).BeginInit();
            this.SuspendLayout();
            // 
            // grd_Facturas
            // 
            this.grd_Facturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_Facturas.Location = new System.Drawing.Point(12, 115);
            this.grd_Facturas.Name = "grd_Facturas";
            this.grd_Facturas.Size = new System.Drawing.Size(1141, 357);
            this.grd_Facturas.TabIndex = 0;
            // 
            // dpickerInicio
            // 
            this.dpickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpickerInicio.Location = new System.Drawing.Point(332, 73);
            this.dpickerInicio.Name = "dpickerInicio";
            this.dpickerInicio.Size = new System.Drawing.Size(100, 20);
            this.dpickerInicio.TabIndex = 1;
            // 
            // dpickerFin
            // 
            this.dpickerFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpickerFin.Location = new System.Drawing.Point(529, 74);
            this.dpickerFin.Name = "dpickerFin";
            this.dpickerFin.Size = new System.Drawing.Size(100, 20);
            this.dpickerFin.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(273, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Desde : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(470, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hasta : ";
            // 
            // txt_Ruc
            // 
            this.txt_Ruc.Location = new System.Drawing.Point(111, 74);
            this.txt_Ruc.Name = "txt_Ruc";
            this.txt_Ruc.Size = new System.Drawing.Size(121, 20);
            this.txt_Ruc.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "RUC :";
            // 
            // btn_ver
            // 
            this.btn_ver.Location = new System.Drawing.Point(837, 525);
            this.btn_ver.Name = "btn_ver";
            this.btn_ver.Size = new System.Drawing.Size(116, 26);
            this.btn_ver.TabIndex = 32;
            this.btn_ver.Text = "Ver";
            this.btn_ver.UseVisualStyleBackColor = true;
            this.btn_ver.Click += new System.EventHandler(this.btn_ver_Click);
            // 
            // btn_Anular
            // 
            this.btn_Anular.Enabled = false;
            this.btn_Anular.Location = new System.Drawing.Point(44, 491);
            this.btn_Anular.Name = "btn_Anular";
            this.btn_Anular.Size = new System.Drawing.Size(116, 26);
            this.btn_Anular.TabIndex = 48;
            this.btn_Anular.Text = "Anular";
            this.btn_Anular.UseVisualStyleBackColor = true;
            this.btn_Anular.Click += new System.EventHandler(this.btn_Anular_Click);
            // 
            // btn_EnviarSunat
            // 
            this.btn_EnviarSunat.Enabled = false;
            this.btn_EnviarSunat.Image = global::Contabilidad.Properties.Resources.sunat;
            this.btn_EnviarSunat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_EnviarSunat.Location = new System.Drawing.Point(958, 12);
            this.btn_EnviarSunat.Name = "btn_EnviarSunat";
            this.btn_EnviarSunat.Size = new System.Drawing.Size(87, 43);
            this.btn_EnviarSunat.TabIndex = 49;
            this.btn_EnviarSunat.Text = "ENVIAR";
            this.btn_EnviarSunat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_EnviarSunat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_EnviarSunat.UseVisualStyleBackColor = true;
            this.btn_EnviarSunat.Click += new System.EventHandler(this.btn_EnviarSunat_Click);
            // 
            // btn_Reporte
            // 
            this.btn_Reporte.Image = global::Contabilidad.Properties.Resources.report;
            this.btn_Reporte.Location = new System.Drawing.Point(805, 12);
            this.btn_Reporte.Name = "btn_Reporte";
            this.btn_Reporte.Size = new System.Drawing.Size(43, 43);
            this.btn_Reporte.TabIndex = 47;
            this.btn_Reporte.UseVisualStyleBackColor = true;
            this.btn_Reporte.Click += new System.EventHandler(this.btn_Reporte_Click);
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Image = global::Contabilidad.Properties.Resources.close;
            this.btn_Cerrar.Location = new System.Drawing.Point(1065, 525);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(49, 43);
            this.btn_Cerrar.TabIndex = 33;
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // btn_pdf
            // 
            this.btn_pdf.Image = global::Contabilidad.Properties.Resources.iconPdf;
            this.btn_pdf.Location = new System.Drawing.Point(645, 13);
            this.btn_pdf.Name = "btn_pdf";
            this.btn_pdf.Size = new System.Drawing.Size(43, 43);
            this.btn_pdf.TabIndex = 31;
            this.btn_pdf.UseVisualStyleBackColor = true;
            this.btn_pdf.Click += new System.EventHandler(this.btn_pdf_Click);
            // 
            // btn_excel
            // 
            this.btn_excel.Image = global::Contabilidad.Properties.Resources.excel1;
            this.btn_excel.Location = new System.Drawing.Point(467, 12);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(51, 43);
            this.btn_excel.TabIndex = 30;
            this.btn_excel.UseVisualStyleBackColor = true;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Image = global::Contabilidad.Properties.Resources.print1;
            this.btn_imprimir.Location = new System.Drawing.Point(282, 12);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(54, 44);
            this.btn_imprimir.TabIndex = 29;
            this.btn_imprimir.UseVisualStyleBackColor = true;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // btn_Nuevo
            // 
            this.btn_Nuevo.Image = global::Contabilidad.Properties.Resources.new1;
            this.btn_Nuevo.Location = new System.Drawing.Point(109, 12);
            this.btn_Nuevo.Name = "btn_Nuevo";
            this.btn_Nuevo.Size = new System.Drawing.Size(59, 44);
            this.btn_Nuevo.TabIndex = 28;
            this.btn_Nuevo.UseVisualStyleBackColor = true;
            this.btn_Nuevo.Click += new System.EventHandler(this.btn_Nuevo_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Image = global::Contabilidad.Properties.Resources.lupa;
            this.btn_Buscar.Location = new System.Drawing.Point(923, 66);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(57, 38);
            this.btn_Buscar.TabIndex = 5;
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_Consultar
            // 
            this.btn_Consultar.Enabled = false;
            this.btn_Consultar.Location = new System.Drawing.Point(264, 491);
            this.btn_Consultar.Name = "btn_Consultar";
            this.btn_Consultar.Size = new System.Drawing.Size(116, 26);
            this.btn_Consultar.TabIndex = 50;
            this.btn_Consultar.Text = "Consultar";
            this.btn_Consultar.UseVisualStyleBackColor = true;
            this.btn_Consultar.Click += new System.EventHandler(this.btn_Consultar_Click);
            // 
            // btn_ConAnulacion
            // 
            this.btn_ConAnulacion.Enabled = false;
            this.btn_ConAnulacion.Location = new System.Drawing.Point(441, 491);
            this.btn_ConAnulacion.Name = "btn_ConAnulacion";
            this.btn_ConAnulacion.Size = new System.Drawing.Size(116, 26);
            this.btn_ConAnulacion.TabIndex = 51;
            this.btn_ConAnulacion.Text = "Consultar Anulación";
            this.btn_ConAnulacion.UseVisualStyleBackColor = true;
            this.btn_ConAnulacion.Click += new System.EventHandler(this.btn_ConAnulacion_Click);
            // 
            // lbl_Sunat
            // 
            this.lbl_Sunat.AutoSize = true;
            this.lbl_Sunat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Sunat.Location = new System.Drawing.Point(135, 524);
            this.lbl_Sunat.Name = "lbl_Sunat";
            this.lbl_Sunat.Size = new System.Drawing.Size(64, 22);
            this.lbl_Sunat.TabIndex = 52;
            this.lbl_Sunat.Text = "label4";
            this.lbl_Sunat.Visible = false;
            // 
            // btn_ConsultarMasivo
            // 
            this.btn_ConsultarMasivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ConsultarMasivo.Location = new System.Drawing.Point(1026, 66);
            this.btn_ConsultarMasivo.Name = "btn_ConsultarMasivo";
            this.btn_ConsultarMasivo.Size = new System.Drawing.Size(116, 43);
            this.btn_ConsultarMasivo.TabIndex = 57;
            this.btn_ConsultarMasivo.Text = "Consultar SUNAT (Todos)";
            this.btn_ConsultarMasivo.UseVisualStyleBackColor = true;
            this.btn_ConsultarMasivo.Click += new System.EventHandler(this.btn_ConsultarMasivo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(714, 481);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Total Dolares : ";
            // 
            // txt_TotalDolares
            // 
            this.txt_TotalDolares.Enabled = false;
            this.txt_TotalDolares.Location = new System.Drawing.Point(815, 478);
            this.txt_TotalDolares.Name = "txt_TotalDolares";
            this.txt_TotalDolares.Size = new System.Drawing.Size(121, 20);
            this.txt_TotalDolares.TabIndex = 59;
            // 
            // txt_TotalSoles
            // 
            this.txt_TotalSoles.Enabled = false;
            this.txt_TotalSoles.Location = new System.Drawing.Point(1030, 478);
            this.txt_TotalSoles.Name = "txt_TotalSoles";
            this.txt_TotalSoles.Size = new System.Drawing.Size(121, 20);
            this.txt_TotalSoles.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(945, 481);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Total Soles : ";
            // 
            // cmb_Estado
            // 
            this.cmb_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Estado.FormattingEnabled = true;
            this.cmb_Estado.Location = new System.Drawing.Point(736, 73);
            this.cmb_Estado.Name = "cmb_Estado";
            this.cmb_Estado.Size = new System.Drawing.Size(130, 21);
            this.cmb_Estado.TabIndex = 62;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(672, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 63;
            this.label6.Text = "Estado : ";
            // 
            // ListaFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 578);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmb_Estado);
            this.Controls.Add(this.txt_TotalSoles);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_TotalDolares);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_ConsultarMasivo);
            this.Controls.Add(this.lbl_Sunat);
            this.Controls.Add(this.btn_ConAnulacion);
            this.Controls.Add(this.btn_Consultar);
            this.Controls.Add(this.btn_EnviarSunat);
            this.Controls.Add(this.btn_Anular);
            this.Controls.Add(this.btn_Reporte);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.btn_ver);
            this.Controls.Add(this.btn_pdf);
            this.Controls.Add(this.btn_excel);
            this.Controls.Add(this.btn_imprimir);
            this.Controls.Add(this.btn_Nuevo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Ruc);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dpickerFin);
            this.Controls.Add(this.dpickerInicio);
            this.Controls.Add(this.grd_Facturas);
            this.Name = "ListaFactura";
            this.Text = "FACTURAS";
            ((System.ComponentModel.ISupportInitialize)(this.grd_Facturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grd_Facturas;
        private System.Windows.Forms.DateTimePicker dpickerInicio;
        private System.Windows.Forms.DateTimePicker dpickerFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.TextBox txt_Ruc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Nuevo;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.Button btn_pdf;
        private System.Windows.Forms.Button btn_ver;
        private System.Windows.Forms.Button btn_Cerrar;
        private System.Windows.Forms.Button btn_Reporte;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_Anular;
        private System.Windows.Forms.Button btn_EnviarSunat;
        private System.Windows.Forms.Button btn_Consultar;
        private System.Windows.Forms.Button btn_ConAnulacion;
        private System.Windows.Forms.Label lbl_Sunat;
        private System.Windows.Forms.Button btn_ConsultarMasivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_TotalDolares;
        private System.Windows.Forms.TextBox txt_TotalSoles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_Estado;
        private System.Windows.Forms.Label label6;
    }
}