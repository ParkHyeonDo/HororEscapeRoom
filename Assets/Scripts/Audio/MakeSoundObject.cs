using UnityEngine;

public class MakeSoundObject : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        _audioSource.clip = _audioClip;
    }
    public void StartAudio()
    {
        _audioSource.Play();
    }

    public void StopAudio()
    {
        _audioSource.Stop();
    }
}