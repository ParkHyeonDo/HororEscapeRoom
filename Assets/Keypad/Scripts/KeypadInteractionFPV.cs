using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NavKeypad { 
public class KeypadInteractionFPV : MonoBehaviour
{
    private Camera cam;
    private void Awake() => cam = Camera.main;
    private void Update()
    {
        var ray = cam.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2));

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("마우스 클릭됨");
            if (Physics.Raycast(ray, out var hit,2f))
            {
                Debug.Log("ray 발사됨");
                if (hit.collider.TryGetComponent(out KeypadButton keypadButton))
                {
                    keypadButton.PressButton();
                }
                else
                {
                    Debug.Log("키패드 없음");
                }
            }
        }
    }
}
}