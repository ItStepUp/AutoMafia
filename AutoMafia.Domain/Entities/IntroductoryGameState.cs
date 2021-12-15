namespace AutoMafia.Domain.Entities;

//ознакомительный дневной тур
public class IntroductoryGameState : ActiveGameState
{
    public Player SpeakingPlayer { get; private set; }
    
    public IntroductoryGameState(NewGameState previousState) : base(previousState)
    {
        //инициализируется SpeakingPlayer
    }

    public void NextPlayer()
    {
        //переходит очередь говорить следующему игроку
        
        //если предыдущий игрок был последним
        NightGameState newState = new NightGameState(this);
        RaiseStateChanged(newState);
    }
 
}