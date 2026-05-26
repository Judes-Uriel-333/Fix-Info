using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// IMPORTANT
using System.Data.SqlClient;

namespace WindowsFormsAppFixInfo
{
    public partial class Form1 : Form
    {
        // chaine de connexion !!!!
        // on spécifie le nom du serveur, le nom de la base et les infos de connexion
        private string cn = "Server=.\\SQLEXPRESS;Database=Fixinfo;Trusted_Connection=True;Connect Timeout=5;";

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // affichage de la boite de connexion
            FormLogin frm = new FormLogin();
            DialogResult dr = frm.ShowDialog();

            // fermeture de la boite 
            // si l'utilisateur a cliqué sur OK, on vérifie les identifiants
            if (dr == DialogResult.OK)
            {
                string lelogin = frm.login;
                string lepwd = frm.password;

                // connexion à la base pour vérifier les identifiants
                SqlConnection con = new SqlConnection(this.cn);
                con.Open();

                // on va compter combien de personnes ont ce login et ce mot de passe
                string sql = "select count(*) as nb from Login where Nom = @lenom and PWD = @lewpd";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("lenom", lelogin);
                cmd.Parameters.AddWithValue("lewpd", lepwd);

                // execution de la requete 
                SqlDataReader sqldr = cmd.ExecuteReader();

                // lecture du résultat
                sqldr.Read();

                // on récupère le nombre de personnes qui ont ce login et ce mot de passe
                int res = Convert.ToInt32(sqldr["nb"]);

                con.Close();

                // si le résultat est 0, c'est que les identifiants sont incorrects
                if (res == 0)
                {
                    MessageBox.Show("Identifiants incorrects");
                    // si les identifiants sont faux
                    Application.Exit();
                }           
            }
            else
            {
                // si l'utilisateur a cliqué sur annuler, on ferme l'application
                Application.Exit();
            }

            // on remplit la combo box des matériels
            FillMatos();
        }

        // on remplit la boite de materiel
        private void FillMatos()
        {
            SqlConnection con = new SqlConnection(this.cn);
            con.Open();

            // requette pour récupérer tous les noms de matériels
            string sql = "select nom from Materiel";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader sqldr = cmd.ExecuteReader();

            // on tourne en rond pour remplir la combo box avec chaque nom de matériel
            while (sqldr.Read() != false)
            {
                comboBoxMatos.Items.Add(sqldr["nom"].ToString());
            }

            con.Close();          
        }

        // on trouve l'id d'un matériel à partir de son nom
        private int findIdMatos(string nom)
        {
            SqlConnection con = new SqlConnection(this.cn);
            con.Open();

            // requete pour retourner l'id d'un matériel à partir de son nom
            string sql = "select ID_MATOS from Materiel where Nom = @nom";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("nom", nom);
            SqlDataReader sqldr = cmd.ExecuteReader();

            // on lit la seule ligne du résulat  : l'id du matériel
            sqldr.Read();
            int res = Convert.ToInt32(sqldr["ID_MATOS"]);
            con.Close();

            // on retourne l'id du matériel
            return res;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();    
        }

        private void buttonCreer_Click(object sender, EventArgs e)
        {
            // on vérifie que tous les champs sont remplis
            if (textBoxNom.Text == "" || textBoxPrix.Text == "" || textBoxDesc.Text == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs");
                return;
            }

            // ouverture de la connexion à la base de données
            SqlConnection con = new SqlConnection(this.cn);
            con.Open();

            // on réupère les données saisies par l'utilisateur
            string nommatos = textBoxNom.Text;
            decimal prix = Convert.ToDecimal(textBoxPrix.Text);
            string desc = textBoxDesc.Text;
            DateTime dateInstall = dateTimePickerDI.Value;
            Decimal MTBF = numericUpDownMTBF.Value;

            // requete pour insérer un nouveau matériel dans la base de données
            string sql = "INSERT INTO Materiel VALUES(@nommatos, @prix, @desc, @dateInstall, @MTBF)";

            // on remplace les paramètres de la requete par les données saisies
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("nommatos", nommatos);
            cmd.Parameters.AddWithValue("prix", prix);
            cmd.Parameters.AddWithValue("desc", desc);
            cmd.Parameters.AddWithValue("dateInstall", dateInstall);
            cmd.Parameters.AddWithValue("MTBF", MTBF);

            // execution de la requete
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Matériel créé avec succès");
        }

        private void buttonCreerInter_Click(object sender, EventArgs e)
        {
            // On vérifie qu'un matériel a bien été sélectionné
            if (comboBoxMatos.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir un matériel");
                comboBoxMatos.Focus();
                return;
            }

            // on ouvre la connexion à la base de données
            SqlConnection con = new SqlConnection(this.cn);
            con.Open();

            // on récupère les données saisies par l'utilisateur
            string matos = comboBoxMatos.SelectedItem.ToString();
            int idmatos = findIdMatos(matos);
            decimal prix = Convert.ToDecimal(textBoxPrixInter.Text);
            string desc = textBoxCommentInter.Text;
            DateTime dateInstall = dateTimePickerDateInter.Value;

            // la requête pour insérer une nouvelle intervention dans la base de données
            string sql = "INSERT INTO Inter VALUES(@dateInstall, @idmatos, @prix,@desc)";

            // paramétrage de la requete avec les données saisies par l'utilisateur
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("idmatos", idmatos);
            cmd.Parameters.AddWithValue("prix", prix);
            cmd.Parameters.AddWithValue("desc", desc);
            cmd.Parameters.AddWithValue("dateInstall", dateInstall);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Intervention créée avec succès");

        }
    }
}
