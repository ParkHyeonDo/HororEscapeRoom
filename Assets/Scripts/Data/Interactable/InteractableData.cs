using UnityEngine;

[CreateAssetMenu(fileName = "InteractableObject", menuName = "New InteractableObject/Default", order = 0)]
public class InteractableData : ScriptableObject
{
    public string ObjectName;
    [TextArea]
    public string Description;
    [TextArea(10, 20)]
    public string Content;

    public bool isHint;
    public bool isPuzzle;

    public virtual void Interact()
    {
        Debug.Log("interact");

        if (isHint)
        {
            // 힌트 관련 처리 로직을 여기에 추가
        }
        else if (isPuzzle)
        {
            // PuzzleManager 인스턴스를 통해 직소 퍼즐 UI 활성화
            if (PuzzleManager.Instance != null)
            {
                PuzzleManager.Instance.ActivatePuzzle();
                Debug.Log("Jigsaw Puzzle activated.");
            }
            else
            {
                Debug.LogWarning("PuzzleManager instance not found.");
            }
        }
    }

    public virtual void Temp()
    {
        Debug.Log("");
    }
}
