using AutoMapper;
using Read_aloud_webapi.Models;
using Read_aloud_webapi.Controllers.Resource;

namespace Read_aloud_webapi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberResource>();
            CreateMap<Assignment, AssignmentResource>();
        }
    }
}