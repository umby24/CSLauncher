namespace CSLauncher.Forms {
    partial class PreferencesForm {
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
            this.chkLauncherOpen = new System.Windows.Forms.CheckBox();
            this.chkUsernames = new System.Windows.Forms.CheckBox();
            this.chkPasswords = new System.Windows.Forms.CheckBox();
            this.chkServers = new System.Windows.Forms.CheckBox();
            this.btnForgetUsernames = new System.Windows.Forms.Button();
            this.btnForgetPasswords = new System.Windows.Forms.Button();
            this.btnForgetServer = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkLauncherOpen
            // 
            this.chkLauncherOpen.AutoSize = true;
            this.chkLauncherOpen.Font = new System.Drawing.Font("Source Sans Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLauncherOpen.ForeColor = System.Drawing.Color.White;
            this.chkLauncherOpen.Location = new System.Drawing.Point(3, 12);
            this.chkLauncherOpen.Name = "chkLauncherOpen";
            this.chkLauncherOpen.Size = new System.Drawing.Size(132, 19);
            this.chkLauncherOpen.TabIndex = 0;
            this.chkLauncherOpen.Text = "Keep Launcher Open";
            this.chkLauncherOpen.UseVisualStyleBackColor = true;
            // 
            // chkUsernames
            // 
            this.chkUsernames.AutoSize = true;
            this.chkUsernames.Font = new System.Drawing.Font("Source Sans Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUsernames.ForeColor = System.Drawing.Color.White;
            this.chkUsernames.Location = new System.Drawing.Point(3, 89);
            this.chkUsernames.Name = "chkUsernames";
            this.chkUsernames.Size = new System.Drawing.Size(141, 19);
            this.chkUsernames.TabIndex = 1;
            this.chkUsernames.Text = "Remember Usernames";
            this.chkUsernames.UseVisualStyleBackColor = true;
            // 
            // chkPasswords
            // 
            this.chkPasswords.AutoSize = true;
            this.chkPasswords.Font = new System.Drawing.Font("Source Sans Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPasswords.ForeColor = System.Drawing.Color.White;
            this.chkPasswords.Location = new System.Drawing.Point(3, 127);
            this.chkPasswords.Name = "chkPasswords";
            this.chkPasswords.Size = new System.Drawing.Size(138, 19);
            this.chkPasswords.TabIndex = 2;
            this.chkPasswords.Text = "Remember Passwords";
            this.chkPasswords.UseVisualStyleBackColor = true;
            // 
            // chkServers
            // 
            this.chkServers.AutoSize = true;
            this.chkServers.Font = new System.Drawing.Font("Source Sans Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkServers.ForeColor = System.Drawing.Color.White;
            this.chkServers.Location = new System.Drawing.Point(3, 165);
            this.chkServers.Name = "chkServers";
            this.chkServers.Size = new System.Drawing.Size(177, 19);
            this.chkServers.TabIndex = 3;
            this.chkServers.Text = "Remember Last Joined Server";
            this.chkServers.UseVisualStyleBackColor = true;
            // 
            // btnForgetUsernames
            // 
            this.btnForgetUsernames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(130)))), ((int)(((byte)(183)))));
            this.btnForgetUsernames.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(115)))), ((int)(((byte)(172)))));
            this.btnForgetUsernames.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(92)))), ((int)(((byte)(159)))));
            this.btnForgetUsernames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForgetUsernames.Font = new System.Drawing.Font("Source Sans Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForgetUsernames.ForeColor = System.Drawing.Color.White;
            this.btnForgetUsernames.Location = new System.Drawing.Point(186, 80);
            this.btnForgetUsernames.Name = "btnForgetUsernames";
            this.btnForgetUsernames.Size = new System.Drawing.Size(136, 32);
            this.btnForgetUsernames.TabIndex = 4;
            this.btnForgetUsernames.Text = "Forget Usernames";
            this.btnForgetUsernames.UseVisualStyleBackColor = false;
            this.btnForgetUsernames.Click += new System.EventHandler(this.btnForgetUsernames_Click);
            // 
            // btnForgetPasswords
            // 
            this.btnForgetPasswords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(130)))), ((int)(((byte)(183)))));
            this.btnForgetPasswords.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(115)))), ((int)(((byte)(172)))));
            this.btnForgetPasswords.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(92)))), ((int)(((byte)(159)))));
            this.btnForgetPasswords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForgetPasswords.Font = new System.Drawing.Font("Source Sans Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForgetPasswords.ForeColor = System.Drawing.Color.White;
            this.btnForgetPasswords.Location = new System.Drawing.Point(186, 118);
            this.btnForgetPasswords.Name = "btnForgetPasswords";
            this.btnForgetPasswords.Size = new System.Drawing.Size(136, 32);
            this.btnForgetPasswords.TabIndex = 5;
            this.btnForgetPasswords.Text = "Forget Passwords";
            this.btnForgetPasswords.UseVisualStyleBackColor = false;
            this.btnForgetPasswords.Click += new System.EventHandler(this.btnForgetPasswords_Click);
            // 
            // btnForgetServer
            // 
            this.btnForgetServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(130)))), ((int)(((byte)(183)))));
            this.btnForgetServer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(115)))), ((int)(((byte)(172)))));
            this.btnForgetServer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(92)))), ((int)(((byte)(159)))));
            this.btnForgetServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForgetServer.Font = new System.Drawing.Font("Source Sans Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForgetServer.ForeColor = System.Drawing.Color.White;
            this.btnForgetServer.Location = new System.Drawing.Point(186, 156);
            this.btnForgetServer.Name = "btnForgetServer";
            this.btnForgetServer.Size = new System.Drawing.Size(136, 32);
            this.btnForgetServer.TabIndex = 6;
            this.btnForgetServer.Text = "Forget Server";
            this.btnForgetServer.UseVisualStyleBackColor = false;
            this.btnForgetServer.Click += new System.EventHandler(this.btnForgetServer_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(130)))), ((int)(((byte)(183)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(115)))), ((int)(((byte)(172)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(92)))), ((int)(((byte)(159)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Source Sans Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(146, 217);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 32);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(130)))), ((int)(((byte)(183)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(115)))), ((int)(((byte)(172)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(92)))), ((int)(((byte)(159)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Source Sans Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(237, 217);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 32);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.button4_Click);
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(115)))), ((int)(((byte)(172)))));
            this.ClientSize = new System.Drawing.Size(334, 256);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnForgetServer);
            this.Controls.Add(this.btnForgetPasswords);
            this.Controls.Add(this.btnForgetUsernames);
            this.Controls.Add(this.chkServers);
            this.Controls.Add(this.chkPasswords);
            this.Controls.Add(this.chkUsernames);
            this.Controls.Add(this.chkLauncherOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferencesForm";
            this.Text = "ClassicalSharp Launcher - Preferences";
            this.Load += new System.EventHandler(this.PreferencesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkLauncherOpen;
        private System.Windows.Forms.CheckBox chkUsernames;
        private System.Windows.Forms.CheckBox chkPasswords;
        private System.Windows.Forms.CheckBox chkServers;
        private System.Windows.Forms.Button btnForgetUsernames;
        private System.Windows.Forms.Button btnForgetPasswords;
        private System.Windows.Forms.Button btnForgetServer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}