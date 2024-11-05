using UnityEngine;

public class AnimatedData : ScriptableObject
{
    public RuntimeAnimatorController _controller;
    public string ObjectName;
    public string Description;

    public virtual void Interact(Animator animator)
    {
        animator.runtimeAnimatorController ??= _controller;
    }

}