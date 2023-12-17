using System.ComponentModel.DataAnnotations;
using WebApplication4.Models;

namespace WebApplication4.Models
{
    public class Funkcjonariusz_w_patrolu
    {
        [Key]
        public int Id { get; set; }
        public int id_Patrolu { get; set; }
        public int id_Funkcjonariusza { get; set;}

        public virtual Patrol Patrol { get; set; }
        public virtual Funkcjonariusz Funkcjonariusz { get; set; }
    }
}
