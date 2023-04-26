namespace DataAccess.Entities
{
    public class DsSysLogSystem
    {
        public int IdLog { get; set; }

        public string User { get; set; } = null!;

        public string Action { get; set; } = null!;

        public string Service { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? InnerException { get; set; }

        public string Priority { get; set; } = null!;

        public DateTime? DateRegister { get; set; }
    }
}
