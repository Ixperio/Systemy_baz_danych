using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Stopien
    {
        [Key]
        public int Id_Stopnia { get; set; }
        public string Nazwa { get; set; }
        public int Zarobki { get; set; }

        public virtual ICollection<Funkcjonariusz> Funkcjonariusze { get; set; }
    }
}