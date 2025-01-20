using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories.Trip
{
    public class InfoTruckersRepository : IInfoTruckersRepository
    {
        private readonly ApplicationContext _context;

        public InfoTruckersRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Trucker> GetTruckers()
        {
            return _context.Truckers;
        }

        public Trucker? GetTrucker(int idTrucker, bool includeTrips)
        {
            if (includeTrips)
                return _context.Truckers.Include(c => c.Trips)
                    .Where(c => c.Id == idTrucker).FirstOrDefault();

            return _context.Truckers.Where(c => c.Id == idTrucker).FirstOrDefault();
        }

        public void CreateTrucker(CreateTruckerDto trucker)
        {
            var newTrucker = new Trucker
            {
                CompleteName = trucker.CompleteName,
                TruckerType = trucker.TruckerType,
            };
            _context.Truckers.Add(newTrucker);
            SaveChanges();
        }
        public void UpdateTrucker(int id, UpdateTruckerDto trucker)
        {
            var existingTrucker = _context.Truckers.FirstOrDefault(x => x.Id == id);

            if (existingTrucker != null)
            {
                existingTrucker.CompleteName = trucker.CompleteName;
                existingTrucker.TruckerType = trucker.TruckerType;

                SaveChanges();
            }
        }
        public void DeleteTrucker(int id)
        {
            var trucker = _context.Truckers.FirstOrDefault(x => x.Id == id);
            if (trucker != null)
            {
                _context.Truckers.Remove(trucker);
                SaveChanges();
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
