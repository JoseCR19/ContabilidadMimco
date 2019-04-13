namespace Conta.RegistroCompras
{
    partial class RegistrarAsientosCompras
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
            this.cmb_UnidadNegocio = new System.Windows.Forms.ComboBox();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.grd_Facturas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Facturas)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_UnidadNegocio
            // 
            this.cmb_UnidadNegocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_UnidadNegocio.FormattingEnabled = true;
            this.cmb_UnidadNegocio.Location = new System.Drawing.Point(325, 37);
            this.cmb_UnidadNegocio.Name = "cmb_UnidadNegocio";
            this.cmb_UnidadNegocio.Size = new System.Drawing.Size(257, 21);
            this.cmb_UnidadNegocio.TabIndex = 38;
            this.cmb_UnidadNegocio.SelectedIndexChanged += new System.EventHandler(this.cmb_UnidadNegocio_SelectedIndexChanged_1);
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Image = global::Contabilidad.Properties.Resources.close;
            this.btn_Cerrar.Location = new System.Drawing.Point(841, 389);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(49, 43);
            this.btn_Cerrar.TabIndex = 37;
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // grd_Facturas
            // 
            this.grd_Facturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_Facturas.Location = new System.Drawing.Point(26, 82);
            this.grd_Facturas.Name = "grd_Facturas";
            this.grd_Facturas.ReadOnly = true;
            this.grd_Facturas.Size = new System.Drawing.Size(864, 299);
            this.grd_Facturas.TabIndex = 36;
            // 
            // RegistrarAsientosCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 439);
            this.Controls.Add(this.cmb_UnidadNegocio);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.grd_Facturas);
            this.Name = "RegistrarAsientosCompras";
            this.Text = "RegistrarAsientosCompras";
            ((System.ComponentModel.ISupportInitialize)(this.grd_Facturas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_UnidadNegocio;
        private System.Windows.Forms.Button btn_Cerrar;
        private System.Windows.Forms.DataGridView grd_Facturas;
    }
}