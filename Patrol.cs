namespace Aplikacja.Models
{
    public class Patrol
    {
        public int Id_Patrolu { get; set; }
        public DateOnly Data { get; set; }  
        public String Radiowozy_Policyjne_Nr_Rejestracyjny { get; set; }

        public virtual Radiowoz_policyjny radiowoz_policyjny { get; set; }   

        public virtual ICollection<Funkcjonariusz_w_patrolu>  funkcjonariusz_w_patrolu { get; set; }
    }
}
