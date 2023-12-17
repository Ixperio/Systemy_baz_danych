using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Charakter_zdarzenia
    {
        [Key]
        public int id { get; set; }
        public int Id_Rodzaju {  get; set; }
        public String Nazwa {  get; set; }

       
    }
}
