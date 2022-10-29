namespace ApiDNSForDE.DB
{
    public class LockDNS
    {
        public int LockDNSId { get; set; }
        public string HostName { get; set; }
        public string DNS { get; set; }
        public int TimeAut { get; set; }    

    }
}