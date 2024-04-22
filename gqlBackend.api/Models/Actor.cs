namespace gqlBackend.api.Models
{
    public class Actor
    {
        public Actor(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
