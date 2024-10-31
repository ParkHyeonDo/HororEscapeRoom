using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class QuickSlot : MonoBehaviour
{
    //public ItemData Item;
    public Image Icon;
    private Outline _outline;
    public TextMeshProUGUI ItemStackCount;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
        _outline.enabled = false;
    }

    public void SetStackCount(int num)
    {
        ItemStackCount.text = num.ToString();
    }
}
