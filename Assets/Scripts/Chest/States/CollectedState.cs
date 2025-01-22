public class CollectedState : IChestState
{
    public void OnStateEnter()
    {
        
    }

    public void OnClick(ChestView chestView)
    {
        chestView.Destroy();
    }

    public void OnStateExit()
    {
        
    }
}
