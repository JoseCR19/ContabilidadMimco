namespace Conta.RegistroVentas
{
    partial class LibroVentas
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
            this.components = new System.ComponentModel.Container();
            this.cmb_Mes = new System.Windows.Forms.ComboBox();
            this.lbl_anho = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grd_Ventas = new System.Windows.Forms.DataGridView();
            this.btn_Cargar = new System.Windows.Forms.Button();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.btn_Txt = new System.Windows.Forms.Button();
            this.btn_Reporte = new System.Windows.Forms.Button();
            this.btn_excel = new System.Windows.Forms.Button();
            this.dataSet1 = new Contabilidad.DataSet.DataSet1();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Ventas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_Mes
            // 
            this.cmb_Mes.FormattingEnabled = true;
            this.cmb_Mes.Location = new System.Drawing.Point(78, 32);
            this.cmb_Mes.Name = "cmb_Mes";
            this.cmb_Mes.Size = new System.Drawing.Size(135, 21);
            this.cmb_Mes.TabIndex = 0;
            this.cmb_Mes.SelectedIndexChanged += new System.EventHandler(this.cmb_Mes_SelectedIndexChanged);
            // 
            // lbl_anho
            // 
            this.lbl_anho.AutoSize = true;
            this.lbl_anho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_anho.Location = new System.Drawing.Point(237, 33);
            this.lbl_anho.Name = "lbl_anho";
            this.lbl_anho.Size = new System.Drawing.Size(39, 20);
            this.lbl_anho.TabIndex = 1;
            this.lbl_anho.Text = "año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mes :";
            // 
            // grd_Ventas
            // 
            this.grd_Ventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_Ventas.Location = new System.Drawing.Point(10, 77);
            this.grd_Ventas.Name = "grd_Ventas";
            this.grd_Ventas.ReadOnly = true;
            this.grd_Ventas.Size = new System.Drawing.Size(990, 264);
            this.grd_Ventas.TabIndex = 4;
            this.grd_Ventas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_Ventas_CellContentClick);
            // 
            // btn_Cargar
            // 
            this.btn_Cargar.Location = new System.Drawing.Point(314, 32);
            this.btn_Cargar.Name = "btn_Cargar";
            this.btn_Cargar.Size = new System.Drawing.Size(75, 23);
            this.btn_Cargar.TabIndex = 5;
            this.btn_Cargar.Text = "Cargar";
            this.btn_Cargar.UseVisualStyleBackColor = true;
            this.btn_Cargar.Click += new System.EventHandler(this.btn_Cargar_Click);
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Image = global::Contabilidad.Properties.Resources.close;
            this.btn_Cerrar.Location = new System.Drawing.Point(951, 356);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(49, 43);
            this.btn_Cerrar.TabIndex = 50;
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // btn_Txt
            // 
            this.btn_Txt.Image = global::Contabilidad.Properties.Resources.txt2;
            this.btn_Txt.Location = new System.Drawing.Point(796, 12);
            this.btn_Txt.Name = "btn_Txt";
            this.btn_Txt.Size = new System.Drawing.Size(43, 43);
            this.btn_Txt.TabIndex = 49;
            this.btn_Txt.UseVisualStyleBackColor = true;
            this.btn_Txt.Click += new System.EventHandler(this.btn_Txt_Click);
            // 
            // btn_Reporte
            // 
            this.btn_Reporte.Image = global::Contabilidad.Properties.Resources.report;
            this.btn_Reporte.Location = new System.Drawing.Point(672, 12);
            this.btn_Reporte.Name = "btn_Reporte";
            this.btn_Reporte.Size = new System.Drawing.Size(43, 43);
            this.btn_Reporte.TabIndex = 48;
            this.btn_Reporte.UseVisualStyleBackColor = true;
            this.btn_Reporte.Click += new System.EventHandler(this.btn_Reporte_Click);
            // 
            // btn_excel
            // 
            this.btn_excel.Image = global::Contabilidad.Properties.Resources.excel1;
            this.btn_excel.Location = new System.Drawing.Point(535, 12);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(51, 43);
            this.btn_excel.TabIndex = 31;
            this.btn_excel.UseVisualStyleBackColor = true;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSet1BindingSource
            // 
            this.dataSet1BindingSource.DataSource = this.dataSet1;
            this.dataSet1BindingSource.Position = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(419, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 51;
            this.button1.Text = "Soles\r\n";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(419, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 52;
            this.button2.Text = "Dolares\r\n";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LibroVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 411);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.btn_Txt);
            this.Controls.Add(this.btn_Reporte);
            this.Controls.Add(this.btn_excel);
            this.Controls.Add(this.btn_Cargar);
            this.Controls.Add(this.grd_Ventas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_anho);
            this.Controls.Add(this.cmb_Mes);
            this.Name = "LibroVentas";
            this.Text = "LibroVentas";
            this.Load += new System.EventHandler(this.LibroVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd_Ventas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Mes;
        private System.Windows.Forms.Label lbl_anho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grd_Ventas;
        private System.Windows.Forms.Button btn_Cargar;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.Button btn_Reporte;
        private System.Windows.Forms.Button btn_Txt;
        private System.Windows.Forms.Button btn_Cerrar;
        private Contabilidad.DataSet.DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}