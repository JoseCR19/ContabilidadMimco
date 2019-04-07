namespace Contabilidad.Caja
{
    partial class AgregarCajaChica
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
            this.grdDocumento = new System.Windows.Forms.DataGridView();
            this.btn_Aceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_BuscarDocumento = new System.Windows.Forms.TextBox();
            this.grv_detalle = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_detalle)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDocumento
            // 
            this.grdDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDocumento.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdDocumento.Location = new System.Drawing.Point(4, 41);
            this.grdDocumento.Name = "grdDocumento";
            this.grdDocumento.RowHeadersVisible = false;
            this.grdDocumento.Size = new System.Drawing.Size(853, 316);
            this.grdDocumento.TabIndex = 8;
            this.grdDocumento.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDocumento_CellContentClick);
            this.grdDocumento.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grdDocumento_CellValidating);
            this.grdDocumento.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDocumento_CellValueChanged);
            this.grdDocumento.CurrentCellDirtyStateChanged += new System.EventHandler(this.grdDocumento_CurrentCellDirtyStateChanged);
            this.grdDocumento.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdDocumento_DataError);
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.Location = new System.Drawing.Point(710, 363);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(147, 29);
            this.btn_Aceptar.TabIndex = 9;
            this.btn_Aceptar.Text = "Aceptar";
            this.btn_Aceptar.UseVisualStyleBackColor = true;
            this.btn_Aceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Razon Social / RUC / N° Documento :";
            // 
            // txt_BuscarDocumento
            // 
            this.txt_BuscarDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_BuscarDocumento.Location = new System.Drawing.Point(4, 18);
            this.txt_BuscarDocumento.Name = "txt_BuscarDocumento";
            this.txt_BuscarDocumento.Size = new System.Drawing.Size(853, 20);
            this.txt_BuscarDocumento.TabIndex = 10;
            // 
            // grv_detalle
            // 
            this.grv_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grv_detalle.Location = new System.Drawing.Point(863, 41);
            this.grv_detalle.Name = "grv_detalle";
            this.grv_detalle.Size = new System.Drawing.Size(356, 316);
            this.grv_detalle.TabIndex = 12;
            // 
            // AgregarCajaChica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 399);
            this.Controls.Add(this.grv_detalle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_BuscarDocumento);
            this.Controls.Add(this.btn_Aceptar);
            this.Controls.Add(this.grdDocumento);
            this.Name = "AgregarCajaChica";
            this.Text = "AgregarCajaChica";
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv_detalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdDocumento;
        private System.Windows.Forms.Button btn_Aceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_BuscarDocumento;
        private System.Windows.Forms.DataGridView grv_detalle;
    }
}