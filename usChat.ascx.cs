using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatRoom
{
    public partial class usChat : System.Web.UI.UserControl
    {
        public string idDiscussion { get; set; }
        public string dateDiscussion { get; set; }
        public string discours { get; set; }
        public string idSalon { get; set; }
        public string idUtilisateur { get; set; }
        public string nomUtilisateur { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            /* ---- Using Repeater ---- */
            userNom.Text = nomUtilisateur;
            MsgID.Text = discours;
            dateIdlbl.Text = dateDiscussion;
        }
    }
}