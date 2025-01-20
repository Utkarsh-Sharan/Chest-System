public class UnlockedState : IChestState
{
    public void OnStateEnter()
    {
        
    }

    public void OnClick(ChestView chestView)
    {
        chestView.ChangeState(ChestStates.Collected);
    }

    public void OnStateExit()
    {
        
    }
}
