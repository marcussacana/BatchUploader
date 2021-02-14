
namespace Batch_Uploader
{
    partial class UploadForm
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
            this.tbLinkList = new System.Windows.Forms.TextBox();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.lblDrivePath = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.ckAnon = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbLinkList
            // 
            this.tbLinkList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLinkList.Location = new System.Drawing.Point(12, 12);
            this.tbLinkList.Multiline = true;
            this.tbLinkList.Name = "tbLinkList";
            this.tbLinkList.Size = new System.Drawing.Size(775, 397);
            this.tbLinkList.TabIndex = 0;
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbPath.Location = new System.Drawing.Point(82, 416);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(523, 23);
            this.tbPath.TabIndex = 1;
            this.tbPath.Text = "My Drive:/Batch Uploads";
            // 
            // lblDrivePath
            // 
            this.lblDrivePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDrivePath.AutoSize = true;
            this.lblDrivePath.Location = new System.Drawing.Point(12, 419);
            this.lblDrivePath.Name = "lblDrivePath";
            this.lblDrivePath.Size = new System.Drawing.Size(64, 15);
            this.lblDrivePath.TabIndex = 2;
            this.lblDrivePath.Text = "Drive Path:";
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.Location = new System.Drawing.Point(701, 415);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(86, 23);
            this.btnUpload.TabIndex = 3;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Clicked);
            // 
            // ckAnon
            // 
            this.ckAnon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ckAnon.AutoSize = true;
            this.ckAnon.Location = new System.Drawing.Point(610, 418);
            this.ckAnon.Name = "ckAnon";
            this.ckAnon.Size = new System.Drawing.Size(85, 19);
            this.ckAnon.TabIndex = 4;
            this.ckAnon.Text = "Anon Links";
            this.ckAnon.UseVisualStyleBackColor = true;
            // 
            // UploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 451);
            this.Controls.Add(this.ckAnon);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.lblDrivePath);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.tbLinkList);
            this.MinimumSize = new System.Drawing.Size(815, 490);
            this.Name = "UploadForm";
            this.Text = "Upload";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLinkList;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label lblDrivePath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.CheckBox ckAnon;
    }
}