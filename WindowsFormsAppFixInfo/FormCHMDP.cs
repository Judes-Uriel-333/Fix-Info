using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsAppFixInfo
{
    public partial class FormCHMDP : Form
    {
        private string cn ="Server=MSI\\SQLEXPRESS;Database=Fixinfo;Trusted_Connection=True;";
        public FormCHMDP()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // verifier id et mdp
            string lelogin = textBoxLogin.Text;
            string lepwd = textBoxPWD.Text;

            SqlConnection con = new SqlConnection(this.cn);
            con.Open();
            string sql = "select count(*) as nb from Login where Nom = @lenom and PWD = @lewpd";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("lenom", lelogin);
            cmd.Parameters.AddWithValue("lewpd", lepwd);

            SqlDataReader sqldr = cmd.ExecuteReader();

            sqldr.Read();

            int res = Convert.ToInt32(sqldr["nb"]);

            con.Close();

            if (res == 0)
            {
                MessageBox.Show("Identifiants incorrects");
                return;
            }

            // changement de mdp
            // aaaaaaaaaaaaaaaaa

            string sqlch = "UPDATE Login SET PWD = @pwd WHERE Nom = @nom";
            SqlCommand cmdch = new SqlCommand(sqlch, con);
            cmdch.Parameters.AddWithValue("pwd", textBoxNouvMDP.Text);

        }
    }
}
