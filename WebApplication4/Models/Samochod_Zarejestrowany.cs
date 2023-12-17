
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Samochod_Zarejestrowany
    {
        [Key]
        public int Id { get; set; }
        public string Nr_Rejestracyjny {  get; set; }
        public int Przebieg {  get; set; }
        public int Id_Obywatela {  get; set; }
        public int Id_Samochodu { get; set; }
        public DateTime Rocznik { get; set; }
        public DateTime Ubezpieczenie { get; set; }
        [ForeignKey("Id_Samochodu")]
        public virtual Samochod Samochod { get; set; }
        [ForeignKey("Id_Obywatela")]
        public virtual Obywatel Obywatel { get; set; }
        public virtual ICollection<Zdarzenie> Zdarzenia { get; set; }

    }
}