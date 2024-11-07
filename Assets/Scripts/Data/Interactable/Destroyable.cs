using Unity.VisualScripting;

public class Destroyable : InteractableData
{
    public override void Interact()
    {
        base.Interact();
        Destroy(GameManager.Instance.Player.InteractTarget.gameObject);
    }
}