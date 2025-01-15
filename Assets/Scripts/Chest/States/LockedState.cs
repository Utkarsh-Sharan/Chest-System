public class LockedState : IChestState
{
    public void OnStateEnter()
    {
        
    }

    public void OnClick()
    {
        //show popup showing Start Timer and Unlock with gems buttons.
        GameService.Instance.UIService.ClosePopupPanel();
        GameService.Instance.UIService.ShowChestStateOnClick();
    }

    public void OnStateExit()
    {
        
    }
}
