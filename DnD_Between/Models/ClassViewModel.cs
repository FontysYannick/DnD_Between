namespace DnD_Between.Models
{
    public class ClassViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ClassViewModel()
        { }

        public ClassViewModel(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
