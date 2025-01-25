public class LockedState : IChestState
{
    public void OnStateEnter()
    {
        
    }

    public void OnClick(ChestItem chestItem)
    {
        ChestScriptableObject chestData = chestItem.GetChestData();
        GameService.Instance.UIService.OpenPopup(PopupType.Chest_Unlock_Popup, chestData, chestItem);
    }

    public void OnStateExit()
    {
        
    }
}
