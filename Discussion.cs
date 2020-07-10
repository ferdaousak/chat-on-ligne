using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatRoom
{
    public class Discussion
    {
        public Discussion(string idDiscussion, string dateDiscussion, string discours, string idSalon, string idUtilisateur, string nomUtilisateur)
        {
            this.idDiscussion = idDiscussion;
            this.dateDiscussion = dateDiscussion;
            this.discours = discours;
            this.idSalon = idSalon;
            this.idUtilisateur = idUtilisateur;
            this.nomUtilisateur = nomUtilisateur;
        }
        public string idDiscussion { get; set; }
        public string dateDiscussion { get; set; }
        public string discours { get; set; }
        public string idSalon { get; set; }
        public string idUtilisateur { get; set; }
        public string nomUtilisateur { get; set; }
    }
}