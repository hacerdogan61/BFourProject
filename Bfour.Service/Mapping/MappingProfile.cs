using AutoMapper;
using Bfour.Core.DTO;
using Bfour.Core.Entities;

namespace Bfour.Service.Mapping
{
    public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			CreateMap<OrderDTO, Order>();
            CreateMap<OrderDetailDTO, OrderDetail>();
            CreateMap<MemberShipDTO, MemberShip>();
            CreateMap<MemberDTO, Member>();
            CreateMap<ProductDTO, Product>();
        }
	}
}

