namespace Contabilidad.Reporte
{
    partial class ReporteDiario
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
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dpickerFin = new System.Windows.Forms.DateTimePicker();
            this.dpickerInicio = new System.Windows.Forms.DateTimePicker();
            this.grd_Voucher = new System.Windows.Forms.DataGridView();
            this.btn_Reporte = new System.Windows.Forms.Button();
            this.btn_Regresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Voucher)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Image = global::Contabilidad.Properties.Resources.lupa;
            this.btn_Buscar.Location = new System.Drawing.Point(865, 74);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(57, 38);
            this.btn_Buscar.TabIndex = 143;
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(600, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 142;
            this.label2.Text = "Hasta : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(189, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 141;
            this.label1.Text = "Desde : ";
            // 
            // dpickerFin
            // 
            this.dpickerFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpickerFin.Location = new System.Drawing.Point(681, 86);
            this.dpickerFin.Name = "dpickerFin";
            this.dpickerFin.Size = new System.Drawing.Size(100, 20);
            this.dpickerFin.TabIndex = 140;
            // 
            // dpickerInicio
            // 
            this.dpickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpickerInicio.Location = new System.Drawing.Point(268, 86);
            this.dpickerInicio.Name = "dpickerInicio";
            this.dpickerInicio.Size = new System.Drawing.Size(100, 20);
            this.dpickerInicio.TabIndex = 139;
            // 
            // grd_Voucher
            // 
            this.grd_Voucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_Voucher.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grd_Voucher.Location = new System.Drawing.Point(29, 131);
            this.grd_Voucher.Name = "grd_Voucher";
            this.grd_Voucher.RowHeadersVisible = false;
            this.grd_Voucher.Size = new System.Drawing.Size(1236, 326);
            this.grd_Voucher.TabIndex = 144;
            this.grd_Voucher.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_Voucher_CellContentClick);
            this.grd_Voucher.CurrentCellDirtyStateChanged += new System.EventHandler(this.grd_Voucher_CurrentCellDirtyStateChanged);
            // 
            // btn_Reporte
            // 
            this.btn_Reporte.Image = global::Contabilidad.Properties.Resources.report;
            this.btn_Reporte.Location = new System.Drawing.Point(483, 12);
            this.btn_Reporte.Name = "btn_Reporte";
            this.btn_Reporte.Size = new System.Drawing.Size(43, 43);
            this.btn_Reporte.TabIndex = 154;
            this.btn_Reporte.UseVisualStyleBackColor = true;
            this.btn_Reporte.Click += new System.EventHandler(this.btn_Reporte_Click);
            // 
            // btn_Regresar
            // 
            this.btn_Regresar.Image = global::Contabilidad.Properties.Resources.close;
            this.btn_Regresar.Location = new System.Drawing.Point(1203, 463);
            this.btn_Regresar.Name = "btn_Regresar";
            this.btn_Regresar.Size = new System.Drawing.Size(62, 46);
            this.btn_Regresar.TabIndex = 155;
            this.btn_Regresar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Regresar.UseVisualStyleBackColor = true;
            this.btn_Regresar.Click += new System.EventHandler(this.btn_Regresar_Click);
            // 
            // ReporteDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 520);
            this.Controls.Add(this.btn_Regresar);
            this.Controls.Add(this.btn_Reporte);
            this.Controls.Add(this.grd_Voucher);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dpickerFin);
            this.Controls.Add(this.dpickerInicio);
            this.Name = "ReporteDiario";
            this.Text = "ReporteDiario";
            this.Load += new System.EventHandler(this.ReporteDiario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd_Voucher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpickerFin;
        private System.Windows.Forms.DateTimePicker dpickerInicio;
        private System.Windows.Forms.DataGridView grd_Voucher;
        private System.Windows.Forms.Button btn_Reporte;
        private System.Windows.Forms.Button btn_Regresar;
    }
}