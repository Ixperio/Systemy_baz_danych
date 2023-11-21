using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication4.Models
{
    public class Funkcjonariusz
    {
        public int id_Funkcjonariusza {  get; set; }

        public int telefon {  get; set; }
        public int Pesel {  get; set; }
        public int id_Stopnia { get; set; }

        public string adres_Email { get; set; }
        public string Wyksztalcenie { get; set; }

        public virtual Stopien Stopien { get; set; }

        public virtual Obywatel Obywatel { get; set; }

        public virtual ICollection<Grafik> Grafiki { get; set; }

    }
}