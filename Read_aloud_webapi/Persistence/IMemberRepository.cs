using Read_aloud_webapi.Models;
using Read_aloud_webapi.Controllers.Resource;

namespace Read_aloud_webapi.Persistence
{
    public interface IMemberRepository
    {
        //get all members details
        Task<IEnumerable<Member>> GetAllMembersPersonalData();

        //get all members details and assignment
        Task<IEnumerable<Member>> GetAllMembersAndAssignments();

        //get a single members details and assignment
        Task<Member> GetMemberAndAssignments(int id);

        //Register a new user
        Task<Member> RegisterMember(MemberResource memberResource);

        bool DoesUserExist(string? id);

        Task<Member> GetMemberById(int Id);

        void RemoveMember(Member member);
    }
}