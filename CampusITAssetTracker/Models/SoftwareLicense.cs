
using CampusITAssetTracker.Models;

namespace ampusITAssetTracker.Models
{
    public class SoftwareLicense : CampusAsset
    {
        public int RemainingMonths { get; set; }

        public SoftwareLicense(
            string tag,
            decimal price,
            int remainingMonths)
            : base(tag, price)
        {
            RemainingMonths = remainingMonths;
        }

        public override decimal CalculateDepreciation()
        {
            return PurchasePrice * 0.10m;
        }
    }
}
