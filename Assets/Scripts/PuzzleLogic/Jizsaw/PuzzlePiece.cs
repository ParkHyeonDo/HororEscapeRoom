using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Vector2 originalPosition;
    public RectTransform targetPosition;
    public bool isSnapped = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        // �ʱ� ��ġ�� ������ ��ġ�� �����մϴ�.
        Vector2 randomOffset = new Vector2(Random.Range(-300, 300), Random.Range(-300, 300)); // ĵ���� �� ���� ��ġ ����
        rectTransform.anchoredPosition += randomOffset;
        originalPosition = rectTransform.anchoredPosition; // ���� ��ġ�� originalPosition���� ����
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isSnapped) return;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isSnapped) return;
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Vector2.Distance(rectTransform.anchoredPosition, targetPosition.anchoredPosition) < 50f)
        {
            SnapToPosition();
        }
        else
        {
            //ResetPosition();
        }
    }

    private void SnapToPosition()
    {
        rectTransform.anchoredPosition = targetPosition.anchoredPosition;
        isSnapped = true;
    }

    private void ResetPosition()
    {
        rectTransform.anchoredPosition = originalPosition;
    }
}
