using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication4.Models
{
    public class Patrol
    {
        [Key]
        public int Id_Patrolu { get; set; }
        public DateTime Data { get; set; }  
        public String Radiowozy_Policyjne_Nr_Rejestracyjny { get; set; }
       
        public virtual Radiowoz_policyjny radiowoz_policyjny { get; set; }   

        public virtual ICollection<Funkcjonariusz_w_patrolu>  funkcjonariusz_w_patrolu { get; set; }
    }
}
