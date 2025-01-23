public class CollectedState : IChestState
{
    public void OnStateEnter()
    {
        
    }

    public void OnClick(ChestView chestView)
    {
        GameService.Instance.CurrencyService.ChestCollected(chestView);
        chestView.Destroy();
    }

    public void OnStateExit()
    {
        
    }
}
