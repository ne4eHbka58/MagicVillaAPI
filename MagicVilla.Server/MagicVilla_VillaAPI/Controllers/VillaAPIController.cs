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
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ILogger<VillaAPIController> _logger;
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;
        public VillaAPIController(ILogger<VillaAPIController> logger, IVillaRepository dbVilla, IMapper mapper)
        {
            _logger = logger;
            _dbVilla = dbVilla;
            _mapper = mapper;
            this._response = new();  
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            try
            {
                _logger.LogInformation("Getting all villas");
                IEnumerable<Villa> villaList = await _dbVilla.GetAllAsync();
                _response.Result = _mapper.Map<List<VillaDTO>>(villaList);
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


        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> GetVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Get Villa Error (Id = 0) with Id = " + id);
                    _response.StatusCode=HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var villa = await _dbVilla.GetAsync(v => v.Id == id);

                if (villa == null)
                {
                    _logger.LogError("Get Villa Error (Not found) with Id = " + id);
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                _logger.LogInformation("Getting Villa with Id = " + id);
                _response.Result = _mapper.Map<VillaDTO>(villa);
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

        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody]VillaCreateDTO createDTO)
        {
            try
            {
                if (await _dbVilla.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {
                    _logger.LogError("Create Villa Error (Villa has already existing name)");
                    _response.ErrorMessages = new List<string> { "Villa already Exists!" };
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                if (createDTO == null)
                {
                    _logger.LogError("Create Villa Error (Empty villa)");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                Villa villa = _mapper.Map<Villa>(createDTO);

                await _dbVilla.CreateAsync(villa);

                _logger.LogInformation("Successfully creating villa with Id " + villa.Id);

                _response.Result = _mapper.Map<VillaDTO>(villa);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetVilla", new { id = villa.Id }, _response);
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


        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Delete Villa Error (Id = 0) with Id = " + id);
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var villa = await _dbVilla.GetAsync(v => v.Id == id);

                if (villa == null)
                {
                    _logger.LogError("Delete Villa Error (Villa not found) with Id = " + id);
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "Villa not found" };
                    return NotFound(_response);
                }

                await _dbVilla.RemoveAsync(villa);

                _logger.LogInformation("Successfully deleting villa with Id = " + id);

                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                _response.StatusCode = HttpStatusCode.OK;
                _logger.LogError(ex.Message);
            }
            return _response;
        }


        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody]VillaUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id) 
                {
                    _logger.LogError("Update Villa Error (New villa is empty or Id != new Id) with Id = " + id);
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "New villa is empty or Id != new Id" };
                    return BadRequest(_response);
                }

                Villa model = _mapper.Map<Villa>(updateDTO);

                await _dbVilla.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = model;

                _logger.LogInformation("Successfully updating villa with Id = " + id);
                return Ok(_response);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError("Update Villa Error (Villa not found) with Id = " + id);
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "Villa not found" };
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                _response.StatusCode = HttpStatusCode.OK;
                _logger.LogError(ex.Message);
            }
            return _response;
        }


        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            try
            {
                if (patchDTO == null || id == 0)
                {
                    _logger.LogError("Update Partial Villa Error (New villa is empty or Id == 0) with Id = " + id);
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "New villa is empty or Id == 0" };
                    return BadRequest(_response);
                }

                var villa = await _dbVilla.GetAsync(v => v.Id == id, false);

                if (villa == null)
                {
                    _logger.LogError("Update Partial Villa Error (Villa not found) with Id = " + id);
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "Villa not found" };
                    return NotFound(_response);
                }

                VillaUpdateDTO updateDTO = _mapper.Map<VillaUpdateDTO>(villa);

                patchDTO.ApplyTo(updateDTO, ModelState);

                Villa model = _mapper.Map<Villa>(updateDTO);

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Update Partial Villa Error (New villa is not vaild) with Id = " + id);
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>{ "New villa is not vaild" };
                    return BadRequest(ModelState);
                }

                await _dbVilla.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = model;

                _logger.LogInformation("Successfully partially updating villa with Id = " + id);
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
