using System.Text.RegularExpressions;

namespace Models.rogue;

public class Rogue : GameCharacter
{
    private string _stealthCode;

    public Rogue(string id, string name, bool isAlive, string stealthCode, string guildName) : base(id, name, isAlive)
    {
        StealthCode = stealthCode;
        GuildName = guildName;
    }

    public string StealthCode
    {
        get => _stealthCode;
        set
        {
            if (!Regex.IsMatch(value, @"^RG-\d+$"))
                throw new InvalidStealthCodeException("Invalid Stealth Code. Stealth code must be a valid RG-number.");
            _stealthCode = value;
        }
    }

    public string GuildName { get; set; }

    public override void Revive()
    {
        if (!GuildName.Contains("Black Fang"))
            throw new UnauthorizedGuildException("You are not allowed to revive this guild.");
        base.Revive();
    }

    public override string ToString()
    {
        return base.ToString() + ", Stealth Code: " + StealthCode + ", Guild Name: " + GuildName + "]";
    }
}