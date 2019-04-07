namespace Contabilidad
{
    partial class Retencion
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
            this.txt_Serie = new System.Windows.Forms.TextBox();
            this.txt_Numero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Cliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Ruc = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dpick_Fecha = new System.Windows.Forms.DateTimePicker();
            this.txt_Voucher = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grdDocumento = new System.Windows.Forms.DataGridView();
            this.btn_Regresar = new System.Windows.Forms.Button();
            this.btn_SaveData = new System.Windows.Forms.Button();
            this.txt_TotalSoles = new System.Windows.Forms.TextBox();
            this.txt_TotalDolares = new System.Windows.Forms.TextBox();
            this.txt_TRetencionDolares = new System.Windows.Forms.TextBox();
            this.txt_TRetencionSoles = new System.Windows.Forms.TextBox();
            this.txt_codcliente = new System.Windows.Forms.TextBox();
            this.btn_BuscarDocu = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Observacion = new System.Windows.Forms.TextBox();
            this.txt_codot = new System.Windows.Forms.TextBox();
            this.txt_MonedaCod = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumento)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Código Retención :";
            // 
            // txt_Serie
            // 
            this.txt_Serie.Enabled = false;
            this.txt_Serie.Location = new System.Drawing.Point(147, 18);
            this.txt_Serie.Name = "txt_Serie";
            this.txt_Serie.Size = new System.Drawing.Size(35, 20);
            this.txt_Serie.TabIndex = 45;
            // 
            // txt_Numero
            // 
            this.txt_Numero.Enabled = false;
            this.txt_Numero.Location = new System.Drawing.Point(189, 18);
            this.txt_Numero.Name = "txt_Numero";
            this.txt_Numero.Size = new System.Drawing.Size(76, 20);
            this.txt_Numero.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Proveedor :";
            // 
            // txt_Cliente
            // 
            this.txt_Cliente.Enabled = false;
            this.txt_Cliente.Location = new System.Drawing.Point(87, 85);
            this.txt_Cliente.Name = "txt_Cliente";
            this.txt_Cliente.Size = new System.Drawing.Size(468, 20);
            this.txt_Cliente.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(561, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 74;
            this.label2.Text = "RUC :";
            // 
            // txt_Ruc
            // 
            this.txt_Ruc.Enabled = false;
            this.txt_Ruc.Location = new System.Drawing.Point(611, 86);
            this.txt_Ruc.Name = "txt_Ruc";
            this.txt_Ruc.Size = new System.Drawing.Size(99, 20);
            this.txt_Ruc.TabIndex = 73;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_Numero);
            this.panel1.Controls.Add(this.txt_Serie);
            this.panel1.Location = new System.Drawing.Point(270, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 55);
            this.panel1.TabIndex = 75;
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Image = global::Contabilidad.Properties.Resources.lupa;
            this.btn_Buscar.Location = new System.Drawing.Point(732, 86);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(57, 38);
            this.btn_Buscar.TabIndex = 76;
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(350, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 77;
            this.label4.Text = "Fecha Emisión :";
            // 
            // dpick_Fecha
            // 
            this.dpick_Fecha.Enabled = false;
            this.dpick_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpick_Fecha.Location = new System.Drawing.Point(459, 112);
            this.dpick_Fecha.Name = "dpick_Fecha";
            this.dpick_Fecha.Size = new System.Drawing.Size(99, 20);
            this.dpick_Fecha.TabIndex = 78;
            // 
            // txt_Voucher
            // 
            this.txt_Voucher.Enabled = false;
            this.txt_Voucher.Location = new System.Drawing.Point(88, 112);
            this.txt_Voucher.Name = "txt_Voucher";
            this.txt_Voucher.Size = new System.Drawing.Size(174, 20);
            this.txt_Voucher.TabIndex = 79;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 80;
            this.label5.Text = "Voucher :";
            // 
            // grdDocumento
            // 
            this.grdDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDocumento.Location = new System.Drawing.Point(18, 178);
            this.grdDocumento.Name = "grdDocumento";
            this.grdDocumento.ReadOnly = true;
            this.grdDocumento.Size = new System.Drawing.Size(775, 231);
            this.grdDocumento.TabIndex = 81;
            // 
            // btn_Regresar
            // 
            this.btn_Regresar.Location = new System.Drawing.Point(503, 462);
            this.btn_Regresar.Name = "btn_Regresar";
            this.btn_Regresar.Size = new System.Drawing.Size(62, 46);
            this.btn_Regresar.TabIndex = 83;
            this.btn_Regresar.Text = "Regresar";
            this.btn_Regresar.UseVisualStyleBackColor = true;
            this.btn_Regresar.Click += new System.EventHandler(this.btn_Regresar_Click);
            // 
            // btn_SaveData
            // 
            this.btn_SaveData.Image = global::Contabilidad.Properties.Resources.saveopt;
            this.btn_SaveData.Location = new System.Drawing.Point(255, 462);
            this.btn_SaveData.Name = "btn_SaveData";
            this.btn_SaveData.Size = new System.Drawing.Size(48, 46);
            this.btn_SaveData.TabIndex = 82;
            this.btn_SaveData.UseVisualStyleBackColor = true;
            this.btn_SaveData.Click += new System.EventHandler(this.btn_SaveData_Click);
            // 
            // txt_TotalSoles
            // 
            this.txt_TotalSoles.Enabled = false;
            this.txt_TotalSoles.Location = new System.Drawing.Point(523, 417);
            this.txt_TotalSoles.Name = "txt_TotalSoles";
            this.txt_TotalSoles.Size = new System.Drawing.Size(81, 20);
            this.txt_TotalSoles.TabIndex = 84;
            // 
            // txt_TotalDolares
            // 
            this.txt_TotalDolares.Enabled = false;
            this.txt_TotalDolares.Location = new System.Drawing.Point(438, 417);
            this.txt_TotalDolares.Name = "txt_TotalDolares";
            this.txt_TotalDolares.Size = new System.Drawing.Size(81, 20);
            this.txt_TotalDolares.TabIndex = 85;
            // 
            // txt_TRetencionDolares
            // 
            this.txt_TRetencionDolares.Enabled = false;
            this.txt_TRetencionDolares.Location = new System.Drawing.Point(608, 417);
            this.txt_TRetencionDolares.Name = "txt_TRetencionDolares";
            this.txt_TRetencionDolares.Size = new System.Drawing.Size(81, 20);
            this.txt_TRetencionDolares.TabIndex = 86;
            // 
            // txt_TRetencionSoles
            // 
            this.txt_TRetencionSoles.Enabled = false;
            this.txt_TRetencionSoles.Location = new System.Drawing.Point(693, 417);
            this.txt_TRetencionSoles.Name = "txt_TRetencionSoles";
            this.txt_TRetencionSoles.Size = new System.Drawing.Size(81, 20);
            this.txt_TRetencionSoles.TabIndex = 87;
            // 
            // txt_codcliente
            // 
            this.txt_codcliente.Location = new System.Drawing.Point(18, 488);
            this.txt_codcliente.Name = "txt_codcliente";
            this.txt_codcliente.Size = new System.Drawing.Size(100, 20);
            this.txt_codcliente.TabIndex = 88;
            this.txt_codcliente.Visible = false;
            // 
            // btn_BuscarDocu
            // 
            this.btn_BuscarDocu.Image = global::Contabilidad.Properties.Resources.lupamedio;
            this.btn_BuscarDocu.Location = new System.Drawing.Point(277, 111);
            this.btn_BuscarDocu.Name = "btn_BuscarDocu";
            this.btn_BuscarDocu.Size = new System.Drawing.Size(38, 23);
            this.btn_BuscarDocu.TabIndex = 91;
            this.btn_BuscarDocu.UseVisualStyleBackColor = true;
            this.btn_BuscarDocu.Click += new System.EventHandler(this.btn_BuscarDocu_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(94, 441);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 13);
            this.lblTotal.TabIndex = 106;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(22, 440);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(37, 13);
            this.label28.TabIndex = 105;
            this.label28.Text = "Son :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 107;
            this.label6.Text = "Observación :";
            // 
            // txt_Observacion
            // 
            this.txt_Observacion.Enabled = false;
            this.txt_Observacion.Location = new System.Drawing.Point(105, 138);
            this.txt_Observacion.Multiline = true;
            this.txt_Observacion.Name = "txt_Observacion";
            this.txt_Observacion.Size = new System.Drawing.Size(684, 34);
            this.txt_Observacion.TabIndex = 108;
            // 
            // txt_codot
            // 
            this.txt_codot.Location = new System.Drawing.Point(18, 462);
            this.txt_codot.Name = "txt_codot";
            this.txt_codot.Size = new System.Drawing.Size(100, 20);
            this.txt_codot.TabIndex = 109;
            this.txt_codot.Visible = false;
            // 
            // txt_MonedaCod
            // 
            this.txt_MonedaCod.Location = new System.Drawing.Point(124, 488);
            this.txt_MonedaCod.Name = "txt_MonedaCod";
            this.txt_MonedaCod.Size = new System.Drawing.Size(100, 20);
            this.txt_MonedaCod.TabIndex = 110;
            this.txt_MonedaCod.Visible = false;
            // 
            // Retencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 512);
            this.Controls.Add(this.txt_MonedaCod);
            this.Controls.Add(this.txt_codot);
            this.Controls.Add(this.txt_Observacion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.btn_BuscarDocu);
            this.Controls.Add(this.txt_codcliente);
            this.Controls.Add(this.txt_TRetencionSoles);
            this.Controls.Add(this.txt_TRetencionDolares);
            this.Controls.Add(this.txt_TotalDolares);
            this.Controls.Add(this.txt_TotalSoles);
            this.Controls.Add(this.btn_Regresar);
            this.Controls.Add(this.btn_SaveData);
            this.Controls.Add(this.grdDocumento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Voucher);
            this.Controls.Add(this.dpick_Fecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Ruc);
            this.Controls.Add(this.txt_Cliente);
            this.Controls.Add(this.label1);
            this.Name = "Retencion";
            this.Text = "Retencion";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Serie;
        private System.Windows.Forms.TextBox txt_Numero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Cliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Ruc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dpick_Fecha;
        private System.Windows.Forms.TextBox txt_Voucher;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView grdDocumento;
        private System.Windows.Forms.Button btn_Regresar;
        private System.Windows.Forms.Button btn_SaveData;
        private System.Windows.Forms.TextBox txt_TotalSoles;
        private System.Windows.Forms.TextBox txt_TotalDolares;
        private System.Windows.Forms.TextBox txt_TRetencionDolares;
        private System.Windows.Forms.TextBox txt_TRetencionSoles;
        private System.Windows.Forms.TextBox txt_codcliente;
        private System.Windows.Forms.Button btn_BuscarDocu;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Observacion;
        private System.Windows.Forms.TextBox txt_codot;
        private System.Windows.Forms.TextBox txt_MonedaCod;
    }
}