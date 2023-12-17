using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Samochod
    {
        [Key]
        public int Id_Samochodu { get; set; }
        public String Marka { get; set; }
        public String Model { get; set; }

        

        public virtual ICollection<Radiowoz_policyjny> Radiowoz_policyjny {  get; set; } 
        public virtual ICollection<Samochod_Zarejestrowany> Samochod_Zarejestrowane { get; set; }
    }
}
