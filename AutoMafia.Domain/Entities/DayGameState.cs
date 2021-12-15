namespace AutoMafia.Domain.Entities;

public class DayGameState : ActiveGameState
{
    
    
    public DayGameState(ActiveGameState previousState) : base(previousState)
    {
    }
}