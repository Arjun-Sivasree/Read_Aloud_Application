using AutoMapper;
using Read_aloud_webapi.Models;
using Read_aloud_webapi.Controllers.Resource;

namespace Read_aloud_webapi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //domain model to resource (for mappning db to api response)
            CreateMap<Member, MemberResource>();
            CreateMap<Assignment, AssignmentResource>();
            CreateMap<Member, MemberResource>();

            //resource to domain model (for mapping request to db)
            CreateMap<MemberResource, Member>();
        }
    }
}