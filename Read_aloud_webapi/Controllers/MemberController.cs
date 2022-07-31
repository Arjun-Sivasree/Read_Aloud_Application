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
    [Route("[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly ReadAloudContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public MemberController(ReadAloudContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }

        // GET: Member/GetMembersAndPersonalData
        [HttpGet]
        [Route("MembersAndPersonalData")]
        public async Task<ActionResult<IEnumerable<MemberResource>>> GetMembersAndPersonalData()
        {
            if (_context.Members == null)
            {
                return BadRequest();
            }
            var memberData = await _context.Members.ToListAsync();
            return Ok(_mapper.Map<List<Member>, List<MemberResource>>(memberData));
        }

        // GET: Member/GetMembersAndAssignments
        [HttpGet]
        [Route("MembersAndAssignments")]
        public async Task<ActionResult<IEnumerable<MemberResource>>> GetMembersAndAssignments()
        {
            if (_context.Members == null)
            {
                return BadRequest();
            }
            var memberData = await _context.Members.Include(c => c.Assignments).ToListAsync();
            return Ok(_mapper.Map<List<Member>, List<MemberResource>>(memberData));
        }

        //Post: Member/MemberAndPersonalData
        [HttpPost]
        [Route("MemberAndPersonalData")]
        public async Task<ActionResult<Member>> RegisterMember([FromBody] MemberResource memberResource)
        {
            if (_context.Members == null)
            {
                return BadRequest();
            }

            try
            {
                //check whether member exists before adding
                if (_context.Members.Any(c => c.EmailId == memberResource.EmailId))
                {
                    return BadRequest("Member already exists");
                }

                //map from resource to domain class
                Member _member = _mapper.Map<MemberResource, Member>(memberResource);

                //add and save to db
                var response = await _context.Members.AddAsync(_member);
                await _context.SaveChangesAsync();

                //map from domain class to resource
                MemberResource result = _mapper.Map<Member, MemberResource>(_member);

                //return success
                return Created("http://localhost:5000/Member/MemberAndPersonalData", result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET: Member/GetConnectionString
        [HttpGet]
        [Route("GetConnectionString")]
        public ActionResult<Test> GetConnectionString()
        {
            Test test = new Test();
            test.Key = _config.GetConnectionString("read_aloud_connectionString");
            return Ok(test);
        }

        private bool MemberExists(int id)
        {
            return (_context.Members?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
