
namespace ChatCliente
{
    partial class frmCliente
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCliente));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServidorIP = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.txtMensagem = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAnexaImagem = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servidor IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario";
            // 
            // txtServidorIP
            // 
            this.txtServidorIP.Location = new System.Drawing.Point(91, 23);
            this.txtServidorIP.Name = "txtServidorIP";
            this.txtServidorIP.Size = new System.Drawing.Size(126, 23);
            this.txtServidorIP.TabIndex = 2;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(303, 23);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(156, 23);
            this.txtUsuario.TabIndex = 3;
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(465, 22);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(75, 23);
            this.btnConectar.TabIndex = 4;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // txtMensagem
            // 
            this.txtMensagem.Location = new System.Drawing.Point(22, 477);
            this.txtMensagem.Multiline = true;
            this.txtMensagem.Name = "txtMensagem";
            this.txtMensagem.Size = new System.Drawing.Size(390, 48);
            this.txtMensagem.TabIndex = 6;
            this.txtMensagem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMensagem_KeyPress);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.Azure;
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviar.Image")));
            this.btnEnviar.Location = new System.Drawing.Point(465, 477);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 48);
            this.btnEnviar.TabIndex = 7;
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-9, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(602, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "_________________________________________________________________________________" +
    "______________________________________";
            // 
            // btnAnexaImagem
            // 
            this.btnAnexaImagem.BackColor = System.Drawing.Color.Azure;
            this.btnAnexaImagem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnexaImagem.Image = ((System.Drawing.Image)(resources.GetObject("btnAnexaImagem.Image")));
            this.btnAnexaImagem.Location = new System.Drawing.Point(418, 477);
            this.btnAnexaImagem.Name = "btnAnexaImagem";
            this.btnAnexaImagem.Size = new System.Drawing.Size(41, 48);
            this.btnAnexaImagem.TabIndex = 9;
            this.btnAnexaImagem.UseVisualStyleBackColor = false;
            this.btnAnexaImagem.Click += new System.EventHandler(this.btnAnexaImagem_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(22, 90);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(518, 363);
            this.txtLog.TabIndex = 10;
            this.txtLog.Text = "";
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(568, 548);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnAnexaImagem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtMensagem);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtServidorIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCliente";
            this.Text = "Usuario";
            this.Load += new System.EventHandler(this.frmCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServidorIP;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.TextBox txtMensagem;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAnexaImagem;
        private System.Windows.Forms.RichTextBox txtLog;
    }
}

