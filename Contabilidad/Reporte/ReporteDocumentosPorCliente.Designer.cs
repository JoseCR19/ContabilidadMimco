namespace Contabilidad
{
    partial class ReporteDocumentosPorCliente
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
            this.cmb_Moneda = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Cliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_ver = new System.Windows.Forms.Button();
            this.grd_Documentos = new System.Windows.Forms.DataGridView();
            this.txt_codcliente = new System.Windows.Forms.TextBox();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.btn_BuscarOT = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btn_Reporte = new System.Windows.Forms.Button();
            this.btn_pdf = new System.Windows.Forms.Button();
            this.btn_excel = new System.Windows.Forms.Button();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cmb_TipoDocumento = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_SubTotalD = new System.Windows.Forms.TextBox();
            this.txt_IGVD = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_SubTotalS = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_IGVS = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Dolares = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.cmb_ejercicio2 = new System.Windows.Forms.ComboBox();
            this.cmb_periodo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Documentos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_Moneda
            // 
            this.cmb_Moneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Moneda.FormattingEnabled = true;
            this.cmb_Moneda.Location = new System.Drawing.Point(1037, 78);
            this.cmb_Moneda.Name = "cmb_Moneda";
            this.cmb_Moneda.Size = new System.Drawing.Size(138, 21);
            this.cmb_Moneda.TabIndex = 71;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(967, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 70;
            this.label5.Text = "Moneda : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(499, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 66;
            this.label2.Text = "Perido : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(287, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Ejercicio : ";
            // 
            // txt_Cliente
            // 
            this.txt_Cliente.BackColor = System.Drawing.Color.White;
            this.txt_Cliente.Location = new System.Drawing.Point(82, 78);
            this.txt_Cliente.Name = "txt_Cliente";
            this.txt_Cliente.Size = new System.Drawing.Size(131, 20);
            this.txt_Cliente.TabIndex = 72;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 73;
            this.label3.Text = "Cliente : ";
            // 
            // btn_ver
            // 
            this.btn_ver.Location = new System.Drawing.Point(5, 399);
            this.btn_ver.Name = "btn_ver";
            this.btn_ver.Size = new System.Drawing.Size(160, 26);
            this.btn_ver.TabIndex = 76;
            this.btn_ver.Text = "Visualizar";
            this.btn_ver.UseVisualStyleBackColor = true;
            this.btn_ver.Click += new System.EventHandler(this.btn_ver_Click);
            // 
            // grd_Documentos
            // 
            this.grd_Documentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_Documentos.Location = new System.Drawing.Point(5, 118);
            this.grd_Documentos.Name = "grd_Documentos";
            this.grd_Documentos.ReadOnly = true;
            this.grd_Documentos.Size = new System.Drawing.Size(1287, 274);
            this.grd_Documentos.TabIndex = 75;
            // 
            // txt_codcliente
            // 
            this.txt_codcliente.Location = new System.Drawing.Point(44, 466);
            this.txt_codcliente.Name = "txt_codcliente";
            this.txt_codcliente.Size = new System.Drawing.Size(100, 20);
            this.txt_codcliente.TabIndex = 80;
            this.txt_codcliente.Visible = false;
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Image = global::Contabilidad.Properties.Resources.close;
            this.btn_Cerrar.Location = new System.Drawing.Point(1243, 433);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(49, 43);
            this.btn_Cerrar.TabIndex = 79;
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // btn_BuscarOT
            // 
            this.btn_BuscarOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BuscarOT.Image = global::Contabilidad.Properties.Resources.lupamedio;
            this.btn_BuscarOT.Location = new System.Drawing.Point(220, 78);
            this.btn_BuscarOT.Name = "btn_BuscarOT";
            this.btn_BuscarOT.Size = new System.Drawing.Size(38, 23);
            this.btn_BuscarOT.TabIndex = 74;
            this.btn_BuscarOT.UseVisualStyleBackColor = true;
            this.btn_BuscarOT.Click += new System.EventHandler(this.btn_BuscarOT_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Image = global::Contabilidad.Properties.Resources.lupa;
            this.btn_Buscar.Location = new System.Drawing.Point(1190, 65);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(57, 38);
            this.btn_Buscar.TabIndex = 69;
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_Reporte
            // 
            this.btn_Reporte.Image = global::Contabilidad.Properties.Resources.report;
            this.btn_Reporte.Location = new System.Drawing.Point(1037, 13);
            this.btn_Reporte.Name = "btn_Reporte";
            this.btn_Reporte.Size = new System.Drawing.Size(43, 43);
            this.btn_Reporte.TabIndex = 62;
            this.btn_Reporte.UseVisualStyleBackColor = true;
            this.btn_Reporte.Click += new System.EventHandler(this.btn_Reporte_Click);
            // 
            // btn_pdf
            // 
            this.btn_pdf.Image = global::Contabilidad.Properties.Resources.iconPdf;
            this.btn_pdf.Location = new System.Drawing.Point(789, 13);
            this.btn_pdf.Name = "btn_pdf";
            this.btn_pdf.Size = new System.Drawing.Size(43, 43);
            this.btn_pdf.TabIndex = 61;
            this.btn_pdf.UseVisualStyleBackColor = true;
            this.btn_pdf.Click += new System.EventHandler(this.btn_pdf_Click);
            // 
            // btn_excel
            // 
            this.btn_excel.Image = global::Contabilidad.Properties.Resources.excel1;
            this.btn_excel.Location = new System.Drawing.Point(513, 13);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(51, 43);
            this.btn_excel.TabIndex = 60;
            this.btn_excel.UseVisualStyleBackColor = true;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Image = global::Contabilidad.Properties.Resources.print1;
            this.btn_imprimir.Location = new System.Drawing.Point(213, 13);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(54, 44);
            this.btn_imprimir.TabIndex = 59;
            this.btn_imprimir.UseVisualStyleBackColor = true;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // cmb_TipoDocumento
            // 
            this.cmb_TipoDocumento.FormattingEnabled = true;
            this.cmb_TipoDocumento.Location = new System.Drawing.Point(800, 77);
            this.cmb_TipoDocumento.Name = "cmb_TipoDocumento";
            this.cmb_TipoDocumento.Size = new System.Drawing.Size(161, 21);
            this.cmb_TipoDocumento.TabIndex = 85;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(686, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 84;
            this.label8.Text = "Tipo Documento :";
            // 
            // txt_SubTotalD
            // 
            this.txt_SubTotalD.Enabled = false;
            this.txt_SubTotalD.Location = new System.Drawing.Point(839, 401);
            this.txt_SubTotalD.Name = "txt_SubTotalD";
            this.txt_SubTotalD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_SubTotalD.Size = new System.Drawing.Size(83, 20);
            this.txt_SubTotalD.TabIndex = 99;
            // 
            // txt_IGVD
            // 
            this.txt_IGVD.Enabled = false;
            this.txt_IGVD.Location = new System.Drawing.Point(982, 402);
            this.txt_IGVD.Name = "txt_IGVD";
            this.txt_IGVD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_IGVD.Size = new System.Drawing.Size(68, 20);
            this.txt_IGVD.TabIndex = 98;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(767, 405);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 97;
            this.label10.Text = "Sub Total : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(928, 405);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 96;
            this.label11.Text = "IGV :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(694, 402);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 17);
            this.label12.TabIndex = 95;
            this.label12.Text = "Dólares : ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1066, 405);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 94;
            this.label13.Text = "Total : ";
            // 
            // txt_SubTotalS
            // 
            this.txt_SubTotalS.Enabled = false;
            this.txt_SubTotalS.Location = new System.Drawing.Point(318, 403);
            this.txt_SubTotalS.Name = "txt_SubTotalS";
            this.txt_SubTotalS.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_SubTotalS.Size = new System.Drawing.Size(83, 20);
            this.txt_SubTotalS.TabIndex = 93;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(249, 406);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 92;
            this.label9.Text = "Sub Total : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(411, 406);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 91;
            this.label4.Text = "IGV :";
            // 
            // txt_IGVS
            // 
            this.txt_IGVS.Enabled = false;
            this.txt_IGVS.Location = new System.Drawing.Point(453, 403);
            this.txt_IGVS.Name = "txt_IGVS";
            this.txt_IGVS.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_IGVS.Size = new System.Drawing.Size(68, 20);
            this.txt_IGVS.TabIndex = 90;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(180, 404);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 89;
            this.label6.Text = "Soles : ";
            // 
            // txt_Dolares
            // 
            this.txt_Dolares.Enabled = false;
            this.txt_Dolares.Location = new System.Drawing.Point(1117, 401);
            this.txt_Dolares.Name = "txt_Dolares";
            this.txt_Dolares.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Dolares.Size = new System.Drawing.Size(100, 20);
            this.txt_Dolares.TabIndex = 88;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(535, 405);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 87;
            this.label7.Text = "Total : ";
            // 
            // txt_Total
            // 
            this.txt_Total.Enabled = false;
            this.txt_Total.Location = new System.Drawing.Point(585, 402);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Total.Size = new System.Drawing.Size(100, 20);
            this.txt_Total.TabIndex = 86;
            // 
            // cmb_ejercicio2
            // 
            this.cmb_ejercicio2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ejercicio2.FormattingEnabled = true;
            this.cmb_ejercicio2.Location = new System.Drawing.Point(349, 81);
            this.cmb_ejercicio2.Name = "cmb_ejercicio2";
            this.cmb_ejercicio2.Size = new System.Drawing.Size(138, 21);
            this.cmb_ejercicio2.TabIndex = 100;
            // 
            // cmb_periodo
            // 
            this.cmb_periodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_periodo.FormattingEnabled = true;
            this.cmb_periodo.Location = new System.Drawing.Point(547, 81);
            this.cmb_periodo.Name = "cmb_periodo";
            this.cmb_periodo.Size = new System.Drawing.Size(138, 21);
            this.cmb_periodo.TabIndex = 101;
            // 
            // ReporteDocumentosPorCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 504);
            this.Controls.Add(this.cmb_periodo);
            this.Controls.Add(this.cmb_ejercicio2);
            this.Controls.Add(this.txt_SubTotalD);
            this.Controls.Add(this.txt_IGVD);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt_SubTotalS);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_IGVS);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_Dolares);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_Total);
            this.Controls.Add(this.cmb_TipoDocumento);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_codcliente);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.btn_ver);
            this.Controls.Add(this.grd_Documentos);
            this.Controls.Add(this.btn_BuscarOT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Cliente);
            this.Controls.Add(this.cmb_Moneda);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Reporte);
            this.Controls.Add(this.btn_pdf);
            this.Controls.Add(this.btn_excel);
            this.Controls.Add(this.btn_imprimir);
            this.Name = "ReporteDocumentosPorCliente";
            this.Text = "ReporteDocumentosPorCliente";
            this.Load += new System.EventHandler(this.ReporteDocumentosPorCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd_Documentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Reporte;
        private System.Windows.Forms.Button btn_pdf;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.ComboBox cmb_Moneda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Cliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_BuscarOT;
        private System.Windows.Forms.Button btn_ver;
        private System.Windows.Forms.DataGridView grd_Documentos;
        private System.Windows.Forms.Button btn_Cerrar;
        private System.Windows.Forms.TextBox txt_codcliente;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ComboBox cmb_TipoDocumento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_SubTotalD;
        private System.Windows.Forms.TextBox txt_IGVD;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_SubTotalS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_IGVS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Dolares;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.ComboBox cmb_ejercicio2;
        private System.Windows.Forms.ComboBox cmb_periodo;
    }
}