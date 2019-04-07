namespace Contabilidad.Caja
{
    partial class InsertarPrestamoBancario
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Banco = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Moneda = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_NroCuenta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Monto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dpick_FechaEmision = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dpick_FechaVcto = new System.Windows.Forms.DateTimePicker();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Banco :";
            // 
            // cmb_Banco
            // 
            this.cmb_Banco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Banco.FormattingEnabled = true;
            this.cmb_Banco.Location = new System.Drawing.Point(134, 21);
            this.cmb_Banco.Name = "cmb_Banco";
            this.cmb_Banco.Size = new System.Drawing.Size(215, 21);
            this.cmb_Banco.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(382, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Moneda :";
            // 
            // cmb_Moneda
            // 
            this.cmb_Moneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Moneda.FormattingEnabled = true;
            this.cmb_Moneda.Location = new System.Drawing.Point(456, 21);
            this.cmb_Moneda.Name = "cmb_Moneda";
            this.cmb_Moneda.Size = new System.Drawing.Size(115, 21);
            this.cmb_Moneda.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "N° Cuenta :";
            // 
            // txt_NroCuenta
            // 
            this.txt_NroCuenta.Enabled = false;
            this.txt_NroCuenta.Location = new System.Drawing.Point(134, 64);
            this.txt_NroCuenta.Name = "txt_NroCuenta";
            this.txt_NroCuenta.Size = new System.Drawing.Size(215, 20);
            this.txt_NroCuenta.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(391, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Monto :";
            // 
            // txt_Monto
            // 
            this.txt_Monto.Location = new System.Drawing.Point(456, 63);
            this.txt_Monto.Name = "txt_Monto";
            this.txt_Monto.Size = new System.Drawing.Size(115, 20);
            this.txt_Monto.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fecha Emisión :";
            // 
            // dpick_FechaEmision
            // 
            this.dpick_FechaEmision.CustomFormat = "";
            this.dpick_FechaEmision.Enabled = false;
            this.dpick_FechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpick_FechaEmision.Location = new System.Drawing.Point(135, 101);
            this.dpick_FechaEmision.Name = "dpick_FechaEmision";
            this.dpick_FechaEmision.Size = new System.Drawing.Size(92, 20);
            this.dpick_FechaEmision.TabIndex = 98;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(318, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 99;
            this.label6.Text = "Fecha Vencimiento :";
            // 
            // dpick_FechaVcto
            // 
            this.dpick_FechaVcto.CustomFormat = "";
            this.dpick_FechaVcto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpick_FechaVcto.Location = new System.Drawing.Point(458, 101);
            this.dpick_FechaVcto.Name = "dpick_FechaVcto";
            this.dpick_FechaVcto.Size = new System.Drawing.Size(92, 20);
            this.dpick_FechaVcto.TabIndex = 100;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Location = new System.Drawing.Point(269, 148);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(131, 35);
            this.btn_Guardar.TabIndex = 101;
            this.btn_Guardar.Text = "Guardar";
            this.btn_Guardar.UseVisualStyleBackColor = true;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // InsertarCargoBancario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 195);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.dpick_FechaVcto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dpick_FechaEmision);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Monto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_NroCuenta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_Moneda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_Banco);
            this.Controls.Add(this.label1);
            this.Name = "InsertarCargoBancario";
            this.Text = "InsertarCargoBancario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Banco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Moneda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_NroCuenta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Monto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dpick_FechaEmision;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dpick_FechaVcto;
        private System.Windows.Forms.Button btn_Guardar;
    }
}