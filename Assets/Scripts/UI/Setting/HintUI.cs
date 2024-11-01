using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintUI : MonoBehaviour
{
    [Header("Hint Elements")]
    public TextMeshProUGUI noteNameText;           // 쪽지 이름을 표시할 UI
    public TextMeshProUGUI shortDescriptionText;    // 짧은 설명을 표시할 UI
    public TextMeshProUGUI noteContentText;         // 긴 쪽지 내용을 표시할 UI

    public GameObject noteDisplayWindow;            // 쪽지 UI 창

    void Start()
    {
        // 시작 시 UI 창을 비활성화
        noteDisplayWindow.SetActive(false);
    }
    // 쪽지 정보를 설정하고 UI 창을 표시하는 메서드
}
