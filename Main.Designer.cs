
namespace Batch_Uploader
{
    partial class Main
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
            this.gbEnv = new System.Windows.Forms.GroupBox();
            this.tbBitlyApiKey = new System.Windows.Forms.TextBox();
            this.tbDriveApiKey = new System.Windows.Forms.TextBox();
            this.lblBitly = new System.Windows.Forms.Label();
            this.lblDrive = new System.Windows.Forms.Label();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.tbAutoRename = new System.Windows.Forms.TextBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnSel = new System.Windows.Forms.Button();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.btnRenameVol = new System.Windows.Forms.Button();
            this.btnInverse = new System.Windows.Forms.Button();
            this.gbEnv.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEnv
            // 
            this.gbEnv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEnv.Controls.Add(this.tbBitlyApiKey);
            this.gbEnv.Controls.Add(this.tbDriveApiKey);
            this.gbEnv.Controls.Add(this.lblBitly);
            this.gbEnv.Controls.Add(this.lblDrive);
            this.gbEnv.Controls.Add(this.btnRename);
            this.gbEnv.Controls.Add(this.btnUpload);
            this.gbEnv.Controls.Add(this.tbAutoRename);
            this.gbEnv.Location = new System.Drawing.Point(12, 312);
            this.gbEnv.Name = "gbEnv";
            this.gbEnv.Size = new System.Drawing.Size(775, 127);
            this.gbEnv.TabIndex = 0;
            this.gbEnv.TabStop = false;
            this.gbEnv.Text = "Ambiente";
            // 
            // tbBitlyApiKey
            // 
            this.tbBitlyApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBitlyApiKey.Location = new System.Drawing.Point(87, 86);
            this.tbBitlyApiKey.Name = "tbBitlyApiKey";
            this.tbBitlyApiKey.Size = new System.Drawing.Size(601, 23);
            this.tbBitlyApiKey.TabIndex = 11;
            this.tbBitlyApiKey.Text = "Token";
            this.tbBitlyApiKey.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tbBitlyApiKey.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // tbDriveApiKey
            // 
            this.tbDriveApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDriveApiKey.Location = new System.Drawing.Point(87, 58);
            this.tbDriveApiKey.Name = "tbDriveApiKey";
            this.tbDriveApiKey.Size = new System.Drawing.Size(682, 23);
            this.tbDriveApiKey.TabIndex = 10;
            this.tbDriveApiKey.Text = "ClientID|Secret";
            this.tbDriveApiKey.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.tbDriveApiKey.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // lblBitly
            // 
            this.lblBitly.AutoSize = true;
            this.lblBitly.Location = new System.Drawing.Point(10, 89);
            this.lblBitly.Name = "lblBitly";
            this.lblBitly.Size = new System.Drawing.Size(76, 15);
            this.lblBitly.TabIndex = 9;
            this.lblBitly.Text = "Bitly API Key:";
            // 
            // lblDrive
            // 
            this.lblDrive.AutoSize = true;
            this.lblDrive.Location = new System.Drawing.Point(6, 61);
            this.lblDrive.Name = "lblDrive";
            this.lblDrive.Size = new System.Drawing.Size(80, 15);
            this.lblDrive.TabIndex = 8;
            this.lblDrive.Text = "Drive API Key:";
            // 
            // btnRename
            // 
            this.btnRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRename.Location = new System.Drawing.Point(694, 24);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 7;
            this.btnRename.Text = "Renomear";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnAutoRename_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.Location = new System.Drawing.Point(694, 85);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 6;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // tbAutoRename
            // 
            this.tbAutoRename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAutoRename.Location = new System.Drawing.Point(6, 25);
            this.tbAutoRename.Name = "tbAutoRename";
            this.tbAutoRename.Size = new System.Drawing.Size(682, 23);
            this.tbAutoRename.TabIndex = 0;
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUp.Location = new System.Drawing.Point(751, 12);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(36, 29);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "^";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDown.Location = new System.Drawing.Point(751, 82);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(36, 29);
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "v";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnSel
            // 
            this.btnSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSel.Location = new System.Drawing.Point(751, 47);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(36, 29);
            this.btnSel.TabIndex = 4;
            this.btnSel.Text = "X";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // lbFiles
            // 
            this.lbFiles.AllowDrop = true;
            this.lbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.ItemHeight = 15;
            this.lbFiles.Location = new System.Drawing.Point(12, 12);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(733, 289);
            this.lbFiles.TabIndex = 5;
            // 
            // btnRenameVol
            // 
            this.btnRenameVol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRenameVol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRenameVol.Location = new System.Drawing.Point(751, 148);
            this.btnRenameVol.Name = "btnRenameVol";
            this.btnRenameVol.Size = new System.Drawing.Size(36, 23);
            this.btnRenameVol.TabIndex = 6;
            this.btnRenameVol.Text = "R";
            this.btnRenameVol.UseVisualStyleBackColor = true;
            this.btnRenameVol.Click += new System.EventHandler(this.btnRenameVol_Click);
            // 
            // btnInverse
            // 
            this.btnInverse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInverse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnInverse.Location = new System.Drawing.Point(751, 177);
            this.btnInverse.Name = "btnInverse";
            this.btnInverse.Size = new System.Drawing.Size(36, 23);
            this.btnInverse.TabIndex = 7;
            this.btnInverse.Text = "I";
            this.btnInverse.UseVisualStyleBackColor = true;
            this.btnInverse.Click += new System.EventHandler(this.btnInverse_Click);
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 451);
            this.Controls.Add(this.btnInverse);
            this.Controls.Add(this.btnRenameVol);
            this.Controls.Add(this.lbFiles);
            this.Controls.Add(this.btnSel);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.gbEnv);
            this.MinimumSize = new System.Drawing.Size(815, 490);
            this.Name = "Main";
            this.Text = "Batch Uploader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnExiting);
            this.gbEnv.ResumeLayout(false);
            this.gbEnv.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEnv;
        private System.Windows.Forms.TextBox tbAutoRename;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnRenameVol;
        private System.Windows.Forms.Button btnInverse;
        private System.Windows.Forms.TextBox tbBitlyApiKey;
        private System.Windows.Forms.TextBox tbDriveApiKey;
        private System.Windows.Forms.Label lblBitly;
        private System.Windows.Forms.Label lblDrive;
    }
}

