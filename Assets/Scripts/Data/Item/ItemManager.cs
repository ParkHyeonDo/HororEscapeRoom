using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<GameObject> ItemsList;


    private void Awake()
    {
        GameManager.Instance.ItemManager = this;
    }

    public void LoadItemState(bool[] items)
    {
        for (int i = 0; i < items.Length; i++) 
        {
            ItemsList[i].SetActive(items[i]);
        }
    }

    public bool[] GetItemState()
    {
        bool[] result = new bool[ItemsList.Count];
        for (int i = 0; i < ItemsList.Count; i++)
        {
            result[i] = ItemsList[i].activeSelf;
        }
        return result;
    }
}