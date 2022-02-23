using CadViagem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadViagem.Repositories
{
    public interface ITripRepository
    {
        TripViewModel AddTrip(TripViewModel trip);

        List<TripViewModel> SearchAll();
    }
}
