using System;
using System.Windows.Forms;

namespace WindowsFormsAppFixInfo
{
    public partial class FormLogin : Form
    {
        public string login, password;

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // passage des informations dans les textbox vers les variables
            this.login = textBoxLogin.Text;
            this.password = textBoxPWD.Text;
        }

        private void checkBoxMDP_CheckedChanged(object sender, EventArgs e)
        {
             textBoxPWD.UseSystemPasswordChar = !checkBoxMDP.Checked;
        }

        private void buttonChMDP_Click(object sender, EventArgs e)
        {
            FormCHMDP dlg = new FormCHMDP();
            dlg.ShowDialog();
        }

        public FormLogin()
        {
            InitializeComponent();
        }
    }
}
