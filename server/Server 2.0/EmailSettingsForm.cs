using System;
using System.Windows.Forms;

namespace Server_2._0 {
    public partial class EmailSettingsForm : Form
    {
        public EmailSettingsForm()
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
					this.tbUserName.Text = "oopw14";
					this.tbPassword.Text = "oooopppp";
					break;
				case "DenMax":
					this.tbUserName.Text = "denmaxrus";
					this.tbPassword.Text = "64213477";
					break;
			}
		}
    }
}
