using DAL_DnD.Context;
using Interface_DnD.Interface;
using Logic_DnD.Classes;
using System.Collections.Generic;

namespace Logic_DnD.Container
{
    public class Class_Container
    {
        IClass _Context;

        public Class_Container(IClass context)
        {
            this._Context = context;
        }

        public List<Class> Getall()
        {
            List<Class> list = new List<Class>();

            foreach (var item in _Context.Getall())
            {
                list.Add(new Class(item.ID, item.name));
            }

            return list;
        }
    }
}
