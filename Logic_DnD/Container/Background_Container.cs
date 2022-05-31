using Interface_DnD.Interface;
using Logic_DnD.Classes;
using System.Collections.Generic;

namespace Logic_DnD.Container
{
    public class Background_Container
    {
        IBackground _Context;

        public Background_Container(IBackground context)
        {
            this._Context = context;
        }

        public List<Background> Getall()
        {
            List<Background> list = new List<Background>();

            foreach (var item in _Context.Getall())
            {
                list.Add(new Background(item.ID, item.Class, item.Name, item.Description));
            }

            return list;
        }

        public List<Background> GetByFilter(string filter)
        {
            List<Background> list = new List<Background>();

            foreach (var item in _Context.Getbyfilter(filter))
            {
                list.Add(new Background(item.ID, item.Class, item.Name, item.Description));
            }

            return list;
        }
    }
}
