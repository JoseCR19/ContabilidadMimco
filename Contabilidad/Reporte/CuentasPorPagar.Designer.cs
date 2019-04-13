namespace Contabilidad.Reporte
{
    partial class CuentasPorPagar
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbx_mes = new System.Windows.Forms.ComboBox();
            this.cbx_anio = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_UnidadNegocio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Dolares = new System.Windows.Forms.TextBox();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dpickerFin = new System.Windows.Forms.DateTimePicker();
            this.dpickerInicio = new System.Windows.Forms.DateTimePicker();
            this.btn_excel = new System.Windows.Forms.Button();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.grd_Documentos = new System.Windows.Forms.DataGridView();
            this.cbx_dia = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_un2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Total2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Dolares2 = new System.Windows.Forms.TextBox();
            this.btn_buscarv = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_excelv = new System.Windows.Forms.Button();
            this.grd_Documentos2 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Documentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Documentos2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Image = global::Contabilidad.Properties.Resources.close;
            this.btn_Cerrar.Location = new System.Drawing.Point(897, 463);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(49, 43);
            this.btn_Cerrar.TabIndex = 47;
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(950, 445);
            this.tabControl1.TabIndex = 48;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbx_mes);
            this.tabPage1.Controls.Add(this.cbx_anio);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cmb_UnidadNegocio);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txt_Total);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.txt_Dolares);
            this.tabPage1.Controls.Add(this.btn_Buscar);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dpickerFin);
            this.tabPage1.Controls.Add(this.dpickerInicio);
            this.tabPage1.Controls.Add(this.btn_excel);
            this.tabPage1.Controls.Add(this.btn_imprimir);
            this.tabPage1.Controls.Add(this.grd_Documentos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(942, 419);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cuentas Por Pagar";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbx_dia);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.cbx_un2);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txt_Total2);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txt_Dolares2);
            this.tabPage2.Controls.Add(this.btn_buscarv);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.btn_excelv);
            this.tabPage2.Controls.Add(this.grd_Documentos2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(942, 419);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cuentas Por Pagar Vencer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbx_mes
            // 
            this.cbx_mes.FormattingEnabled = true;
            this.cbx_mes.Location = new System.Drawing.Point(519, 68);
            this.cbx_mes.Name = "cbx_mes";
            this.cbx_mes.Size = new System.Drawing.Size(121, 21);
            this.cbx_mes.TabIndex = 90;
            // 
            // cbx_anio
            // 
            this.cbx_anio.FormattingEnabled = true;
            this.cbx_anio.Location = new System.Drawing.Point(329, 68);
            this.cbx_anio.Name = "cbx_anio";
            this.cbx_anio.Size = new System.Drawing.Size(121, 21);
            this.cbx_anio.TabIndex = 89;
            this.cbx_anio.SelectedIndexChanged += new System.EventHandler(this.cbx_anio_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 88;
            this.label3.Text = "Unidad Negocio: ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cmb_UnidadNegocio
            // 
            this.cmb_UnidadNegocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_UnidadNegocio.FormattingEnabled = true;
            this.cmb_UnidadNegocio.Location = new System.Drawing.Point(145, 68);
            this.cmb_UnidadNegocio.Name = "cmb_UnidadNegocio";
            this.cmb_UnidadNegocio.Size = new System.Drawing.Size(121, 21);
            this.cmb_UnidadNegocio.TabIndex = 87;
            this.cmb_UnidadNegocio.SelectedIndexChanged += new System.EventHandler(this.cmb_UnidadNegocio_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(244, 389);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 86;
            this.label4.Text = "Total Soles: ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txt_Total
            // 
            this.txt_Total.Enabled = false;
            this.txt_Total.Location = new System.Drawing.Point(329, 386);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Total.Size = new System.Drawing.Size(100, 20);
            this.txt_Total.TabIndex = 85;
            this.txt_Total.TextChanged += new System.EventHandler(this.txt_Total_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(444, 390);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 13);
            this.label13.TabIndex = 84;
            this.label13.Text = "Total Dólares: ";
            // 
            // txt_Dolares
            // 
            this.txt_Dolares.Enabled = false;
            this.txt_Dolares.Location = new System.Drawing.Point(536, 386);
            this.txt_Dolares.Name = "txt_Dolares";
            this.txt_Dolares.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Dolares.Size = new System.Drawing.Size(100, 20);
            this.txt_Dolares.TabIndex = 83;
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Image = global::Contabilidad.Properties.Resources.lupa;
            this.btn_Buscar.Location = new System.Drawing.Point(697, 58);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(57, 38);
            this.btn_Buscar.TabIndex = 82;
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(461, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 81;
            this.label2.Text = "Periodo : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(273, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "Ejercicio : ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dpickerFin
            // 
            this.dpickerFin.Enabled = false;
            this.dpickerFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpickerFin.Location = new System.Drawing.Point(804, 32);
            this.dpickerFin.Name = "dpickerFin";
            this.dpickerFin.Size = new System.Drawing.Size(100, 20);
            this.dpickerFin.TabIndex = 79;
            this.dpickerFin.Visible = false;
            // 
            // dpickerInicio
            // 
            this.dpickerInicio.Enabled = false;
            this.dpickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpickerInicio.Location = new System.Drawing.Point(804, 58);
            this.dpickerInicio.Name = "dpickerInicio";
            this.dpickerInicio.Size = new System.Drawing.Size(100, 20);
            this.dpickerInicio.TabIndex = 78;
            this.dpickerInicio.Visible = false;
            // 
            // btn_excel
            // 
            this.btn_excel.Image = global::Contabilidad.Properties.Resources.excel1;
            this.btn_excel.Location = new System.Drawing.Point(536, 16);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(51, 43);
            this.btn_excel.TabIndex = 77;
            this.btn_excel.UseVisualStyleBackColor = true;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click_1);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Image = global::Contabilidad.Properties.Resources.print1;
            this.btn_imprimir.Location = new System.Drawing.Point(348, 16);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(54, 44);
            this.btn_imprimir.TabIndex = 76;
            this.btn_imprimir.UseVisualStyleBackColor = true;
            // 
            // grd_Documentos
            // 
            this.grd_Documentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_Documentos.Location = new System.Drawing.Point(39, 101);
            this.grd_Documentos.Name = "grd_Documentos";
            this.grd_Documentos.ReadOnly = true;
            this.grd_Documentos.Size = new System.Drawing.Size(865, 275);
            this.grd_Documentos.TabIndex = 75;
            this.grd_Documentos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_Documentos_CellContentClick);
            // 
            // cbx_dia
            // 
            this.cbx_dia.FormattingEnabled = true;
            this.cbx_dia.Location = new System.Drawing.Point(363, 66);
            this.cbx_dia.Name = "cbx_dia";
            this.cbx_dia.Size = new System.Drawing.Size(121, 21);
            this.cbx_dia.TabIndex = 100;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Unidad Negocio: ";
            // 
            // cbx_un2
            // 
            this.cbx_un2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_un2.FormattingEnabled = true;
            this.cbx_un2.Location = new System.Drawing.Point(145, 66);
            this.cbx_un2.Name = "cbx_un2";
            this.cbx_un2.Size = new System.Drawing.Size(121, 21);
            this.cbx_un2.TabIndex = 98;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(244, 387);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 97;
            this.label6.Text = "Total Soles: ";
            // 
            // txt_Total2
            // 
            this.txt_Total2.Enabled = false;
            this.txt_Total2.Location = new System.Drawing.Point(329, 384);
            this.txt_Total2.Name = "txt_Total2";
            this.txt_Total2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Total2.Size = new System.Drawing.Size(100, 20);
            this.txt_Total2.TabIndex = 96;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(444, 388);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 95;
            this.label7.Text = "Total Dólares: ";
            // 
            // txt_Dolares2
            // 
            this.txt_Dolares2.Enabled = false;
            this.txt_Dolares2.Location = new System.Drawing.Point(536, 384);
            this.txt_Dolares2.Name = "txt_Dolares2";
            this.txt_Dolares2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Dolares2.Size = new System.Drawing.Size(100, 20);
            this.txt_Dolares2.TabIndex = 94;
            // 
            // btn_buscarv
            // 
            this.btn_buscarv.Image = global::Contabilidad.Properties.Resources.lupa;
            this.btn_buscarv.Location = new System.Drawing.Point(697, 56);
            this.btn_buscarv.Name = "btn_buscarv";
            this.btn_buscarv.Size = new System.Drawing.Size(57, 38);
            this.btn_buscarv.TabIndex = 93;
            this.btn_buscarv.UseVisualStyleBackColor = true;
            this.btn_buscarv.Click += new System.EventHandler(this.btn_buscarv_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(273, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 92;
            this.label8.Text = "Vencimiento :";
            // 
            // btn_excelv
            // 
            this.btn_excelv.Image = global::Contabilidad.Properties.Resources.excel1;
            this.btn_excelv.Location = new System.Drawing.Point(536, 14);
            this.btn_excelv.Name = "btn_excelv";
            this.btn_excelv.Size = new System.Drawing.Size(51, 43);
            this.btn_excelv.TabIndex = 91;
            this.btn_excelv.UseVisualStyleBackColor = true;
            this.btn_excelv.Click += new System.EventHandler(this.btn_excelv_Click);
            // 
            // grd_Documentos2
            // 
            this.grd_Documentos2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_Documentos2.Location = new System.Drawing.Point(39, 99);
            this.grd_Documentos2.Name = "grd_Documentos2";
            this.grd_Documentos2.ReadOnly = true;
            this.grd_Documentos2.Size = new System.Drawing.Size(865, 275);
            this.grd_Documentos2.TabIndex = 90;
            // 
            // CuentasPorPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 518);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_Cerrar);
            this.Name = "CuentasPorPagar";
            this.Text = "CuentasPorPagar";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Documentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Documentos2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Cerrar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cbx_mes;
        private System.Windows.Forms.ComboBox cbx_anio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_UnidadNegocio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_Dolares;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpickerFin;
        private System.Windows.Forms.DateTimePicker dpickerInicio;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.DataGridView grd_Documentos;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cbx_dia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbx_un2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Total2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Dolares2;
        private System.Windows.Forms.Button btn_buscarv;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_excelv;
        private System.Windows.Forms.DataGridView grd_Documentos2;
    }
}