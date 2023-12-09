namespace Zhaoxi.NET6Demo.IdentitySer
{
    //Current 意思为通用的
    public class CurrentUser
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NikeName { get; set; }
        public int Age { get; set; }
        public List<string>? RoleList { get; set; }
        public string? Description { get; set; }
    }
}
