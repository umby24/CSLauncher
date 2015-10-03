using CSLauncher.Properties;

namespace CSLauncher.Forms {
    partial class LoginForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.btnPrefs = new System.Windows.Forms.Button();
            this.comboUsername = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.serviceImage = new System.Windows.Forms.PictureBox();
            this.btnOptions = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.directToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singlePlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.serviceImage)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrefs
            // 
            this.btnPrefs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(143)))), ((int)(((byte)(217)))));
            this.btnPrefs.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrefs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrefs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrefs.ForeColor = System.Drawing.Color.White;
            this.btnPrefs.Location = new System.Drawing.Point(105, 154);
            this.btnPrefs.Name = "btnPrefs";
            this.btnPrefs.Size = new System.Drawing.Size(85, 23);
            this.btnPrefs.TabIndex = 0;
            this.btnPrefs.Text = "Preferences";
            this.btnPrefs.UseVisualStyleBackColor = false;
            this.btnPrefs.Click += new System.EventHandler(this.btnPrefs_Click);
            // 
            // comboUsername
            // 
            this.comboUsername.FormattingEnabled = true;
            this.comboUsername.Location = new System.Drawing.Point(12, 101);
            this.comboUsername.Name = "comboUsername";
            this.comboUsername.Size = new System.Drawing.Size(268, 21);
            this.comboUsername.TabIndex = 2;
            this.comboUsername.SelectedIndexChanged += new System.EventHandler(this.comboUsername_SelectedIndexChanged);
            this.comboUsername.TextChanged += new System.EventHandler(this.comboUsername_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(12, 128);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(268, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // btnResume
            // 
            this.btnResume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(143)))), ((int)(((byte)(217)))));
            this.btnResume.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResume.ForeColor = System.Drawing.Color.White;
            this.btnResume.Location = new System.Drawing.Point(12, 154);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(66, 23);
            this.btnResume.TabIndex = 4;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = false;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(143)))), ((int)(((byte)(217)))));
            this.btnSignIn.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignIn.ForeColor = System.Drawing.Color.White;
            this.btnSignIn.Location = new System.Drawing.Point(205, 154);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(75, 23);
            this.btnSignIn.TabIndex = 5;
            this.btnSignIn.Text = "Sign In >";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // serviceImage
            // 
            this.serviceImage.BackColor = System.Drawing.Color.Transparent;
            this.serviceImage.Image = global::CSLauncher.Properties.Resources.ClassiCubeLogo;
            this.serviceImage.Location = new System.Drawing.Point(12, 12);
            this.serviceImage.Name = "serviceImage";
            this.serviceImage.Size = new System.Drawing.Size(268, 83);
            this.serviceImage.TabIndex = 6;
            this.serviceImage.TabStop = false;
            // 
            // btnOptions
            // 
            this.btnOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(143)))), ((int)(((byte)(217)))));
            this.btnOptions.ContextMenuStrip = this.contextMenuStrip1;
            this.btnOptions.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptions.ForeColor = System.Drawing.Color.White;
            this.btnOptions.Location = new System.Drawing.Point(74, 154);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(16, 23);
            this.btnOptions.TabIndex = 7;
            this.btnOptions.Text = "▼";
            this.btnOptions.UseVisualStyleBackColor = false;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.directToolStripMenuItem,
            this.singlePlayerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 48);
            // 
            // directToolStripMenuItem
            // 
            this.directToolStripMenuItem.Name = "directToolStripMenuItem";
            this.directToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.directToolStripMenuItem.Text = "Direct...";
            this.directToolStripMenuItem.Click += new System.EventHandler(this.directToolStripMenuItem_Click);
            // 
            // singlePlayerToolStripMenuItem
            // 
            this.singlePlayerToolStripMenuItem.Name = "singlePlayerToolStripMenuItem";
            this.singlePlayerToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.singlePlayerToolStripMenuItem.Text = "Single Player";
            this.singlePlayerToolStripMenuItem.Click += new System.EventHandler(this.singlePlayerToolStripMenuItem_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnSignIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CSLauncher.Properties.Resources.ClassiCubeBG;
            this.ClientSize = new System.Drawing.Size(292, 187);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.serviceImage);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.comboUsername);
            this.Controls.Add(this.btnPrefs);
            this.Name = "LoginForm";
            this.Text = "ClassicalSharp Launcher";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.serviceImage)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrefs;
        private System.Windows.Forms.ComboBox comboUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.PictureBox serviceImage;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem directToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singlePlayerToolStripMenuItem;
    }
}

