using System;
using System.Windows.Forms;

namespace server
{
    public partial class FormEmailSettings : Form
    {
        public FormEmailSettings()
        {
            InitializeComponent();
        }

		private void FormEmailSettings_Load(object sender, EventArgs e) {
			cbAccounts.SelectedItem = cbAccounts.Items[1];
		}

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

		private void cbAccounts_SelectedIndexChange(object sender, EventArgs e) {
			switch(cbAccounts.SelectedItem.ToString()) {
				case "default":
					this.name.Text = "oopw14";
					this.pass.Text = "oooopppp";
					break;
				case "DenMax":
					this.name.Text = "denmaxrus";
					this.pass.Text = "64213477";
					break;
			}
		}
    }
}
