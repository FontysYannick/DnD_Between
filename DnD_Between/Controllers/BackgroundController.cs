using DAL_DnD.Context;
using DnD_Between.Models;
using Logic_DnD.Classes;
using Logic_DnD.Container;
using Microsoft.AspNetCore.Mvc;

namespace DnD_Between.Controllers
{
    public class BackgroundController : Controller
    {
        Background_Container container = new Background_Container(new Background_Context());

        public IActionResult Index(FilterViewModel filterViewModel)
        {
            List<BackgroundViewModel> backgroundViews = new List<BackgroundViewModel>();
            List<Background> background = container.GetByFilter(filterViewModel.Class);

            if (background.Count != 0)
            {
                foreach (var item in background)
                {
                    backgroundViews.Add(new BackgroundViewModel(item.Class, item.Name, item.Description));
                }
            }
            else
            {
                foreach (var item in container.Getall())
                {
                    backgroundViews.Add(new BackgroundViewModel(item.Class, item.Name, item.Description));
                }
            }
            filterViewModel.BackgroundViewModel = backgroundViews;
            
            return View(filterViewModel);


        }
    }
}
