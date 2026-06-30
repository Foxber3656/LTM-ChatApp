using ChatShared.Models;

namespace ChatServer.Storage
{
    public class GroupRepository
    {
        private readonly string file = Path.Combine("Data", "groups.json");
        private readonly List<Group> groups;

        public GroupRepository()
        {
            Directory.CreateDirectory("Data");
            groups = JsonStorage.Load<Group>(file);
        }

        public List<Group> GetAll()
        {
            return groups;
        }

        public Group? Find(string groupName)
        {
            return groups.FirstOrDefault(x =>
                x.GroupName.Equals(groupName,
                StringComparison.OrdinalIgnoreCase));
        }

        public bool Exists(string groupName)
        {
            return Find(groupName) != null;
        }

        public bool Add(Group group)
        {
            if (Exists(group.GroupName))
                return false;

            groups.Add(group);

            Save();

            return true;
        }

        public bool Delete(string groupName)
        {
            Group? group = Find(groupName);

            if (group == null)
                return false;

            groups.Remove(group);

            Save();

            return true;
        }

        public void Save()
        {
            JsonStorage.Save(file, groups);
        }
    }
}