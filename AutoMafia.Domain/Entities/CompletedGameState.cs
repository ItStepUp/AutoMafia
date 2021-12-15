namespace AutoMafia.Domain.Entities;

public class CompletedGameState : IGameState
{
    public bool MafiaWon { get; }

    public CompletedGameState(bool mafiaWon)
    {
        MafiaWon = mafiaWon;
    }

    public event Func<IGameState, Task>? StateChanged;
}