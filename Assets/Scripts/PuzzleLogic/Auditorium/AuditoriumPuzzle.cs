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
    public GameObject Projector;
    public AnimatedObject Door;
    private Animator _animator;
    [Header("Note Reward")]
    [SerializeField] private Transform _transform;
    [SerializeField] private GameObject _note;
    [SerializeField] private GameObject _keyPrefabs;

    public Light ProjectorLight;
    public List<Color> _color;

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
        IsPlaying = true;
        AudioManager.Instance.PlayBGM("SpookTensionUp");
        if (Door.Data.GetType() == typeof(AuditoryDoor))
        {
            _animator = Door.GetComponent<Animator>();
            AuditoryDoor data = (AuditoryDoor)Door.Data;
            data.IsOpen = false;
            data.IsLock = true;
            _animator.SetBool("isOpen", false);
        }
        yield return wait;
        while (IsPlaying == true)
        {
            int collectValue = Random.Range(0, _color.Count);
            _collect.Add(collectValue);
            for(int i = 0; i < _collect.Count; i++)
            {
                ProjectorLight.color = _color[_collect[i]];
                AudioManager.Instance.PlaySfx("Beep0.5s");
                yield return wait;
            }
            ProjectorLight.color = Color.white;
            while (true)
            {
                if(_collect.Count <= Input.Count)
                {
                    if(CheckLogic())
                    {
                        gamecount++;
                        break;
                    }
                    else
                    {
                        Projector.SetActive(true);
                        AudioManager.Instance.PlaySfx("PianoJumpScare");
                        yield return few;
                        Projector.SetActive(false);
                        Input.Clear();
                        _collect.Clear();
                        gamecount = 0;
                        break;
                    }
                }
                yield return few;
            }
            if (gamecount > 3)
            {
                IsPlaying = false;
                if (Door.Data.GetType() == typeof(AuditoryDoor))
                {
                    AuditoryDoor data = (AuditoryDoor)Door.Data;
                    data.IsLock = false;
                    AudioManager.Instance.PlayBGM("ChangeChapter");
                    // 노트 생성
                    Instantiate<GameObject>(_note, _transform.position, Quaternion.Euler(90f,0f,0f));
                    Instantiate<GameObject>(_keyPrefabs, _transform.position, Quaternion.Euler(90f, 0f, 0f));
                    QuestManager.Instance.QuestClearCheck(2);
                }
                StopCoroutine(StartPuzzle());
                break;
            }
            yield return null;
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

