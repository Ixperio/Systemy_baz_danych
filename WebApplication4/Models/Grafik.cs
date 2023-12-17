using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Grafik
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int Id_Funkcjonariusza {  get; set; }
        public string Godzina_Przyjscia { get; set; }
        public string Godzina_Wyjscia { get; set; }
        public int Id_Zmiany {  get; set; }
        [ForeignKey("Id_Zmiany")]
        public virtual Zmiana Zmiana { get; set; }
        [ForeignKey("Id_Funkcjonariusza")]
        public virtual Funkcjonariusz Funkcjonariusz { get; set; }  
    }
}