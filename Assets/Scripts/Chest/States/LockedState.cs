public class LockedState : IChestState
{
    public void OnStateEnter()
    {
        
    }

    public void OnClick(ChestItem chestItem)
    {
        ChestView chestView = chestItem.GetComponent<ChestView>();
        GameService.Instance.UIService.OpenPopup(PopupType.Chest_Unlock_Popup, chestView);
    }

    public void OnStateExit()
    {
        
    }
}
