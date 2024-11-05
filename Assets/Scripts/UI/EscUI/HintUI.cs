using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HintUI : MonoBehaviour
{
    [Header("Hint Elements")]
    public List<TextMeshProUGUI> noteNameTexts; // 오른쪽 패널의 여러 쪽지 이름 UI 리스트
    public List<TextMeshProUGUI> hintTexts;     // 오른쪽 패널의 여러 힌트 내용 UI 리스트
    public GameObject noteDisplayWindow;        // 오른쪽 패널 UI 창

    [Header("Hint Buttons")]
    public List<Button> hintButtons;            // HintsButton 내의 버튼들
    public List<GameObject> hintImages;         // 각 Hint에 대한 이미지 오브젝트 리스트

    private Dictionary<int, (string noteName, string content)> hintDictionary = new Dictionary<int, (string, string)>();

    public int currentNoteIndex; // 현재 선택된 노트의 인덱스

    void Start()
    {
        noteDisplayWindow.SetActive(false); // 시작 시 UI 창 비활성화

        // 각 버튼에 클릭 이벤트 추가
        for (int i = 0; i < hintButtons.Count; i++)
        {
            int index = i; // Capture the index for use in the lambda
            hintButtons[index].onClick.RemoveAllListeners(); // 기존 리스너 제거
            hintButtons[index].onClick.AddListener(() => OnHintButtonClicked(index));
        }
    }

    // 버튼 클릭 시 호출되는 메서드
    private void OnHintButtonClicked(int index)
    {
        Debug.Log("Clicked button index: " + index);
        currentNoteIndex = index; // 현재 클릭된 인덱스를 저장
        DisplayHint(index);
    }

    // 쪽지를 추가하는 메서드
    public void AddNote(int index, string noteName, string content)
    {
        if (hintDictionary.ContainsKey(index))
        {
            return; // 이미 추가된 쪽지라면 무시
        }

        // 딕셔너리에 내용 추가
        hintDictionary.Add(index, (noteName, content));

        // 버튼 텍스트 설정
        if (index < hintButtons.Count)
        {
            hintButtons[index].GetComponentInChildren<TextMeshProUGUI>().text = noteName;
            hintButtons[index].gameObject.SetActive(true); // 버튼 활성화
        }
    }

    // 인덱스를 기반으로 쪽지 정보를 설정하고 UI 창을 표시하는 메서드
    public void DisplayHint(int index)
    {
        // 모든 이미지를 숨김
        foreach (var image in hintImages)
        {
            image.SetActive(false);
        }

        // 선택된 인덱스가 리스트의 범위를 벗어나지 않는지 확인
        if (index < noteNameTexts.Count && index < hintTexts.Count)
        {
            if (hintDictionary.TryGetValue(index, out var noteData))
            {
                noteNameTexts[index].text = string.IsNullOrEmpty(noteData.noteName) ? "???" : noteData.noteName;
                hintTexts[index].text = string.IsNullOrEmpty(noteData.content) ? "???" : noteData.content;

                // 해당 인덱스의 이미지를 활성화
                if (index < hintImages.Count)
                {
                    hintImages[index].SetActive(true);
                }

                noteDisplayWindow.SetActive(true);
            }
            else
            {
                // 인덱스가 존재하지 않는 경우 기본값으로 ??? 표시
                noteNameTexts[index].text = "???";
                hintTexts[index].text = "???";
                noteDisplayWindow.SetActive(true);
            }
        }
    }
}
