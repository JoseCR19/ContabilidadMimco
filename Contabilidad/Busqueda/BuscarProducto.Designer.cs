namespace Contabilidad
{
    partial class BuscarProducto
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
            this.btn_Aceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_BuscarProducto = new System.Windows.Forms.TextBox();
            this.grd_Producto = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Producto)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.Location = new System.Drawing.Point(470, 375);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(141, 23);
            this.btn_Aceptar.TabIndex = 4;
            this.btn_Aceptar.Text = "Aceptar";
            this.btn_Aceptar.UseVisualStyleBackColor = true;
            this.btn_Aceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Código o Descripción :";
            // 
            // txt_BuscarProducto
            // 
            this.txt_BuscarProducto.Location = new System.Drawing.Point(152, 18);
            this.txt_BuscarProducto.Name = "txt_BuscarProducto";
            this.txt_BuscarProducto.Size = new System.Drawing.Size(459, 20);
            this.txt_BuscarProducto.TabIndex = 5;
            // 
            // grd_Producto
            // 
            this.grd_Producto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_Producto.Location = new System.Drawing.Point(13, 53);
            this.grd_Producto.Name = "grd_Producto";
            this.grd_Producto.Size = new System.Drawing.Size(598, 306);
            this.grd_Producto.TabIndex = 7;
            // 
            // BuscarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 410);
            this.Controls.Add(this.grd_Producto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_BuscarProducto);
            this.Controls.Add(this.btn_Aceptar);
            this.Name = "BuscarProducto";
            this.Text = "BuscarProducto";
            ((System.ComponentModel.ISupportInitialize)(this.grd_Producto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Aceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_BuscarProducto;
        private System.Windows.Forms.DataGridView grd_Producto;
    }
}