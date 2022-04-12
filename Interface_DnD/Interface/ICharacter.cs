using Interface_DnD.DTO;
using System.Collections.Generic;

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
