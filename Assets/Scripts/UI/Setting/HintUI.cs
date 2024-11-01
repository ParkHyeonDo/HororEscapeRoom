using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintUI : MonoBehaviour
{
    [Header("Hint Elements")]
    public TextMeshProUGUI noteNameText;           // ���� �̸��� ǥ���� UI
    public TextMeshProUGUI shortDescriptionText;    // ª�� ������ ǥ���� UI
    public TextMeshProUGUI noteContentText;         // �� ���� ������ ǥ���� UI

    public GameObject noteDisplayWindow;            // ���� UI â

    void Start()
    {
        // ���� �� UI â�� ��Ȱ��ȭ
        noteDisplayWindow.SetActive(false);
    }
    // ���� ������ �����ϰ� UI â�� ǥ���ϴ� �޼���
}
