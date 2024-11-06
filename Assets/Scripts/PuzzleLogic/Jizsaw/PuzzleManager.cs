using System.Collections;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public GameObject jigsawPuzzle;
    public PuzzlePiece[] puzzlePieces;      // ���� ���� �迭
    public GameObject completedPuzzle;      // �Ϸ� UI ������Ʈ
    public float autoCloseDelay = 2.0f;     // ���� �Ϸ� �� �ڵ����� ������ �ð�

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
        PauseState(false);                               // �÷��̾� �þ� ȸ�� �簳
    }

    public void ClosePuzzle(GameObject gameObject)
    {
        gameObject.SetActive(false);
        ResetCursor(); // Ŀ���� ����
        PauseState(false); // �÷��̾� �þ� ȸ�� �簳
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
            UnlockCursor(); // ������ Ȱ��ȭ�Ǹ� Ŀ���� ���̰� ��
            PauseState(true); // ������ Ȱ��ȭ�Ǹ� �þ� ȸ�� ����
        }
    }

    // Ŀ���� ���̰� �ϰ� ��� ����
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Ŀ���� �ٽ� ��װ� ����
    private void ResetCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
