namespace AutoMafia.Domain.Entities
{
    public class Player
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public enum Сondition {Live, Deadб, Silence}

        public Player(Guid id, string name, Сondition сondition/*Role*/)
        {
            Id = id;
            Name = name;            
        }
    }
}
