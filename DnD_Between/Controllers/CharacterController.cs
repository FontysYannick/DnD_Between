using DnD_Between.Models;
using Logic_DnD.Classes;
using Logic_DnD.Container;
using Microsoft.AspNetCore.Mvc;

namespace DnD_Between.Controllers
{
    public class CharacterController : Controller
    {
        Character_Container Char_Con = new Character_Container();


        public IActionResult Index()
        {
            List<CharacterViewModel> characterViews = new List<CharacterViewModel>();
            List<Character> characters = Char_Con.Getall();

            foreach (Character item in characters)
            {
                characterViews.Add(new CharacterViewModel(item.ID, item.name, item.str, item.dex, item.con, item.intt, item.wis, item.cha, item.level, item.speed, item.char_class.name, item.char_race.name));
            }

            return View(characterViews);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            Character characters = Char_Con.Getbyid(id);
            CharacterViewModel characterViews = new CharacterViewModel(characters.ID, characters.name, characters.str, characters.dex, characters.con, characters.intt, characters.wis, characters.cha, characters.level, characters.speed, characters.char_class.name, characters.char_race.name);

            return View(characterViews);
        }
    }
}
