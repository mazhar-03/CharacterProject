using Models;
using Models.mage;
using Models.rogue;

namespace Services;

public interface IGameCharacterService
{
    //Warrior
    bool AddWarrior(Warrior warrior);
    List<Warrior> GetAllWarriors();
    bool UpdateWarrior(string id, Warrior warrior);

    //Mage
    bool AddMage(Mage mage);
    List<Mage> GetAllMages();
    bool UpdateMage(string id, Mage mage);

    //Rogue
    bool AddRogue(Rogue rogue);
    List<Rogue> GetAllRogues();
    bool UpdateRogue(string id, Rogue rogue);

    // Shared
    bool ReviveCharacter(string id);
    bool DeleteCharacter(string id);
}