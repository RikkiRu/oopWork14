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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

		private void cbAccounts_SelectionChangeCommitted(object sender, EventArgs e) {
			switch(cbAccounts.SelectedItem.ToString()){
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
