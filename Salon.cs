using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace ChatRoom
{
    public class Salon
    {
        public Salon(string idSalon, string nomSalon, string dateSalon, string descriptionSalon)
        {
            this.idSalon = idSalon;
            this.nomSalon = nomSalon;
            this.dateSalon = dateSalon;
            this.descriptionSalon = descriptionSalon;
        }
        public string idSalon { get; set; }
        public string nomSalon { get; set; }
        public string dateSalon { get; set; }
        public string descriptionSalon { get; set; }
    }
}
}