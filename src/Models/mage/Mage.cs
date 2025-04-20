namespace Models.mage;

public class Mage : GameCharacter
{
    public Mage(string id, string name, bool isAlive, int? mana) : base(id, name, isAlive)
    {
        Mana = mana;
    }

    public int? Mana { get; set; }

    public override void Revive()
    {
        if (Mana == null) throw new EmptyManaException("Mana has to be set!");

        Mana -= 20;
        base.Revive();
    }

    public override string ToString()
    {
        return base.ToString() + ", Mana: " + Mana + "]";
    }
}