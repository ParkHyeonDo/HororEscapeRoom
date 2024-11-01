using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class PlayerCondition : MonoBehaviour
{
    public ConditionUI ConditionUI;

    Condition _stamina { get { return ConditionUI.Stamina; } }
    Condition _battery { get { return ConditionUI.Battery; } }
    // ## _mental ?


    private void Update()
    {
        _stamina.Add(_stamina.PassiveValue * Time.deltaTime);

        UseBattery();
    }


    public void UseBattery() 
    {
        if (_battery.CurValue > 0 /*## && bool 손전등 == true */)
        {
            _battery.Subtract(_battery.PassiveValue * Time.deltaTime);
        }
    }

    public void ChargeBattery(float amount) 
    {
        _battery.Add(amount);
    }

    public void UseStamina(float amount) 
    {
        if (_stamina.CurValue - amount < 0f) 
        {
            return;
        }
        _stamina.Subtract(amount);
    }

    private void Die() 
    {
        // ## 게임오버 씬 또는 UI 호출
    }


}

