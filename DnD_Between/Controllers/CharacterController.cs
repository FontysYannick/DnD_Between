using DAL_DnD.Context;
using DnD_Between.Models;
using Logic_DnD.Classes;
using Logic_DnD.Container;
using Microsoft.AspNetCore.Mvc;

namespace DnD_Between.Controllers
{
    public class CharacterController : Controller
    {
        Character_Container Char_Con = new Character_Container(new Character_Context());
        Character Char_ = new Character();

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
        public IActionResult Detail(int ID)
        {
            Char_ = Char_Con.Getbyid(ID);
            CharacterViewModel characterViews = new CharacterViewModel(Char_.ID, Char_.name, Char_.str, Char_.dex, Char_.con, Char_.intt, Char_.wis, Char_.cha, Char_.level, Char_.speed, Char_.char_class.name, Char_.char_race.name);

            return View(characterViews);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CharacterViewModel charview)
        {
            if (ModelState.IsValid)
            {
                Class clss = new Class(Int32.Parse(charview.Class), "class");
                Race race = new Race(Int32.Parse(charview.Race), "race");
                Char_ = new Character(0, charview.Name, charview.Str, charview.Dex, charview.Con, charview.Int, charview.Wis, charview.Cha, charview.Level, charview.Speed, clss, race);
                int ID = Char_Con.AddCharacter(Char_);

                return RedirectToAction("Detail", new {id = ID });
            }

            return View();
        }

        public IActionResult Update(int ID)
        {
            Char_ = Char_Con.Getbyid(ID);
            CharacterViewModel characterViews = new CharacterViewModel(Char_.ID, Char_.name, Char_.str, Char_.dex, Char_.con, Char_.intt, Char_.wis, Char_.cha, Char_.level, Char_.speed, Char_.char_class.name, Char_.char_race.name);

            return View(characterViews);
        }

        [HttpPost]
        public IActionResult Update(CharacterViewModel charview)
        {
            if (ModelState.IsValid)
            {
                Class clss = new Class(Int32.Parse(charview.Class), "class");
                Race race = new Race(Int32.Parse(charview.Race), "race");
                Character pip = new Character(charview.ID, charview.Name, charview.Str, charview.Dex, charview.Con, charview.Int, charview.Wis, charview.Cha, charview.Level, charview.Speed, clss, race);
                Char_Con.UpdateCharacter(pip);

                return RedirectToAction("Detail", new {id = charview.ID });
            }

            return View();
        }

        public IActionResult Delete(int ID)
        {
            Char_Con.DeleteCharacter(ID);
            return RedirectToAction("Index", "Character");
        }
    }
}
