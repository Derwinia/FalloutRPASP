namespace FalloutRP.DTO
{
    public class RuleDTO
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
    }
    public class RuleModifyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
    public class RuleCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
    }
    public class RuleFolderCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
    }
    public class RuleOrderDTO
    {
        public int PreviousOrder { get; set; }
        public int CurrentOrder { get; set; }
    }
}
