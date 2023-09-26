namespace FalloutRP.DTO
{
    public class RuleDTO
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
    }
}
