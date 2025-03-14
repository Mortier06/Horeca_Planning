using HorecaPlannerBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorecaPlannerBL.Interfaces
{
    public interface IHorecaPlannerRepository
    {
        void VoegWerknemerToe(Werknemer werknemer);
        bool HeeftWerknemer(Werknemer werknemer);
        List<Werknemer> GeefWerknemers();
    }
}
