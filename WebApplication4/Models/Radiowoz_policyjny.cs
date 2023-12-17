using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Radiowoz_policyjny
    {
        [Key]
        public int Id { get; set; }
        public String Nr_Rejestracyjny { get; set; }
        public int Rocznik { get; set; }

        public int id_Samochodu { get; set; }

        public DateTime Ubezpieczenie { get; set; }
        public int Przebieg {  get; set; }
        public DateTime Przeglad {  get; set; }
        [ForeignKey("id_Samochodu")]
        public virtual Samochod Samochod { get; set; }

    }
}
