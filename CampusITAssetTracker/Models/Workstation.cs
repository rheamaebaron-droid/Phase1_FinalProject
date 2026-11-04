
using CampusITAssetTracker.Interfaces;
using CampusITAssetTracker.Models;
using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace CampusITAssetTracker.Models
{
    public class Workstation : CampusAsset, IBorrowable, INetworkable
    {
        public bool IsCheckedOut { get; set; }

        public string BorrowerId { get; set; }

        public string IpAddress { get; set; }

        public string MacAddress { get; set; }

        public Workstation(string tag, decimal price)
            : base(tag, price)
        {
            IsCheckedOut = false;
            BorrowerId = "";
            IpAddress = "";
            MacAddress = "";
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
                    "This workstation is already borrowed.");
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
