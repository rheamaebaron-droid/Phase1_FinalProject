namespace CampusITAssetTracker.Interfaces
{
    public interface INetworkable
    {
        string IpAddress { get; set; }

        string MacAddress { get; set; }

        void UpdateNetworkInfo(string ipAddress, string macAddress);
    }
}