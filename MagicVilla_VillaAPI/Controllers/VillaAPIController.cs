using AutoMapper;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogger<VillaAPIController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public VillaAPIController(ILogger<VillaAPIController> logger, ApplicationDbContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas()
        {
            _logger.LogInformation("Getting all villas");
            IEnumerable<Villa> villaList = await _db.Villas.ToListAsync();
            return Ok(_mapper.Map<List<VillaDTO>>(villaList)); 
        }


        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<VillaDTO>> GetVilla(int id)
        {
            if (id == 0 )
            {
                _logger.LogError("Get Villa Error (Id = 0) with Id = " + id);
                return BadRequest("");
            }

            var villa = await _db.Villas.FirstOrDefaultAsync(v => v.Id == id);

            if (villa == null)
            {
                _logger.LogError("Get Villa Error (Not found) with Id = " + id);
                return NotFound(""); 
            }

            _logger.LogInformation("Getting Villa with Id = " + id);
            return Ok(_mapper.Map<VillaDTO>(villa));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<VillaDTO>> CreateVilla([FromBody]VillaCreateDTO createDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if(await _db.Villas.FirstOrDefaultAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
            {
                _logger.LogError("Create Villa Error (Villa has already existing name)");
                ModelState.AddModelError("CustomError", "Villa already Exists!");
                return BadRequest(ModelState);
            }

            if (createDTO == null)
            { 
                _logger.LogError("Create Villa Error (Empty villa)");
                return BadRequest(createDTO);
            }

            Villa model = _mapper.Map<Villa>(createDTO);

            await _db.Villas.AddAsync(model);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Successfully creating villa with Id " + model.Id);
            return CreatedAtRoute("GetVilla", new { id = model.Id }, model);
        }


        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteVilla(int id)
        {
            if (id == 0 )
            {
                _logger.LogError("Delete Villa Error (Id = 0) with Id = " + id);
                return BadRequest();
            }

            var villa = await _db.Villas.FirstOrDefaultAsync(v => v.Id == id);

            if (villa == null)
            {
                _logger.LogError("Delete Villa Error (Villa not found) with Id = " + id);
                return NotFound();
            }

            _db.Villas.Remove(villa);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Successfully deleting villa with Id = " + id);
            return NoContent();
        }


        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<VillaDTO>> UpdateVilla(int id, [FromBody]VillaUpdateDTO updateDTO)
        {
            if (updateDTO == null || id != updateDTO.Id) 
            {
                _logger.LogError("Update Villa Error (New villa is empty or Id != new Id) with Id = " + id);
                return BadRequest();
            }

            Villa model = _mapper.Map<Villa>(updateDTO);

            try
            {
                _db.Villas.Update(model);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError("Update Villa Error (Villa not found) with Id = " + id);
                return NotFound("");
            }

            _logger.LogInformation("Successfully updating villa with Id = " + id);
            return CreatedAtRoute("GetVilla", new { id = id }, model);
        }


        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<VillaDTO>> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                _logger.LogError("Update Partial Villa Error (New villa is empty or Id == 0) with Id = " + id);
                return BadRequest();
            }

            var villa = await _db.Villas.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);

            if (villa == null)
            {
                _logger.LogError("Update Partial Villa Error (New villa is empty) with Id = " + id);
                return NotFound("");
            }

            VillaUpdateDTO updateDTO = _mapper.Map<VillaUpdateDTO>(villa);

            patchDTO.ApplyTo(updateDTO, ModelState);

            Villa model = _mapper.Map<Villa>(updateDTO);

            if (!ModelState.IsValid)
            {
                _logger.LogError("Update Partial Villa Error (New villa is not vaild) with Id = " + id);
                return BadRequest(ModelState);
            }

            _db.Villas.Update(model);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Successfully partially updating villa with Id = " + id);
            return CreatedAtRoute("GetVilla", new { id = id }, model);
        }
    }
}
