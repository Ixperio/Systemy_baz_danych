using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication4.Models
{
    public class Funkcjonariusz
    {
        [Key]
        public int id_Funkcjonariusza {  get; set; }

        public int telefon {  get; set; }
        public int id_Obywatela {  get; set; }
        public int id_Stopnia { get; set; }

        public string adres_Email { get; set; }
        public string Wyksztalcenie { get; set; }

        public virtual Stopien Stopien { get; set; }

        [ForeignKey("id_Obywatela")]
        public virtual Obywatel Obywatel { get; set; }

        public virtual ICollection<Grafik> Grafiki { get; set; }

    }
}