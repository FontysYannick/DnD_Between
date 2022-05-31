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
            string? session_ID = HttpContext.Session.GetString("ID");
            List<CharacterViewModel> characterViews = new List<CharacterViewModel>();

            if (session_ID != null)
            {
                int myValue = Convert.ToInt32(session_ID);
                List<Character> characters = Char_Con.Getbyuser(myValue);
                CharacterViewModel character = new CharacterViewModel();

                foreach (Character item in characters)
                {
                    characterViews.Add(character.ToViewModel(item));
                }

                return View(characterViews);
            }

            return View(characterViews);
        }

        [HttpGet]
        public IActionResult Detail(int ID)
        {
            Char_ = Char_Con.Getbyid(ID);
            CharacterViewModel character = new CharacterViewModel();
            return View(character.ToViewModel(Char_));
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
                CharacterViewModel character = new CharacterViewModel();
                Char_ = character.FromViewModel(charview, Convert.ToInt32(HttpContext.Session.GetString("ID")));
                int ID = Char_Con.AddCharacter(Char_);

                return RedirectToAction("Detail", new { id = ID });
            }

            return View();
        }

        public IActionResult Update(int ID)
        {
            Char_ = Char_Con.Getbyid(ID);
            CharacterViewModel character = new CharacterViewModel();
            return View(character.ToViewModel(Char_));
        }

        [HttpPost]
        public IActionResult Update(CharacterViewModel charview)
        {
            if (ModelState.IsValid)
            {
                CharacterViewModel character = new CharacterViewModel();
                Char_ = character.FromViewModel(charview, Convert.ToInt32(HttpContext.Session.GetString("ID")));
                Char_Con.UpdateCharacter(Char_);

                return RedirectToAction("Detail", new { id = charview.ID });
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
