
using CampusITAssetTracker.Interfaces;
using CampusITAssetTracker.Models;
using System.Net.NetworkInformation;

namespace CampusITAssetTracker.Models
{
    public class Peripheral : CampusAsset, IBorrowable
    {
        public bool IsCheckedOut { get; set; }

        public string BorrowerId { get; set; }

        public Peripheral(string tag, decimal price)
            : base(tag, price)
        {
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
                    "This peripheral is already borrowed.");
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
    }
}
