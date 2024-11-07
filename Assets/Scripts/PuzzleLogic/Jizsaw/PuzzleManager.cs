using System.Collections;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public GameObject jigsawPuzzle;
    public PuzzlePiece[] puzzlePieces;      // ���� ���� �迭
    public GameObject completedPuzzle;      // �Ϸ� UI ������Ʈ
    public float autoCloseDelay = 2.0f;     // ���� �Ϸ� �� �ڵ����� ������ �ð�
    public BoxCollider boxCollider;
    public BoxCollider clipboard;
    private bool puzzleCompleted = false;   // ���� �Ϸ� ���� Ȯ�ο�

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
            StartCoroutine(AutoClosePuzzle()); // ���� �Ϸ� �� �ڵ����� ����
        }
    }

    IEnumerator AutoClosePuzzle()
    {
        yield return new WaitForSeconds(autoCloseDelay); // ������ �ð���ŭ ���
        ClosePuzzle(completedPuzzle);                    // �Ϸ� UI �ݱ�
        ResetCursor();                                   // Ŀ���� ���� ���·� ����
        PauseState(true);                               // �÷��̾� �þ� ȸ�� �簳
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

    // Ŀ���� ���̰� �ϰ� ��� ����
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
    }

    // Ŀ���� �ٽ� ��װ� ����
    private void ResetCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // �÷��̾��� �þ� ȸ���� �Ͻ� �����ϰų� �簳
    private void PauseState(bool isPaused)
    {
        var playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.UpdatePauseState(isPaused);
        }
    }
}
