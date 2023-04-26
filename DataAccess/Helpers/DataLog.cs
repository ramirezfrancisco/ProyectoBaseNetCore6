namespace DataAccess.Helpers
{
    public class DataLog
    {
        public string user { get; set; }
        public string action { get; set; }
        public string service { get; set; }
        public string description { get; set; }
        public string innerExeption { get; set; }
        public string priority { get; set; }
    }
}
