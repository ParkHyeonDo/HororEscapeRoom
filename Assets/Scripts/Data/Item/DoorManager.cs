using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public List<GameObject> DoorsList;


    private void Awake()
    {
        GameManager.Instance.DoorManager = this;
    }

    private void Start()
    {
        foreach (GameObject Door in DoorsList)
        {
            Door temp = (Door)(Door.GetComponent<AnimatedObject>().Data);
            temp.IsLock = true;
            temp.IsOpen = false;
            Door.GetComponent<AnimatedObject>().Data = temp;
        }
        DoorsList[0].GetComponent<Door>().IsLock = false;
    }
    // Start is called before the first frame update
    public void SetDoorState(bool[] doorStates)
    {
        for (int i = 0; i < doorStates.Length; i++)
        {
            Door temp = (Door)(DoorsList[i].GetComponent<AnimatedObject>().Data);
            temp.IsLock = doorStates[i];
            DoorsList[i].GetComponent<AnimatedObject>().Data = temp;
        }
    }

    public bool[] GetDoorState()
    {
        bool[] result = new bool[DoorsList.Count];
        for (int i = 0; i < DoorsList.Count; i++)
        {
            Door temp = (Door)(DoorsList[i].GetComponent<AnimatedObject>().Data);
            result[i] = temp.IsLock;
        }
        return result;
    }
}
