using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float CurValue;
    public float StartValue;
    public float MaxValue;
    private Image _uiBar;
    public float PassiveValue;
    private void Start()
    {
        CurValue = StartValue;    
        _uiBar = GetComponent<Image>();
    }

    private void Update()
    {
        _uiBar.fillAmount = CurValue / MaxValue;
    }

    public void Add(float value)
    {
        CurValue = Mathf.Min(CurValue + value, MaxValue);
    }

    public void Subtract(float value)
    {
        CurValue = Mathf.Max(CurValue - value, 0);
    }
}
