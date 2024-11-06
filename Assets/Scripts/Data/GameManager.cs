using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player Player;
    public ItemManager ItemManager;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

}