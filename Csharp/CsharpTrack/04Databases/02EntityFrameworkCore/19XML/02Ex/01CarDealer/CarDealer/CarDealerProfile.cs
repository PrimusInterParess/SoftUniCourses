using AutoMapper;
using CarDealer.Dots.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierInputModel, Supplier>();
            this.CreateMap<PartInputModel, Part>();
            this.CreateMap<CarInputModel, Car>();
            this.CreateMap<SaleInputModel, Sale>();
            this.CreateMap<CustomerInputModel, Customer>();
        }
    }
}
