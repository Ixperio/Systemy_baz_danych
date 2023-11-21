using WebApplication4.Models;

namespace Aplikacja.Models
{
    public class Funkcjonariusz_w_patrolu
    {
        public int Id { get; set; }
        public int id_Patrolu { get; set; }
        public int id_Funkcjonariusza { get; set;}

        public virtual Patrol Patrol { get; set; }
        public virtual Funkcjonariusz Funkcjonariusz { get; set; }
    }
}
