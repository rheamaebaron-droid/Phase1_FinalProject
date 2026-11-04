
using CampusAssetTracker.Api.Services;
using CampusITAssetTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace CampusAssetTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly AssetService _service;

        public AssetController(AssetService service)
        {
            _service = service;
        }

        // GET: api/asset
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllAssets());
        }

        // POST: api/asset
        [HttpPost]
        public IActionResult Add([FromBody] CampusAsset asset)
        {
            if (asset == null)
            {
                return BadRequest("Invalid asset information.");
            }

            try
            {
                _service.AddAsset(asset);

                return Ok("Asset successfully added.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/asset/depreciation
        [HttpGet("depreciation")]
        public IActionResult GetDepreciation()
        {
            decimal total = _service.GetTotalDepreciation();

            return Ok(total);
        }

        // GET: api/asset/checkout
        [HttpGet("checkout")]
        public IActionResult GetCheckOut()
        {
            return Ok(_service.GetCheckedOutItems());
        }

        // GET: api/asset/network
        [HttpGet("network")]
        public IActionResult GetNetwork()
        {
            return Ok(_service.GetNetworkDevices());
        }
    }
}
