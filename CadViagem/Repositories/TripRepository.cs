using CadViagem.Data;
using CadViagem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadViagem.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public TripRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public TripViewModel AddTrip(TripViewModel trip)
        {
            _dataBaseContext.Add(trip);
            _dataBaseContext.SaveChanges();
            return trip;
        }

        public List<TripViewModel> SearchAll()
        {
            return _dataBaseContext.Trip.Include(x => x.Driver).ToList();
        }
    }
}
