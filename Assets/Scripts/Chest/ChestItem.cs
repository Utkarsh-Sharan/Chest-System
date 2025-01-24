using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChestItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI chestStateText;
    private ChestStateMachine stateMachine;

    private void Start()
    {
        chestStateText.text = "Locked";

        stateMachine = new ChestStateMachine();
        stateMachine.ChangeState(ChestStates.Locked);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        stateMachine.OnClick(this);
    }

    public void ChangeState(ChestStates newState) => stateMachine.ChangeState(newState);

    public ChestStates GetChestState() => stateMachine.GetCurrentState();
}
