﻿namespace Logic_DnD.Classes
{
    public class Class
    {
        public int ID { get; private set; }
        public string name { get; private set; }
        public string description { get; private set; }

        public Class(int ID)
        {
            this.ID = ID;
        }

        public Class(int id, string name, string description)
        {
            this.ID = id;
            this.name = name;
            this.description = description;
        }
    }
}
