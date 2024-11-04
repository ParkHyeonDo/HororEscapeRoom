using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionUI : MonoBehaviour
{
    public Condition Battery;
    public Condition Stamina;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Player.Condition.ConditionUI = this;
    }
}
