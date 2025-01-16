public class LockedState : IChestState
{
    public void OnStateEnter()
    {
        
    }

    public void OnClick(ChestView chestView)
    {
        //show popup showing Start Timer and Unlock with gems buttons.
        GameService.Instance.UIService.OpenPopupOfType(PopupType.Chest_Click_Popup, chestView);
        //GameService.Instance.UIService.ShowChestStateOnClick();
    }

    public void OnStateExit()
    {
        
    }
}
