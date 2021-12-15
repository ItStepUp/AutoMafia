namespace AutoMafia.Domain.Entities;

public class NightGameState : ActiveGameState
{
    public Role ActiveRole { get; private set; }

    private readonly Dictionary<Guid, Guid> _roleIdToPickedPlayerId = new Dictionary<Guid, Guid>();
    public IReadOnlyDictionary<Guid, Guid> RoleIdToPickedPlayerId => _roleIdToPickedPlayerId;

    public NightGameState(ActiveGameState previousState) : base(previousState)
    { }

    public void Pick(Guid playerId)
    {
        //валидация
        
        _roleIdToPickedPlayerId.Add(ActiveRole.Id, playerId);
        
        //переход к следующей активной роли
        
        //если эта роль была последней
        DayGameState newState = new DayGameState(this);
        
        RaiseStateChanged(newState);
    }
    
    
}