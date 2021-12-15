namespace AutoMafia.Domain.Entities;

public class NightGameState : ActiveGameState
{
    public Role ActiveRole { get; private set; }
    public NightResult Result { get; private set; } = new NightResult();

    private readonly Dictionary<Guid, Guid> _roleIdToPickedPlayerId = new Dictionary<Guid, Guid>();
    public IReadOnlyDictionary<Guid, Guid> RoleIdToPickedPlayerId => _roleIdToPickedPlayerId;

    public NightGameState(ActiveGameState previousState) : base(previousState)
    {
        //инициализируется ActiveRole
    }

    public void Pick(Guid playerId)
    {
        //валидация
        
        _roleIdToPickedPlayerId.Add(ActiveRole.Id, playerId);
        
        //переход к следующей активной роли
        
        //если эта роль была последней
        //вычисляются итоги ночи
        Result = new NightResult();
        //изменяются состояния игроков в соответствии с итогами ночи (кто умер, у кого нет языка)
        
        //если имеет смысл продолжать
        {
            DayGameState newState = new DayGameState(this);
            RaiseStateChanged(newState);
        }
        //если не имеет смысл продолжать
        {
            bool mafiaWon = false; //вычисляется, кто выиграл
            CompletedGameState newState = new CompletedGameState(false);
            RaiseStateChanged(newState);
        }
    }
    
    
}