using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private ChestView chestView;
    [SerializeField] private List<ChestScriptableObject> chestSO;

    public void CreateRandomChest()
    {
        Instantiate(chestView.gameObject);
    }
}
