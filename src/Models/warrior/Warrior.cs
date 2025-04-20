namespace Models;

public class Warrior : GameCharacter, IStaminaMonitor
{
    private int _stamina;

    public Warrior(string id, string name, bool isAlive, int stamina) : base(id, name, isAlive)
    {
        Stamina = stamina;
    }

    public int Stamina
    {
        get => _stamina;
        set
        {
            if (value > 100 || value < 0) throw new InvalidStaminaException("Stamina must be between 0 and 100!");
            if (value < 15) WarnLowStamina();
            _stamina = value;
        }
    }

    public void WarnLowStamina()
    {
        Console.WriteLine("WARNING LOW STAMINA");
    }

    public override void Revive()
    {
        if (Stamina < 10) throw new ExhaustedWarriorException("The stamina has to be at least 10 for reviving!");
        base.Revive();
    }

    public override string ToString()
    {
        return base.ToString() + ", Stamina: " + Stamina + " ]";
    }
}