
using ampusITAssetTracker.Models;
using CampusITAssetTracker.Interfaces;
using CampusITAssetTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusAssetTracker.Api.Services
{
    public class AssetService
    {
        private List<CampusAsset> _assets;

        public AssetService()
        {
            _assets = new List<CampusAsset>();

            // Sample data for testing
            _assets.Add(new Workstation("WS001", 35000m));

            _assets.Add(new NetworkingHardware("NET001", 12000m));

            _assets.Add(new Peripheral("PER001", 2500m));

            _assets.Add(new SoftwareLicense("SW001", 5000m, 12));
        }

        // Add a new asset
        public void AddAsset(CampusAsset asset)
        {
            bool exists = _assets.Any(a => a.AssetTag == asset.AssetTag);

            if (exists)
            {
                throw new InvalidOperationException(
                    "Asset tag already exists.");
            }

            _assets.Add(asset);
        }

        // Get all assets
        public List<CampusAsset> GetAllAssets()
        {
            return _assets;
        }

        // Calculate total annual depreciation
        public decimal GetTotalDepreciation()
        {
            return _assets.Sum(a => a.CalculateDepreciation());
        }

        // Get all borrowed assets
        public List<IBorrowable> GetCheckedOutItems()
        {
            return _assets
                .OfType<IBorrowable>()
                .Where(a => a.IsCheckedOut)
                .ToList();
        }

        // Get all network devices
        public List<INetworkable> GetNetworkDevices()
        {
            return _assets
                .OfType<INetworkable>()
                .ToList();
        }
    }
}
