using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorecaPlannerBL.Model
{
    public class Werknemer
    {
        public Werknemer(string naam, string telnr, string email)
        {
            Naam = naam;
            Telnr = telnr;
            Email = email;
        }

        public Werknemer(int id, string naam, string telnr, string email)
        {
            Id = id;
            Naam = naam;
            Telnr = telnr;
            Email = email;
        }

        public int Id { get; set; }
        public string Naam { get; set; }
        public string Telnr { get; set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return $"{Id}, {Naam}, {Telnr}, {Email}";
        }
    }
}
