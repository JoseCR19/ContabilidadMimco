namespace Contabilidad.Reporte
{
    partial class CuentasPorCobrar
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_UnidadNegocio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Dolares = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dpickerFin = new System.Windows.Forms.DateTimePicker();
            this.dpickerInicio = new System.Windows.Forms.DateTimePicker();
            this.grd_Documentos = new System.Windows.Forms.DataGridView();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btn_excel = new System.Windows.Forms.Button();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.cbx_anio = new System.Windows.Forms.ComboBox();
            this.cbx_mes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Documentos)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 87;
            this.label3.Text = "Unidad Negocio: ";
            // 
            // cmb_UnidadNegocio
            // 
            this.cmb_UnidadNegocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_UnidadNegocio.FormattingEnabled = true;
            this.cmb_UnidadNegocio.Location = new System.Drawing.Point(124, 63);
            this.cmb_UnidadNegocio.Name = "cmb_UnidadNegocio";
            this.cmb_UnidadNegocio.Size = new System.Drawing.Size(121, 21);
            this.cmb_UnidadNegocio.TabIndex = 86;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 394);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 85;
            this.label4.Text = "Total Soles: ";
            // 
            // txt_Total
            // 
            this.txt_Total.Enabled = false;
            this.txt_Total.Location = new System.Drawing.Point(97, 394);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Total.Size = new System.Drawing.Size(100, 20);
            this.txt_Total.TabIndex = 84;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(215, 394);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 13);
            this.label13.TabIndex = 83;
            this.label13.Text = "Total Dólares: ";
            // 
            // txt_Dolares
            // 
            this.txt_Dolares.Enabled = false;
            this.txt_Dolares.Location = new System.Drawing.Point(312, 394);
            this.txt_Dolares.Name = "txt_Dolares";
            this.txt_Dolares.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Dolares.Size = new System.Drawing.Size(100, 20);
            this.txt_Dolares.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(436, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 79;
            this.label2.Text = "Periodo : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(251, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "Ejercicio : ";
            // 
            // dpickerFin
            // 
            this.dpickerFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpickerFin.Location = new System.Drawing.Point(756, 53);
            this.dpickerFin.Name = "dpickerFin";
            this.dpickerFin.Size = new System.Drawing.Size(100, 20);
            this.dpickerFin.TabIndex = 77;
            this.dpickerFin.Visible = false;
            // 
            // dpickerInicio
            // 
            this.dpickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpickerInicio.Location = new System.Drawing.Point(756, 27);
            this.dpickerInicio.Name = "dpickerInicio";
            this.dpickerInicio.Size = new System.Drawing.Size(100, 20);
            this.dpickerInicio.TabIndex = 76;
            this.dpickerInicio.Visible = false;
            // 
            // grd_Documentos
            // 
            this.grd_Documentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_Documentos.Location = new System.Drawing.Point(12, 93);
            this.grd_Documentos.Name = "grd_Documentos";
            this.grd_Documentos.ReadOnly = true;
            this.grd_Documentos.Size = new System.Drawing.Size(859, 275);
            this.grd_Documentos.TabIndex = 73;
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Image = global::Contabilidad.Properties.Resources.close;
            this.btn_Cerrar.Location = new System.Drawing.Point(822, 379);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(49, 43);
            this.btn_Cerrar.TabIndex = 81;
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Image = global::Contabilidad.Properties.Resources.lupa;
            this.btn_Buscar.Location = new System.Drawing.Point(627, 46);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(57, 38);
            this.btn_Buscar.TabIndex = 80;
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_excel
            // 
            this.btn_excel.Image = global::Contabilidad.Properties.Resources.excel1;
            this.btn_excel.Location = new System.Drawing.Point(509, 9);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(51, 43);
            this.btn_excel.TabIndex = 75;
            this.btn_excel.UseVisualStyleBackColor = true;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Image = global::Contabilidad.Properties.Resources.print1;
            this.btn_imprimir.Location = new System.Drawing.Point(277, 9);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(54, 44);
            this.btn_imprimir.TabIndex = 74;
            this.btn_imprimir.UseVisualStyleBackColor = true;
            // 
            // cbx_anio
            // 
            this.cbx_anio.FormattingEnabled = true;
            this.cbx_anio.Location = new System.Drawing.Point(309, 63);
            this.cbx_anio.Name = "cbx_anio";
            this.cbx_anio.Size = new System.Drawing.Size(121, 21);
            this.cbx_anio.TabIndex = 88;
            // 
            // cbx_mes
            // 
            this.cbx_mes.FormattingEnabled = true;
            this.cbx_mes.Location = new System.Drawing.Point(494, 63);
            this.cbx_mes.Name = "cbx_mes";
            this.cbx_mes.Size = new System.Drawing.Size(121, 21);
            this.cbx_mes.TabIndex = 89;
            // 
            // CuentasPorCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 460);
            this.Controls.Add(this.cbx_mes);
            this.Controls.Add(this.cbx_anio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_UnidadNegocio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Total);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt_Dolares);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dpickerFin);
            this.Controls.Add(this.dpickerInicio);
            this.Controls.Add(this.btn_excel);
            this.Controls.Add(this.btn_imprimir);
            this.Controls.Add(this.grd_Documentos);
            this.Name = "CuentasPorCobrar";
            this.Text = "CuentasPorCobrar";
            ((System.ComponentModel.ISupportInitialize)(this.grd_Documentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_UnidadNegocio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_Dolares;
        private System.Windows.Forms.Button btn_Cerrar;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpickerFin;
        private System.Windows.Forms.DateTimePicker dpickerInicio;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.DataGridView grd_Documentos;
        private System.Windows.Forms.ComboBox cbx_anio;
        private System.Windows.Forms.ComboBox cbx_mes;
    }
}