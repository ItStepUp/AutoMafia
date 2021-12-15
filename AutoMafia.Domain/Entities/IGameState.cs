namespace AutoMafia.Domain.Entities;

public interface IGameState
{
    event Func<IGameState, Task> StateChanged;
    
    
}