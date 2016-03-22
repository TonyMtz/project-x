using UnityEngine;

// TODO - this and HPController is almost the same

public class EnemyHPController : MonoBehaviour
{
    private BaseCharacter enemy;

    private TextMesh hpText;

    private bool isFacingLeft = true;

    // Use this for initialization
    void Start()
    {
        enemy = transform.GetComponentInParent<BaseCharacter>();
        hpText = transform.GetComponentInParent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        string currentHP = enemy.getCurrentHealthPoints().ToString();
        string maxHP = enemy.getMaxHealthPoints().ToString();

        hpText.text = string.Format("HP: {0}/{1}", currentHP, maxHP);

        if (enemy.IsFacingLeft() != isFacingLeft)
        {
            isFacingLeft = enemy.IsFacingLeft();
            Flip();
        }
    }

    private void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }
}
