namespace AutoMafia.Domain.Entities;

//еще не начатая игра
public class NewGameState : IGameState
{
    private readonly List<Guid> _accountIds = new List<Guid>();
    public IReadOnlyCollection<Guid> AccountIds => _accountIds;

    public void Join(Guid accountId)
    {
        _accountIds.Add(accountId);
    }

    public void Start()
    {
        //валидация, достаточно ли игроков

        IGameState newState = new IntroductoryGameState(this);
        
        StateChanged?.Invoke(newState);
    }
    
    public event Func<IGameState, Task>? StateChanged;
}