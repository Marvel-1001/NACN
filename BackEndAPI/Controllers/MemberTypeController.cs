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
    public class MemberTypeController : ControllerBase
    {
        private readonly IMemberTypeService _membertypeService;
        private readonly IMapper _mapper;

        public MemberTypeController(
            IMemberTypeService membertypeService, IMapper mapper)
        {
            _membertypeService = membertypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseApi<List<MemberTypeDTO>> _response = new ResponseApi<List<MemberTypeDTO>>();
            try
            {
                List<MemberType> membertypeList = await _membertypeService.GetList();
                if(membertypeList.Count > 0)
                {
                    List<MemberTypeDTO> dtoList = _mapper.Map<List<MemberTypeDTO>>(membertypeList);
                    _response = new ResponseApi<List<MemberTypeDTO>>() { Status = true, Msg = "Ok", Value = dtoList };

                } else
                {
                    _response = new ResponseApi<List<MemberTypeDTO>>() { Status = false, Msg = "No data" };
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            } 
            catch (Exception ex)
            {
                _response = new ResponseApi<List<MemberTypeDTO>> { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
