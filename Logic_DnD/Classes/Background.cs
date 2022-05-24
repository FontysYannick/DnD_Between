using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_DnD.Classes
{
    public class Background
    {
        public int ID { get; private set; }
        public string Class { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Background(int ID, string Class, string Name, string Description)
        { 
            this.ID = ID;
            this.Class = Class;
            this.Name = Name;
            this.Description = Description;
        }
    }
}

