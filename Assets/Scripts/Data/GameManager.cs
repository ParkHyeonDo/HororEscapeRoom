using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player Player;
    public ItemManager ItemManager;
    public AuditoriumPuzzle Auditorium;
    public DoorManager DoorManager;

    protected override void Awake()
    {
        base.Awake();
    }
}