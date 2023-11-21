using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Zmiana
    {
        public int Id_Zmiany { get; set; }
        public string Godzina_Rozpoczecia { get; set; }
        public string Godzina_Zakonczenia { get; set; }
        public virtual ICollection<Grafik> Grafiki {  get; set; }
    }
}