using Aplikacja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Samochod_Zarejestrowany
    {
        public string Nr_Rejestracyjny {  get; set; }
        public int Przebieg {  get; set; }
        public int Pesel {  get; set; }
        public int Id_Samochodu { get; set; }
        public int Rocznik { get; set; }
        public DateTime Ubezpieczenie { get; set; }
        public virtual Samochod Samochod { get; set; }
        public virtual Obywatel Obywatel { get; set; }
        public virtual ICollection<Zdarzenie> Zdarzenia { get; set; }

    }
}