using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {

            this.CreateMap<CustomerInputModel, Customer>();

            this.CreateMap<CarInputModel, Car>();

            this.CreateMap<PartInputModel, Part>();

            this.CreateMap<SaleInputModel, Sale>();

            this.CreateMap<SupplierInputModel, Supplier>();


        }
    }
}
