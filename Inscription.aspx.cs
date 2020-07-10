using Npgsql;
using System;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatRoom
{
    public partial class Inscription : System.Web.UI.Page
    {
        NpgsqlConnection cnx = new NpgsqlConnection("Server=localhost; Port=5432 ;User Id=postgres; Password=ferdaous; Database=ChatRoom");
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            // --- Nom vide---
            if (String.IsNullOrEmpty(nom.Text))
            {
                nomVer.Visible = true;
                return;
            }
            else
                nomVer.Visible = false;
            // --- E-mail vide ---
            if (String.IsNullOrEmpty(email.Text))
            {
                emailVer.Visible = true;
                return;
            }
            else
                emailVer.Visible = false;
            // --- E-mail invalide ---
            if (!IsValidEmail(email.Text))
            {
                invalide.Visible = true;
                return;
            }
            else
                invalide.Visible = false;
            // --- Login vide ---
            if (String.IsNullOrEmpty(username.Text))
            {
                userVer.Visible = true;
                return;
            }
            else
                username.Visible = false;
            // --- Password vide ---
            if (String.IsNullOrEmpty(mdp.Text))
            {
                mdpVer.Visible = true;
                return;
            }
            else
                mdpVer.Visible = false;
            // --- Confirmation Password vide ---
            if (String.IsNullOrEmpty(confirmeMdp.Text))
            {
                confirmVer.Visible = true;
                return;
            }
            else
                confirmVer.Visible = false;
            // --- Confirmation Password différent ---
            if (!confirmeMdp.Text.Equals(mdp.Text))
            {
                mdpIncc.Visible = true;
                return;
            }
            else
                mdpIncc.Visible = false;

            // --- Insertion dans la BDD ---
            DateTime dt = DateTime.Now;
            try
            {
                cnx.Open();
                /*String qr = "select \"login\" from public.\"Utilisateur\" where login = '" + txtUsername + "'";
                NpgsqlCommand cm = new NpgsqlCommand(qr, cnx);
                var rd = cm.ExecuteReader();
                rd.Read();
                //String log = (String)rd.GetValue(0);
                if ((String)rd.GetValue(0) == txtUsername.Text)
                {
                    lblExist.Visible = true;
                    return;
                }
                else
                {*/
                /*lblExist.Visible = false;*/
                String qry = "insert into public.\"Utilisateur\" (\"nomUtilisateur\", \"emailUtilisateur\", login, password, \"idProfil\", \"dateUtilisateur\") Values ('" + nom.Text + "', '" + email.Text + "', '" + username.Text + "', '" + GetMD5(mdp.Text) + "', 2, :date)";
                NpgsqlCommand cmd = new NpgsqlCommand(qry, cnx);
                NpgsqlParameter param = new NpgsqlParameter(":date", NpgsqlTypes.NpgsqlDbType.Date);
                param.Value = dt;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                lblTest.Text = "Utilisateur enregistré !";
                //var reader = cmd.ExecuteReader();
                //reader.Read();
                //int id = (int)reader.GetValue(0);
                //reader.Close();
                //cmd.ExecuteNonQuery();
                //MessageBox.Show(id.ToString());
                cnx.Close();
                Response.Redirect("Auth.aspx");
                //}
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
                lblTest.Text = "Veuillez Choisir un autre nom <br/> Un compte de même nom existe déjà ! <br>" + ex.Message;
                /*if (ex.ErrorCode.Equals(23505))
                {
                    lblTest.Text = "Veuillez Choisir un autre nom \n Un compte de même nom existe déjà !";
                }*/
            }
        }

        // ------------- Le champ E-mail valide ou non -------------
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        // ------------- Le cryptage du mot de passe dans la BDD -------------
        public static String GetMD5(String Texte)
        {
            String md5Hash = "";
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = Encoding.ASCII.GetBytes(Texte);
            data = x.ComputeHash(data);
            md5Hash = Encoding.ASCII.GetString(data);
            return md5Hash;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}