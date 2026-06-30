namespace ChatShared.Models
{
    public class Group
    {
        public string GroupName { get; set; } = "";

        public string Owner { get; set; } = "";

        public int MemberCount
        {
            get {return Members.Count;}
        }

        public List<string> Members { get; set; } = new();
    }
}
