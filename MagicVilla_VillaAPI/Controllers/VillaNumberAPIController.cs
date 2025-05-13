using AutoMapper;
using Azure;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/VillaNumberAPI")]
    [ApiController]
    public class VillaNumberAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ILogger<VillaNumberAPIController> _logger;
        private readonly IVillaNumberRepository _dbVillaNumber;
        private readonly IMapper _mapper;
        public VillaNumberAPIController(ILogger<VillaNumberAPIController> logger, IVillaNumberRepository dbVillaNumber, IMapper mapper)
        {
            _logger = logger;
            _dbVillaNumber = dbVillaNumber;
            _mapper = mapper;
            this._response = new();  
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetVillaNumbers()
        {
            try
            {
                _logger.LogInformation("Getting all numbers");
                IEnumerable<VillaNumber> numbersList = await _dbVillaNumber.GetAllAsync();
                _response.Result = _mapper.Map<List<VillaNumberDTO>>(numbersList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _logger.LogError(ex.Message);
            }
            return _response;
        }


        [HttpGet("{no:int}", Name = "GetVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> GetVillaNumber(int no)
        {
            try
            {
                if (no == 0)
                {
                    _logger.LogError("Get Villa number Error (Id = 0) with no = " + no);
                    _response.StatusCode=HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var number = await _dbVillaNumber.GetAsync(v => v.VillaNo == no);

                if (number == null)
                {
                    _logger.LogError("Get Villa number Error (Not found) with no = " + no);
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                _logger.LogInformation("Getting Villa number with no = " + no);
                _response.Result = _mapper.Map<VillaNumberDTO>(number);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _logger.LogError(ex.Message);
            }
            return _response;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody]VillaNumberCreateDTO createDTO)
        {
            try
            {

                if (await _dbVillaNumber.GetAsync(u => u.VillaNo == createDTO.VillaNo) != null)
                {
                    _logger.LogError("Create Villa number Error (Villa number has already existing no)");
                    _response.ErrorMessages = new List<string> { "Villa number already Exists!" };
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                if (createDTO == null)
                {
                    _logger.LogError("Create Villa number Error (Empty number)");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                VillaNumber number = _mapper.Map<VillaNumber>(createDTO);

                await _dbVillaNumber.CreateAsync(number);

                _logger.LogInformation("Successfully creating villa number with no " + number.VillaNo);

                _response.Result = _mapper.Map<VillaNumberDTO>(number);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetVillaNumber", new { no = number.VillaNo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _logger.LogError(ex.Message);
            }
            return _response;
        }


        [HttpDelete("{no:int}", Name = "DeleteVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int no)
        {
            try
            {
                if (no == 0)
                {
                    _logger.LogError("Delete Villa Error (Id = 0) with Id = " + no);
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var number = await _dbVillaNumber.GetAsync(v => v.VillaNo == no);

                if (number == null)
                {
                    _logger.LogError("Delete Villa number Error (Number not found) with no = " + no);
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "Number not found" };
                    return NotFound(_response);
                }

                await _dbVillaNumber.RemoveAsync(number);

                _logger.LogInformation("Successfully deleting villa number with no = " + no);

                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _logger.LogError(ex.Message);
            }
            return _response;
        }


        [HttpPut("{no:int}", Name = "UpdateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int no, [FromBody]VillaNumberUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || no != updateDTO.VillaNo) 
                {
                    _logger.LogError("Update Villa number Error (New number is empty or no != new no) with no = " + no);
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "New number is empty or no != new no" };
                    return BadRequest(_response);
                }

                VillaNumber model = _mapper.Map<VillaNumber>(updateDTO);

                await _dbVillaNumber.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = model;

                _logger.LogInformation("Successfully updating villa number with no = " + no);
                return Ok(_response);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError("Update Villa number Error (Number not found) with no = " + no);
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "Number not found" };
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _logger.LogError(ex.Message);
            }
            return _response;
        }


        [HttpPatch("{no:int}", Name = "UpdatePartialVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> UpdatePartialVillaNumber(int no, JsonPatchDocument<VillaNumberUpdateDTO> patchDTO)
        {
            try
            {
                if (patchDTO == null || no == 0)
                {
                    _logger.LogError("Update Partial Villa number Error (New number is empty or no == 0) with no = " + no);
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "New number is empty or no == 0" };
                    return BadRequest(_response);
                }

                var number = await _dbVillaNumber.GetAsync(v => v.VillaNo == no, false);

                if (number == null)
                {
                    _logger.LogError("Update Partial Villa number Error (Number not found) with no = " + no);
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "Number not found" };
                    return NotFound(_response);
                }

                VillaNumberUpdateDTO updateDTO = _mapper.Map<VillaNumberUpdateDTO>(number);

                patchDTO.ApplyTo(updateDTO, ModelState);

                VillaNumber model = _mapper.Map<VillaNumber>(updateDTO);

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Update Partial Villa number Error (New number is not vaild) with no = " + no);
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>{ "New number is not vaild" };
                    return BadRequest(ModelState);
                }

                await _dbVillaNumber.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = model;

                _logger.LogInformation("Successfully partially updating villa with no = " + no);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _logger.LogError(ex.Message);
            }
            return _response;
        }
    }
}
