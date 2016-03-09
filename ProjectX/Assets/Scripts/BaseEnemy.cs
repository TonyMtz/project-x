using UnityEngine;

public abstract class BaseEnemy : Character
{
    [SerializeField]
    protected Transform[] collisionCheck;

    [SerializeField]
    protected float collisionCheckRadius;

    [SerializeField]
    protected LayerMask whatIsCollision;

    // Use this for initialization
    override public void Start()
    {
        base.Start();
        isFacingLeft = true;
    }
}
