using System.Collections.Generic;


namespace AutoLister
{
    public class Group
    {
        public string Name;

        List<Student> Members;
        public void GetMembersFromFile(string path)
        {
            var reader = new CSVReader();
            Members = reader.ReadList(path);
        }
    }
}
