
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication4.Models;

namespace WebApplication4.Models
{
    public class Obywatel
    {
        [Key]
        public int Id { get; set; }
        public int Pesel {  get; set; }
        public string Imie {  get; set; }
        public string Nazwisko { get; set;}
        public DateTime DataUrodzenia { get; set; }
        public string Ulica { get; set; }
        public string Nr_Budynku { get; set; }
        public string Miasto { get; set; }

        public virtual ICollection<Zdarzenie> Zdarzenie { get; set; }
        public virtual ICollection<Samochod_Zarejestrowany> Samochody_Zarejestrowane { get; set; }
       
    }
}