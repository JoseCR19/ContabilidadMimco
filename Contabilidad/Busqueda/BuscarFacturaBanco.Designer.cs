﻿namespace Contabilidad.Busqueda
{
    partial class BuscarFacturaBanco
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_BuscarDocumento = new System.Windows.Forms.TextBox();
            this.btn_Aceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumento)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDocumento
            // 
            this.grdDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDocumento.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdDocumento.Location = new System.Drawing.Point(13, 53);
            this.grdDocumento.Name = "grdDocumento";
            this.grdDocumento.RowHeadersVisible = false;
            this.grdDocumento.Size = new System.Drawing.Size(810, 399);
            this.grdDocumento.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Razon Social / RUC / N° Documento :";
            // 
            // txt_BuscarDocumento
            // 
            this.txt_BuscarDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_BuscarDocumento.Location = new System.Drawing.Point(12, 24);
            this.txt_BuscarDocumento.Name = "txt_BuscarDocumento";
            this.txt_BuscarDocumento.Size = new System.Drawing.Size(811, 20);
            this.txt_BuscarDocumento.TabIndex = 7;
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.Location = new System.Drawing.Point(659, 458);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(164, 23);
            this.btn_Aceptar.TabIndex = 9;
            this.btn_Aceptar.Text = "Aceptar";
            this.btn_Aceptar.UseVisualStyleBackColor = true;
            this.btn_Aceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // BuscarFacturaBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 500);
            this.Controls.Add(this.btn_Aceptar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_BuscarDocumento);
            this.Controls.Add(this.grdDocumento);
            this.Name = "BuscarFacturaBanco";
            this.Text = "BuscarFacturaBanco";
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdDocumento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_BuscarDocumento;
        private System.Windows.Forms.Button btn_Aceptar;
    }
}