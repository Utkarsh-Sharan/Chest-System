public class LockedState : IChestState
{
    public void OnStateEnter()
    {
        
    }

    public void OnClick(ChestView chestObject)
    {
        GameService.Instance.UIService.OpenPopup(PopupType.Chest_Click_Popup, chestObject);
    }

    public void OnStateExit()
    {
        
    }
}
