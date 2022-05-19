namespace Logic_DnD.Classes
{
    public class Race
    {
        public int ID { get; private set; }
        public string name { get; private set; }

        public Race(int id)
        {
            this.ID = id;
        }

        public Race(int id, string name)
        {
            this.ID = id;
            this.name = name;
        }
    }
}
