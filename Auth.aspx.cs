using Npgsql;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatRoom
{
    public partial class Auth : System.Web.UI.Page
    {
        NpgsqlConnection cnx = new NpgsqlConnection("Server=localhost; Port=5432 ;User Id=postgres; Password=ferdaous; Database=ChatRoom");
        public static string idProfil = "";
        public static string idUser = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.Open();
                String qry = "SELECT \"idProfil\", \"idUtilisateur\" FROM public.\"Utilisateur\" WHERE login = '" + usernameAu.Text + "' and password = '" + GetMD5(mdpAuth.Text) + "'";
                NpgsqlCommand cmd = new NpgsqlCommand(qry, cnx);
                var reader = cmd.ExecuteReader();
                reader.Read();

                int idProf = (int)reader.GetValue(0);
                int idUs = (int)reader.GetValue(1);

                idProfil = idProf.ToString();
                idUser = idUs.ToString();
                lblId.Text = idUser;

                //lblId.Text = idProf.ToString();
                reader.Close();
                if (idProf.Equals(null))
                {
                    return;
                }
                //cmd.ExecuteNonQuery();
                //MessageBox.Show(id.ToString());
                cnx.Close();
                Response.Redirect("MesSalons.aspx");
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                lblId.Text = "Le nom d'utilisateur ou le mot de passe est incorrect !";
                lblId.Text += ex.Message;
            }
        }
        /*public int getIdUser
        {
            get { return idUser; }
        }*/

        public string myIdProfil
        {
            get { return idProfil; }
        }
        public string myIdUser
        {
            get { return idUser; }
        }
        public void setUserId(int us)
        {
            idUser = us.ToString();
        }
        

        public static String GetMD5(String Texte)
        {
            String md5Hash = "";
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = Encoding.ASCII.GetBytes(Texte);
            data = x.ComputeHash(data);
            md5Hash = Encoding.ASCII.GetString(data);
            return md5Hash;
        }
    }
}