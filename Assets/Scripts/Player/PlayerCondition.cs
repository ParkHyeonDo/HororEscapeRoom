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
    public Condition Mental { get { return ConditionUI.Mental; } }

    private void Update()
    {
        Stamina.Add(Stamina.PassiveValue * Time.deltaTime);
        UseMental(5.0f);
        RecoverMental(1.0f);
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
    public void UseMental(float amount) 
    {
        // 점프스퀘어를 만났을 때 멘탈 감소


        //배터리 전부 소진시 멘탈 감소
        if (Battery.CurValue == 0)
        {
            Mental.Subtract(amount*Time.deltaTime);
        }

        // 멘탈 게이지가 너무 낮아지면 사망 처리
        if (Mental.CurValue <= 0)
        {

            Die();
        }
    }

    public void RecoverMental(float amount)
    {
        //회복조건은 조금더 생각해 보아야 될수도?
        if (Battery.CurValue > 0)
        {
            Mental.Add(amount);
        }

    }

    private void Die() 
    {
        // ## 게임오버 씬 또는 UI 호출
        //Debug.Log("Die");
    }


}

