using System.Collections.Generic;

public class ChestService
{
    private ChestController chestController;

    public ChestService(List<ChestScriptableObject> chestSO, ChestController chestController)
    {
        this.chestController = chestController;
    }

    public void CreateRandomChest()
    {
        chestController.CreateRandomChest();
    }
}
