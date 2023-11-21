using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Grafik
    {
        public DateTime Data { get; set; }
        public int Id_Funkcjonariusza {  get; set; }
        public string Godzina_Przyjscia { get; set; }
        public string Godzina_Wyjscia { get; set; }
        public int Id_Zmiany {  get; set; }
        public virtual Zmiana Zmiana { get; set; }
        public virtual Funkcjonariusz Funkcjonariusz { get; set; }  
    }
}