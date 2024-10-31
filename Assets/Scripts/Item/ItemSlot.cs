using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;


public class ItemSlot : MonoBehaviour
{
    public ItemData Data;
    public Image Icon;
    public QuickSlot QuickSlot;
    public TextMeshProUGUI QuantityText;
    private Outline _outline;

    public bool Equipped;
    public int Quantity;


    private void Awake()
    {
        _outline = GetComponent<Outline>();
    }

    private void OnEnable()
    {
        _outline.enabled = Equipped;   
    }

    public void Set() 
    {
        Icon.gameObject.SetActive(true);
        Icon.sprite = Data.Icon;
        QuantityText.text = Quantity > 1 ? Quantity.ToString() : string.Empty;

        if (_outline != null) 
        {
            _outline.enabled = Equipped;
        }
    }

    public void Clear()
    {
        Data = null;
        Icon.gameObject.SetActive(false);
        QuantityText.text = string.Empty;
    }

}

