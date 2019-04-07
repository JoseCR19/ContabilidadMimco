namespace Contabilidad.CtaXcobrar
{
    partial class AbonoBanco
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
            this.txt_NroDoc = new System.Windows.Forms.TextBox();
            this.txt_Serie = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.btn_BuscarFactura = new System.Windows.Forms.Button();
            this.txt_Fecha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Tabla = new System.Windows.Forms.TextBox();
            this.txt_MonedaCod = new System.Windows.Forms.TextBox();
            this.txt_Observacion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Tcambio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Moneda = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Cuenta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Banco = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Importe = new System.Windows.Forms.TextBox();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.grd_Detalle = new System.Windows.Forms.DataGridView();
            this.txt_Deshacer = new System.Windows.Forms.Button();
            this.btn_SaveData = new System.Windows.Forms.Button();
            this.btn_BuscarCliente = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Ruc = new System.Windows.Forms.TextBox();
            this.txt_Razon = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_ClienteCod = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Detalle)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_NroDoc
            // 
            this.txt_NroDoc.Enabled = false;
            this.txt_NroDoc.Location = new System.Drawing.Point(175, 40);
            this.txt_NroDoc.Name = "txt_NroDoc";
            this.txt_NroDoc.Size = new System.Drawing.Size(104, 20);
            this.txt_NroDoc.TabIndex = 0;
            // 
            // txt_Serie
            // 
            this.txt_Serie.Enabled = false;
            this.txt_Serie.Location = new System.Drawing.Point(108, 40);
            this.txt_Serie.Name = "txt_Serie";
            this.txt_Serie.Size = new System.Drawing.Size(57, 20);
            this.txt_Serie.TabIndex = 1;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(18, 43);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(79, 13);
            this.label25.TabIndex = 26;
            this.label25.Text = "Documento :";
            // 
            // btn_BuscarFactura
            // 
            this.btn_BuscarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BuscarFactura.Location = new System.Drawing.Point(243, 7);
            this.btn_BuscarFactura.Name = "btn_BuscarFactura";
            this.btn_BuscarFactura.Size = new System.Drawing.Size(147, 23);
            this.btn_BuscarFactura.TabIndex = 27;
            this.btn_BuscarFactura.Text = "Buscar Documentos";
            this.btn_BuscarFactura.UseVisualStyleBackColor = true;
            this.btn_BuscarFactura.Click += new System.EventHandler(this.btn_BuscarFactura_Click);
            // 
            // txt_Fecha
            // 
            this.txt_Fecha.Enabled = false;
            this.txt_Fecha.Location = new System.Drawing.Point(107, 54);
            this.txt_Fecha.Name = "txt_Fecha";
            this.txt_Fecha.Size = new System.Drawing.Size(116, 20);
            this.txt_Fecha.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Fecha Pago :";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txt_ClienteCod);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txt_Razon);
            this.panel1.Controls.Add(this.txt_Ruc);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btn_BuscarCliente);
            this.panel1.Controls.Add(this.txt_Tabla);
            this.panel1.Controls.Add(this.txt_MonedaCod);
            this.panel1.Controls.Add(this.txt_Observacion);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txt_Tcambio);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_Moneda);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_Cuenta);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmb_Banco);
            this.panel1.Controls.Add(this.txt_Fecha);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(21, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 146);
            this.panel1.TabIndex = 30;
            // 
            // txt_Tabla
            // 
            this.txt_Tabla.Enabled = false;
            this.txt_Tabla.Location = new System.Drawing.Point(594, 56);
            this.txt_Tabla.Name = "txt_Tabla";
            this.txt_Tabla.Size = new System.Drawing.Size(54, 20);
            this.txt_Tabla.TabIndex = 41;
            this.txt_Tabla.Visible = false;
            // 
            // txt_MonedaCod
            // 
            this.txt_MonedaCod.Enabled = false;
            this.txt_MonedaCod.Location = new System.Drawing.Point(520, 57);
            this.txt_MonedaCod.Name = "txt_MonedaCod";
            this.txt_MonedaCod.Size = new System.Drawing.Size(54, 20);
            this.txt_MonedaCod.TabIndex = 40;
            this.txt_MonedaCod.Visible = false;
            // 
            // txt_Observacion
            // 
            this.txt_Observacion.Location = new System.Drawing.Point(107, 114);
            this.txt_Observacion.Name = "txt_Observacion";
            this.txt_Observacion.Size = new System.Drawing.Size(541, 20);
            this.txt_Observacion.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Oberservacion:";
            // 
            // txt_Tcambio
            // 
            this.txt_Tcambio.Enabled = false;
            this.txt_Tcambio.Location = new System.Drawing.Point(594, 85);
            this.txt_Tcambio.Name = "txt_Tcambio";
            this.txt_Tcambio.Size = new System.Drawing.Size(54, 20);
            this.txt_Tcambio.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(517, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "T. Cambio :";
            // 
            // txt_Moneda
            // 
            this.txt_Moneda.Enabled = false;
            this.txt_Moneda.Location = new System.Drawing.Point(300, 85);
            this.txt_Moneda.Name = "txt_Moneda";
            this.txt_Moneda.Size = new System.Drawing.Size(204, 20);
            this.txt_Moneda.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(231, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Moneda :";
            // 
            // txt_Cuenta
            // 
            this.txt_Cuenta.Enabled = false;
            this.txt_Cuenta.Location = new System.Drawing.Point(107, 85);
            this.txt_Cuenta.Name = "txt_Cuenta";
            this.txt_Cuenta.Size = new System.Drawing.Size(116, 20);
            this.txt_Cuenta.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "N° Cuenta :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(240, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Banco :";
            // 
            // cmb_Banco
            // 
            this.cmb_Banco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Banco.FormattingEnabled = true;
            this.cmb_Banco.Location = new System.Drawing.Point(300, 53);
            this.cmb_Banco.Name = "cmb_Banco";
            this.cmb_Banco.Size = new System.Drawing.Size(204, 21);
            this.cmb_Banco.TabIndex = 30;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txt_Importe);
            this.panel2.Controls.Add(this.txt_NroDoc);
            this.panel2.Controls.Add(this.txt_Serie);
            this.panel2.Controls.Add(this.btn_BuscarFactura);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Location = new System.Drawing.Point(21, 167);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(659, 72);
            this.panel2.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(392, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Importe :";
            // 
            // txt_Importe
            // 
            this.txt_Importe.Enabled = false;
            this.txt_Importe.Location = new System.Drawing.Point(486, 38);
            this.txt_Importe.Name = "txt_Importe";
            this.txt_Importe.Size = new System.Drawing.Size(126, 20);
            this.txt_Importe.TabIndex = 28;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Enabled = false;
            this.btn_Guardar.Image = global::Contabilidad.Properties.Resources.guardar;
            this.btn_Guardar.Location = new System.Drawing.Point(569, 341);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(41, 37);
            this.btn_Guardar.TabIndex = 32;
            this.btn_Guardar.UseVisualStyleBackColor = true;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // btn_Editar
            // 
            this.btn_Editar.Image = global::Contabilidad.Properties.Resources.editar;
            this.btn_Editar.Location = new System.Drawing.Point(569, 280);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(41, 37);
            this.btn_Editar.TabIndex = 31;
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // grd_Detalle
            // 
            this.grd_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_Detalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grd_Detalle.Location = new System.Drawing.Point(86, 254);
            this.grd_Detalle.Name = "grd_Detalle";
            this.grd_Detalle.ReadOnly = true;
            this.grd_Detalle.Size = new System.Drawing.Size(404, 202);
            this.grd_Detalle.TabIndex = 32;
            // 
            // txt_Deshacer
            // 
            this.txt_Deshacer.Image = global::Contabilidad.Properties.Resources.undo;
            this.txt_Deshacer.Location = new System.Drawing.Point(569, 403);
            this.txt_Deshacer.Name = "txt_Deshacer";
            this.txt_Deshacer.Size = new System.Drawing.Size(41, 39);
            this.txt_Deshacer.TabIndex = 33;
            this.txt_Deshacer.UseVisualStyleBackColor = true;
            this.txt_Deshacer.Click += new System.EventHandler(this.txt_Deshacer_Click);
            // 
            // btn_SaveData
            // 
            this.btn_SaveData.Image = global::Contabilidad.Properties.Resources.saveopt;
            this.btn_SaveData.Location = new System.Drawing.Point(328, 468);
            this.btn_SaveData.Name = "btn_SaveData";
            this.btn_SaveData.Size = new System.Drawing.Size(48, 46);
            this.btn_SaveData.TabIndex = 34;
            this.btn_SaveData.UseVisualStyleBackColor = true;
            this.btn_SaveData.Click += new System.EventHandler(this.btn_SaveData_Click);
            // 
            // btn_BuscarCliente
            // 
            this.btn_BuscarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BuscarCliente.Image = global::Contabilidad.Properties.Resources.lupamedio;
            this.btn_BuscarCliente.Location = new System.Drawing.Point(253, 3);
            this.btn_BuscarCliente.Name = "btn_BuscarCliente";
            this.btn_BuscarCliente.Size = new System.Drawing.Size(38, 23);
            this.btn_BuscarCliente.TabIndex = 30;
            this.btn_BuscarCliente.UseVisualStyleBackColor = true;
            this.btn_BuscarCliente.Click += new System.EventHandler(this.btn_BuscarCliente_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(58, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "RUC :";
            // 
            // txt_Ruc
            // 
            this.txt_Ruc.Enabled = false;
            this.txt_Ruc.Location = new System.Drawing.Point(107, 3);
            this.txt_Ruc.Name = "txt_Ruc";
            this.txt_Ruc.Size = new System.Drawing.Size(116, 20);
            this.txt_Ruc.TabIndex = 43;
            // 
            // txt_Razon
            // 
            this.txt_Razon.Enabled = false;
            this.txt_Razon.Location = new System.Drawing.Point(107, 29);
            this.txt_Razon.Name = "txt_Razon";
            this.txt_Razon.Size = new System.Drawing.Size(541, 20);
            this.txt_Razon.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(45, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "Cliente :";
            // 
            // txt_ClienteCod
            // 
            this.txt_ClienteCod.Enabled = false;
            this.txt_ClienteCod.Location = new System.Drawing.Point(520, 3);
            this.txt_ClienteCod.Name = "txt_ClienteCod";
            this.txt_ClienteCod.Size = new System.Drawing.Size(54, 20);
            this.txt_ClienteCod.TabIndex = 46;
            this.txt_ClienteCod.Visible = false;
            // 
            // AbonoBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 525);
            this.Controls.Add(this.btn_SaveData);
            this.Controls.Add(this.txt_Deshacer);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.grd_Detalle);
            this.Controls.Add(this.btn_Editar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AbonoBanco";
            this.Text = "AbonoBanco";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Detalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_NroDoc;
        private System.Windows.Forms.TextBox txt_Serie;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btn_BuscarFactura;
        private System.Windows.Forms.TextBox txt_Fecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Banco;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Moneda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Cuenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Tcambio;
        private System.Windows.Forms.TextBox txt_Observacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Importe;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.DataGridView grd_Detalle;
        private System.Windows.Forms.TextBox txt_MonedaCod;
        private System.Windows.Forms.Button txt_Deshacer;
        private System.Windows.Forms.Button btn_SaveData;
        private System.Windows.Forms.TextBox txt_Tabla;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Razon;
        private System.Windows.Forms.TextBox txt_Ruc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_BuscarCliente;
        private System.Windows.Forms.TextBox txt_ClienteCod;
    }
}