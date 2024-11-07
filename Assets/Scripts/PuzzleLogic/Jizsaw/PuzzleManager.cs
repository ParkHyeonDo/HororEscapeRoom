using System.Collections;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public GameObject jigsawPuzzle;
    public PuzzlePiece[] puzzlePieces;      // 퍼즐 조각 배열
    public GameObject completedPuzzle;      // 완료 UI 오브젝트
    public float autoCloseDelay = 2.0f;     // 퍼즐 완료 후 자동으로 닫히는 시간
    public BoxCollider boxCollider;
    public BoxCollider clipboard;
    private bool puzzleCompleted = false;   // 퍼즐 완료 상태 확인용

    private void Awake()
    {

        Instance = this;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (!puzzleCompleted && IsPuzzleComplete())
        {
            puzzleCompleted = true;
            completedPuzzle.SetActive(true);
            StartCoroutine(AutoClosePuzzle()); // 퍼즐 완료 후 자동으로 닫힘
        }
    }

    IEnumerator AutoClosePuzzle()
    {
        yield return new WaitForSeconds(autoCloseDelay); // 설정한 시간만큼 대기
        ClosePuzzle(completedPuzzle);                    // 완료 UI 닫기
        ResetCursor();                                   // 커서를 원래 상태로 복원
        PauseState(true);                               // 플레이어 시야 회전 재개
    }

    public void ClosePuzzle(GameObject gameObject)
    {
     
        boxCollider.enabled = false;
        gameObject.SetActive(false);
        ResetCursor(); 
        PauseState(false); 
        
    }
    public void OpenPuzzle(GameObject gameObject)
    {
        gameObject.SetActive(true);
        clipboard.enabled = true;
        ResetCursor();
        PauseState(false);
    }
    bool IsPuzzleComplete()
    {
        foreach (PuzzlePiece piece in puzzlePieces)
        {
            if (!piece.isSnapped) return false;
        }
        return true;
    }

    public void ActivatePuzzle()
    {
        if (jigsawPuzzle != null)
        {
            jigsawPuzzle.SetActive(true);
            UnlockCursor();
            PauseState(true);
        }
    }

    // 커서를 보이게 하고 잠금 해제
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
    }

    // 커서를 다시 잠그고 숨김
    private void ResetCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // 플레이어의 시야 회전을 일시 정지하거나 재개
    private void PauseState(bool isPaused)
    {
        var playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.UpdatePauseState(isPaused);
        }
    }
}
