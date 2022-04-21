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
        public IActionResult Detail(int ID)
        {
            Character characters = Char_Con.Getbyid(ID);
            CharacterViewModel characterViews = new CharacterViewModel(characters.ID, characters.name, characters.str, characters.dex, characters.con, characters.intt, characters.wis, characters.cha, characters.level, characters.speed, characters.char_class.name, characters.char_race.name);

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
                Character character = new Character(0, charview.Name, charview.Str, charview.Dex, charview.Con, charview.Int, charview.Wis, charview.Cha, charview.Level, charview.Speed, clss, race);
                Character_Container characterContainer = new Character_Container();
                characterContainer.AddCharacter(character);

                return RedirectToAction("Index", "Character");//check if possible to show detail of specific
            }

            return View();
        }

        public IActionResult Update(int ID)
        {
            Character characters = Char_Con.Getbyid(ID);
            CharacterViewModel characterViews = new CharacterViewModel(characters.ID, characters.name, characters.str, characters.dex, characters.con, characters.intt, characters.wis, characters.cha, characters.level, characters.speed, characters.char_class.name, characters.char_race.name);

            return View(characterViews);
        }

        [HttpPost]
        public IActionResult Update(CharacterViewModel charview)
        {
            if (ModelState.IsValid)
            {
                Class clss = new Class(Int32.Parse(charview.Class), "class");
                Race race = new Race(Int32.Parse(charview.Race), "race");
                Character character = new Character(charview.ID, charview.Name, charview.Str, charview.Dex, charview.Con, charview.Int, charview.Wis, charview.Cha, charview.Level, charview.Speed, clss, race);
                character.UpdateCharacter(character);

                return RedirectToAction("Detail", new RouteValueDictionary(
                        new { controller = "Character", action = "Detail", Id = charview.ID }));
            }

            return View();
        }

        public IActionResult Delete(int ID)
        {
            Character_Container character_Container = new Character_Container();
            //gotta make some sort of quistion if sure
            character_Container.DeleteCharacter(ID);
            return RedirectToAction("Index", "Character");
        }
    }
}
