namespace HasherGui
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && (components != null) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblValidLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHash = new System.Windows.Forms.TextBox();
            this.txtVerifyHash = new System.Windows.Forms.TextBox();
            this.cbVerify = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbAlgorithm = new System.Windows.Forms.ListBox();
            this.btnHash = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpText = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToHash = new System.Windows.Forms.TextBox();
            this.tpFile = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseForFile = new System.Windows.Forms.Button();
            this.txtFileToHash = new System.Windows.Forms.TextBox();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpText.SuspendLayout();
            this.tpFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add( this.lblValidLabel );
            this.panel1.Controls.Add( this.label4 );
            this.panel1.Controls.Add( this.txtHash );
            this.panel1.Controls.Add( this.txtVerifyHash );
            this.panel1.Controls.Add( this.cbVerify );
            this.panel1.Controls.Add( this.label3 );
            this.panel1.Controls.Add( this.lbAlgorithm );
            this.panel1.Controls.Add( this.btnHash );
            this.panel1.Controls.Add( this.tabControl );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point( 0, 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size( 681, 338 );
            this.panel1.TabIndex = 1;
            // 
            // lblValidLabel
            // 
            this.lblValidLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValidLabel.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.lblValidLabel.ForeColor = System.Drawing.Color.Green;
            this.lblValidLabel.Location = new System.Drawing.Point( 569, 241 );
            this.lblValidLabel.Name = "lblValidLabel";
            this.lblValidLabel.Size = new System.Drawing.Size( 100, 23 );
            this.lblValidLabel.TabIndex = 8;
            this.lblValidLabel.Text = "Valid";
            this.lblValidLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValidLabel.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point( 139, 156 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 35, 13 );
            this.label4.TabIndex = 7;
            this.label4.Text = "Hash:";
            // 
            // txtHash
            // 
            this.txtHash.Location = new System.Drawing.Point( 139, 174 );
            this.txtHash.Multiline = true;
            this.txtHash.Name = "txtHash";
            this.txtHash.Size = new System.Drawing.Size( 530, 56 );
            this.txtHash.TabIndex = 6;
            // 
            // txtVerifyHash
            // 
            this.txtVerifyHash.Location = new System.Drawing.Point( 139, 265 );
            this.txtVerifyHash.Multiline = true;
            this.txtVerifyHash.Name = "txtVerifyHash";
            this.txtVerifyHash.Size = new System.Drawing.Size( 530, 59 );
            this.txtVerifyHash.TabIndex = 5;
            this.txtVerifyHash.Visible = false;
            this.txtVerifyHash.TextChanged += new System.EventHandler( this.txtVerifyHash_TextChanged );
            // 
            // cbVerify
            // 
            this.cbVerify.AutoSize = true;
            this.cbVerify.Location = new System.Drawing.Point( 140, 241 );
            this.cbVerify.Name = "cbVerify";
            this.cbVerify.Size = new System.Drawing.Size( 52, 17 );
            this.cbVerify.TabIndex = 4;
            this.cbVerify.Text = "Verify";
            this.cbVerify.UseVisualStyleBackColor = true;
            this.cbVerify.CheckedChanged += new System.EventHandler( this.cbVerify_CheckedChanged );
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point( 8, 4 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 78, 13 );
            this.label3.TabIndex = 3;
            this.label3.Text = "Hash Algorithm";
            // 
            // lbAlgorithm
            // 
            this.lbAlgorithm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAlgorithm.FormattingEnabled = true;
            this.lbAlgorithm.Items.AddRange( new object [] {
            "sha1",
            "sha256",
            "sha512",
            "md5"} );
            this.lbAlgorithm.Location = new System.Drawing.Point( 8, 22 );
            this.lbAlgorithm.Name = "lbAlgorithm";
            this.lbAlgorithm.Size = new System.Drawing.Size( 125, 303 );
            this.lbAlgorithm.TabIndex = 2;
            // 
            // btnHash
            // 
            this.btnHash.Location = new System.Drawing.Point( 594, 146 );
            this.btnHash.Name = "btnHash";
            this.btnHash.Size = new System.Drawing.Size( 75, 23 );
            this.btnHash.TabIndex = 2;
            this.btnHash.Text = "Hash";
            this.btnHash.UseVisualStyleBackColor = true;
            this.btnHash.Click += new System.EventHandler( this.btnHash_Click );
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add( this.tpText );
            this.tabControl.Controls.Add( this.tpFile );
            this.tabControl.Location = new System.Drawing.Point( 139, 12 );
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size( 534, 128 );
            this.tabControl.TabIndex = 1;
            // 
            // tpText
            // 
            this.tpText.Controls.Add( this.label2 );
            this.tpText.Controls.Add( this.txtToHash );
            this.tpText.Location = new System.Drawing.Point( 4, 22 );
            this.tpText.Name = "tpText";
            this.tpText.Padding = new System.Windows.Forms.Padding( 3 );
            this.tpText.Size = new System.Drawing.Size( 526, 102 );
            this.tpText.TabIndex = 0;
            this.tpText.Text = "Text";
            this.tpText.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 7, 7 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 69, 13 );
            this.label2.TabIndex = 1;
            this.label2.Text = "Text to hash:";
            // 
            // txtToHash
            // 
            this.txtToHash.Location = new System.Drawing.Point( 7, 23 );
            this.txtToHash.Multiline = true;
            this.txtToHash.Name = "txtToHash";
            this.txtToHash.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtToHash.Size = new System.Drawing.Size( 513, 73 );
            this.txtToHash.TabIndex = 0;
            // 
            // tpFile
            // 
            this.tpFile.Controls.Add( this.label1 );
            this.tpFile.Controls.Add( this.btnBrowseForFile );
            this.tpFile.Controls.Add( this.txtFileToHash );
            this.tpFile.Location = new System.Drawing.Point( 4, 22 );
            this.tpFile.Name = "tpFile";
            this.tpFile.Padding = new System.Windows.Forms.Padding( 3 );
            this.tpFile.Size = new System.Drawing.Size( 526, 102 );
            this.tpFile.TabIndex = 1;
            this.tpFile.Text = "File";
            this.tpFile.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 6, 8 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 64, 13 );
            this.label1.TabIndex = 2;
            this.label1.Text = "File to hash:";
            // 
            // btnBrowseForFile
            // 
            this.btnBrowseForFile.Location = new System.Drawing.Point( 445, 21 );
            this.btnBrowseForFile.Name = "btnBrowseForFile";
            this.btnBrowseForFile.Size = new System.Drawing.Size( 75, 23 );
            this.btnBrowseForFile.TabIndex = 1;
            this.btnBrowseForFile.Text = "Browse...";
            this.btnBrowseForFile.UseVisualStyleBackColor = true;
            this.btnBrowseForFile.Click += new System.EventHandler( this.btnBrowseForFile_Click );
            // 
            // txtFileToHash
            // 
            this.txtFileToHash.Location = new System.Drawing.Point( 6, 24 );
            this.txtFileToHash.Name = "txtFileToHash";
            this.txtFileToHash.Size = new System.Drawing.Size( 433, 20 );
            this.txtFileToHash.TabIndex = 0;
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.Title = "Select file to hash...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 681, 338 );
            this.Controls.Add( this.panel1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Hasher GUI";
            this.panel1.ResumeLayout( false );
            this.panel1.PerformLayout();
            this.tabControl.ResumeLayout( false );
            this.tpText.ResumeLayout( false );
            this.tpText.PerformLayout();
            this.tpFile.ResumeLayout( false );
            this.tpFile.PerformLayout();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHash;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpText;
        private System.Windows.Forms.TextBox txtToHash;
        private System.Windows.Forms.TabPage tpFile;
        private System.Windows.Forms.Button btnBrowseForFile;
        private System.Windows.Forms.TextBox txtFileToHash;
        private System.Windows.Forms.ListBox lbAlgorithm;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVerifyHash;
        private System.Windows.Forms.CheckBox cbVerify;
        private System.Windows.Forms.Label lblValidLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHash;
    }
}

