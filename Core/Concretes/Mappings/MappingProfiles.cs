using AutoMapper;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using System.Linq;

namespace Core.Concretes.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Role,opt=>opt.MapFrom(src=>src.Roles.FirstOrDefault().RoleId.ToString()));
            CreateMap<Inventory, InventoryDTO>();
            CreateMap<Warehouse, WarehouseDTO>();
        }
    }
}
