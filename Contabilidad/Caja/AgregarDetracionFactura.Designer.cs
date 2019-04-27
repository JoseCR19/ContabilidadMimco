namespace Contabilidad.Caja
{
    partial class AgregarDetracionFactura
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_BuscarDocumento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_BuscarDocumentoD = new System.Windows.Forms.TextBox();
            this.grdDocumento = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_ruc = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmb_all = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumento)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-237, -64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Razon Social / RUC / N° Documento :";
            // 
            // txt_BuscarDocumento
            // 
            this.txt_BuscarDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_BuscarDocumento.Location = new System.Drawing.Point(-237, -47);
            this.txt_BuscarDocumento.Name = "txt_BuscarDocumento";
            this.txt_BuscarDocumento.Size = new System.Drawing.Size(759, 20);
            this.txt_BuscarDocumento.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Razon Social / RUC / N° Documento :";
            // 
            // txt_BuscarDocumentoD
            // 
            this.txt_BuscarDocumentoD.Location = new System.Drawing.Point(15, 31);
            this.txt_BuscarDocumentoD.Name = "txt_BuscarDocumentoD";
            this.txt_BuscarDocumentoD.Size = new System.Drawing.Size(897, 20);
            this.txt_BuscarDocumentoD.TabIndex = 20;
            this.txt_BuscarDocumentoD.TextChanged += new System.EventHandler(this.txt_BuscarDocumentoD_TextChanged);
            // 
            // grdDocumento
            // 
            this.grdDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDocumento.Location = new System.Drawing.Point(15, 57);
            this.grdDocumento.Name = "grdDocumento";
            this.grdDocumento.Size = new System.Drawing.Size(897, 316);
            this.grdDocumento.TabIndex = 21;
            this.grdDocumento.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDocumento_CellContentClick);
            this.grdDocumento.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDocumento_CellEndEdit);
            this.grdDocumento.CurrentCellDirtyStateChanged += new System.EventHandler(this.grdDocumento_CurrentCellDirtyStateChanged);
            this.grdDocumento.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdDocumento_DataError_1);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(793, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 31);
            this.button1.TabIndex = 22;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_ruc
            // 
            this.txt_ruc.Enabled = false;
            this.txt_ruc.Location = new System.Drawing.Point(12, 379);
            this.txt_ruc.Name = "txt_ruc";
            this.txt_ruc.Size = new System.Drawing.Size(100, 20);
            this.txt_ruc.TabIndex = 23;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // cmb_all
            // 
            this.cmb_all.DisplayMember = "detra";
            this.cmb_all.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_all.FormattingEnabled = true;
            this.cmb_all.Items.AddRange(new object[] {
            "Todos",
            "Detracciones"});
            this.cmb_all.Location = new System.Drawing.Point(757, 6);
            this.cmb_all.Name = "cmb_all";
            this.cmb_all.Size = new System.Drawing.Size(98, 21);
            this.cmb_all.TabIndex = 100;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::Contabilidad.Properties.Resources.lupamedio;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Image = global::Contabilidad.Properties.Resources.lupamedio;
            this.button2.Location = new System.Drawing.Point(861, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 21);
            this.button2.TabIndex = 101;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AgregarDetracionFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 421);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmb_all);
            this.Controls.Add(this.txt_ruc);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grdDocumento);
            this.Controls.Add(this.txt_BuscarDocumentoD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_BuscarDocumento);
            this.Name = "AgregarDetracionFactura";
            this.Text = "AgregarDetracionFactura";
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_BuscarDocumento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_BuscarDocumentoD;
        private System.Windows.Forms.DataGridView grdDocumento;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_ruc;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox cmb_all;
        private System.Windows.Forms.Button button2;
    }
}