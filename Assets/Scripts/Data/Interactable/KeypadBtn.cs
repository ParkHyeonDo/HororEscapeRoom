using NavKeypad;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractableObject", menuName = "New InteractableObject/KeypadBtn", order = 4)]
public class KeypadBtn : InteractableData
{
    public override void Interact()
    {
        PressBtn();
    }
    private void PressBtn()
    {
        KeypadButton keypadbutton=GameManager.Instance.Player.InteractTarget.GetComponent<KeypadButton>();
        keypadbutton.PressButton();
    }
}
