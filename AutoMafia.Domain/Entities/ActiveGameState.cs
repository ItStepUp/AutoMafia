namespace AutoMafia.Domain.Entities;

public abstract class ActiveGameState : IGameState
{
    protected readonly List<Player> _players;
    public IReadOnlyCollection<Player> Players => _players;

    protected ActiveGameState(NewGameState previousState)
    {
        _players = new List<Player>();
        // из предыдущего состояния достаются Id аккаунтов и по ним создаются игроки со случайными ролями
    }

    protected ActiveGameState(ActiveGameState previousState)
    {
        _players = previousState._players;
    }

    public event Func<IGameState, Task>? StateChanged;

    protected void RaiseStateChanged(IGameState newState)
    {
        StateChanged?.Invoke(newState);
    }
}