using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource _bgmPlayer;
    public Queue<GameObject> _sfxQueue;

    [SerializeField] private AudioClip[] _bgmArr;
    [SerializeField] private AudioClip[] _sfxArr;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        _sfxQueue = new Queue<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            GameObject obj = new GameObject($"sfxPlayer{i + 1}");
            obj.AddComponent<AudioSource>();
            _sfxQueue.Enqueue(obj);
            DontDestroyOnLoad(obj);
        }
    }

    private void Start()
    {
        
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
}
