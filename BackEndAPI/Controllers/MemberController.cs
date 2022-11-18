using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using BackEndAPI.DTOs;
using BackEndAPI.Models;
using BackEndAPI.Services.Contract;
using BackEndAPI.Utilities;

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;

        public MemberController(IMemberService memberService, IMapper mapper)
        {
            _memberService = memberService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseApi<List<MemberDTO>> _response = new ResponseApi<List<MemberDTO>>();

            try
            {
                List<Member> memberList = await _memberService.GetList();

                if (memberList.Count > 0)
                {
                    List<MemberDTO> dtoList = _mapper.Map<List<MemberDTO>>(memberList);
                    _response = new ResponseApi<List<MemberDTO>> { Status = true, Msg = "Ok", Value = dtoList };
                }
                else
                {
                    _response = new ResponseApi<List<MemberDTO>> { Status = false, Msg = "No data" };
                }
                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<List<MemberDTO>> { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(MemberDTO request)
        {
            ResponseApi<MemberDTO> _response = new ResponseApi<MemberDTO>();

            try
            {
                Member _model = _mapper.Map<Member>(request);
                Member _memberCreated = await _memberService.Add(_model);

                if (_memberCreated.IdMember != 0)
                {
                    _response = new ResponseApi<MemberDTO>
                    {
                        Status = true,
                        Msg = "Ok",
                        Value = _mapper.Map<MemberDTO>(_memberCreated)
                    };
                } else
                {
                    _response = new ResponseApi<MemberDTO> { Status = false, Msg = "Could not create" };

                    return StatusCode(StatusCodes.Status200OK, _response);
                }
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<MemberDTO> { Status = false, Msg = ex.Message };

                
            }
            return StatusCode(StatusCodes.Status500InternalServerError, _response);
        }
    
        [HttpPut]
        public async Task<IActionResult> Put(MemberDTO request)
        {
            ResponseApi<MemberDTO> _response = new ResponseApi<MemberDTO>();

            try
            {
                Member _model = _mapper.Map<Member>(request);
                Member _memberEdited = await _memberService.Update(_model);

                _response = new ResponseApi<MemberDTO>()
                {
                    Status = true,
                    Msg = "Ok",
                    Value = _mapper.Map<MemberDTO>(_memberEdited)
                };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<MemberDTO> { Status = false, Msg = ex.Message };

                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ResponseApi<bool> _response = new ResponseApi<bool>();

            try
            {
                Member _memberFound = await _memberService.Get(id);
                bool deleted = await _memberService.Delete(_memberFound);

                if (deleted)
                    _response = new ResponseApi<bool> { Status = true, Msg = "Ok" };
                else
                    _response = new ResponseApi<bool> { Status = false, Msg = "No deleted" };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<bool> { Status = false, Msg = ex.Message };


                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
