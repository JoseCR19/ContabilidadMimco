namespace Contabilidad
{
    partial class RenovacionLetra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenovacionLetra));
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Serie = new System.Windows.Forms.TextBox();
            this.txt_Numero = new System.Windows.Forms.TextBox();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Telefono = new System.Windows.Forms.TextBox();
            this.txt_TelefAval = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_DireccionAval = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Aval = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_RucAval = new System.Windows.Forms.TextBox();
            this.dpick_Fecha = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Direccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Cliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Ruc = new System.Windows.Forms.TextBox();
            this.txt_NumeroDcto = new System.Windows.Forms.TextBox();
            this.txt_SerieDcto = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.txt_Moneda = new System.Windows.Forms.TextBox();
            this.txt_TotalFactura = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dpck_Fechavcto = new System.Windows.Forms.DateTimePicker();
            this.grdDocumento = new System.Windows.Forms.DataGridView();
            this.btn_Regresar = new System.Windows.Forms.Button();
            this.btn_SaveData = new System.Windows.Forms.Button();
            this.txt_TotalLetra = new System.Windows.Forms.TextBox();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.txt_AvalCod = new System.Windows.Forms.TextBox();
            this.txt_codcliente = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumento)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "N° Letra  :";
            // 
            // txt_Serie
            // 
            this.txt_Serie.Enabled = false;
            this.txt_Serie.Location = new System.Drawing.Point(106, 21);
            this.txt_Serie.Name = "txt_Serie";
            this.txt_Serie.Size = new System.Drawing.Size(35, 20);
            this.txt_Serie.TabIndex = 42;
            // 
            // txt_Numero
            // 
            this.txt_Numero.Enabled = false;
            this.txt_Numero.Location = new System.Drawing.Point(148, 21);
            this.txt_Numero.Name = "txt_Numero";
            this.txt_Numero.Size = new System.Drawing.Size(76, 20);
            this.txt_Numero.TabIndex = 43;
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Buscar.Image")));
            this.btn_Buscar.Location = new System.Drawing.Point(259, 6);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(75, 48);
            this.btn_Buscar.TabIndex = 35;
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_Buscar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_Serie);
            this.panel1.Controls.Add(this.txt_Numero);
            this.panel1.Location = new System.Drawing.Point(285, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 66);
            this.panel1.TabIndex = 60;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txt_Telefono);
            this.panel2.Controls.Add(this.txt_TelefAval);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txt_DireccionAval);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txt_Aval);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txt_RucAval);
            this.panel2.Controls.Add(this.dpick_Fecha);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txt_Direccion);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt_Cliente);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_Ruc);
            this.panel2.Location = new System.Drawing.Point(31, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(902, 124);
            this.panel2.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(681, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 85;
            this.label4.Text = "Teléfono :";
            // 
            // txt_Telefono
            // 
            this.txt_Telefono.Enabled = false;
            this.txt_Telefono.Location = new System.Drawing.Point(761, 8);
            this.txt_Telefono.Name = "txt_Telefono";
            this.txt_Telefono.Size = new System.Drawing.Size(133, 20);
            this.txt_Telefono.TabIndex = 84;
            // 
            // txt_TelefAval
            // 
            this.txt_TelefAval.Enabled = false;
            this.txt_TelefAval.Location = new System.Drawing.Point(761, 60);
            this.txt_TelefAval.Name = "txt_TelefAval";
            this.txt_TelefAval.Size = new System.Drawing.Size(133, 20);
            this.txt_TelefAval.TabIndex = 83;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(681, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 82;
            this.label12.Text = "Teléfono :";
            // 
            // txt_DireccionAval
            // 
            this.txt_DireccionAval.Enabled = false;
            this.txt_DireccionAval.Location = new System.Drawing.Point(118, 88);
            this.txt_DireccionAval.Name = "txt_DireccionAval";
            this.txt_DireccionAval.Size = new System.Drawing.Size(548, 20);
            this.txt_DireccionAval.TabIndex = 80;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 81;
            this.label7.Text = "Dirección Aval:";
            // 
            // txt_Aval
            // 
            this.txt_Aval.Enabled = false;
            this.txt_Aval.Location = new System.Drawing.Point(257, 60);
            this.txt_Aval.Name = "txt_Aval";
            this.txt_Aval.Size = new System.Drawing.Size(409, 20);
            this.txt_Aval.TabIndex = 79;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(673, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 62;
            this.label10.Text = "Fecha Giro:";
            // 
            // txt_RucAval
            // 
            this.txt_RucAval.Enabled = false;
            this.txt_RucAval.Location = new System.Drawing.Point(118, 60);
            this.txt_RucAval.Name = "txt_RucAval";
            this.txt_RucAval.Size = new System.Drawing.Size(133, 20);
            this.txt_RucAval.TabIndex = 77;
            // 
            // dpick_Fecha
            // 
            this.dpick_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpick_Fecha.Location = new System.Drawing.Point(761, 34);
            this.dpick_Fecha.Name = "dpick_Fecha";
            this.dpick_Fecha.Size = new System.Drawing.Size(81, 20);
            this.dpick_Fecha.TabIndex = 63;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(49, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 76;
            this.label5.Text = "Aval  :";
            // 
            // txt_Direccion
            // 
            this.txt_Direccion.Enabled = false;
            this.txt_Direccion.Location = new System.Drawing.Point(118, 34);
            this.txt_Direccion.Name = "txt_Direccion";
            this.txt_Direccion.Size = new System.Drawing.Size(548, 20);
            this.txt_Direccion.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Cliente : ";
            // 
            // txt_Cliente
            // 
            this.txt_Cliente.Enabled = false;
            this.txt_Cliente.Location = new System.Drawing.Point(257, 8);
            this.txt_Cliente.Name = "txt_Cliente";
            this.txt_Cliente.Size = new System.Drawing.Size(409, 20);
            this.txt_Cliente.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Dirección :";
            // 
            // txt_Ruc
            // 
            this.txt_Ruc.Enabled = false;
            this.txt_Ruc.Location = new System.Drawing.Point(118, 8);
            this.txt_Ruc.Name = "txt_Ruc";
            this.txt_Ruc.Size = new System.Drawing.Size(133, 20);
            this.txt_Ruc.TabIndex = 36;
            // 
            // txt_NumeroDcto
            // 
            this.txt_NumeroDcto.Enabled = false;
            this.txt_NumeroDcto.Location = new System.Drawing.Point(161, 12);
            this.txt_NumeroDcto.Name = "txt_NumeroDcto";
            this.txt_NumeroDcto.Size = new System.Drawing.Size(76, 20);
            this.txt_NumeroDcto.TabIndex = 70;
            // 
            // txt_SerieDcto
            // 
            this.txt_SerieDcto.Enabled = false;
            this.txt_SerieDcto.Location = new System.Drawing.Point(120, 12);
            this.txt_SerieDcto.Name = "txt_SerieDcto";
            this.txt_SerieDcto.Size = new System.Drawing.Size(35, 20);
            this.txt_SerieDcto.TabIndex = 69;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(43, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 13);
            this.label18.TabIndex = 68;
            this.label18.Text = "N° DCTO  :";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btn_Add);
            this.panel3.Controls.Add(this.btn_Guardar);
            this.panel3.Controls.Add(this.btn_Editar);
            this.panel3.Controls.Add(this.txt_Moneda);
            this.panel3.Controls.Add(this.txt_TotalFactura);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.dpck_Fechavcto);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.txt_NumeroDcto);
            this.panel3.Controls.Add(this.txt_SerieDcto);
            this.panel3.Location = new System.Drawing.Point(31, 232);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(902, 49);
            this.panel3.TabIndex = 71;
            // 
            // btn_Add
            // 
            this.btn_Add.Image = global::Contabilidad.Properties.Resources.agregar;
            this.btn_Add.Location = new System.Drawing.Point(698, 3);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(41, 37);
            this.btn_Add.TabIndex = 78;
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Enabled = false;
            this.btn_Guardar.Image = global::Contabilidad.Properties.Resources.guardar;
            this.btn_Guardar.Location = new System.Drawing.Point(828, 3);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(41, 37);
            this.btn_Guardar.TabIndex = 77;
            this.btn_Guardar.UseVisualStyleBackColor = true;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // btn_Editar
            // 
            this.btn_Editar.Image = global::Contabilidad.Properties.Resources.editar;
            this.btn_Editar.Location = new System.Drawing.Point(763, 3);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(41, 37);
            this.btn_Editar.TabIndex = 76;
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // txt_Moneda
            // 
            this.txt_Moneda.Enabled = false;
            this.txt_Moneda.Location = new System.Drawing.Point(508, 11);
            this.txt_Moneda.Name = "txt_Moneda";
            this.txt_Moneda.Size = new System.Drawing.Size(34, 20);
            this.txt_Moneda.TabIndex = 75;
            // 
            // txt_TotalFactura
            // 
            this.txt_TotalFactura.Location = new System.Drawing.Point(548, 11);
            this.txt_TotalFactura.Name = "txt_TotalFactura";
            this.txt_TotalFactura.Size = new System.Drawing.Size(97, 20);
            this.txt_TotalFactura.TabIndex = 74;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(449, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 73;
            this.label14.Text = "Monto :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(254, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 71;
            this.label11.Text = "Fecha Vecto:";
            // 
            // dpck_Fechavcto
            // 
            this.dpck_Fechavcto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpck_Fechavcto.Location = new System.Drawing.Point(345, 12);
            this.dpck_Fechavcto.Name = "dpck_Fechavcto";
            this.dpck_Fechavcto.Size = new System.Drawing.Size(81, 20);
            this.dpck_Fechavcto.TabIndex = 72;
            // 
            // grdDocumento
            // 
            this.grdDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDocumento.Location = new System.Drawing.Point(31, 287);
            this.grdDocumento.Name = "grdDocumento";
            this.grdDocumento.ReadOnly = true;
            this.grdDocumento.Size = new System.Drawing.Size(902, 227);
            this.grdDocumento.TabIndex = 72;
            // 
            // btn_Regresar
            // 
            this.btn_Regresar.Location = new System.Drawing.Point(568, 550);
            this.btn_Regresar.Name = "btn_Regresar";
            this.btn_Regresar.Size = new System.Drawing.Size(62, 46);
            this.btn_Regresar.TabIndex = 74;
            this.btn_Regresar.Text = "Regresar";
            this.btn_Regresar.UseVisualStyleBackColor = true;
            this.btn_Regresar.Click += new System.EventHandler(this.btn_Regresar_Click);
            // 
            // btn_SaveData
            // 
            this.btn_SaveData.Image = global::Contabilidad.Properties.Resources.saveopt;
            this.btn_SaveData.Location = new System.Drawing.Point(320, 550);
            this.btn_SaveData.Name = "btn_SaveData";
            this.btn_SaveData.Size = new System.Drawing.Size(48, 46);
            this.btn_SaveData.TabIndex = 73;
            this.btn_SaveData.UseVisualStyleBackColor = true;
            this.btn_SaveData.Click += new System.EventHandler(this.btn_SaveData_Click);
            // 
            // txt_TotalLetra
            // 
            this.txt_TotalLetra.Enabled = false;
            this.txt_TotalLetra.Location = new System.Drawing.Point(793, 520);
            this.txt_TotalLetra.Name = "txt_TotalLetra";
            this.txt_TotalLetra.Size = new System.Drawing.Size(108, 20);
            this.txt_TotalLetra.TabIndex = 76;
            // 
            // txt_Total
            // 
            this.txt_Total.Enabled = false;
            this.txt_Total.Location = new System.Drawing.Point(677, 520);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.Size = new System.Drawing.Size(100, 20);
            this.txt_Total.TabIndex = 75;
            // 
            // txt_AvalCod
            // 
            this.txt_AvalCod.Location = new System.Drawing.Point(137, 540);
            this.txt_AvalCod.Name = "txt_AvalCod";
            this.txt_AvalCod.Size = new System.Drawing.Size(100, 20);
            this.txt_AvalCod.TabIndex = 80;
            this.txt_AvalCod.Visible = false;
            // 
            // txt_codcliente
            // 
            this.txt_codcliente.Location = new System.Drawing.Point(31, 540);
            this.txt_codcliente.Name = "txt_codcliente";
            this.txt_codcliente.Size = new System.Drawing.Size(100, 20);
            this.txt_codcliente.TabIndex = 79;
            this.txt_codcliente.Visible = false;
            // 
            // RenovacionLetra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 608);
            this.Controls.Add(this.txt_AvalCod);
            this.Controls.Add(this.txt_codcliente);
            this.Controls.Add(this.txt_TotalLetra);
            this.Controls.Add(this.txt_Total);
            this.Controls.Add(this.btn_Regresar);
            this.Controls.Add(this.btn_SaveData);
            this.Controls.Add(this.grdDocumento);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "RenovacionLetra";
            this.Text = "RenovacionLetra";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Serie;
        private System.Windows.Forms.TextBox txt_Numero;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_Direccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Cliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Ruc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dpick_Fecha;
        private System.Windows.Forms.TextBox txt_NumeroDcto;
        private System.Windows.Forms.TextBox txt_SerieDcto;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dpck_Fechavcto;
        private System.Windows.Forms.TextBox txt_Moneda;
        private System.Windows.Forms.TextBox txt_TotalFactura;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView grdDocumento;
        private System.Windows.Forms.TextBox txt_Aval;
        private System.Windows.Forms.TextBox txt_RucAval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_TelefAval;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_DireccionAval;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Telefono;
        private System.Windows.Forms.Button btn_Regresar;
        private System.Windows.Forms.Button btn_SaveData;
        private System.Windows.Forms.TextBox txt_TotalLetra;
        private System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.TextBox txt_AvalCod;
        private System.Windows.Forms.TextBox txt_codcliente;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Button btn_Add;
    }
}