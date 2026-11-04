
using CampusITAssetTracker.Interfaces;
using CampusITAssetTracker.Models;
using System.Net.NetworkInformation;

namespace ampusITAssetTracker.Models
{
    public class NetworkingHardware : CampusAsset, IBorrowable, INetworkable
    {
        public string IpAddress { get; set; }

        public string MacAddress { get; set; }

        public bool IsCheckedOut { get; set; }

        public string BorrowerId { get; set; }

        public NetworkingHardware(string tag, decimal price)
            : base(tag, price)
        {
            IpAddress = "";
            MacAddress = "";
            IsCheckedOut = false;
            BorrowerId = "";
        }

        public override decimal CalculateDepreciation()
        {
            return PurchasePrice * 0.10m;
        }

        public void CheckOut(string borrowerId)
        {
            if (Status == "In Repair")
            {
                throw new InvalidOperationException(
                    "Cannot borrow an asset that is in repair.");
            }

            if (IsCheckedOut)
            {
                throw new InvalidOperationException(
                    "This device is already borrowed.");
            }

            IsCheckedOut = true;
            BorrowerId = borrowerId;
            Status = "Borrowed";
        }

        public void CheckIn()
        {
            IsCheckedOut = false;
            BorrowerId = "";
            Status = "Available";
        }

        public void UpdateNetworkInfo(string ipAddress, string macAddress)
        {
            IpAddress = ipAddress;
            MacAddress = macAddress;
        }
    }
}
