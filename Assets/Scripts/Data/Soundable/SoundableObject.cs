using UnityEngine;

public class SoundableObject : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip[] clip;
    public bool IsTrigger;

    private void Start()
    {
        GameManager.Instance.Player.Controller.Interaction += 
    }

}