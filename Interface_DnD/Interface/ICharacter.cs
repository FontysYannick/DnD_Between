using Interface_DnD.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_DnD.Interface
{
    public interface ICharacter
    {
        void AddCharacter(CharacterDTO character);

        void DeleteCharacter(int ID);

        List<CharacterDTO> Getall();

        CharacterDTO Getbyid(int ID);
    }
}
