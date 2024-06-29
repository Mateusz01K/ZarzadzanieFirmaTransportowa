namespace ZarzadzanieFirmaTransportowa.Models.Cars
{
    public class CarModel
    {
        public CarModel() { }
        public int Id { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public int? Power { get; set; }
        public double? Distance { get; set; }
        public int YearOfProduction { get; set; }
    }
}
