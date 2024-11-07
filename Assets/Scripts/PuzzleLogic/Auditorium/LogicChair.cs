using UnityEngine;

public class LogicChair : InteractableObject
{
    [SerializeField] private int _answer;
    private AuditoriumPuzzle _auditorium;

    private void Awake()
    {
        _auditorium = GameManager.Instance.Auditorium;
    }

    public override void Interact()
    {
        if(_auditorium.IsPlaying == true)
        _auditorium.Input.Enqueue(_answer);
    }
}