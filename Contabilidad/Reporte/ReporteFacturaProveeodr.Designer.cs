namespace Contabilidad.Reporte
{
    partial class ReporteFacturaProveeodr
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
            this.cmb_periodo = new System.Windows.Forms.ComboBox();
            this.cmb_ejercicio2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_Ruc = new System.Windows.Forms.TextBox();
            this.grd_Documentos = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Dolares = new System.Windows.Forms.TextBox();
            this.txt_Direccion = new System.Windows.Forms.TextBox();
            this.txt_Cliente = new System.Windows.Forms.TextBox();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Reporte = new System.Windows.Forms.Button();
            this.btn_pdf = new System.Windows.Forms.Button();
            this.btn_excel = new System.Windows.Forms.Button();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Documentos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_periodo
            // 
            this.cmb_periodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_periodo.FormattingEnabled = true;
            this.cmb_periodo.Location = new System.Drawing.Point(646, 77);
            this.cmb_periodo.Name = "cmb_periodo";
            this.cmb_periodo.Size = new System.Drawing.Size(138, 21);
            this.cmb_periodo.TabIndex = 106;
            this.cmb_periodo.SelectedIndexChanged += new System.EventHandler(this.cmb_periodo_SelectedIndexChanged);
            // 
            // cmb_ejercicio2
            // 
            this.cmb_ejercicio2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ejercicio2.FormattingEnabled = true;
            this.cmb_ejercicio2.Location = new System.Drawing.Point(448, 77);
            this.cmb_ejercicio2.Name = "cmb_ejercicio2";
            this.cmb_ejercicio2.Size = new System.Drawing.Size(138, 21);
            this.cmb_ejercicio2.TabIndex = 105;
            this.cmb_ejercicio2.SelectedIndexChanged += new System.EventHandler(this.cmb_ejercicio2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(598, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 103;
            this.label2.Text = "Perido : ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(386, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "Ejercicio : ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(68, 80);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(73, 13);
            this.label21.TabIndex = 113;
            this.label21.Text = "Proveedor :";
            this.label21.Click += new System.EventHandler(this.label21_Click);
            // 
            // txt_Ruc
            // 
            this.txt_Ruc.Enabled = false;
            this.txt_Ruc.Location = new System.Drawing.Point(147, 78);
            this.txt_Ruc.Name = "txt_Ruc";
            this.txt_Ruc.Size = new System.Drawing.Size(133, 20);
            this.txt_Ruc.TabIndex = 112;
            this.txt_Ruc.TextChanged += new System.EventHandler(this.txt_Ruc_TextChanged);
            // 
            // grd_Documentos
            // 
            this.grd_Documentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_Documentos.Location = new System.Drawing.Point(26, 111);
            this.grd_Documentos.Name = "grd_Documentos";
            this.grd_Documentos.ReadOnly = true;
            this.grd_Documentos.Size = new System.Drawing.Size(982, 274);
            this.grd_Documentos.TabIndex = 114;
            this.grd_Documentos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_Documentos_CellContentClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 404);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 117;
            this.label6.Text = "Soles : ";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(97, 407);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 116;
            this.label7.Text = "Total : ";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txt_Total
            // 
            this.txt_Total.Enabled = false;
            this.txt_Total.Location = new System.Drawing.Point(147, 404);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Total.Size = new System.Drawing.Size(100, 20);
            this.txt_Total.TabIndex = 115;
            this.txt_Total.TextChanged += new System.EventHandler(this.txt_Total_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(275, 402);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 17);
            this.label12.TabIndex = 120;
            this.label12.Text = "Dólares : ";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(364, 404);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 119;
            this.label13.Text = "Total : ";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // txt_Dolares
            // 
            this.txt_Dolares.Enabled = false;
            this.txt_Dolares.Location = new System.Drawing.Point(415, 400);
            this.txt_Dolares.Name = "txt_Dolares";
            this.txt_Dolares.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Dolares.Size = new System.Drawing.Size(100, 20);
            this.txt_Dolares.TabIndex = 118;
            this.txt_Dolares.TextChanged += new System.EventHandler(this.txt_Dolares_TextChanged);
            // 
            // txt_Direccion
            // 
            this.txt_Direccion.Enabled = false;
            this.txt_Direccion.Location = new System.Drawing.Point(595, -77);
            this.txt_Direccion.Name = "txt_Direccion";
            this.txt_Direccion.Size = new System.Drawing.Size(546, 20);
            this.txt_Direccion.TabIndex = 123;
            // 
            // txt_Cliente
            // 
            this.txt_Cliente.Enabled = false;
            this.txt_Cliente.Location = new System.Drawing.Point(595, -100);
            this.txt_Cliente.Name = "txt_Cliente";
            this.txt_Cliente.Size = new System.Drawing.Size(546, 20);
            this.txt_Cliente.TabIndex = 122;
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Image = global::Contabilidad.Properties.Resources.close;
            this.btn_Cerrar.Location = new System.Drawing.Point(959, 388);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(49, 43);
            this.btn_Cerrar.TabIndex = 121;
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Contabilidad.Properties.Resources.lupamedio;
            this.button1.Location = new System.Drawing.Point(306, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 25);
            this.button1.TabIndex = 111;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Reporte
            // 
            this.btn_Reporte.Image = global::Contabilidad.Properties.Resources.report;
            this.btn_Reporte.Location = new System.Drawing.Point(920, 12);
            this.btn_Reporte.Name = "btn_Reporte";
            this.btn_Reporte.Size = new System.Drawing.Size(43, 43);
            this.btn_Reporte.TabIndex = 110;
            this.btn_Reporte.UseVisualStyleBackColor = true;
            this.btn_Reporte.Click += new System.EventHandler(this.btn_Reporte_Click);
            // 
            // btn_pdf
            // 
            this.btn_pdf.Image = global::Contabilidad.Properties.Resources.iconPdf;
            this.btn_pdf.Location = new System.Drawing.Point(672, 12);
            this.btn_pdf.Name = "btn_pdf";
            this.btn_pdf.Size = new System.Drawing.Size(43, 43);
            this.btn_pdf.TabIndex = 109;
            this.btn_pdf.UseVisualStyleBackColor = true;
            this.btn_pdf.Click += new System.EventHandler(this.btn_pdf_Click);
            // 
            // btn_excel
            // 
            this.btn_excel.Image = global::Contabilidad.Properties.Resources.excel1;
            this.btn_excel.Location = new System.Drawing.Point(396, 12);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(51, 43);
            this.btn_excel.TabIndex = 108;
            this.btn_excel.UseVisualStyleBackColor = true;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Image = global::Contabilidad.Properties.Resources.print1;
            this.btn_imprimir.Location = new System.Drawing.Point(96, 12);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(54, 44);
            this.btn_imprimir.TabIndex = 107;
            this.btn_imprimir.UseVisualStyleBackColor = true;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Image = global::Contabilidad.Properties.Resources.lupa;
            this.btn_Buscar.Location = new System.Drawing.Point(831, 67);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(57, 38);
            this.btn_Buscar.TabIndex = 104;
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // ReporteFacturaProveeodr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 442);
            this.Controls.Add(this.txt_Direccion);
            this.Controls.Add(this.txt_Cliente);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt_Dolares);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_Total);
            this.Controls.Add(this.grd_Documentos);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_Ruc);
            this.Controls.Add(this.btn_Reporte);
            this.Controls.Add(this.btn_pdf);
            this.Controls.Add(this.btn_excel);
            this.Controls.Add(this.btn_imprimir);
            this.Controls.Add(this.cmb_periodo);
            this.Controls.Add(this.cmb_ejercicio2);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ReporteFacturaProveeodr";
            this.Text = "ReporteFacturaProveeodr";
            this.Load += new System.EventHandler(this.ReporteFacturaProveeodr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd_Documentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_periodo;
        private System.Windows.Forms.ComboBox cmb_ejercicio2;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Reporte;
        private System.Windows.Forms.Button btn_pdf;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_Ruc;
        private System.Windows.Forms.DataGridView grd_Documentos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_Dolares;
        private System.Windows.Forms.Button btn_Cerrar;
        private System.Windows.Forms.TextBox txt_Direccion;
        private System.Windows.Forms.TextBox txt_Cliente;
    }
}