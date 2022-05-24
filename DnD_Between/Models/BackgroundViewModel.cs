namespace DnD_Between.Models
{
    public class BackgroundViewModel
    {
        public int ID { get; set; }
        public string Class { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public BackgroundViewModel()
        { }

        public BackgroundViewModel(string Class, string Name, string Description)
        {
            this.Class = Class;
            this.Name = Name;
            this.Description = Description;
        }
    }
}
