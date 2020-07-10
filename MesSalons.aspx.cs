using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;

namespace ChatRoom
{
    public partial class MesSalons : System.Web.UI.Page
    {
        NpgsqlConnection cnx = new NpgsqlConnection("Server=localhost; Port=5432;User Id=postgres; Password=hafsa; Database=SalonChat");
        private Auth auth = new Auth();
        public string profilId = "";
        public string userId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            profilId = auth.myIdProfil;
            userId = auth.myIdUser;
            if (profilId.Equals("1"))
            {
                btnAddSalon.Visible = true;
            }
            else
            {
                btnAddSalon.Visible = false;
            }
            
            using (cnx)
            {
                cnx.Open();
                string qry = "select \"idSalon\",\"nomSalon\",\"dateSalon\",\"descriptionSalon\" from public.\"Salon\"";
                NpgsqlCommand cmd = new NpgsqlCommand(qry, cnx);
                var reader = cmd.ExecuteReader();
                var mesSalons = new List<Salon>();
                while (reader.Read())
                {
                    mesSalons.Add(new Salon(reader.GetInt32(0).ToString(), reader.GetString(1), (reader.GetDateTime(2)).ToString(), reader.GetString(3)));
                }
                repeaterSalon.DataSource = mesSalons;
                repeaterSalon.DataBind();
                cnx.Close();
            }
        }
        protected void RepeaterSalon_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var MonSalon = e.Item.DataItem as Salon;

                var control = e.Item.FindControl("ucSalon") as ucSalon;
                control.idSalon = MonSalon.idSalon.ToString();
                control.NomSalon = MonSalon.nomSalon.ToString();
                control.DateSalon = MonSalon.dateSalon.ToString();
                control.DescriptionSalon = MonSalon.descriptionSalon.ToString();
            }
        }
        protected void btnAddSalon_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddSalon.aspx");
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            auth.setUserId(0);
            Response.Redirect("Auth.aspx");
        }


    }
}