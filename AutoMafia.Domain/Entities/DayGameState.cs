namespace AutoMafia.Domain.Entities;

public class DayGameState : ActiveGameState
{
    private readonly Dictionary<Guid, Guid> _playerIdToVotedPlayerId = new Dictionary<Guid, Guid>();
    public IReadOnlyDictionary<Guid, Guid> PlayerIdToVotedPlayerId => _playerIdToVotedPlayerId;

    private readonly List<Guid> _playersEligibleToVote = new List<Guid>(); //кто голосует
    private readonly List<Guid> _votablePlayers = new List<Guid>(); //за кого голосуют
    
    public DayGameState(NightGameState previousState) : base(previousState)
    {
        //заполняются списки за кого и кто может голосовать
    }

    public void Vote(Guid votingPlayerId, Guid votedPlayerId)
    {
        //валидация
        _playerIdToVotedPlayerId.Add(votingPlayerId, votedPlayerId);
        
        //если все, кто нужно, проголосовал
        VoteResult result = new VoteResult(); //вычисляется результат голосования
        //если нужно переголосование - обновляются списки, кто и за кого голосует
        VoteEnded?.Invoke(result);

        //если в голосовании выбрали одного человека, обновляется состояние этого человека и
        //если еще имеет смысл продолжать
        {
            NightGameState newState = new NightGameState(this);
            RaiseStateChanged(newState);
        }
        //иначе (не имеет смысл продолжать)
        {
            bool mafiaWon = false; //вычисляется, кто выиграл
            CompletedGameState newState = new CompletedGameState(mafiaWon);
            RaiseStateChanged(newState);
        }
    }

    public event Func<VoteResult, Task> VoteEnded;
}