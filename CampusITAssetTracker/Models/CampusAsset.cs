namespace CampusITAssetTracker.Models
{
    public abstract class CampusAsset
    {
        public string AssetTag { get; private set; }

        public decimal PurchasePrice { get; private set; }

        public string Status { get; protected set; }

        public CampusAsset(string assetTag, decimal price)
        {
            AssetTag = assetTag;
            PurchasePrice = price;
            Status = "Available";
        }

        public abstract decimal CalculateDepreciation();

        public virtual string GetMaintenanceStatus()
        {
            return Status;
        }
    }
}
