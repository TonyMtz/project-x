using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    protected GameController gameController;

    [SerializeField]
    protected float speed = 1;

    [SerializeField]
    protected Transform groundCheck;

    [SerializeField]
    protected LayerMask whatIsGround;

    [SerializeField]
    protected float groundRadius;

    [SerializeField]
    protected float healthPoints;

    protected bool isFacingLeft = false;

    protected Animator animator;

    protected bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    virtual public void Start()
    {
        animator = GetComponent<Animator>();
    }

    virtual public void Move()
    {
        if (isFacingLeft)
        {
            transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
        }
    }

    protected void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }
}
