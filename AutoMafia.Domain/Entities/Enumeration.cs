using System.Reflection;

namespace AutoMafia.Domain.Entities;

public class Enumeration : IComparable
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int MovePriority { get; private set; }

    protected Enumeration(Guid id, string name, int priority) => (Id, Name, MovePriority) = (id, name, priority);
    
    public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<T>();
    
    public override bool Equals(object obj)
    {
        if (obj is not Enumeration otherValue)
        {
            return false;
        }

        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    public override string ToString() => Name;

    public int CompareTo(object other) => Id.CompareTo(((Enumeration) other).Id);
}