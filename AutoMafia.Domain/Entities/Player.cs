namespace AutoMafia.Domain.Entities
{
    public class Player
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public enum Сondition {Live, Dead }

        public Player(int id, string name, Сondition сondition/*Role*/)
        {
            Id = id;
            Name = name;            
        }
    }
}
