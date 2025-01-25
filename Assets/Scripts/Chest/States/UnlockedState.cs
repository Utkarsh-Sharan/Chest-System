public class UnlockedState : IChestState
{
    private int coins, gems;
    private int chestID;

    public void OnStateEnter()
    {
        
    }

    public void OnClick(ChestItem chestItem)
    {
        coins = chestItem.GetChestData().CoinRange.GetRandomValue();
        gems = chestItem.GetChestData().GemRange.GetRandomValue();
        chestID = chestItem.GetID();

        GameService.Instance.CurrencyService.ChestCollected(coins, gems);
        GameService.Instance.SlotService.RemoveChestFromSlot(chestID);
        GameService.Instance.UIService.CloseHoverPopup();

        chestItem.Destroy();
    }

    public void OnStateExit()
    {
        
    }
}
