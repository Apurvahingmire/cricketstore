using AutoMapper;
using CricketStore.BLL.DTOs.Request;
using CricketStore.BLL.DTOs.Response;
using CricketStore.DAL.entities;

namespace CricketStore.BLL.AutoMapperProfile
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<BrandRequestDTO, Brand>();
            CreateMap<CartRequestDTO, Cart>();
            CreateMap<CartDetailRequestDTO, CartDetail>();
            CreateMap<OrderRequestDTO, Order>();
            CreateMap<OderDetailRequestDTO, OderDetail>();
            CreateMap<ProductRequestDTO, Product>();
            CreateMap<UserRequestDTO, User>();
            CreateMap<RoleRequestDTO, Role>();
            CreateMap<LogInRequestDTO, User>();

            CreateMap<Brand, BrandResponseDTO>();
            CreateMap<Cart, CartResponseDTO>();
            CreateMap<CartDetail, CartDetailResponseDTO>();
            CreateMap<Order, OrderResponseDTO>();
            CreateMap<OderDetail, OderDetailResponseDTO>();
            CreateMap<Product, ProductResponseDTO>();
            CreateMap<User, UserResponseDTO>();
            CreateMap<Role, RoleResponseDTO>();
            CreateMap<User, LogInResponseDTO>();
        }
    }
}
