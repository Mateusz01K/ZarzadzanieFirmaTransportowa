using ZarzadzanieFirmaTransportowa.Models.Trailers;

namespace ZarzadzanieFirmaTransportowa.Services.Trailer
{
    public interface ITrailerService
    {
        public List<TrailerModel> GetTrailer();
        public TrailerModel GetTrailer(int id);
        public void InsertTrailer(string Name, string Description, string Type, int MaxLoad, int YearOfProduction);
        public void UpdateTrailer(int id, string Name, string Description, string Type, int MaxLoad, int YearOfProduction);
        public void DeleteTrailer(int id);
    }
}
