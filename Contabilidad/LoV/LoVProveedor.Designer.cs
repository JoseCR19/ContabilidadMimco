namespace Contabilidad.LoV
{
    partial class LoVProveedor
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
            this.lbl_Buscar = new System.Windows.Forms.Label();
            this.txt_Busqueda = new System.Windows.Forms.TextBox();
            this.grdProveedor = new System.Windows.Forms.DataGridView();
            this.rb_Prov = new System.Windows.Forms.RadioButton();
            this.rb_Personal = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Buscar
            // 
            this.lbl_Buscar.AutoSize = true;
            this.lbl_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Buscar.Location = new System.Drawing.Point(12, 38);
            this.lbl_Buscar.Name = "lbl_Buscar";
            this.lbl_Buscar.Size = new System.Drawing.Size(131, 13);
            this.lbl_Buscar.TabIndex = 8;
            this.lbl_Buscar.Text = "Razón Social o RUC :";
            // 
            // txt_Busqueda
            // 
            this.txt_Busqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Busqueda.Location = new System.Drawing.Point(162, 35);
            this.txt_Busqueda.Name = "txt_Busqueda";
            this.txt_Busqueda.Size = new System.Drawing.Size(311, 20);
            this.txt_Busqueda.TabIndex = 7;
            // 
            // grdProveedor
            // 
            this.grdProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProveedor.Location = new System.Drawing.Point(15, 68);
            this.grdProveedor.Name = "grdProveedor";
            this.grdProveedor.ReadOnly = true;
            this.grdProveedor.RowHeadersVisible = false;
            this.grdProveedor.Size = new System.Drawing.Size(456, 311);
            this.grdProveedor.TabIndex = 6;
            // 
            // rb_Prov
            // 
            this.rb_Prov.AutoSize = true;
            this.rb_Prov.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Prov.Location = new System.Drawing.Point(130, 7);
            this.rb_Prov.Name = "rb_Prov";
            this.rb_Prov.Size = new System.Drawing.Size(83, 17);
            this.rb_Prov.TabIndex = 9;
            this.rb_Prov.TabStop = true;
            this.rb_Prov.Text = "Proveedor";
            this.rb_Prov.UseVisualStyleBackColor = true;
            // 
            // rb_Personal
            // 
            this.rb_Personal.AutoSize = true;
            this.rb_Personal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Personal.Location = new System.Drawing.Point(269, 7);
            this.rb_Personal.Name = "rb_Personal";
            this.rb_Personal.Size = new System.Drawing.Size(74, 17);
            this.rb_Personal.TabIndex = 10;
            this.rb_Personal.TabStop = true;
            this.rb_Personal.Text = "Personal";
            this.rb_Personal.UseVisualStyleBackColor = true;
            // 
            // LoVProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 389);
            this.Controls.Add(this.rb_Personal);
            this.Controls.Add(this.rb_Prov);
            this.Controls.Add(this.lbl_Buscar);
            this.Controls.Add(this.txt_Busqueda);
            this.Controls.Add(this.grdProveedor);
            this.Name = "LoVProveedor";
            this.Text = "LoVProveedor";
            ((System.ComponentModel.ISupportInitialize)(this.grdProveedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Buscar;
        private System.Windows.Forms.TextBox txt_Busqueda;
        private System.Windows.Forms.DataGridView grdProveedor;
        private System.Windows.Forms.RadioButton rb_Prov;
        private System.Windows.Forms.RadioButton rb_Personal;
    }
}