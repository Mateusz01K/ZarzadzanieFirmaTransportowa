using ZarzadzanieFirmaTransportowa.Context;
using ZarzadzanieFirmaTransportowa.Models.Cars;
using ZarzadzanieFirmaTransportowa.Models.Trailers;

namespace ZarzadzanieFirmaTransportowa.Services.Trailer
{
    public class TrailerService : ITrailerService
    {

        public readonly CarContext _context;

        public TrailerService(CarContext context)
        {
            _context = context;
        }

        public void DeleteTrailer(int id)
        {
            var trailer = _context.Trailer.FirstOrDefault(x => x.Id == id);
            if (trailer != null)
            {
                _context.Trailer.Remove(trailer);
                _context.SaveChangesAsync();
            }
        }

        public List<TrailerModel> GetTrailer()
        {
            return _context.Trailer.ToList();
        }

        public TrailerModel GetTrailer(int id)
        {
            var trailer = _context.Trailer.FirstOrDefault(x => x.Id == id);
            return trailer ?? new TrailerModel();
        }

        public void InsertTrailer(string Name, string Description, string Type, int MaxLoad, int YearOfProduction)
        {
            var lastId = _context.Trailer.OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
            if (lastId != null)
            {
                _context.Trailer.Add(new TrailerModel()
                {
                    Id = (int)lastId + 1,
                    Model = Name,
                    Brand = Description,
                    Type = Type,
                    MaxLoad = MaxLoad,
                    YearOfProduction = YearOfProduction
                });
                _context.SaveChanges();
            }
        }

        public void UpdateTrailer(int id, string Name, string Description, string Type, int MaxLoad, int YearOfProduction)
        {
            var trailer = _context.Trailer.FirstOrDefault(x => x.Id == id);
            if (trailer != null)
            {
                trailer.Model = Name;
                trailer.Brand = Description;
                trailer.Type = Type;
                trailer.MaxLoad = MaxLoad;
                trailer.YearOfProduction = YearOfProduction;
                _context.SaveChanges();
            }
        }
    }
}
