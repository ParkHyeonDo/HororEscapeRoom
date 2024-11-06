using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource _bgmPlayer;
    public Queue<GameObject> _sfxQueue;

    [SerializeField] private AudioClip[] _bgmArr;
    [SerializeField] private AudioClip[] _sfxArr;
    public SceneManager SceneManager;

    protected override void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            MakeAudioPool();
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _bgmPlayer = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            PlayBGM("StartSceneBGM");
        }
        else if (SceneManager.GetActiveScene().name == "MainScene")
        {
            PlayBGM("ChangeChapter");
            StopLoop();
        }
    }

    public void MakeAudioPool()
    {
        _sfxQueue = new Queue<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            GameObject obj = new GameObject($"sfxPlayer{i + 1}");
            obj.AddComponent<AudioSource>();
            _sfxQueue.Enqueue(obj);
            DontDestroyOnLoad(obj);
        }
        
    }

    public void PlayBGM(string bgmName)
    {
        for (int i = 0; i < _bgmArr.Length; i++)
        {
            if (_bgmArr[i].name == bgmName)
            {
                _bgmPlayer.clip = _bgmArr[i];
                _bgmPlayer.Play();
                return;
            }
        }
    }

    public void StopBGM()
    {
        _bgmPlayer.Stop();
    }

    public void PlaySfx(string sfxName)
    {
        for(int i = 0; i < _sfxArr.Length; i++)
        {
            if (_sfxArr[i].name == sfxName)
            {
                PlaySfxQueue(_sfxQueue, _sfxArr[i]);
            }
        }
    }

    private void PlaySfxQueue(Queue<GameObject> sfxQueue, AudioClip audioClip)
    {
        GameObject obj = sfxQueue.Dequeue();
        obj.GetComponent<AudioSource>().clip = audioClip;
        obj.GetComponent<AudioSource>().Play();
        _sfxQueue.Enqueue(obj);
    }

    public void LoopOn()
    {
        _bgmPlayer.loop = true;
    }

    public void StopLoop()
    {
        _bgmPlayer.loop = false;
    }
}
