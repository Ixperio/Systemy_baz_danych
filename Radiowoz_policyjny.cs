namespace Aplikacja.Models
{
    public class Radiowoz_policyjny
    {
        public String Nr_Rejestracyjny { get; set; }
        public int Rocznik { get; set; }

        public int id_Samochodu { get; set; }

        public DateOnly Ubezpieczenie { get; set; }
        public int Przebieg {  get; set; }
        public DateOnly Przeglad {  get; set; }

        public virtual Samochod Samochod { get; set; }

    }
}
