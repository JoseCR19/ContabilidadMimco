namespace Conta.PlanDeCuenta
{
    partial class PlanContable
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
            this.txt_Cuenta = new System.Windows.Forms.TextBox();
            this.txt_Descripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_TipoCuenta = new System.Windows.Forms.ComboBox();
            this.txt_Tipo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Nivel = new System.Windows.Forms.TextBox();
            this.cmb_NivelSaldo = new System.Windows.Forms.ComboBox();
            this.txt_Anexo = new System.Windows.Forms.TextBox();
            this.cmb_TipoAnexo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_MonedaCod = new System.Windows.Forms.TextBox();
            this.cmb_Moneda = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.btn_SaveData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Cuenta :";
            // 
            // txt_Cuenta
            // 
            this.txt_Cuenta.Location = new System.Drawing.Point(105, 36);
            this.txt_Cuenta.Name = "txt_Cuenta";
            this.txt_Cuenta.Size = new System.Drawing.Size(100, 20);
            this.txt_Cuenta.TabIndex = 52;
            // 
            // txt_Descripcion
            // 
            this.txt_Descripcion.Location = new System.Drawing.Point(214, 36);
            this.txt_Descripcion.Name = "txt_Descripcion";
            this.txt_Descripcion.Size = new System.Drawing.Size(296, 20);
            this.txt_Descripcion.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Tipo Cuenta :";
            // 
            // cmb_TipoCuenta
            // 
            this.cmb_TipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TipoCuenta.FormattingEnabled = true;
            this.cmb_TipoCuenta.Location = new System.Drawing.Point(157, 70);
            this.cmb_TipoCuenta.Name = "cmb_TipoCuenta";
            this.cmb_TipoCuenta.Size = new System.Drawing.Size(192, 21);
            this.cmb_TipoCuenta.TabIndex = 55;
            // 
            // txt_Tipo
            // 
            this.txt_Tipo.Enabled = false;
            this.txt_Tipo.Location = new System.Drawing.Point(105, 71);
            this.txt_Tipo.Name = "txt_Tipo";
            this.txt_Tipo.Size = new System.Drawing.Size(37, 20);
            this.txt_Tipo.TabIndex = 56;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Nivel Saldo :";
            // 
            // txt_Nivel
            // 
            this.txt_Nivel.Enabled = false;
            this.txt_Nivel.Location = new System.Drawing.Point(105, 113);
            this.txt_Nivel.Name = "txt_Nivel";
            this.txt_Nivel.Size = new System.Drawing.Size(37, 20);
            this.txt_Nivel.TabIndex = 59;
            // 
            // cmb_NivelSaldo
            // 
            this.cmb_NivelSaldo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_NivelSaldo.FormattingEnabled = true;
            this.cmb_NivelSaldo.Location = new System.Drawing.Point(157, 112);
            this.cmb_NivelSaldo.Name = "cmb_NivelSaldo";
            this.cmb_NivelSaldo.Size = new System.Drawing.Size(192, 21);
            this.cmb_NivelSaldo.TabIndex = 58;
            // 
            // txt_Anexo
            // 
            this.txt_Anexo.Enabled = false;
            this.txt_Anexo.Location = new System.Drawing.Point(105, 148);
            this.txt_Anexo.Name = "txt_Anexo";
            this.txt_Anexo.Size = new System.Drawing.Size(37, 20);
            this.txt_Anexo.TabIndex = 62;
            // 
            // cmb_TipoAnexo
            // 
            this.cmb_TipoAnexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TipoAnexo.FormattingEnabled = true;
            this.cmb_TipoAnexo.Location = new System.Drawing.Point(157, 147);
            this.cmb_TipoAnexo.Name = "cmb_TipoAnexo";
            this.cmb_TipoAnexo.Size = new System.Drawing.Size(192, 21);
            this.cmb_TipoAnexo.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Tipo Anexo :";
            // 
            // txt_MonedaCod
            // 
            this.txt_MonedaCod.Enabled = false;
            this.txt_MonedaCod.Location = new System.Drawing.Point(105, 184);
            this.txt_MonedaCod.Name = "txt_MonedaCod";
            this.txt_MonedaCod.Size = new System.Drawing.Size(37, 20);
            this.txt_MonedaCod.TabIndex = 68;
            // 
            // cmb_Moneda
            // 
            this.cmb_Moneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Moneda.FormattingEnabled = true;
            this.cmb_Moneda.Location = new System.Drawing.Point(157, 183);
            this.cmb_Moneda.Name = "cmb_Moneda";
            this.cmb_Moneda.Size = new System.Drawing.Size(192, 21);
            this.cmb_Moneda.TabIndex = 67;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 66;
            this.label6.Text = "Moneda :";
            // 
            // btn_Editar
            // 
            this.btn_Editar.Image = global::Contabilidad.Properties.Resources.editICon;
            this.btn_Editar.Location = new System.Drawing.Point(251, 234);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(48, 46);
            this.btn_Editar.TabIndex = 71;
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Visible = false;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Image = global::Contabilidad.Properties.Resources.close;
            this.btn_Cerrar.Location = new System.Drawing.Point(427, 237);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(49, 43);
            this.btn_Cerrar.TabIndex = 70;
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // btn_SaveData
            // 
            this.btn_SaveData.Image = global::Contabilidad.Properties.Resources.saveopt;
            this.btn_SaveData.Location = new System.Drawing.Point(70, 234);
            this.btn_SaveData.Name = "btn_SaveData";
            this.btn_SaveData.Size = new System.Drawing.Size(48, 46);
            this.btn_SaveData.TabIndex = 69;
            this.btn_SaveData.UseVisualStyleBackColor = true;
            this.btn_SaveData.Click += new System.EventHandler(this.btn_SaveData_Click);
            // 
            // PlanContable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 303);
            this.Controls.Add(this.btn_Editar);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.btn_SaveData);
            this.Controls.Add(this.txt_MonedaCod);
            this.Controls.Add(this.cmb_Moneda);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_Anexo);
            this.Controls.Add(this.cmb_TipoAnexo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Nivel);
            this.Controls.Add(this.cmb_NivelSaldo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Tipo);
            this.Controls.Add(this.cmb_TipoCuenta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Descripcion);
            this.Controls.Add(this.txt_Cuenta);
            this.Controls.Add(this.label3);
            this.Name = "PlanContable";
            this.Text = "PlanContable";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Cuenta;
        private System.Windows.Forms.TextBox txt_Descripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_TipoCuenta;
        private System.Windows.Forms.TextBox txt_Tipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Nivel;
        private System.Windows.Forms.ComboBox cmb_NivelSaldo;
        private System.Windows.Forms.TextBox txt_Anexo;
        private System.Windows.Forms.ComboBox cmb_TipoAnexo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_MonedaCod;
        private System.Windows.Forms.ComboBox cmb_Moneda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_SaveData;
        private System.Windows.Forms.Button btn_Cerrar;
        private System.Windows.Forms.Button btn_Editar;
    }
}