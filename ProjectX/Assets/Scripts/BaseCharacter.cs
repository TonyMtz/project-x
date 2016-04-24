using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour
{
    [SerializeField]
    protected GameController gameController;

    [SerializeField]
    protected int healthPoints;

    [SerializeField]
    protected int maxHealthPoints;

    [SerializeField]
    protected int attackPoints;

    [SerializeField]
    protected int expPoints;

    [SerializeField]
    protected int currentLevel;

    [SerializeField]
    private float speed;

    [SerializeField]
    protected Transform groundCheck;

    [SerializeField]
    protected LayerMask whatIsGround;

    [SerializeField]
    protected float groundRadius;

    protected bool isFacingLeft = false;

    protected Animator animator;

    private float velocity;

	public bool secondJump;

    protected bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

    }


    virtual public void Start()
    {
        animator = GetComponent<Animator>();
        RestoreHP();
        velocity = 4f;
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

    public int getCurrentHealthPoints()
    {
        return healthPoints;
    }

    public int getMaxHealthPoints()
    {
        return maxHealthPoints;
    }

    public void DecreaseHP(int val)
    {
        healthPoints -= val;
    }

    public void IncreaseHP(int val)
    {
        healthPoints += val;
    }

    public void RestoreHP()
    {
        healthPoints = maxHealthPoints;
    }

    public int getExperiencePoints()
    {
        return expPoints;
    }

    public float getVelocity()
    {
        return velocity;
    }

    public void increaseExperiencePoints(int val)
    {
        expPoints += val;
    }

    public int getLevel()
    {
        return currentLevel;
    }

    public void setLevel(int val)
    {
        currentLevel = val;

        maxHealthPoints += val;
        velocity += 1f;
        RestoreHP();
    }

    public int getAttackPoints()
    {
        return attackPoints;
    }

    public bool IsFacingLeft()
    {
        return isFacingLeft;
    }

}
