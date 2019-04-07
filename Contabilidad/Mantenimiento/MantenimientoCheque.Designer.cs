namespace Contabilidad.Mantenimiento
{
    partial class MantenimientoCheque
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
            this.cmb_Banco = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Moneda = new System.Windows.Forms.ComboBox();
            this.txt_NroCuenta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_ChequeInicio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_ChequeFin = new System.Windows.Forms.TextBox();
            this.txt_ChequeActual = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grd_Cheque = new System.Windows.Forms.DataGridView();
            this.btn_Regresar = new System.Windows.Forms.Button();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Cheque)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(238, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 90;
            this.label3.Text = "Banco :";
            // 
            // cmb_Banco
            // 
            this.cmb_Banco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Banco.Enabled = false;
            this.cmb_Banco.FormattingEnabled = true;
            this.cmb_Banco.Location = new System.Drawing.Point(305, 12);
            this.cmb_Banco.Name = "cmb_Banco";
            this.cmb_Banco.Size = new System.Drawing.Size(217, 21);
            this.cmb_Banco.TabIndex = 91;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "Moneda :";
            // 
            // cmb_Moneda
            // 
            this.cmb_Moneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Moneda.Enabled = false;
            this.cmb_Moneda.FormattingEnabled = true;
            this.cmb_Moneda.Location = new System.Drawing.Point(90, 50);
            this.cmb_Moneda.Name = "cmb_Moneda";
            this.cmb_Moneda.Size = new System.Drawing.Size(154, 21);
            this.cmb_Moneda.TabIndex = 93;
            // 
            // txt_NroCuenta
            // 
            this.txt_NroCuenta.Enabled = false;
            this.txt_NroCuenta.Location = new System.Drawing.Point(531, 51);
            this.txt_NroCuenta.Name = "txt_NroCuenta";
            this.txt_NroCuenta.Size = new System.Drawing.Size(250, 20);
            this.txt_NroCuenta.TabIndex = 94;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(470, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 95;
            this.label2.Text = "Cuenta :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 96;
            this.label4.Text = "N° Cheque Inicio :";
            // 
            // txt_ChequeInicio
            // 
            this.txt_ChequeInicio.Enabled = false;
            this.txt_ChequeInicio.Location = new System.Drawing.Point(136, 93);
            this.txt_ChequeInicio.Name = "txt_ChequeInicio";
            this.txt_ChequeInicio.Size = new System.Drawing.Size(99, 20);
            this.txt_ChequeInicio.TabIndex = 97;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(583, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 98;
            this.label5.Text = "N° Cheque Fin :";
            // 
            // txt_ChequeFin
            // 
            this.txt_ChequeFin.Enabled = false;
            this.txt_ChequeFin.Location = new System.Drawing.Point(686, 93);
            this.txt_ChequeFin.Name = "txt_ChequeFin";
            this.txt_ChequeFin.Size = new System.Drawing.Size(94, 20);
            this.txt_ChequeFin.TabIndex = 99;
            // 
            // txt_ChequeActual
            // 
            this.txt_ChequeActual.Enabled = false;
            this.txt_ChequeActual.Location = new System.Drawing.Point(391, 132);
            this.txt_ChequeActual.Name = "txt_ChequeActual";
            this.txt_ChequeActual.Size = new System.Drawing.Size(85, 20);
            this.txt_ChequeActual.TabIndex = 101;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(270, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 100;
            this.label6.Text = "N° Cheque Actual :";
            // 
            // grd_Cheque
            // 
            this.grd_Cheque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_Cheque.Location = new System.Drawing.Point(12, 171);
            this.grd_Cheque.Name = "grd_Cheque";
            this.grd_Cheque.ReadOnly = true;
            this.grd_Cheque.RowHeadersVisible = false;
            this.grd_Cheque.Size = new System.Drawing.Size(774, 290);
            this.grd_Cheque.TabIndex = 102;
            // 
            // btn_Regresar
            // 
            this.btn_Regresar.Image = global::Contabilidad.Properties.Resources.close;
            this.btn_Regresar.Location = new System.Drawing.Point(737, 482);
            this.btn_Regresar.Name = "btn_Regresar";
            this.btn_Regresar.Size = new System.Drawing.Size(49, 43);
            this.btn_Regresar.TabIndex = 103;
            this.btn_Regresar.UseVisualStyleBackColor = true;
            this.btn_Regresar.Click += new System.EventHandler(this.btn_Regresar_Click);
            // 
            // btn_Editar
            // 
            this.btn_Editar.Image = global::Contabilidad.Properties.Resources.editar;
            this.btn_Editar.Location = new System.Drawing.Point(664, 124);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(41, 37);
            this.btn_Editar.TabIndex = 113;
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Enabled = false;
            this.btn_Guardar.Image = global::Contabilidad.Properties.Resources.guardar;
            this.btn_Guardar.Location = new System.Drawing.Point(738, 124);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(41, 37);
            this.btn_Guardar.TabIndex = 114;
            this.btn_Guardar.UseVisualStyleBackColor = true;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Image = global::Contabilidad.Properties.Resources.agregar;
            this.btn_Add.Location = new System.Drawing.Point(586, 124);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(41, 37);
            this.btn_Add.TabIndex = 115;
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // MantenimientoCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 536);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.btn_Editar);
            this.Controls.Add(this.btn_Regresar);
            this.Controls.Add(this.grd_Cheque);
            this.Controls.Add(this.txt_ChequeActual);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_ChequeFin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_ChequeInicio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_NroCuenta);
            this.Controls.Add(this.cmb_Moneda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_Banco);
            this.Controls.Add(this.label3);
            this.Name = "MantenimientoCheque";
            this.Text = "MantenimientoCheque";
            ((System.ComponentModel.ISupportInitialize)(this.grd_Cheque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_Banco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Moneda;
        private System.Windows.Forms.TextBox txt_NroCuenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_ChequeInicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_ChequeFin;
        private System.Windows.Forms.TextBox txt_ChequeActual;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView grd_Cheque;
        private System.Windows.Forms.Button btn_Regresar;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Add;
    }
}