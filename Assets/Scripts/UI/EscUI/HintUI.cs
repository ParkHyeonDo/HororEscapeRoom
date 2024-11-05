using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HintUI : MonoBehaviour
{
    [Header("Hint Elements")]
    public List<TextMeshProUGUI> noteNameTexts; // ������ �г��� ���� ���� �̸� UI ����Ʈ
    public List<TextMeshProUGUI> hintTexts;     // ������ �г��� ���� ��Ʈ ���� UI ����Ʈ
    public GameObject noteDisplayWindow;        // ������ �г� UI â

    [Header("Hint Buttons")]
    public List<Button> hintButtons;            // HintsButton ���� ��ư��
    public List<GameObject> hintImages;         // �� Hint�� ���� �̹��� ������Ʈ ����Ʈ

    private Dictionary<int, (string noteName, string content)> hintDictionary = new Dictionary<int, (string, string)>();

    public int currentNoteIndex; // ���� ���õ� ��Ʈ�� �ε���

    void Start()
    {
        noteDisplayWindow.SetActive(false); // ���� �� UI â ��Ȱ��ȭ

        // �� ��ư�� Ŭ�� �̺�Ʈ �߰�
        for (int i = 0; i < hintButtons.Count; i++)
        {
            int index = i; // Capture the index for use in the lambda
            hintButtons[index].onClick.RemoveAllListeners(); // ���� ������ ����
            hintButtons[index].onClick.AddListener(() => OnHintButtonClicked(index));
        }
    }

    // ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    private void OnHintButtonClicked(int index)
    {
        Debug.Log("Clicked button index: " + index);
        currentNoteIndex = index; // ���� Ŭ���� �ε����� ����
        DisplayHint(index);
    }

    // ������ �߰��ϴ� �޼���
    public void AddNote(int index, string noteName, string content)
    {
        if (hintDictionary.ContainsKey(index))
        {
            return; // �̹� �߰��� ������� ����
        }

        // ��ųʸ��� ���� �߰�
        hintDictionary.Add(index, (noteName, content));

        // ��ư �ؽ�Ʈ ����
        if (index < hintButtons.Count)
        {
            hintButtons[index].GetComponentInChildren<TextMeshProUGUI>().text = noteName;
            hintButtons[index].gameObject.SetActive(true); // ��ư Ȱ��ȭ
        }
    }

    // �ε����� ������� ���� ������ �����ϰ� UI â�� ǥ���ϴ� �޼���
    public void DisplayHint(int index)
    {
        // ��� �̹����� ����
        foreach (var image in hintImages)
        {
            image.SetActive(false);
        }

        // ���õ� �ε����� ����Ʈ�� ������ ����� �ʴ��� Ȯ��
        if (index < noteNameTexts.Count && index < hintTexts.Count)
        {
            if (hintDictionary.TryGetValue(index, out var noteData))
            {
                noteNameTexts[index].text = string.IsNullOrEmpty(noteData.noteName) ? "???" : noteData.noteName;
                hintTexts[index].text = string.IsNullOrEmpty(noteData.content) ? "???" : noteData.content;

                // �ش� �ε����� �̹����� Ȱ��ȭ
                if (index < hintImages.Count)
                {
                    hintImages[index].SetActive(true);
                }

                noteDisplayWindow.SetActive(true);
            }
            else
            {
                // �ε����� �������� �ʴ� ��� �⺻������ ??? ǥ��
                noteNameTexts[index].text = "???";
                hintTexts[index].text = "???";
                noteDisplayWindow.SetActive(true);
            }
        }
    }
}
