using proiectDAW.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proiectDAW.Models.Many_To_Many;

namespace proiectDAW.Models.One_To_One
{
    public class Date_Personale : BaseEntity
    {
        public string Email { get; set; }
        public string Tara_Origine { get; set; }
        public string Telefon { get; set; }

        public Utilizator Utilizator { get; set; }

    }
}
