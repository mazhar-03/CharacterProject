namespace Models;

public abstract class GameCharacter
{
    protected GameCharacter(string id, string name, bool isAlive)
    {
        Id = id;
        Name = name;
        IsAlive = isAlive;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public bool IsAlive { get; set; }

    public virtual void Revive()
    {
        if (!IsAlive)
            IsAlive = true;
        else
            throw new AlreadyAliveException("This character is already alive");
    }

    public override string ToString()
    {
        return "[Id: " + Id + "; Name: " + Name + "; IsAlive: " + IsAlive;
    }
}