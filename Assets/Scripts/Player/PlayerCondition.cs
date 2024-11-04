using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class PlayerCondition : MonoBehaviour
{
    public ConditionUI ConditionUI;

    [HideInInspector]
    public Condition Stamina { get { return ConditionUI.Stamina; } }
    public Condition Battery { get { return ConditionUI.Battery; } }
    // ## _mental ?


    private void Update()
    {
        Stamina.Add(Stamina.PassiveValue * Time.deltaTime);

        UseBattery();
    }


    public void UseBattery() 
    {
        if (Battery.CurValue > 0 /*## && bool 손전등 == true */)
        {
            Battery.Subtract(Battery.PassiveValue * Time.deltaTime);
        }
    }

    public void ChargeBattery(float amount) 
    {
        Battery.Add(amount);
    }

    public void UseStamina(float amount) 
    {
        if (Stamina.CurValue - amount < 0f) 
        {
            return;
        }
        Stamina.Subtract(amount);
    }

    private void Die() 
    {
        // ## 게임오버 씬 또는 UI 호출
    }


}

