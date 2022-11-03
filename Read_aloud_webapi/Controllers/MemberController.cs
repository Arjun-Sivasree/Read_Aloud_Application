using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IMemberRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public MemberController(ReadAloudContext context, IMapper mapper, IConfiguration config, IMemberRepository repository, IUnitOfWork unitOfWork)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        // GET: Member/MembersAndPersonalData
        [HttpGet]
        [Route("MembersAndPersonalData")]
        public async Task<ActionResult<IEnumerable<MemberResource>>> GetMembersAndPersonalData()
        {
            var memberData = await _repository.GetAllMembersPersonalData();
            return Ok(_mapper.Map<IEnumerable<Member>, List<MemberResource>>(memberData));
        }

        // GET: Member/MembersAndAssignments
        [HttpGet]
        [Route("MembersAndAssignments")]
        public async Task<ActionResult<IEnumerable<MemberResource>>> GetMembersAndAssignments()
        {
            var memberData = await _repository.GetAllMembersAndAssignments();
            return Ok(_mapper.Map<IEnumerable<Member>, List<MemberResource>>(memberData));
        }

        // GET: Member/MembersAndAssignments/id
        [HttpGet]
        [Route("MembersAndAssignments/{id}")]
        public async Task<ActionResult<MemberResource>> GetMembersAndAssignments(int id)
        {
            var memberData = await _repository.GetMemberAndAssignments(id);

            return Ok(_mapper.Map<Member, MemberResource>(memberData));
        }

        //Post: Member/MemberAndPersonalData
        [HttpPost]
        [Route("MemberAndPersonalData")]
        public async Task<ActionResult<Member>> RegisterMember([FromBody] MemberResource memberResource)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid data format");
                }

                if (_context.Members == null)
                {
                    return BadRequest();
                }

                if (_repository.DoesUserExist(memberResource.EmailId))
                {
                    return BadRequest("User already exists");
                }

                var result = await _repository.RegisterMember(memberResource);

                //return success
                return Created("http://localhost:5000/Member/MemberAndPersonalData", result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Put: Member/MemberAndPersonalData/{id}
        [HttpPut]
        [Route("MemberAndPersonalData/{id}")]
        public async Task<ActionResult<Member>> UpdateMember(int id, [FromBody] MemberResource memberResource)
        {
            if (_context.Members == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("invalid object");
            }

            try
            {
                var member = await _repository.GetMemberById(id);

                if (member == null)
                {
                    return NotFound();
                }

                //map from resource to domain class
                Member _member = _mapper.Map<MemberResource, Member>(memberResource, member);

                //update the db
                await _unitOfWork.Complete();

                //map from domain class to resource
                MemberResource result = _mapper.Map<Member, MemberResource>(_member);

                //return success
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        //Delete: Member/MemberAndPersonalData/id
        [HttpDelete]
        [Route("MemberAndPersonalData/{id}")]
        public async Task<ActionResult<Member>> DeleteMember(int id)
        {
            if (_context.Members == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("invalid object");
            }

            try
            {
                var member = await _repository.GetMemberById(id);

                if (member == null)
                {
                    return NotFound();
                }

                //delete from context
                _repository.RemoveMember(member);

                //update the db
                await _unitOfWork.Complete();

                //return success
                return Ok("Deleted successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET: Member/GetConnectionString
        [HttpGet]
        [Route("GetConnectionString")]
        [Authorize]
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
