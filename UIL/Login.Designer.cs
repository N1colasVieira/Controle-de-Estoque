namespace UIL
{
    partial class Login
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
            this.pnlButton = new System.Windows.Forms.Panel();
            this.lblMinimize = new System.Windows.Forms.Label();
            this.lblMaximize = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblNameHeader = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEsqueceuSenha = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNovoUsuario = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.PictureBox();
            this.pnlBorda = new System.Windows.Forms.Panel();
            this.pnlButton.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogin)).BeginInit();
            this.pnlBorda.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButton
            // 
            this.pnlButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlButton.Controls.Add(this.lblMinimize);
            this.pnlButton.Controls.Add(this.lblMaximize);
            this.pnlButton.Controls.Add(this.lblClose);
            this.pnlButton.Location = new System.Drawing.Point(268, 0);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(82, 34);
            this.pnlButton.TabIndex = 1;
            // 
            // lblMinimize
            // 
            this.lblMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinimize.AutoSize = true;
            this.lblMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimize.ForeColor = System.Drawing.Color.White;
            this.lblMinimize.Location = new System.Drawing.Point(7, 9);
            this.lblMinimize.Name = "lblMinimize";
            this.lblMinimize.Size = new System.Drawing.Size(0, 20);
            this.lblMinimize.TabIndex = 2;
            // 
            // lblMaximize
            // 
            this.lblMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaximize.AutoSize = true;
            this.lblMaximize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaximize.ForeColor = System.Drawing.Color.White;
            this.lblMaximize.Location = new System.Drawing.Point(30, 9);
            this.lblMaximize.Name = "lblMaximize";
            this.lblMaximize.Size = new System.Drawing.Size(0, 20);
            this.lblMaximize.TabIndex = 1;
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.AutoSize = true;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(53, 9);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(21, 20);
            this.lblClose.TabIndex = 0;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseEnter += new System.EventHandler(this.lblClose_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlHeader.Controls.Add(this.pnlButton);
            this.pnlHeader.Controls.Add(this.lblNameHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(350, 34);
            this.pnlHeader.TabIndex = 7;
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseDown);
            this.pnlHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseMove);
            this.pnlHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseUp);
            // 
            // lblNameHeader
            // 
            this.lblNameHeader.AutoSize = true;
            this.lblNameHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameHeader.ForeColor = System.Drawing.Color.White;
            this.lblNameHeader.Location = new System.Drawing.Point(12, 9);
            this.lblNameHeader.Name = "lblNameHeader";
            this.lblNameHeader.Size = new System.Drawing.Size(53, 20);
            this.lblNameHeader.TabIndex = 0;
            this.lblNameHeader.Text = "Login";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(82, 22);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(181, 26);
            this.txtUsuario.TabIndex = 8;
            // 
            // txtSenha
            // 
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(82, 62);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(181, 26);
            this.txtSenha.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Usuário";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(20, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Senha";
            // 
            // lblEsqueceuSenha
            // 
            this.lblEsqueceuSenha.AutoSize = true;
            this.lblEsqueceuSenha.ForeColor = System.Drawing.Color.White;
            this.lblEsqueceuSenha.Location = new System.Drawing.Point(36, 103);
            this.lblEsqueceuSenha.Name = "lblEsqueceuSenha";
            this.lblEsqueceuSenha.Size = new System.Drawing.Size(86, 13);
            this.lblEsqueceuSenha.TabIndex = 12;
            this.lblEsqueceuSenha.Text = "Esqueci a senha";
            this.lblEsqueceuSenha.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblEsqueceuSenha_MouseClick);
            this.lblEsqueceuSenha.MouseEnter += new System.EventHandler(this.lblEsqueceuSenha_MouseEnter);
            this.lblEsqueceuSenha.MouseLeave += new System.EventHandler(this.lblEsqueceuSenha_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(128, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "/";
            // 
            // lblNovoUsuario
            // 
            this.lblNovoUsuario.AutoSize = true;
            this.lblNovoUsuario.ForeColor = System.Drawing.Color.White;
            this.lblNovoUsuario.Location = new System.Drawing.Point(147, 103);
            this.lblNovoUsuario.Name = "lblNovoUsuario";
            this.lblNovoUsuario.Size = new System.Drawing.Size(116, 13);
            this.lblNovoUsuario.TabIndex = 14;
            this.lblNovoUsuario.Text = "Cadastrar novo usuário";
            this.lblNovoUsuario.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblNovoUsuario_MouseClick);
            this.lblNovoUsuario.MouseEnter += new System.EventHandler(this.lblNovoUsuario_MouseEnter);
            this.lblNovoUsuario.MouseLeave += new System.EventHandler(this.lblNovoUsuario_MouseLeave);
            // 
            // btnLogin
            // 
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.Location = new System.Drawing.Point(273, 25);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(63, 63);
            this.btnLogin.TabIndex = 16;
            this.btnLogin.TabStop = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.MouseEnter += new System.EventHandler(this.btnLogin_MouseEnter);
            this.btnLogin.MouseLeave += new System.EventHandler(this.btnLogin_MouseLeave);
            // 
            // pnlBorda
            // 
            this.pnlBorda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBorda.Controls.Add(this.label1);
            this.pnlBorda.Controls.Add(this.btnLogin);
            this.pnlBorda.Controls.Add(this.txtUsuario);
            this.pnlBorda.Controls.Add(this.txtSenha);
            this.pnlBorda.Controls.Add(this.lblNovoUsuario);
            this.pnlBorda.Controls.Add(this.label2);
            this.pnlBorda.Controls.Add(this.label3);
            this.pnlBorda.Controls.Add(this.lblEsqueceuSenha);
            this.pnlBorda.Location = new System.Drawing.Point(1, 34);
            this.pnlBorda.Name = "pnlBorda";
            this.pnlBorda.Size = new System.Drawing.Size(348, 135);
            this.pnlBorda.TabIndex = 17;
            // 
            // ILogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(350, 170);
            this.Controls.Add(this.pnlBorda);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ILogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ILogin";
            this.Load += new System.EventHandler(this.ILogin_Load);
            this.pnlButton.ResumeLayout(false);
            this.pnlButton.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogin)).EndInit();
            this.pnlBorda.ResumeLayout(false);
            this.pnlBorda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Label lblMinimize;
        private System.Windows.Forms.Label lblMaximize;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblNameHeader;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEsqueceuSenha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNovoUsuario;
        private System.Windows.Forms.PictureBox btnLogin;
        private System.Windows.Forms.Panel pnlBorda;
    }
}