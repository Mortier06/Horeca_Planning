using HorecaPlannerBL.Exceptions;
using HorecaPlannerBL.Interfaces;
using HorecaPlannerBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorecaPlannerBL.Beheerder
{
    public class WerknemerBeheer
    {
        private IHorecaPlannerRepository repo;

        public WerknemerBeheer(IHorecaPlannerRepository repo)
        {
            this.repo = repo;
        }

        public void WerknemerToevoegen(Werknemer werknemer)
        {
            try
            {
                if (repo.HeeftWerknemer(werknemer)) throw new HorecaPlannerException("Werknemer bestaat al");
                repo.VoegWerknemerToe(werknemer);
            }
            catch (Exception ex) { throw new HorecaPlannerException("werknemerToevoegen", ex); }
        }
        public List<Werknemer> GeefWerknemers()
        {
            try
            {
                return repo.GeefWerknemers();
            }
            catch (Exception ex) { throw new HorecaPlannerException("GeefWerknemers", ex); }
        }
    }
}
