﻿namespace Contabilidad.LoV
{
    partial class LoVTipoPagoVoucher
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
            this.lbl_Solicita = new System.Windows.Forms.Label();
            this.txt_Busqueda = new System.Windows.Forms.TextBox();
            this.grdSolicita = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdSolicita)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Solicita
            // 
            this.lbl_Solicita.AutoSize = true;
            this.lbl_Solicita.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Solicita.Location = new System.Drawing.Point(12, 20);
            this.lbl_Solicita.Name = "lbl_Solicita";
            this.lbl_Solicita.Size = new System.Drawing.Size(136, 13);
            this.lbl_Solicita.TabIndex = 20;
            this.lbl_Solicita.Text = "Descripción o Código :";
            // 
            // txt_Busqueda
            // 
            this.txt_Busqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Busqueda.Location = new System.Drawing.Point(152, 17);
            this.txt_Busqueda.Name = "txt_Busqueda";
            this.txt_Busqueda.Size = new System.Drawing.Size(321, 20);
            this.txt_Busqueda.TabIndex = 19;
            // 
            // grdSolicita
            // 
            this.grdSolicita.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSolicita.Location = new System.Drawing.Point(15, 51);
            this.grdSolicita.Name = "grdSolicita";
            this.grdSolicita.ReadOnly = true;
            this.grdSolicita.RowHeadersVisible = false;
            this.grdSolicita.Size = new System.Drawing.Size(456, 326);
            this.grdSolicita.TabIndex = 18;
            // 
            // LoVTipoPagoVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 389);
            this.Controls.Add(this.lbl_Solicita);
            this.Controls.Add(this.txt_Busqueda);
            this.Controls.Add(this.grdSolicita);
            this.Name = "LoVTipoPagoVoucher";
            this.Text = "LoVTipoPagoVoucher";
            ((System.ComponentModel.ISupportInitialize)(this.grdSolicita)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Solicita;
        private System.Windows.Forms.TextBox txt_Busqueda;
        private System.Windows.Forms.DataGridView grdSolicita;
    }
}