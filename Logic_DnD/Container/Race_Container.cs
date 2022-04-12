using DAL_DnD.Context;
using Logic_DnD.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_DnD.Container
{
    public class Race_Container
    {
        Race_Context _Context = new Race_Context();

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
