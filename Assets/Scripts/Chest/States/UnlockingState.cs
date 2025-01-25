public class UnlockingState : IChestState
{
    public void OnStateEnter()
    {
        
    }

    public void OnClick(ChestItem chestItem)
    {
        ChestScriptableObject chestData = chestItem.GetChestData();
        GameService.Instance.UIService.OpenPopup(PopupType.Chest_Buy_Popup, chestData, chestItem);
    }

    public void OnStateExit()
    {
        
    }
}
