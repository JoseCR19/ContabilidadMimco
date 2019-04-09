namespace Contabilidad.Caja
{
    partial class EmisionVoucher
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
            this.grd_VoucherDet = new System.Windows.Forms.DataGridView();
            this.txt_NroVoucher = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Banco = new System.Windows.Forms.TextBox();
            this.txt_BancoCod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_NroCuenta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dpick_FechaEmision = new System.Windows.Forms.DateTimePicker();
            this.cmb_Moneda = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_NroCheque = new System.Windows.Forms.TextBox();
            this.lbl_Cheque = new System.Windows.Forms.Label();
            this.lbl_orden = new System.Windows.Forms.Label();
            this.cmb_TipoSolicitante = new System.Windows.Forms.ComboBox();
            this.txt_Solicitante = new System.Windows.Forms.TextBox();
            this.txt_SolicitanteCod = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dpick_FechaPago = new System.Windows.Forms.DateTimePicker();
            this.txt_TipoCambio = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_periodo = new System.Windows.Forms.ComboBox();
            this.cmb_ejercicio2 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_MontoTotal = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmb_Operacion = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_Observacion = new System.Windows.Forms.TextBox();
            this.txt_MovCod = new System.Windows.Forms.TextBox();
            this.txt_Movimiento = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_Modificar = new System.Windows.Forms.Button();
            this.txt_codot = new System.Windows.Forms.TextBox();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_CuentaContable = new System.Windows.Forms.TextBox();
            this.txt_NumReg = new System.Windows.Forms.TextBox();
            this.txt_TotalDocumento = new System.Windows.Forms.TextBox();
            this.btn_Reporte = new System.Windows.Forms.Button();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.btn_SaveData = new System.Windows.Forms.Button();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Regresar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_NroOt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Descripcion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_NroDoc = new System.Windows.Forms.TextBox();
            this.txt_RazonSocial = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Importe = new System.Windows.Forms.TextBox();
            this.rb_Metales = new System.Windows.Forms.RadioButton();
            this.rb_Galvanizado = new System.Windows.Forms.RadioButton();
            this.btn_Rest = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_30 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grd_VoucherDet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grd_VoucherDet
            // 
            this.grd_VoucherDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_VoucherDet.Location = new System.Drawing.Point(16, 335);
            this.grd_VoucherDet.Name = "grd_VoucherDet";
            this.grd_VoucherDet.ReadOnly = true;
            this.grd_VoucherDet.RowHeadersVisible = false;
            this.grd_VoucherDet.Size = new System.Drawing.Size(782, 230);
            this.grd_VoucherDet.TabIndex = 85;
            this.grd_VoucherDet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_VoucherDet_CellContentClick);
            this.grd_VoucherDet.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_VoucherDet_CellEndEdit);
            this.grd_VoucherDet.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grd_VoucherDet_DataError);
            this.grd_VoucherDet.Click += new System.EventHandler(this.grd_VoucherDet_Click);
            // 
            // txt_NroVoucher
            // 
            this.txt_NroVoucher.Enabled = false;
            this.txt_NroVoucher.Location = new System.Drawing.Point(86, 11);
            this.txt_NroVoucher.Name = "txt_NroVoucher";
            this.txt_NroVoucher.Size = new System.Drawing.Size(99, 20);
            this.txt_NroVoucher.TabIndex = 90;
            this.txt_NroVoucher.TextChanged += new System.EventHandler(this.txt_NroVoucher_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 89;
            this.label3.Text = "N° Voucher :";
            // 
            // txt_Banco
            // 
            this.txt_Banco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Banco.Enabled = false;
            this.txt_Banco.Location = new System.Drawing.Point(312, 11);
            this.txt_Banco.Name = "txt_Banco";
            this.txt_Banco.Size = new System.Drawing.Size(226, 20);
            this.txt_Banco.TabIndex = 93;
            // 
            // txt_BancoCod
            // 
            this.txt_BancoCod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_BancoCod.Enabled = false;
            this.txt_BancoCod.Location = new System.Drawing.Point(259, 11);
            this.txt_BancoCod.Name = "txt_BancoCod";
            this.txt_BancoCod.Size = new System.Drawing.Size(43, 20);
            this.txt_BancoCod.TabIndex = 91;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(202, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 92;
            this.label2.Text = "Banco :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(560, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 94;
            this.label1.Text = "N° Cuenta :";
            // 
            // txt_NroCuenta
            // 
            this.txt_NroCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_NroCuenta.Enabled = false;
            this.txt_NroCuenta.Location = new System.Drawing.Point(641, 11);
            this.txt_NroCuenta.Name = "txt_NroCuenta";
            this.txt_NroCuenta.Size = new System.Drawing.Size(143, 20);
            this.txt_NroCuenta.TabIndex = 95;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(636, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 96;
            this.label4.Text = "F. Emisión :";
            // 
            // dpick_FechaEmision
            // 
            this.dpick_FechaEmision.CustomFormat = "";
            this.dpick_FechaEmision.Enabled = false;
            this.dpick_FechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpick_FechaEmision.Location = new System.Drawing.Point(709, 41);
            this.dpick_FechaEmision.Name = "dpick_FechaEmision";
            this.dpick_FechaEmision.Size = new System.Drawing.Size(82, 20);
            this.dpick_FechaEmision.TabIndex = 97;
            // 
            // cmb_Moneda
            // 
            this.cmb_Moneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Moneda.Enabled = false;
            this.cmb_Moneda.FormattingEnabled = true;
            this.cmb_Moneda.Location = new System.Drawing.Point(537, 41);
            this.cmb_Moneda.Name = "cmb_Moneda";
            this.cmb_Moneda.Size = new System.Drawing.Size(98, 21);
            this.cmb_Moneda.TabIndex = 99;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(475, 45);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 13);
            this.label18.TabIndex = 98;
            this.label18.Text = "Moneda :";
            // 
            // txt_NroCheque
            // 
            this.txt_NroCheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_NroCheque.Enabled = false;
            this.txt_NroCheque.Location = new System.Drawing.Point(258, 40);
            this.txt_NroCheque.Name = "txt_NroCheque";
            this.txt_NroCheque.Size = new System.Drawing.Size(87, 20);
            this.txt_NroCheque.TabIndex = 101;
            // 
            // lbl_Cheque
            // 
            this.lbl_Cheque.AutoSize = true;
            this.lbl_Cheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cheque.Location = new System.Drawing.Point(179, 43);
            this.lbl_Cheque.Name = "lbl_Cheque";
            this.lbl_Cheque.Size = new System.Drawing.Size(76, 13);
            this.lbl_Cheque.TabIndex = 100;
            this.lbl_Cheque.Text = "N° Cheque :";
            // 
            // lbl_orden
            // 
            this.lbl_orden.AutoSize = true;
            this.lbl_orden.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_orden.Location = new System.Drawing.Point(272, 76);
            this.lbl_orden.Name = "lbl_orden";
            this.lbl_orden.Size = new System.Drawing.Size(93, 13);
            this.lbl_orden.TabIndex = 102;
            this.lbl_orden.Text = "A la Orden de :";
            // 
            // cmb_TipoSolicitante
            // 
            this.cmb_TipoSolicitante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TipoSolicitante.Enabled = false;
            this.cmb_TipoSolicitante.FormattingEnabled = true;
            this.cmb_TipoSolicitante.Location = new System.Drawing.Point(371, 72);
            this.cmb_TipoSolicitante.Name = "cmb_TipoSolicitante";
            this.cmb_TipoSolicitante.Size = new System.Drawing.Size(108, 21);
            this.cmb_TipoSolicitante.TabIndex = 103;
            this.cmb_TipoSolicitante.SelectedIndexChanged += new System.EventHandler(this.cmb_TipoSolicitante_SelectedIndexChanged);
            // 
            // txt_Solicitante
            // 
            this.txt_Solicitante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Solicitante.Enabled = false;
            this.txt_Solicitante.Location = new System.Drawing.Point(580, 74);
            this.txt_Solicitante.Name = "txt_Solicitante";
            this.txt_Solicitante.Size = new System.Drawing.Size(212, 20);
            this.txt_Solicitante.TabIndex = 105;
            this.txt_Solicitante.TextChanged += new System.EventHandler(this.txt_Solicitante_TextChanged);
            // 
            // txt_SolicitanteCod
            // 
            this.txt_SolicitanteCod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_SolicitanteCod.Enabled = false;
            this.txt_SolicitanteCod.Location = new System.Drawing.Point(489, 74);
            this.txt_SolicitanteCod.Name = "txt_SolicitanteCod";
            this.txt_SolicitanteCod.Size = new System.Drawing.Size(85, 20);
            this.txt_SolicitanteCod.TabIndex = 104;
            this.txt_SolicitanteCod.TextChanged += new System.EventHandler(this.txt_SolicitanteCod_TextChanged_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 106;
            this.label7.Text = "Fecha Pago :";
            // 
            // dpick_FechaPago
            // 
            this.dpick_FechaPago.CustomFormat = "";
            this.dpick_FechaPago.Enabled = false;
            this.dpick_FechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpick_FechaPago.Location = new System.Drawing.Point(96, 105);
            this.dpick_FechaPago.Name = "dpick_FechaPago";
            this.dpick_FechaPago.Size = new System.Drawing.Size(99, 20);
            this.dpick_FechaPago.TabIndex = 107;
            // 
            // txt_TipoCambio
            // 
            this.txt_TipoCambio.Enabled = false;
            this.txt_TipoCambio.Location = new System.Drawing.Point(260, 106);
            this.txt_TipoCambio.Name = "txt_TipoCambio";
            this.txt_TipoCambio.Size = new System.Drawing.Size(79, 20);
            this.txt_TipoCambio.TabIndex = 109;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(210, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 108;
            this.label12.Text = "T.C. :";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmb_periodo);
            this.panel1.Controls.Add(this.cmb_ejercicio2);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_MontoTotal);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.cmb_Operacion);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.txt_Observacion);
            this.panel1.Controls.Add(this.cmb_TipoSolicitante);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_NroVoucher);
            this.panel1.Controls.Add(this.txt_TipoCambio);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txt_BancoCod);
            this.panel1.Controls.Add(this.dpick_FechaPago);
            this.panel1.Controls.Add(this.txt_Banco);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_Solicitante);
            this.panel1.Controls.Add(this.txt_NroCuenta);
            this.panel1.Controls.Add(this.txt_SolicitanteCod);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dpick_FechaEmision);
            this.panel1.Controls.Add(this.lbl_orden);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.txt_NroCheque);
            this.panel1.Controls.Add(this.txt_MovCod);
            this.panel1.Controls.Add(this.cmb_Moneda);
            this.panel1.Controls.Add(this.txt_Movimiento);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lbl_Cheque);
            this.panel1.Location = new System.Drawing.Point(4, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 196);
            this.panel1.TabIndex = 112;
            // 
            // cmb_periodo
            // 
            this.cmb_periodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_periodo.FormattingEnabled = true;
            this.cmb_periodo.Location = new System.Drawing.Point(149, 159);
            this.cmb_periodo.Name = "cmb_periodo";
            this.cmb_periodo.Size = new System.Drawing.Size(108, 21);
            this.cmb_periodo.TabIndex = 121;
            // 
            // cmb_ejercicio2
            // 
            this.cmb_ejercicio2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ejercicio2.FormattingEnabled = true;
            this.cmb_ejercicio2.Location = new System.Drawing.Point(5, 159);
            this.cmb_ejercicio2.Name = "cmb_ejercicio2";
            this.cmb_ejercicio2.Size = new System.Drawing.Size(108, 21);
            this.cmb_ejercicio2.TabIndex = 120;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(146, 143);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 119;
            this.label16.Text = "Periodo";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 143);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 13);
            this.label15.TabIndex = 118;
            this.label15.Text = "Ejercicio";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(347, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 115;
            this.label5.Text = "Total:";
            // 
            // txt_MontoTotal
            // 
            this.txt_MontoTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_MontoTotal.Location = new System.Drawing.Point(390, 40);
            this.txt_MontoTotal.Name = "txt_MontoTotal";
            this.txt_MontoTotal.Size = new System.Drawing.Size(83, 20);
            this.txt_MontoTotal.TabIndex = 114;
            this.txt_MontoTotal.TextChanged += new System.EventHandler(this.txt_MontoTotal_TextChanged);
            this.txt_MontoTotal.Leave += new System.EventHandler(this.txt_MontoTotal_Leave);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(2, 43);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(73, 13);
            this.label21.TabIndex = 113;
            this.label21.Text = "Operación :";
            // 
            // cmb_Operacion
            // 
            this.cmb_Operacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Operacion.Enabled = false;
            this.cmb_Operacion.FormattingEnabled = true;
            this.cmb_Operacion.Location = new System.Drawing.Point(79, 40);
            this.cmb_Operacion.Name = "cmb_Operacion";
            this.cmb_Operacion.Size = new System.Drawing.Size(99, 21);
            this.cmb_Operacion.TabIndex = 112;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(358, 109);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 13);
            this.label19.TabIndex = 111;
            this.label19.Text = "Observación :";
            // 
            // txt_Observacion
            // 
            this.txt_Observacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Observacion.Enabled = false;
            this.txt_Observacion.Location = new System.Drawing.Point(452, 105);
            this.txt_Observacion.Multiline = true;
            this.txt_Observacion.Name = "txt_Observacion";
            this.txt_Observacion.Size = new System.Drawing.Size(341, 75);
            this.txt_Observacion.TabIndex = 110;
            // 
            // txt_MovCod
            // 
            this.txt_MovCod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_MovCod.Enabled = false;
            this.txt_MovCod.Location = new System.Drawing.Point(96, 73);
            this.txt_MovCod.Name = "txt_MovCod";
            this.txt_MovCod.Size = new System.Drawing.Size(42, 20);
            this.txt_MovCod.TabIndex = 110;
            this.txt_MovCod.TextChanged += new System.EventHandler(this.txt_MovCod_TextChanged_1);
            // 
            // txt_Movimiento
            // 
            this.txt_Movimiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Movimiento.Enabled = false;
            this.txt_Movimiento.Location = new System.Drawing.Point(144, 73);
            this.txt_Movimiento.Name = "txt_Movimiento";
            this.txt_Movimiento.Size = new System.Drawing.Size(126, 20);
            this.txt_Movimiento.TabIndex = 111;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(-1, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 110;
            this.label8.Text = "T. Movimiento :";
            // 
            // btn_Modificar
            // 
            this.btn_Modificar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Modificar.Location = new System.Drawing.Point(254, 3);
            this.btn_Modificar.Name = "btn_Modificar";
            this.btn_Modificar.Size = new System.Drawing.Size(90, 23);
            this.btn_Modificar.TabIndex = 131;
            this.btn_Modificar.Text = "EDITAR";
            this.btn_Modificar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Modificar.UseVisualStyleBackColor = true;
            this.btn_Modificar.Visible = false;
            this.btn_Modificar.Click += new System.EventHandler(this.btn_Modificar_Click);
            // 
            // txt_codot
            // 
            this.txt_codot.Location = new System.Drawing.Point(15, 575);
            this.txt_codot.Name = "txt_codot";
            this.txt_codot.Size = new System.Drawing.Size(100, 20);
            this.txt_codot.TabIndex = 127;
            this.txt_codot.Visible = false;
            // 
            // txt_Total
            // 
            this.txt_Total.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Total.Enabled = false;
            this.txt_Total.Location = new System.Drawing.Point(632, 605);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.Size = new System.Drawing.Size(92, 20);
            this.txt_Total.TabIndex = 128;
            this.txt_Total.TextChanged += new System.EventHandler(this.txt_Total_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(555, 611);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 13);
            this.label17.TabIndex = 129;
            this.label17.Text = "Total :";
            // 
            // txt_CuentaContable
            // 
            this.txt_CuentaContable.Location = new System.Drawing.Point(15, 598);
            this.txt_CuentaContable.Name = "txt_CuentaContable";
            this.txt_CuentaContable.Size = new System.Drawing.Size(100, 20);
            this.txt_CuentaContable.TabIndex = 130;
            // 
            // txt_NumReg
            // 
            this.txt_NumReg.Location = new System.Drawing.Point(121, 575);
            this.txt_NumReg.Name = "txt_NumReg";
            this.txt_NumReg.Size = new System.Drawing.Size(100, 20);
            this.txt_NumReg.TabIndex = 133;
            this.txt_NumReg.Visible = false;
            // 
            // txt_TotalDocumento
            // 
            this.txt_TotalDocumento.Location = new System.Drawing.Point(118, 602);
            this.txt_TotalDocumento.Name = "txt_TotalDocumento";
            this.txt_TotalDocumento.Size = new System.Drawing.Size(100, 20);
            this.txt_TotalDocumento.TabIndex = 134;
            this.txt_TotalDocumento.Visible = false;
            // 
            // btn_Reporte
            // 
            this.btn_Reporte.Image = global::Contabilidad.Properties.Resources.report;
            this.btn_Reporte.Location = new System.Drawing.Point(499, 5);
            this.btn_Reporte.Name = "btn_Reporte";
            this.btn_Reporte.Size = new System.Drawing.Size(43, 43);
            this.btn_Reporte.TabIndex = 136;
            this.btn_Reporte.UseVisualStyleBackColor = true;
            this.btn_Reporte.Click += new System.EventHandler(this.btn_Reporte_Click);
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Image = global::Contabilidad.Properties.Resources.print1;
            this.btn_imprimir.Location = new System.Drawing.Point(395, 3);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(54, 44);
            this.btn_imprimir.TabIndex = 135;
            this.btn_imprimir.UseVisualStyleBackColor = true;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // btn_SaveData
            // 
            this.btn_SaveData.Image = global::Contabilidad.Properties.Resources.saveopt;
            this.btn_SaveData.Location = new System.Drawing.Point(312, 572);
            this.btn_SaveData.Name = "btn_SaveData";
            this.btn_SaveData.Size = new System.Drawing.Size(48, 46);
            this.btn_SaveData.TabIndex = 111;
            this.btn_SaveData.UseVisualStyleBackColor = true;
            this.btn_SaveData.Click += new System.EventHandler(this.btn_SaveData_Click);
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Image = global::Contabilidad.Properties.Resources.undocolor;
            this.btn_Limpiar.Location = new System.Drawing.Point(437, 572);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(48, 46);
            this.btn_Limpiar.TabIndex = 110;
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Enabled = false;
            this.btn_Guardar.Image = global::Contabilidad.Properties.Resources.guardar;
            this.btn_Guardar.Location = new System.Drawing.Point(748, 286);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(41, 37);
            this.btn_Guardar.TabIndex = 88;
            this.btn_Guardar.UseVisualStyleBackColor = true;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // btn_Editar
            // 
            this.btn_Editar.Enabled = false;
            this.btn_Editar.Image = global::Contabilidad.Properties.Resources.editar;
            this.btn_Editar.Location = new System.Drawing.Point(683, 286);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(41, 37);
            this.btn_Editar.TabIndex = 87;
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Enabled = false;
            this.btn_Add.Image = global::Contabilidad.Properties.Resources.agregar;
            this.btn_Add.Location = new System.Drawing.Point(578, 286);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(41, 37);
            this.btn_Add.TabIndex = 86;
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Regresar
            // 
            this.btn_Regresar.Image = global::Contabilidad.Properties.Resources.close;
            this.btn_Regresar.Location = new System.Drawing.Point(748, 575);
            this.btn_Regresar.Name = "btn_Regresar";
            this.btn_Regresar.Size = new System.Drawing.Size(49, 43);
            this.btn_Regresar.TabIndex = 84;
            this.btn_Regresar.UseVisualStyleBackColor = true;
            this.btn_Regresar.Click += new System.EventHandler(this.btn_Regresar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 116;
            this.label6.Text = "Nro OT : ";
            // 
            // txt_NroOt
            // 
            this.txt_NroOt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_NroOt.Enabled = false;
            this.txt_NroOt.Location = new System.Drawing.Point(84, 255);
            this.txt_NroOt.Name = "txt_NroOt";
            this.txt_NroOt.Size = new System.Drawing.Size(134, 20);
            this.txt_NroOt.TabIndex = 116;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(242, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(184, 13);
            this.label9.TabIndex = 137;
            this.label9.Text = "Descripción/ N°Comprobante : ";
            // 
            // txt_Descripcion
            // 
            this.txt_Descripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Descripcion.Enabled = false;
            this.txt_Descripcion.Location = new System.Drawing.Point(433, 255);
            this.txt_Descripcion.Name = "txt_Descripcion";
            this.txt_Descripcion.Size = new System.Drawing.Size(142, 20);
            this.txt_Descripcion.TabIndex = 138;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(583, 259);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 139;
            this.label10.Text = "N°Doc : ";
            // 
            // txt_NroDoc
            // 
            this.txt_NroDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_NroDoc.Enabled = false;
            this.txt_NroDoc.Location = new System.Drawing.Point(644, 255);
            this.txt_NroDoc.Name = "txt_NroDoc";
            this.txt_NroDoc.Size = new System.Drawing.Size(142, 20);
            this.txt_NroDoc.TabIndex = 140;
            // 
            // txt_RazonSocial
            // 
            this.txt_RazonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_RazonSocial.Enabled = false;
            this.txt_RazonSocial.Location = new System.Drawing.Point(114, 295);
            this.txt_RazonSocial.Name = "txt_RazonSocial";
            this.txt_RazonSocial.Size = new System.Drawing.Size(230, 20);
            this.txt_RazonSocial.TabIndex = 142;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(15, 299);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 13);
            this.label11.TabIndex = 141;
            this.label11.Text = "Razón Social : ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(377, 299);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 143;
            this.label13.Text = "Importe : ";
            // 
            // txt_Importe
            // 
            this.txt_Importe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Importe.Enabled = false;
            this.txt_Importe.Location = new System.Drawing.Point(440, 295);
            this.txt_Importe.Name = "txt_Importe";
            this.txt_Importe.Size = new System.Drawing.Size(97, 20);
            this.txt_Importe.TabIndex = 144;
            // 
            // rb_Metales
            // 
            this.rb_Metales.AutoSize = true;
            this.rb_Metales.Enabled = false;
            this.rb_Metales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Metales.Location = new System.Drawing.Point(7, 29);
            this.rb_Metales.Name = "rb_Metales";
            this.rb_Metales.Size = new System.Drawing.Size(82, 17);
            this.rb_Metales.TabIndex = 145;
            this.rb_Metales.TabStop = true;
            this.rb_Metales.Text = "METALES";
            this.rb_Metales.UseVisualStyleBackColor = true;
            // 
            // rb_Galvanizado
            // 
            this.rb_Galvanizado.AutoSize = true;
            this.rb_Galvanizado.Enabled = false;
            this.rb_Galvanizado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Galvanizado.Location = new System.Drawing.Point(91, 29);
            this.rb_Galvanizado.Name = "rb_Galvanizado";
            this.rb_Galvanizado.Size = new System.Drawing.Size(112, 17);
            this.rb_Galvanizado.TabIndex = 146;
            this.rb_Galvanizado.TabStop = true;
            this.rb_Galvanizado.Text = "GALVANIZADO";
            this.rb_Galvanizado.UseVisualStyleBackColor = true;
            this.rb_Galvanizado.CheckedChanged += new System.EventHandler(this.rb_Galvanizado_CheckedChanged);
            // 
            // btn_Rest
            // 
            this.btn_Rest.Enabled = false;
            this.btn_Rest.Image = global::Contabilidad.Properties.Resources.minus;
            this.btn_Rest.Location = new System.Drawing.Point(632, 286);
            this.btn_Rest.Name = "btn_Rest";
            this.btn_Rest.Size = new System.Drawing.Size(41, 37);
            this.btn_Rest.TabIndex = 147;
            this.btn_Rest.UseVisualStyleBackColor = true;
            this.btn_Rest.Click += new System.EventHandler(this.btn_Rest_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(555, 582);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 13);
            this.label14.TabIndex = 148;
            this.label14.Text = "Total 30% :";
            // 
            // txt_30
            // 
            this.txt_30.Enabled = false;
            this.txt_30.Location = new System.Drawing.Point(632, 579);
            this.txt_30.Name = "txt_30";
            this.txt_30.Size = new System.Drawing.Size(92, 20);
            this.txt_30.TabIndex = 149;
            // 
            // EmisionVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 637);
            this.Controls.Add(this.txt_30);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btn_Rest);
            this.Controls.Add(this.rb_Galvanizado);
            this.Controls.Add(this.rb_Metales);
            this.Controls.Add(this.txt_Importe);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt_RazonSocial);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_NroDoc);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_Descripcion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_NroOt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Reporte);
            this.Controls.Add(this.btn_imprimir);
            this.Controls.Add(this.btn_Modificar);
            this.Controls.Add(this.txt_TotalDocumento);
            this.Controls.Add(this.txt_NumReg);
            this.Controls.Add(this.txt_CuentaContable);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txt_Total);
            this.Controls.Add(this.txt_codot);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_SaveData);
            this.Controls.Add(this.btn_Limpiar);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.btn_Editar);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.grd_VoucherDet);
            this.Controls.Add(this.btn_Regresar);
            this.Name = "EmisionVoucher";
            this.Text = "EmisionVoucher";
            this.Load += new System.EventHandler(this.EmisionVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd_VoucherDet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.DataGridView grd_VoucherDet;
        private System.Windows.Forms.Button btn_Regresar;
        private System.Windows.Forms.TextBox txt_NroVoucher;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Banco;
        private System.Windows.Forms.TextBox txt_BancoCod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_NroCuenta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dpick_FechaEmision;
        private System.Windows.Forms.ComboBox cmb_Moneda;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_NroCheque;
        private System.Windows.Forms.Label lbl_Cheque;
        private System.Windows.Forms.Label lbl_orden;
        private System.Windows.Forms.ComboBox cmb_TipoSolicitante;
        private System.Windows.Forms.TextBox txt_Solicitante;
        private System.Windows.Forms.TextBox txt_SolicitanteCod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dpick_FechaPago;
        private System.Windows.Forms.TextBox txt_TipoCambio;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_SaveData;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_MovCod;
        private System.Windows.Forms.TextBox txt_Movimiento;
        private System.Windows.Forms.TextBox txt_codot;
        private System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_CuentaContable;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txt_Observacion;
        private System.Windows.Forms.Button btn_Modificar;
        private System.Windows.Forms.TextBox txt_NumReg;
        private System.Windows.Forms.TextBox txt_TotalDocumento;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmb_Operacion;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.Button btn_Reporte;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_MontoTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_NroOt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Descripcion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_NroDoc;
        private System.Windows.Forms.TextBox txt_RazonSocial;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_Importe;
        private System.Windows.Forms.RadioButton rb_Metales;
        private System.Windows.Forms.RadioButton rb_Galvanizado;
        private System.Windows.Forms.Button btn_Rest;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_30;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmb_ejercicio2;
        private System.Windows.Forms.ComboBox cmb_periodo;
    }
}