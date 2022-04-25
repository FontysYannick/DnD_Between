using DAL_DnD.Context;
using Interface_DnD.Interface;
using Logic_DnD.Classes;
using System.Collections.Generic;

namespace Logic_DnD.Container
{
    public class Race_Container
    {
        IRace _Context;

        public Race_Container(IRace context)
        {
            this._Context = context;
        }

        public List<Race> Getall()
        {
            List<Race> list = new List<Race>();

            foreach (var item in _Context.Getall())
            {
                list.Add(new Race(item.ID, item.name));
            }

            return list;
        }
    }
}
