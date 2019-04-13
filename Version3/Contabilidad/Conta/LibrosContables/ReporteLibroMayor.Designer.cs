namespace Conta.LibrosContables
{
    partial class ReporteLibroMayor
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
            this.grd_Ventas = new System.Windows.Forms.DataGridView();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.btn_Txt = new System.Windows.Forms.Button();
            this.btn_Reporte = new System.Windows.Forms.Button();
            this.btn_excel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Ventas)).BeginInit();
            this.SuspendLayout();
            // 
            // grd_Ventas
            // 
            this.grd_Ventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_Ventas.Location = new System.Drawing.Point(11, 77);
            this.grd_Ventas.Name = "grd_Ventas";
            this.grd_Ventas.ReadOnly = true;
            this.grd_Ventas.Size = new System.Drawing.Size(990, 264);
            this.grd_Ventas.TabIndex = 56;
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Image = global::Contabilidad.Properties.Resources.close;
            this.btn_Cerrar.Location = new System.Drawing.Point(952, 356);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(49, 43);
            this.btn_Cerrar.TabIndex = 60;
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // btn_Txt
            // 
            this.btn_Txt.Image = global::Contabilidad.Properties.Resources.txt2;
            this.btn_Txt.Location = new System.Drawing.Point(652, 12);
            this.btn_Txt.Name = "btn_Txt";
            this.btn_Txt.Size = new System.Drawing.Size(43, 43);
            this.btn_Txt.TabIndex = 59;
            this.btn_Txt.UseVisualStyleBackColor = true;
            // 
            // btn_Reporte
            // 
            this.btn_Reporte.Image = global::Contabilidad.Properties.Resources.report;
            this.btn_Reporte.Location = new System.Drawing.Point(528, 12);
            this.btn_Reporte.Name = "btn_Reporte";
            this.btn_Reporte.Size = new System.Drawing.Size(43, 43);
            this.btn_Reporte.TabIndex = 58;
            this.btn_Reporte.UseVisualStyleBackColor = true;
            this.btn_Reporte.Click += new System.EventHandler(this.btn_Reporte_Click);
            // 
            // btn_excel
            // 
            this.btn_excel.Image = global::Contabilidad.Properties.Resources.excel1;
            this.btn_excel.Location = new System.Drawing.Point(391, 12);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(51, 43);
            this.btn_excel.TabIndex = 57;
            this.btn_excel.UseVisualStyleBackColor = true;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // ReporteLibroMayor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 411);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.btn_Txt);
            this.Controls.Add(this.btn_Reporte);
            this.Controls.Add(this.btn_excel);
            this.Controls.Add(this.grd_Ventas);
            this.Name = "ReporteLibroMayor";
            this.Text = "ReporteLibroMayor";
            ((System.ComponentModel.ISupportInitialize)(this.grd_Ventas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Cerrar;
        private System.Windows.Forms.Button btn_Txt;
        private System.Windows.Forms.Button btn_Reporte;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.DataGridView grd_Ventas;
    }
}