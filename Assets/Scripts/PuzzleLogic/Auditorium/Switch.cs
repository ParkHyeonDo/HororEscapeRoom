using UnityEngine;

public class Switch : InteractableObject
{
    public GameObject _target;
    private bool _starter;
    private string _description;

    private void Start()
    {
        _description = $"<b>{Data.ObjectName}</b>\n{Data.Description}";
    }

    public override string GetPrompt()
    {
        return _description;
    }

    public override void Interact()
    {
        if (_starter == false && GameManager.Instance.Auditorium.IsPlaying == false)
        {
            _starter = true;
            StartCoroutine(GameManager.Instance.Auditorium.StartPuzzle());
            _target.SetActive(true);
        }
        else if(_starter == true && GameManager.Instance.Auditorium.IsPlaying == true)
        {
            _description = $"<color=#FF0000><b>�۵����� �ʴ´�. �۵����� �ʴ´�. �۵����� �ʴ´�. �۵����� �ʴ´�. �۵����� �ʴ´�. �۵����� �ʴ´�. �۵����� �ʴ´�. �۵����� �ʴ´�. �۵����� �ʴ´�. �۵����� �ʴ´�. �۵����� �ʴ´�. �۵����� �ʴ´�.</b></color>";
        }
        else if(_starter == true && GameManager.Instance.Auditorium.IsPlaying == false)
        {
            _description = $"<b>{Data.ObjectName}</b>\n{Data.Description}";
            if (_target.activeSelf)
            {
                _target.SetActive(false);
            }
            else
            {
                _target.SetActive(true);
            }
        }
    }
}