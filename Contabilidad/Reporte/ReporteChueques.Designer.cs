﻿namespace Contabilidad.Reporte
{
    partial class ReporteChueques
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
            this.txt_Dolares = new System.Windows.Forms.TextBox();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btn_excel = new System.Windows.Forms.Button();
            this.grd_Voucher = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dpickerFin = new System.Windows.Forms.DateTimePicker();
            this.dpickerInicio = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Voucher)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(529, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 154;
            this.label3.Text = "Total Soles:";
            // 
            // txt_Dolares
            // 
            this.txt_Dolares.Enabled = false;
            this.txt_Dolares.Location = new System.Drawing.Point(849, 423);
            this.txt_Dolares.Name = "txt_Dolares";
            this.txt_Dolares.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Dolares.Size = new System.Drawing.Size(100, 20);
            this.txt_Dolares.TabIndex = 153;
            // 
            // txt_Total
            // 
            this.txt_Total.Enabled = false;
            this.txt_Total.Location = new System.Drawing.Point(616, 423);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Total.Size = new System.Drawing.Size(100, 20);
            this.txt_Total.TabIndex = 152;
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Image = global::Contabilidad.Properties.Resources.close;
            this.btn_Cerrar.Location = new System.Drawing.Point(891, 463);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(49, 43);
            this.btn_Cerrar.TabIndex = 151;
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Image = global::Contabilidad.Properties.Resources.lupa;
            this.btn_Buscar.Location = new System.Drawing.Point(849, 42);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(57, 38);
            this.btn_Buscar.TabIndex = 150;
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_excel
            // 
            this.btn_excel.Image = global::Contabilidad.Properties.Resources.excel1;
            this.btn_excel.Location = new System.Drawing.Point(468, 4);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(51, 43);
            this.btn_excel.TabIndex = 149;
            this.btn_excel.UseVisualStyleBackColor = true;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // grd_Voucher
            // 
            this.grd_Voucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_Voucher.Location = new System.Drawing.Point(32, 91);
            this.grd_Voucher.Name = "grd_Voucher";
            this.grd_Voucher.ReadOnly = true;
            this.grd_Voucher.Size = new System.Drawing.Size(988, 326);
            this.grd_Voucher.TabIndex = 148;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(584, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 147;
            this.label2.Text = "Hasta : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(173, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 146;
            this.label1.Text = "Desde : ";
            // 
            // dpickerFin
            // 
            this.dpickerFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpickerFin.Location = new System.Drawing.Point(665, 54);
            this.dpickerFin.Name = "dpickerFin";
            this.dpickerFin.Size = new System.Drawing.Size(100, 20);
            this.dpickerFin.TabIndex = 145;
            // 
            // dpickerInicio
            // 
            this.dpickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpickerInicio.Location = new System.Drawing.Point(252, 54);
            this.dpickerInicio.Name = "dpickerInicio";
            this.dpickerInicio.Size = new System.Drawing.Size(100, 20);
            this.dpickerInicio.TabIndex = 144;
            // 
            // ReporteChueques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 511);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Dolares);
            this.Controls.Add(this.txt_Total);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.btn_excel);
            this.Controls.Add(this.grd_Voucher);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dpickerFin);
            this.Controls.Add(this.dpickerInicio);
            this.Name = "ReporteChueques";
            this.Text = "ReporteChueques";
            ((System.ComponentModel.ISupportInitialize)(this.grd_Voucher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Dolares;
        private System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.Button btn_Cerrar;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.DataGridView grd_Voucher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpickerFin;
        private System.Windows.Forms.DateTimePicker dpickerInicio;
    }
}