using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PopupScriptableObject", menuName = "ScriptableObjects/PopupScriptableObject")]
public class PopupScriptableObject : ScriptableObject
{
    public PopupType PopupType;
    public GameObject PopupObject;
}
