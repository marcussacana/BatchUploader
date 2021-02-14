using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Batch_Uploader
{
    public partial class Input : Form
    {
        public Input() {
            InitializeComponent();
        }
        public Input(string Initial) : this() {
            tbInput.Text = Initial;
        }

        public string Value => tbInput.Text;

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
