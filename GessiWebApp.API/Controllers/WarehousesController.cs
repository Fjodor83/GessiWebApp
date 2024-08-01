using GessiWebApp.API.DTOs;
using GessiWebApp.API.Services;
using GessiWebApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GessiWebApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehousesController : ControllerBase
    {
        private readonly WarehouseService _service;

        public WarehousesController(WarehouseService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetWarehouses()
        {
            var warehouses = _service.GetWarehouses();
            return Ok(warehouses);
        }

        [HttpGet("{id}")]
        public IActionResult GetWarehouse(int id)
        {
            var warehouse = _service.GetWarehouseById(id);
            if (warehouse == null) return NotFound();
            return Ok(warehouse);
        }

        [HttpPost]
        public IActionResult CreateWarehouse([FromBody] WarehouseDto warehouseDto)
        {
            var warehouse = new Warehouse
            {
                WarehouseCode = warehouseDto.WarehouseCode,
                Name = warehouseDto.Name,
                Description = warehouseDto.Description,
                Notes = warehouseDto.Notes
            };
            _service.CreateWarehouse(warehouse);
            return CreatedAtAction(nameof(GetWarehouse), new { id = warehouse.Id }, warehouse);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateWarehouse(int id, [FromBody] WarehouseDto warehouseDto)
        {
            var warehouse = _service.GetWarehouseById(id);
            if (warehouse == null) return NotFound();

            warehouse.WarehouseCode = warehouseDto.WarehouseCode;
            warehouse.Name = warehouseDto.Name;
            warehouse.Description = warehouseDto.Description;
            warehouse.Notes = warehouseDto.Notes;

            _service.UpdateWarehouse(warehouse);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWarehouse(int id)
        {
            _service.DeleteWarehouse(id);
            return NoContent();
        }
    }
}