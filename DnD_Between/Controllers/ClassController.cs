using DAL_DnD.Context;
using DnD_Between.Models;
using Logic_DnD.Classes;
using Logic_DnD.Container;
using Microsoft.AspNetCore.Mvc;

namespace DnD_Between.Controllers
{
    public class ClassController : Controller
    {
        Class_Container Class_Con = new Class_Container(new Class_Context());

        public IActionResult Index()
        {
            List<ClassViewModel> classViews = new List<ClassViewModel>();
            List<Class> classes = Class_Con.Getall();

            foreach (Class item in classes)
            {
                classViews.Add(new ClassViewModel(item.name, item.description));
            }

            return View(classViews);
        }
    }
}
