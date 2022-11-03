using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Read_aloud_webapi.Models;
using Read_aloud_webapi.Controllers.Resource;
using AutoMapper;

namespace Read_aloud_webapi.Persistence
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ReadAloudContext _context;
        private readonly IMapper _mapper;
        public MemberRepository(ReadAloudContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Member>> GetAllMembersPersonalData()
        {
            var _members = new List<Member>();

            if (_context.Members != null)
            {
                return await _context.Members.ToListAsync();
            }

            return _members;
        }

        public async Task<IEnumerable<Member>> GetAllMembersAndAssignments()
        {
            var _members = new List<Member>();

            if (_context.Members != null)
            {
                return await _context.Members.Include(c => c.Assignments).ToListAsync();
            }

            return _members;
        }

        public async Task<Member> GetMemberAndAssignments(int id)
        {
            var _member = new Member();

            if (_context.Members != null)
            {
                var result = await _context.Members.Include(c => c.Assignments).SingleOrDefaultAsync(m => m.Id == id);

                if (result != null)
                {
                    return result;
                }
            }

            return _member;
        }

        public async Task<Member> RegisterMember(MemberResource memberResource)
        {
            //map from resource to domain class
            Member _member = _mapper.Map<MemberResource, Member>(memberResource);

            //add and save to db
            var response = await _context.Members.AddAsync(_member);
            await _context.SaveChangesAsync();

            //map from domain class to resource
            MemberResource result = _mapper.Map<Member, MemberResource>(_member);

            return _member;
        }

        public async Task<Member> GetMemberById(int Id)
        {
            return await _context.Members.FindAsync(Id);
        }

        public void RemoveMember(Member member)
        {
            _context.Remove(member);
        }

        public bool DoesUserExist(string? emailId)
        {
            //check whether member exists before adding
            return _context.Members.Any(c => c.EmailId == emailId);
        }
    }
}