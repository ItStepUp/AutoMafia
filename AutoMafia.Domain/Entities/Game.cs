namespace AutoMafia.Domain.Entities;

public class Game
{
    public Guid Id { get; private set; }
    public IGameState State { get; private set; } = new NewGameState();

    public Game()
    {
        State.StateChanged += OnStateChanged;
    }

    private Task OnStateChanged(IGameState newState)
    {
        State.StateChanged -= OnStateChanged;
        if (State is DayGameState dayState)
            dayState.VoteEnded -= OnVoteEnded;
        
        newState.StateChanged += OnStateChanged;
        if (newState is DayGameState newDayState)
            newDayState.VoteEnded += OnVoteEnded;

        if (State is NightGameState nightState)
        {
            NightResult nightResult = nightState.Result;
        }

        if (newState is CompletedGameState completedState)
        {
            bool mafiaWon = completedState.MafiaWon;
        }

        State = newState;
        //всех оповещаем о изменившемся состоянии игры. 
        //если предыдущее состояние ночное, в оповещение также входят итоги ночи
        //если новое состояние - конечное, в оповещение также входят итоги игры
        return Task.CompletedTask;
    }

    private Task OnVoteEnded(VoteResult arg)
    {
        //всех оповещаем о итогах голосования
        return Task.CompletedTask;
    }

    public void Start()
    {
        if (State is NewGameState newGameState)
            newGameState.Start();
    }

    public void Vote(Guid voterId, Guid votedPlayerId)
    {
        if (State is DayGameState dayState)
            dayState.Vote(voterId, votedPlayerId);
    }

    public void Pick(Guid playerId)
    {
        if (State is NightGameState nightState)
            nightState.Pick(playerId);
    }

    public void NextSpeakingPlayer()
    {
        if (State is IntroductoryGameState introductoryState)
            introductoryState.NextPlayer();
    }
}