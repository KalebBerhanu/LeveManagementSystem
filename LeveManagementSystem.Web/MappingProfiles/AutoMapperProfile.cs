using AutoMapper;
using LeveManagementSystem.Web.Data;
using LeveManagementSystem.Web.Models.LeaveTypes;

namespace LeveManagementSystem.Web.MappingProfiles
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile() {
            CreateMap<LeaveType, LeaveTypeReadOnlyVM>();
            //.ForMember(dest => dest.NumberOfDays, opt => opt.MapFrom(src => src.NumberOfDays)); 
            CreateMap<LeaveTypeCreateVM, LeaveType>();

            CreateMap<LeaveTypeEditVM, LeaveType>().ReverseMap();
             
        }
    }
}
