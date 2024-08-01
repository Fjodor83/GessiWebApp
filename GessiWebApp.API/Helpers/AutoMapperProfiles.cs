using AutoMapper;
using GessiWebApp.API.Models;
using GessiWebApp.API.DTOs;

namespace GessiWebApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Mappature tra le entità del dominio e i DTO
            CreateMap<Material, MaterialDto>().ReverseMap();
            CreateMap<Warehouse, WarehouseDto>().ReverseMap();
            CreateMap<Movement, MovementDto>().ReverseMap();
            CreateMap<PickingMission, PickingMissionDto>().ReverseMap();
        }
    }
}