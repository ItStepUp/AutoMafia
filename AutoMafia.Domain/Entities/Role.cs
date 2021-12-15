namespace AutoMafia.Domain.Entities;

public class Role 
    : Enumeration
{
    public static Role Peaceful = new(new Guid(), nameof(Peaceful), 0);
    public static Role Maniac = new(new Guid(), nameof(Maniac), 1);
    public static Role Сourtesan = new(new Guid(), nameof(Сourtesan), 2);
    public static Role Detective = new(new Guid(), nameof(Detective), 3);
    public static Role Doctor = new(new Guid(), nameof(Doctor), 4);
    public static Role Mafia = new(new Guid(), nameof(Mafia), 5);
    public static Role Don = new(new Guid(), nameof(Don), 6);
    public Role(Guid id, string name, int priority) : base(id, name, priority)
    {
    }
}