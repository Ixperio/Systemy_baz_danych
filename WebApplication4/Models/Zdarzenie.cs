using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication4.Models;

namespace WebApplication4.Models
{
    public class Zdarzenie
    {
        [Key]
        public int Id_Zdarzenia { get; set; }
        public int Id_Obywatela { get; set; }

        public DateTime Data {  get; set; }
        public int Samochod_Id { get; set; }
        
      
       public int Id_Patrolu { get; set; }
      
        public int Id_Rodzaju { get; set; }
        [ForeignKey("Id_Obywatela")]
        public virtual Obywatel Obywatel { get; set; }
        [ForeignKey("Id_Patrolu")]
        public virtual Patrol Patrol { get; set; }
        [ForeignKey("Id_Rodzaju")]
        public virtual Charakter_zdarzenia Charakter_Zdarzenia { get; set; }
        [ForeignKey("Samochod_Id")]
        public virtual Samochod_Zarejestrowany Samochod_zarejestrowany { get; set; }


    }
}
