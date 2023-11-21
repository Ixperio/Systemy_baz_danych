namespace Aplikacja.Models
{
    public class Samochod
    {
        public int Id_Samochodu { get; set; }
        public String Marka { get; set; }
        public String Model { get; set; }

        public virtual int Samochody_PK { get; set; }

        public virtual ICollection<Radiowoz_policyjny> Radiowoz_policyjny {  get; set; } 
    }
}
