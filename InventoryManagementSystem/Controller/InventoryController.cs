using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InventoryManagementSystem.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private InventoryService _inventoryService;

        public InventoryController(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        [LogApiAction]
        public IEnumerable<Item> Get()
        {
            return _inventoryService.getItems().ToArray();
        }
    }
}