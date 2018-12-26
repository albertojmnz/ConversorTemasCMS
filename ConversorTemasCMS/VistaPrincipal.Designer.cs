using System;
using System.Windows.Forms;

namespace ConversorTemasCMS
{
    partial class VistaPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ofdCargarFicheroHtml = new System.Windows.Forms.OpenFileDialog();
            this.ofdCargarFicheroXml = new System.Windows.Forms.OpenFileDialog();
            this.sfdExaminar = new System.Windows.Forms.SaveFileDialog();
            this.txtFicheroHtml = new System.Windows.Forms.TextBox();
            this.btnFicheroHtml = new System.Windows.Forms.Button();
            this.txtFicheroXml = new System.Windows.Forms.TextBox();
            this.btnFicheroXml = new System.Windows.Forms.Button();
            this.btnGenerarTema = new System.Windows.Forms.Button();
            this.pnlMensajes = new System.Windows.Forms.Panel();
            this.lblMensajes = new System.Windows.Forms.Label();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.ddlIdioma = new System.Windows.Forms.ComboBox();
            this.lblIdioma = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnlMensajes.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdCargarFicheroHtml
            // 
            this.ofdCargarFicheroHtml.DefaultExt = "html";
            this.ofdCargarFicheroHtml.FileName = "ofdCargarFichero";
            this.ofdCargarFicheroHtml.Tag = "Cargar fichero";
            this.ofdCargarFicheroHtml.Title = "Cargar fichero";
            // 
            // ofdCargarFicheroXml
            // 
            this.ofdCargarFicheroXml.DefaultExt = "xml";
            this.ofdCargarFicheroXml.FileName = "ofdCargarFichero";
            this.ofdCargarFicheroXml.Tag = "Cargar fichero";
            this.ofdCargarFicheroXml.Title = "Cargar fichero";
            // 
            // sfdExaminar
            // 
            this.sfdExaminar.FileName = "page.tpl";
            this.sfdExaminar.DefaultExt = ".php";
            this.sfdExaminar.Filter = "PHP (*.php)|*.php";
            this.sfdExaminar.Tag = "Examinar";
            this.sfdExaminar.Title = "Examinar";
            // 
            // txtFicheroHtml
            // 
            this.txtFicheroHtml.Enabled = false;
            this.txtFicheroHtml.Location = new System.Drawing.Point(52, 94);
            this.txtFicheroHtml.Name = "txtFicheroHtml";
            this.txtFicheroHtml.Size = new System.Drawing.Size(468, 20);
            this.txtFicheroHtml.TabIndex = 0;
            // 
            // btnFicheroHtml
            // 
            this.btnFicheroHtml.Location = new System.Drawing.Point(584, 91);
            this.btnFicheroHtml.Name = "btnFicheroHtml";
            this.btnFicheroHtml.Size = new System.Drawing.Size(146, 23);
            this.btnFicheroHtml.TabIndex = 1;
            this.btnFicheroHtml.Text = "Seleccionar Fichero (.Html)";
            this.btnFicheroHtml.UseVisualStyleBackColor = true;
            this.btnFicheroHtml.Click += new System.EventHandler(this.btnFicheroHtml_Click);
            // 
            // txtFicheroXml
            // 
            this.txtFicheroXml.Enabled = false;
            this.txtFicheroXml.Location = new System.Drawing.Point(52, 135);
            this.txtFicheroXml.Name = "txtFicheroXml";
            this.txtFicheroXml.Size = new System.Drawing.Size(468, 20);
            this.txtFicheroXml.TabIndex = 2;
            // 
            // btnFicheroXml
            // 
            this.btnFicheroXml.Location = new System.Drawing.Point(584, 132);
            this.btnFicheroXml.Name = "btnFicheroXml";
            this.btnFicheroXml.Size = new System.Drawing.Size(146, 23);
            this.btnFicheroXml.TabIndex = 3;
            this.btnFicheroXml.Text = "Seleccionar Fichero (.Xml)";
            this.btnFicheroXml.UseVisualStyleBackColor = true;
            this.btnFicheroXml.Click += new System.EventHandler(this.btnFicheroXml_Click);
            // 
            // btnConvertir
            // 
            this.btnGenerarTema.Location = new System.Drawing.Point(324, 226);
            this.btnGenerarTema.Name = "btnConvertir";
            this.btnGenerarTema.Size = new System.Drawing.Size(146, 23);
            this.btnGenerarTema.TabIndex = 4;
            this.btnGenerarTema.Text = "Convertir";
            this.btnGenerarTema.UseVisualStyleBackColor = true;
            this.btnGenerarTema.Click += new System.EventHandler(this.btnGenerarTema_Click);
            // 
            // pnlMensajes
            // 
            this.pnlMensajes.AutoScroll = true;
            this.pnlMensajes.BackColor = System.Drawing.SystemColors.Desktop;
            this.pnlMensajes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMensajes.Controls.Add(this.lblMensajes);
            this.pnlMensajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMensajes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pnlMensajes.Location = new System.Drawing.Point(52, 278);
            this.pnlMensajes.Name = "pnlMensajes";
            this.pnlMensajes.Size = new System.Drawing.Size(678, 79);
            this.pnlMensajes.TabIndex = 5;
            // 
            // lblMensajes
            // 
            this.lblMensajes.AutoSize = true;
            this.lblMensajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajes.Location = new System.Drawing.Point(0, 27);
            this.lblMensajes.Margin = new System.Windows.Forms.Padding(0);
            this.lblMensajes.Name = "lblMensajes";
            this.lblMensajes.Size = new System.Drawing.Size(0, 18);
            this.lblMensajes.TabIndex = 0;
            // 
            // txtDestino
            // 
            this.txtDestino.Enabled = false;
            this.txtDestino.Location = new System.Drawing.Point(52, 181);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(468, 20);
            this.txtDestino.TabIndex = 6;
            // 
            // btnExaminar
            // 
            this.btnExaminar.Location = new System.Drawing.Point(584, 178);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(146, 23);
            this.btnExaminar.TabIndex = 7;
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // ddlIdioma
            // 
            this.ddlIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlIdioma.FormattingEnabled = true;
            this.ddlIdioma.Location = new System.Drawing.Point(52, 26);
            this.ddlIdioma.Name = "ddlIdioma";
            this.ddlIdioma.Size = new System.Drawing.Size(121, 21);
            this.ddlIdioma.TabIndex = 8;
            this.ddlIdioma.SelectedIndexChanged += new System.EventHandler(this.ddlIdioma_SelectedIndexChanged);
            // 
            // lblIdioma
            // 
            this.lblIdioma.AutoSize = true;
            this.lblIdioma.Location = new System.Drawing.Point(49, 10);
            this.lblIdioma.Name = "lblIdioma";
            this.lblIdioma.Size = new System.Drawing.Size(41, 13);
            this.lblIdioma.TabIndex = 9;
            this.lblIdioma.Text = "Idioma:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Formulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(817, 383);
            this.Controls.Add(this.lblIdioma);
            this.Controls.Add(this.ddlIdioma);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.pnlMensajes);
            this.Controls.Add(this.btnGenerarTema);
            this.Controls.Add(this.btnFicheroXml);
            this.Controls.Add(this.txtFicheroXml);
            this.Controls.Add(this.btnFicheroHtml);
            this.Controls.Add(this.txtFicheroHtml);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Formulario";
            this.Text = "Convertidor";
            this.Load += new System.EventHandler(this.Formulario_Load);
            this.pnlMensajes.ResumeLayout(false);
            this.pnlMensajes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdCargarFicheroHtml;
        private System.Windows.Forms.OpenFileDialog ofdCargarFicheroXml;
        private System.Windows.Forms.SaveFileDialog sfdExaminar;
        private System.Windows.Forms.TextBox txtFicheroHtml;
        private System.Windows.Forms.Button btnFicheroHtml;
        private System.Windows.Forms.TextBox txtFicheroXml;
        private System.Windows.Forms.Button btnFicheroXml;
        private System.Windows.Forms.Button btnGenerarTema;
        private System.Windows.Forms.Panel pnlMensajes;
        private System.Windows.Forms.Label lblMensajes;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.ComboBox ddlIdioma;
        private System.Windows.Forms.Label lblIdioma;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

