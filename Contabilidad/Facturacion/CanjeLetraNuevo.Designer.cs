namespace Contabilidad.Facturacion
{
    partial class CanjeLetraNuevo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CanjeLetraNuevo));
            this.btn_Modificar = new System.Windows.Forms.Button();
            this.txt_NumeroDcto = new System.Windows.Forms.TextBox();
            this.txt_SerieDcto = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dpick_Fecha = new System.Windows.Forms.DateTimePicker();
            this.dpck_Fechavcto = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_Moneda = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_Tcambio = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.dtp_compromiso = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_Direccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Cliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.txt_Ruc = new System.Windows.Forms.TextBox();
            this.grd_facturas = new System.Windows.Forms.DataGridView();
            this.txt_CodMoneda = new System.Windows.Forms.TextBox();
            this.txt_nroregletra = new System.Windows.Forms.TextBox();
            this.txt_fechavctodcto = new System.Windows.Forms.TextBox();
            this.txt_AvalCod = new System.Windows.Forms.TextBox();
            this.txt_codcliente = new System.Windows.Forms.TextBox();
            this.txt_Abono = new System.Windows.Forms.TextBox();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.btn_Regresar = new System.Windows.Forms.Button();
            this.btn_SaveData = new System.Windows.Forms.Button();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.btn_Rest = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_tipodoc = new System.Windows.Forms.TextBox();
            this.btn_Anular = new System.Windows.Forms.Button();
            this.btn_Reporte = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_facturas)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Modificar
            // 
            this.btn_Modificar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Modificar.Location = new System.Drawing.Point(499, 28);
            this.btn_Modificar.Name = "btn_Modificar";
            this.btn_Modificar.Size = new System.Drawing.Size(90, 23);
            this.btn_Modificar.TabIndex = 84;
            this.btn_Modificar.Text = "EDITAR";
            this.btn_Modificar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Modificar.UseVisualStyleBackColor = true;
            this.btn_Modificar.Visible = false;
            this.btn_Modificar.Click += new System.EventHandler(this.btn_Modificar_Click);
            // 
            // txt_NumeroDcto
            // 
            this.txt_NumeroDcto.Location = new System.Drawing.Point(798, 34);
            this.txt_NumeroDcto.Name = "txt_NumeroDcto";
            this.txt_NumeroDcto.Size = new System.Drawing.Size(153, 20);
            this.txt_NumeroDcto.TabIndex = 67;
            // 
            // txt_SerieDcto
            // 
            this.txt_SerieDcto.Enabled = false;
            this.txt_SerieDcto.Location = new System.Drawing.Point(736, 34);
            this.txt_SerieDcto.Name = "txt_SerieDcto";
            this.txt_SerieDcto.Size = new System.Drawing.Size(41, 20);
            this.txt_SerieDcto.TabIndex = 66;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(733, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 13);
            this.label18.TabIndex = 65;
            this.label18.Text = "Serie :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(155, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Fecha Giro:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(317, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "Fecha Vecto:";
            // 
            // dpick_Fecha
            // 
            this.dpick_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpick_Fecha.Location = new System.Drawing.Point(230, 9);
            this.dpick_Fecha.Name = "dpick_Fecha";
            this.dpick_Fecha.Size = new System.Drawing.Size(81, 20);
            this.dpick_Fecha.TabIndex = 47;
            // 
            // dpck_Fechavcto
            // 
            this.dpck_Fechavcto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpck_Fechavcto.Location = new System.Drawing.Point(408, 9);
            this.dpck_Fechavcto.Name = "dpck_Fechavcto";
            this.dpck_Fechavcto.Size = new System.Drawing.Size(81, 20);
            this.dpck_Fechavcto.TabIndex = 48;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmb_Moneda);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.txt_Direccion);
            this.panel1.Controls.Add(this.txt_NumeroDcto);
            this.panel1.Controls.Add(this.txt_SerieDcto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.txt_Cliente);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_Buscar);
            this.panel1.Controls.Add(this.txt_Ruc);
            this.panel1.Location = new System.Drawing.Point(43, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(963, 122);
            this.panel1.TabIndex = 85;
            // 
            // cmb_Moneda
            // 
            this.cmb_Moneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Moneda.FormattingEnabled = true;
            this.cmb_Moneda.Location = new System.Drawing.Point(94, 90);
            this.cmb_Moneda.Name = "cmb_Moneda";
            this.cmb_Moneda.Size = new System.Drawing.Size(133, 21);
            this.cmb_Moneda.TabIndex = 110;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txt_Tcambio);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.dtp_compromiso);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.dpck_Fechavcto);
            this.panel3.Controls.Add(this.dpick_Fecha);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(233, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(718, 46);
            this.panel3.TabIndex = 109;
            // 
            // txt_Tcambio
            // 
            this.txt_Tcambio.Enabled = false;
            this.txt_Tcambio.Location = new System.Drawing.Point(80, 9);
            this.txt_Tcambio.Name = "txt_Tcambio";
            this.txt_Tcambio.Size = new System.Drawing.Size(54, 20);
            this.txt_Tcambio.TabIndex = 52;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(4, 13);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(72, 13);
            this.label23.TabIndex = 51;
            this.label23.Text = "T. Cambio :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(504, 12);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(74, 13);
            this.label22.TabIndex = 49;
            this.label22.Text = "Fecha Cmp:";
            // 
            // dtp_compromiso
            // 
            this.dtp_compromiso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_compromiso.Location = new System.Drawing.Point(595, 9);
            this.dtp_compromiso.Name = "dtp_compromiso";
            this.dtp_compromiso.Size = new System.Drawing.Size(81, 20);
            this.dtp_compromiso.TabIndex = 50;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(8, 67);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 13);
            this.label21.TabIndex = 70;
            this.label21.Text = "RUC :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(8, 93);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(60, 13);
            this.label20.TabIndex = 69;
            this.label20.Text = "Moneda :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(795, 14);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(97, 13);
            this.label19.TabIndex = 68;
            this.label19.Text = "Nr° Documento:";
            // 
            // txt_Direccion
            // 
            this.txt_Direccion.Enabled = false;
            this.txt_Direccion.Location = new System.Drawing.Point(94, 34);
            this.txt_Direccion.Name = "txt_Direccion";
            this.txt_Direccion.Size = new System.Drawing.Size(546, 20);
            this.txt_Direccion.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Proveedor : ";
            // 
            // txt_Cliente
            // 
            this.txt_Cliente.Enabled = false;
            this.txt_Cliente.Location = new System.Drawing.Point(94, 11);
            this.txt_Cliente.Name = "txt_Cliente";
            this.txt_Cliente.Size = new System.Drawing.Size(546, 20);
            this.txt_Cliente.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Dirección :";
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Buscar.Image")));
            this.btn_Buscar.Location = new System.Drawing.Point(652, 6);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(75, 48);
            this.btn_Buscar.TabIndex = 35;
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // txt_Ruc
            // 
            this.txt_Ruc.Enabled = false;
            this.txt_Ruc.Location = new System.Drawing.Point(94, 60);
            this.txt_Ruc.Name = "txt_Ruc";
            this.txt_Ruc.Size = new System.Drawing.Size(133, 20);
            this.txt_Ruc.TabIndex = 36;
            // 
            // grd_facturas
            // 
            this.grd_facturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_facturas.Location = new System.Drawing.Point(42, 239);
            this.grd_facturas.Name = "grd_facturas";
            this.grd_facturas.Size = new System.Drawing.Size(963, 249);
            this.grd_facturas.TabIndex = 97;
            this.grd_facturas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_facturas_CellClick);
            this.grd_facturas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_facturas_CellEndEdit);
            this.grd_facturas.Click += new System.EventHandler(this.grd_facturas_Click);
            // 
            // txt_CodMoneda
            // 
            this.txt_CodMoneda.Location = new System.Drawing.Point(42, 548);
            this.txt_CodMoneda.Name = "txt_CodMoneda";
            this.txt_CodMoneda.Size = new System.Drawing.Size(100, 20);
            this.txt_CodMoneda.TabIndex = 108;
            this.txt_CodMoneda.Visible = false;
            // 
            // txt_nroregletra
            // 
            this.txt_nroregletra.Location = new System.Drawing.Point(42, 496);
            this.txt_nroregletra.Name = "txt_nroregletra";
            this.txt_nroregletra.Size = new System.Drawing.Size(100, 20);
            this.txt_nroregletra.TabIndex = 107;
            this.txt_nroregletra.Visible = false;
            // 
            // txt_fechavctodcto
            // 
            this.txt_fechavctodcto.Location = new System.Drawing.Point(148, 496);
            this.txt_fechavctodcto.Name = "txt_fechavctodcto";
            this.txt_fechavctodcto.Size = new System.Drawing.Size(100, 20);
            this.txt_fechavctodcto.TabIndex = 106;
            this.txt_fechavctodcto.Visible = false;
            // 
            // txt_AvalCod
            // 
            this.txt_AvalCod.Location = new System.Drawing.Point(148, 522);
            this.txt_AvalCod.Name = "txt_AvalCod";
            this.txt_AvalCod.Size = new System.Drawing.Size(100, 20);
            this.txt_AvalCod.TabIndex = 105;
            this.txt_AvalCod.Visible = false;
            // 
            // txt_codcliente
            // 
            this.txt_codcliente.Location = new System.Drawing.Point(42, 522);
            this.txt_codcliente.Name = "txt_codcliente";
            this.txt_codcliente.Size = new System.Drawing.Size(100, 20);
            this.txt_codcliente.TabIndex = 104;
            this.txt_codcliente.Visible = false;
            // 
            // txt_Abono
            // 
            this.txt_Abono.Enabled = false;
            this.txt_Abono.Location = new System.Drawing.Point(898, 507);
            this.txt_Abono.Name = "txt_Abono";
            this.txt_Abono.Size = new System.Drawing.Size(108, 20);
            this.txt_Abono.TabIndex = 102;
            // 
            // txt_Total
            // 
            this.txt_Total.Enabled = false;
            this.txt_Total.Location = new System.Drawing.Point(782, 507);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.Size = new System.Drawing.Size(100, 20);
            this.txt_Total.TabIndex = 101;
            // 
            // btn_Regresar
            // 
            this.btn_Regresar.Image = global::Contabilidad.Properties.Resources.close;
            this.btn_Regresar.Location = new System.Drawing.Point(615, 522);
            this.btn_Regresar.Name = "btn_Regresar";
            this.btn_Regresar.Size = new System.Drawing.Size(62, 46);
            this.btn_Regresar.TabIndex = 100;
            this.btn_Regresar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Regresar.UseVisualStyleBackColor = true;
            this.btn_Regresar.Click += new System.EventHandler(this.btn_Regresar_Click);
            // 
            // btn_SaveData
            // 
            this.btn_SaveData.Image = global::Contabilidad.Properties.Resources.saveopt;
            this.btn_SaveData.Location = new System.Drawing.Point(363, 522);
            this.btn_SaveData.Name = "btn_SaveData";
            this.btn_SaveData.Size = new System.Drawing.Size(48, 46);
            this.btn_SaveData.TabIndex = 99;
            this.btn_SaveData.UseVisualStyleBackColor = true;
            this.btn_SaveData.Click += new System.EventHandler(this.btn_SaveData_Click);
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Image = global::Contabilidad.Properties.Resources.undocolor;
            this.btn_Limpiar.Location = new System.Drawing.Point(491, 522);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(48, 46);
            this.btn_Limpiar.TabIndex = 98;
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Image = global::Contabilidad.Properties.Resources.agregar;
            this.btn_Add.Location = new System.Drawing.Point(912, 194);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(41, 37);
            this.btn_Add.TabIndex = 95;
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(781, 206);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 13);
            this.label16.TabIndex = 91;
            this.label16.Text = "Agregar Facturas :";
            // 
            // btn_Rest
            // 
            this.btn_Rest.Enabled = false;
            this.btn_Rest.Image = global::Contabilidad.Properties.Resources.minus;
            this.btn_Rest.Location = new System.Drawing.Point(964, 194);
            this.btn_Rest.Name = "btn_Rest";
            this.btn_Rest.Size = new System.Drawing.Size(41, 37);
            this.btn_Rest.TabIndex = 148;
            this.btn_Rest.UseVisualStyleBackColor = true;
            this.btn_Rest.Click += new System.EventHandler(this.btn_Rest_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(777, 491);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 149;
            this.label3.Text = "Total Importe :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(895, 491);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 150;
            this.label4.Text = "Total Abono :";
            // 
            // txt_tipodoc
            // 
            this.txt_tipodoc.Enabled = false;
            this.txt_tipodoc.Location = new System.Drawing.Point(148, 548);
            this.txt_tipodoc.Name = "txt_tipodoc";
            this.txt_tipodoc.Size = new System.Drawing.Size(100, 20);
            this.txt_tipodoc.TabIndex = 151;
            this.txt_tipodoc.Visible = false;
            // 
            // btn_Anular
            // 
            this.btn_Anular.Location = new System.Drawing.Point(381, 28);
            this.btn_Anular.Name = "btn_Anular";
            this.btn_Anular.Size = new System.Drawing.Size(90, 23);
            this.btn_Anular.TabIndex = 152;
            this.btn_Anular.Text = "Anular";
            this.btn_Anular.UseVisualStyleBackColor = true;
            this.btn_Anular.Click += new System.EventHandler(this.btn_Anular_Click);
            // 
            // btn_Reporte
            // 
            this.btn_Reporte.Image = global::Contabilidad.Properties.Resources.report;
            this.btn_Reporte.Location = new System.Drawing.Point(615, 17);
            this.btn_Reporte.Name = "btn_Reporte";
            this.btn_Reporte.Size = new System.Drawing.Size(43, 43);
            this.btn_Reporte.TabIndex = 153;
            this.btn_Reporte.UseVisualStyleBackColor = true;
            this.btn_Reporte.Click += new System.EventHandler(this.btn_Reporte_Click);
            // 
            // CanjeLetraNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 585);
            this.Controls.Add(this.btn_Reporte);
            this.Controls.Add(this.btn_Anular);
            this.Controls.Add(this.txt_tipodoc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Rest);
            this.Controls.Add(this.txt_CodMoneda);
            this.Controls.Add(this.txt_nroregletra);
            this.Controls.Add(this.txt_fechavctodcto);
            this.Controls.Add(this.txt_AvalCod);
            this.Controls.Add(this.txt_codcliente);
            this.Controls.Add(this.txt_Abono);
            this.Controls.Add(this.txt_Total);
            this.Controls.Add(this.btn_Regresar);
            this.Controls.Add(this.btn_SaveData);
            this.Controls.Add(this.btn_Limpiar);
            this.Controls.Add(this.grd_facturas);
            this.Controls.Add(this.btn_Modificar);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.panel1);
            this.Name = "CanjeLetraNuevo";
            this.Text = "CanjeLetraNuevo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_facturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Modificar;
        private System.Windows.Forms.TextBox txt_NumeroDcto;
        private System.Windows.Forms.TextBox txt_SerieDcto;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dpick_Fecha;
        private System.Windows.Forms.DateTimePicker dpck_Fechavcto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_Direccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Cliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.TextBox txt_Ruc;
        private System.Windows.Forms.DataGridView grd_facturas;
        private System.Windows.Forms.TextBox txt_CodMoneda;
        private System.Windows.Forms.TextBox txt_nroregletra;
        private System.Windows.Forms.TextBox txt_fechavctodcto;
        private System.Windows.Forms.TextBox txt_AvalCod;
        private System.Windows.Forms.TextBox txt_codcliente;
        private System.Windows.Forms.TextBox txt_Abono;
        private System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.Button btn_Regresar;
        private System.Windows.Forms.Button btn_SaveData;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.ComboBox cmb_Moneda;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_Tcambio;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dtp_compromiso;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btn_Rest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_tipodoc;
        private System.Windows.Forms.Button btn_Anular;
        private System.Windows.Forms.Button btn_Reporte;
    }
}