using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatRoom
{
    public partial class usSalon : System.Web.UI.UserControl
    {

        NpgsqlConnection cnx = new NpgsqlConnection("Server=localhost; Port=5432;User Id=postgres; Password=ferdaous; Database=ChatRoom");
        private Auth auth = new Auth();
        public string profilId = "";
        public static string idSalonToEdit = "";
        public static string nomSalonToEdit = "";
        public static string descSalonToEdit = "";

        public static String idToPass = "";
        public String idSalon { get; set; }
        public String NomSalon { get; set; }
        public String DescriptionSalon { get; set; }
        public String DateSalon { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            profilId = auth.myIdProfil;
            idProfil.Text = profilId;
            if (profilId.Equals("1"))
            {
                //btnEdit.Visible = true;
                //btnDalete.Visible = true;
                LinkMd.Visible = true;
                LinkSp.Visible = true;
            }
            else
            {
                //btnEdit.Visible = false;
                //btnDalete.Visible = false;
                LinkMd.Visible = false;
                LinkSp.Visible = false;
            }
            /* ---- Using Repeater ---- */
            salonId.Text = idSalon;
            nomId.Text = NomSalon;
            desId.Text = DescriptionSalon;
            dateId.Text = DateSalon;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            idToPass = idSalon;
            nomSalonToEdit = nomId.Text;
            Response.Redirect("EspaceChat.aspx");
        }
        public string SalonId
        {
            get { return idToPass; }
        }

        protected void LinkMd_Click(object sender, EventArgs e)
        {
            idSalonToEdit = salonId.Text;
            nomSalonToEdit = nomId.Text;
            descSalonToEdit = desId.Text;
            Response.Redirect("EditSalon.aspx");
        }

        protected void LinkSp_Click(object sender, EventArgs e)
        {
            using (cnx)
            {
                cnx.Open();
                string rq = "delete from public.\"Discussion\" where \"idSalon\" = '" + idSalon + "'";
                NpgsqlCommand cm = new NpgsqlCommand(rq, cnx);
                cm.ExecuteNonQuery();
                string qry = "delete from public.\"Salon\" where \"idSalon\" = '" + idSalon + "'";
                NpgsqlCommand cmd = new NpgsqlCommand(qry, cnx);
                cmd.ExecuteNonQuery();
                cnx.Close();
            }
        }
    }
}