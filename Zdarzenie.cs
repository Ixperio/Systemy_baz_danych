using WebApplication4.Models;

namespace Aplikacja.Models
{
    public class Zdarzenie
    {
        public int Id_Zdarzenia { get; set; }
        public int Obywatel_Pesel { get; set; }

        public DateTime Data {  get; set; }
        
        public int Patrole_Id_Patrolu { get; set; }
        public int Charakter_Zdarzenia_Id_Rodzaju { get; set; }

        public virtual Obywatel Obywatel { get; set; }

        public virtual Patrol Patrol { get; set; }

        public virtual Charakter_zdarzenia Charakter_Zdarzenia { get; set; }
        
        public virtual Samochod_Zarejestrowany Samochod_zarejestrowany { get; set; }


    }
}
