using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface_DnD.DTO;
using Interface_DnD.Interface;

namespace UnitTestProject_DnD.Stub
{
    public class Character_Stub : ICharacter
    {
        public int AddCharacter(CharacterDTO character)
        {
            throw new NotImplementedException();
        }

        public void DeleteCharacter(int ID)
        {
            throw new NotImplementedException();
        }

        public List<CharacterDTO> Getall()
        {
            throw new NotImplementedException();
        }

        public CharacterDTO Getbyid(int ID)
        {
            throw new NotImplementedException();
        }

        public void UpdateCharacter(CharacterDTO character)
        {
            throw new NotImplementedException();
        }
    }
}
