public class UnlockingState : IChestState
{
    public void OnStateEnter()
    {
        
    }

    public void OnClick(ChestView chestView)
    {
        GameService.Instance.UIService.OpenPopup(PopupType.Chest_Buy_Popup, chestView);
    }

    public void OnStateExit()
    {
        
    }
}
