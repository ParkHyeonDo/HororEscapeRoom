using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuditoriumPuzzle : MonoBehaviour
{
    private List<int> _collect = new List<int>();
    public Queue<int> Input = new Queue<int>();
    private WaitForSeconds wait = new WaitForSeconds(2f);
    private WaitForSeconds few = new WaitForSeconds(1f);
    private WaitForSeconds waitLong = new WaitForSeconds(5f);
    public bool IsPlaying;

    public Light ProjectorLight;
    public List<Color> _color;

    private void Awake()
    {
        //GameManager.Instance.Auditorium = this;
    }

    private void Start()
    {
        _color.Add(Color.red);
        _color.Add(Color.green);
        _color.Add(Color.blue);
        _color.Add(Color.black);
    }

    public IEnumerator StartPuzzle()
    {
        int gamecount = 0;
        ProjectorLight.color = Color.white;
        yield return wait;
        IsPlaying = true;
        while (IsPlaying == true)
        {
            int collectValue = Random.Range(0, _color.Count);
            _collect.Add(collectValue);
            foreach (int collect in _collect)
            {
                ProjectorLight.color = _color[collectValue];
                AudioManager.Instance.PlaySfx("Beep0.5s");
                yield return wait;
            }
            ProjectorLight.color = Color.white;
            while (true)
            {
                if(_collect.Count == Input.Count)
                {
                    if(CheckLogic())
                    {
                        gamecount++;
                        break;
                    }
                    else
                    {
                        //점프 스케어
                        //정신력 감소
                    }
                }
                yield return few;
            }
            if (gamecount == 4)
            {
                IsPlaying = false;
                StopCoroutine(StartPuzzle());
            }
            yield return few;
        }
    }

    public bool CheckLogic()
    {
        bool check = false;
        for (int i = 0; i < _collect.Count; i++)
        {
            if (_collect[i] == Input.Dequeue())
            {
                check = true;
            }
            else
            {
                return false;
            }
        }
        return check;
    }
}

