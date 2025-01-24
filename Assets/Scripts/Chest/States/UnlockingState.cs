public class UnlockingState : IChestState
{
    public void OnStateEnter()
    {
        
    }

    public void OnClick(ChestItem chestItem)
    {
        ChestView chestView = chestItem.GetComponent<ChestView>();
        GameService.Instance.UIService.OpenPopup(PopupType.Chest_Buy_Popup, chestView);
    }

    public void OnStateExit()
    {
        
    }
}
