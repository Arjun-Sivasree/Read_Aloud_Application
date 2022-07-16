using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Read_aloud_webapi.Models;
using Read_aloud_webapi.Persistence;
using Read_aloud_webapi.Controllers.Resource;
using AutoMapper;

namespace Read_aloud_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly ReadAloudContext _context;
        private readonly IMapper _mapper;

        public MemberController(ReadAloudContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Member
        [HttpGet]
        [Route("GetMembersAndPersonalData")]
        public async Task<ActionResult<IEnumerable<MemberResource>>> GetMembersAndPersonalData()
        {
            if (_context.Members == null)
            {
                return NotFound();
            }
            var memberData = await _context.Members.ToListAsync();
            return Ok(_mapper.Map<List<Member>, List<MemberResource>>(memberData));
        }

        // GET: api/Member
        [HttpGet]
        [Route("GetMembersAndAssignments")]
        public async Task<ActionResult<IEnumerable<MemberResource>>> GetMembersAndAssignments()
        {
            if (_context.Members == null)
            {
                return NotFound();
            }
            var memberData = await _context.Members.Include(c => c.Assignments).ToListAsync();
            return _mapper.Map<List<Member>, List<MemberResource>>(memberData);
        }

        private bool MemberExists(int id)
        {
            return (_context.Members?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
