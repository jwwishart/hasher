using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Wishart.Hasher;
using System.IO;

namespace HasherGui
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();

            // Set default size
            this.Size = new Size( 687, 302 );
            
            lbAlgorithm.Items.Clear();

            foreach ( string s in Hasher.GetRegisteredKeys() ) {
                lbAlgorithm.Items.Add( s );
            }

            lbAlgorithm.SelectedIndex = 0;
        }

        private void cbVerify_CheckedChanged( object sender, EventArgs e ) {
            if (cbVerify.Checked) {
                txtVerifyHash.Visible = true;
                lblValidLabel.Visible = true;
                this.Size = new Size( 687, 366 );

                ValidateHash();
            } else {
                txtVerifyHash.Visible = false;
                lblValidLabel.Visible = false;
                this.Size = new Size( 687, 302 );
            }
        }

        private void btnHash_Click( object sender, EventArgs e ) {
            if ( tabControl.SelectedIndex == 0 ) {
                txtHash.Text = Hasher.Hash( Hasher.StringToBytes( txtToHash.Text ),
                    Hasher.GetHashAlgorithm( lbAlgorithm.SelectedItem.ToString() ) );
            } else {
                if ( File.Exists( txtFileToHash.Text ) ) {
                    txtHash.Text = Hasher.Hash( File.ReadAllBytes( txtFileToHash.Text ),
                        Hasher.GetHashAlgorithm( lbAlgorithm.SelectedItem.ToString() ) );
                } else {
                    MessageBox.Show( "File Doesn't Exist", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
            
            ValidateHash();
        }

        private void ValidateHash() {
            if ( txtHash.Text.Equals( txtVerifyHash.Text, StringComparison.OrdinalIgnoreCase ) ) {
                lblValidLabel.ForeColor = Color.Green;
                lblValidLabel.Text = "Valid";

                txtVerifyHash.BackColor = Color.LightGreen;
            } else {
                lblValidLabel.ForeColor = Color.Red;
                lblValidLabel.Text = "Invalid";
                txtVerifyHash.BackColor = Color.Pink;
            }
        }

        private void txtVerifyHash_TextChanged( object sender, EventArgs e ) {
            ValidateHash();
        }

        private void btnBrowseForFile_Click( object sender, EventArgs e ) {
            OpenFileDialog openFile = new OpenFileDialog();
            DialogResult result = openFile.ShowDialog();

            if ( result == System.Windows.Forms.DialogResult.OK ) {
                txtFileToHash.Text = openFile.FileName;
            }
        }

    }
}
