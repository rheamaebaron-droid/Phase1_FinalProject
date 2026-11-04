namespace CampusITAssetTracker.Interfaces
{
    public interface IBorrowable
    {
        bool IsCheckedOut { get; set; }

        string BorrowerId { get; set; }

        void CheckOut(string borrowerId);

        void CheckIn();
    }
}