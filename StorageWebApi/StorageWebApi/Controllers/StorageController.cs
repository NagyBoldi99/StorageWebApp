using Microsoft.AspNetCore.Mvc;
using StorageWebApi.Data.DTO;
using StorageWebApi.Services;

namespace StorageWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService _storageService;

        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        // Create a new storage
        [HttpPost("create")]
        public IActionResult CreateStorage(CreateStorageDto dto)
        {
            try
            {
                _storageService.CreateStorage(dto);
                return Ok("Storage created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        // Get storage by ID
        [HttpGet("{id}")]
        public IActionResult GetStorageById(Guid id)
        {
            var storage = _storageService.FindStorageById(id);
            if (storage == null)
            {
                return NotFound($"Storage with ID {id} not found.");
            }

            return Ok(storage);
        }

        // Get all storages
        [HttpGet("all")]
        public IActionResult GetAllStorages()
        {
            var storages = _storageService.FindAllStorages();
            return Ok(storages);
        }

        // Delete a storage by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteStorage(Guid id)
        {
            try
            {
                _storageService.DeleteStorage(id);
                return Ok($"Storage with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }
}
