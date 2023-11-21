using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("MyCS") { }

        public DbSet<Funkjonariusz> Funkcjonariusze { get; set; }

        public DbSet<Funkcjonariusz_W_Patrolu> Funkcjonariusze_W_Patrolu { get; set; }

        public DbSet<Grafik> Grafik { get; set; }

        public DbSet<Obywatel> Obywatele { get; set; }
        public DbSet<Patrol> Patrol { get; set; }
        public DbSet<Radiowoz_policyjny> Radiowowzy_policyjne { get; set; }
        public DbSet<Samochod> Samochody { get; set; }
        public DbSet<Samochod_Zarejestrowany> Samochody_Zarejestrowane { get; set; }
        public DbSet<Stopien> Stopien { get; set; }
        public DbSet<Zmiana> Zmiana { get; set; }
        public DbSet<Charakter_zdarzenia> Charakter_Zdarzenia { get; set; }
        public DbSet<Zdarzenie> Zdarzenia { get; set; },

    }
}