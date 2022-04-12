using DAL_DnD.Context;
using Logic_DnD.Classes;
using System.Collections.Generic;

namespace Logic_DnD.Container
{
    public class Class_Container
    {
        Class_Context _Context = new Class_Context();

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
