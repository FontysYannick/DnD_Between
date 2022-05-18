using Interface_DnD.DTO;
using System.Collections.Generic;

namespace Interface_DnD.Interface
{
    public interface ICharacter
    {
        int AddCharacter(CharacterDTO character);

        void UpdateCharacter(CharacterDTO character);

        void DeleteCharacter(int ID);

        List<CharacterDTO> Getall();
        List<CharacterDTO> Getbyuser(int ID);

        CharacterDTO Getbyid(int ID);
    }
}
